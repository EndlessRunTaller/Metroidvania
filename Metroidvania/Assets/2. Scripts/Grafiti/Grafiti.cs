using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grafiti : MonoBehaviour
{
    public InputManager inputManager;
    public bool InGraffiti;
    public Animator animator;

    private float contador = 0;
    public bool hacerGrafiti = false;

    public Muros muros;
    public Image barra;

    private int CantidadGrafitis = 0;
    public TextMeshProUGUI CantidadGrafitisText;


    private void Start()
    {
        barra.fillAmount = 0;
    }
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
        if (!muros.Completado)
        {
            if (hacerGrafiti)
            {
                contador += 1;
                animator.SetBool("Grafiti", hacerGrafiti);
            }
            else
            {
                contador = 0;
                animator.SetBool("Grafiti", hacerGrafiti);
            }
            if(muros.TiempoNecesario == contador)
            {
                muros.Completado = true;
            }
        }
        else
        {
            animator.SetBool("Grafiti", false);
            contador = 0;
            StartCoroutine(SumarGrafiti());

        }
    }

    public bool HacerGrafiti()
    {
        return InGraffiti;
    }

    IEnumerator SumarGrafiti()
    {
        CantidadGrafitis = CantidadGrafitis + 1;
        Debug.Log(CantidadGrafitis);
        yield return null;
    }


}
