using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioTransicion : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelOpciones;
    public GameObject panelTransicion;
    public GameObject panelComoseJuega;
    public GameObject panelVolumen;

    IEnumerator OPCIONES()
    {
        panelInicio.SetActive(false);
        panelTransicion.SetActive(true);
        //AudioManager.instance.PlayAudio(AudioManager.instance.Estatica);
        yield return new WaitForSeconds(1f);
        panelTransicion.SetActive(false);
        panelOpciones.SetActive(true);
        yield return null;
    }

    IEnumerator VOLVEROPCIONES()
    {
        panelOpciones.SetActive(false);
        panelTransicion.SetActive(true);
        yield return new WaitForSeconds(1f);
        panelTransicion.SetActive(false);
        panelInicio.SetActive(true);
        yield return null;
    }

    IEnumerator VOLVERDECONTROLES()
    {
        panelComoseJuega.SetActive(false);
        panelTransicion.SetActive(true);
        yield return new WaitForSeconds(1f);
        panelTransicion.SetActive(false);
        panelOpciones.SetActive(true);
        yield return null;
    }

    IEnumerator TRANSICIONCONTROLES()
    {
        panelOpciones.SetActive(false);
        panelTransicion.SetActive(true);
        yield return new WaitForSeconds(1f);
        panelTransicion.SetActive(false);
        panelComoseJuega.SetActive(true);
    }

    IEnumerator VOLUMEN()
    {
        panelOpciones.SetActive(false);
        panelTransicion.SetActive(true);
        yield return new WaitForSeconds(1f);
        panelTransicion.SetActive(false);
        panelVolumen.SetActive(true);
        yield return null;
    }

    IEnumerator VOLVERDEVOLUMENAOPCIONES()
    {
        panelVolumen.SetActive(false);
        panelTransicion.SetActive(true);
        //AudioManager.instance.PlayAudio(AudioManager.instance.Estatica);
        yield return new WaitForSeconds(1f);
        panelTransicion.SetActive(false);
        panelOpciones.SetActive(true);
        yield return null;
    }

    public void TRANSICIONAOPCIONES()
    {
        StartCoroutine(OPCIONES());
    }

    public void VOLVEROAOPCIONES()
    {
        StartCoroutine(VOLVEROPCIONES());
    }

    public void VOLVERDECONTROLESAOPCIONES()
    {
        StartCoroutine(VOLVERDECONTROLES());
    }

    public void CONTROLES()
    {
        StartCoroutine(TRANSICIONCONTROLES());
    }

    public void BOTONVULUMEN()
    {
        StartCoroutine(VOLUMEN());
    }

    public void BOTONVOLVERDELAUDIO()
    {
        StartCoroutine(VOLVERDEVOLUMENAOPCIONES());
    }
}
