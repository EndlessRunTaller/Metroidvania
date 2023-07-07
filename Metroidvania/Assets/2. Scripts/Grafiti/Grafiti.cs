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

    public Muros muro1, muro2, muro3, muro4;
    public Image[] barra;
    public GameObject[] GrafitiImagen;
    public GameObject[] circulo;
    public GameObject Sprite;

    private int CantidadGrafitis = 0;
    public TextMeshProUGUI CantidadGrafitisText;


    private void Start()
    {
        barra[0].fillAmount = 0;
        barra[1].fillAmount = 0;
        barra[2].fillAmount = 0;

        muro1.Completado = false;
        muro2.Completado = false;
        muro3.Completado = false;

        muro1.InGraffiti = false;
        muro2.InGraffiti = false;
        muro3.InGraffiti = false;
    }

    private void Update()
    {
        if (muro1.InGraffiti)
        {
            Grafiti1();

        }
        if(muro2.InGraffiti)
        {
            Grafiti2();
        }
        if (muro3.InGraffiti)
        {
            Grafiti3();
        }
        if (muro4.InGraffiti)
        {
            Grafiti4();
        }

        SUMAR();
        CantidadGrafitisText.text = CantidadGrafitis + "/4";
    }

    public void Grafiti1()
    {
        if (!muro1.Completado)
        {
            if (muro1.hacerGrafiti)
            {
                contador += 1;
                animator.SetBool("Grafiti", muro1.hacerGrafiti);
                Sprite.SetActive(true);

            }
            else
            {
                contador = 0;
                animator.SetBool("Grafiti", muro1.hacerGrafiti);
                Sprite.SetActive(false);
            }
            if (muro1.TiempoNecesario == contador)
            {
                muro1.Completado = true;
            }
        }
        else
        {
            animator.SetBool("Grafiti", false);
            contador = 0;
            GrafitiImagen[0].SetActive(true);
            circulo[0].SetActive(false);
            Sprite.SetActive(false);
            muro1.InGraffiti = false;
            CantidadGrafitis = muro1.valor;

        }
        barra[0].fillAmount = contador / muro1.TiempoNecesario;
    }

    public void Grafiti2()
    {
        if (!muro2.Completado)
        {
            if (muro2.hacerGrafiti)
            {
                contador += 1;
                animator.SetBool("Grafiti", muro2.hacerGrafiti);
                Sprite.SetActive(true);

            }
            else
            {
                contador = 0;
                animator.SetBool("Grafiti", muro2.hacerGrafiti);
                Sprite.SetActive(false);
            }
            if (muro2.TiempoNecesario == contador)
            {
                muro2.Completado = true;
            }
        }
        else
        {
            animator.SetBool("Grafiti", false);
            contador = 0;
            GrafitiImagen[1].SetActive(true);
            circulo[1].SetActive(false);
            Sprite.SetActive(false);
            muro2.InGraffiti = false;


        }
        barra[1].fillAmount = contador / muro2.TiempoNecesario;
    }

    public void Grafiti3()
    {
        if (!muro3.Completado)
        {
            if (muro3.hacerGrafiti)
            {
                contador += 1;
                animator.SetBool("Grafiti", muro3.hacerGrafiti);
                Sprite.SetActive(true);

            }
            else
            {
                contador = 0;
                animator.SetBool("Grafiti", muro3.hacerGrafiti);
                Sprite.SetActive(false);
            }
            if (muro3.TiempoNecesario == contador)
            {
                muro3.Completado = true;
            }
        }
        else
        {
            animator.SetBool("Grafiti", false);
            contador = 0;
            GrafitiImagen[2].SetActive(true);
            circulo[2].SetActive(false);
            Sprite.SetActive(false);
            muro3.InGraffiti = false;


        }
        barra[2].fillAmount = contador / muro3.TiempoNecesario;
    }

    public void Grafiti4()
    {
        if (!muro4.Completado)
        {
            if (muro4.hacerGrafiti)
            {
                contador += 1;
                animator.SetBool("Grafiti", muro4.hacerGrafiti);
                Sprite.SetActive(true);

            }
            else
            {
                contador = 0;
                animator.SetBool("Grafiti", muro4.hacerGrafiti);
                Sprite.SetActive(false);
            }
            if (muro4.TiempoNecesario == contador)
            {
                muro4.Completado = true;
            }
        }
        else
        {
            animator.SetBool("Grafiti", false);
            contador = 0;
            GrafitiImagen[3].SetActive(true);
            circulo[3].SetActive(false);
            Sprite.SetActive(false);
            muro4.InGraffiti = false;


        }
        barra[3].fillAmount = contador / muro4.TiempoNecesario;
    }

    private void SUMAR()
    {
        if (muro1.Completado)
        {
            CantidadGrafitis = muro1.valor;
            if (muro2.Completado)
            {
                CantidadGrafitis = muro1.valor + muro2.valor;
                if (muro3.Completado)
                {
                    CantidadGrafitis = muro1.valor + muro2.valor + muro3.valor;
                    if (muro4.Completado)
                    {
                        CantidadGrafitis = muro1.valor + muro2.valor + muro3.valor + muro4.valor;
                    }
                }
            }

        }

    }
}
