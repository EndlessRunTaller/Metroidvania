using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grafiti : MonoBehaviour
{
    public InputManager inputManager;
    public Animator animator;

    private float contador = 0;

    public Muros[] muros;
    public Image[] barra;
    public GameObject[] GrafitiImagen;
    public GameObject[] circulo;
    public GameObject Sprite;

    private int CantidadGrafitis = 0;
    public TextMeshProUGUI CantidadGrafitisText;


    private void Start()
    {
        barra[0].fillAmount = 0;
    }

    private void Update()
    {
        if (!muros[0].Completado)
        {
            if (muros[0].hacerGrafiti)
            {
                contador += 1;
                animator.SetBool("Grafiti", muros[0].hacerGrafiti);
                Sprite.SetActive(true);

            }
            else
            {
                contador = 0;
                animator.SetBool("Grafiti", muros[0].hacerGrafiti);
                Sprite.SetActive(false);
            }
            if(muros[0].TiempoNecesario == contador)
            {
                muros[0].Completado = true;
            }
        }
        else
        {
            animator.SetBool("Grafiti", false);
            contador = 0;
            GrafitiImagen[0].SetActive(true);
            circulo[0].SetActive(false);
            Sprite.SetActive(false);
            CantidadGrafitis = muros[0].valor;
            CantidadGrafitisText.text = CantidadGrafitis + "/7";
        }
        barra[0].fillAmount = contador / muros[0].TiempoNecesario;
    }

    public bool HacerGrafiti()
    {
        return muros[0].InGraffiti;
    }
}
