using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafiti : MonoBehaviour
{
    public InputManager inputManager;
    public bool InGraffiti;
    public Animator animator;

    private float contador = 0;
    public bool hacerGrafiti = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InGraffiti = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InGraffiti = false;
        }
    }

    private void Update()
    {
        if (hacerGrafiti && contador < 200)
        {
            contador += 1;
            Debug.Log(contador);
            animator.SetBool("Grafiti",hacerGrafiti);
        }
        else
        {
            contador = 0;
            animator.SetBool("Grafiti", hacerGrafiti);
            Debug.Log(contador);
        }
    }

    public bool HacerGrafiti()
    {
        return InGraffiti;
    }


}
