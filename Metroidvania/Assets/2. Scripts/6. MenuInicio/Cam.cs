using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private GameObject camaraMenu;
    [SerializeField] private GameObject camaraGameplay;
    [SerializeField] private Transform[] views;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private GameObject UI;
    Transform currentView;
    void Start()
    {
        currentView = views[0].transform;
    }


    public void CambiarAJugar()
    {
        StartCoroutine(Transiciones());
    }

    private void LateUpdate()
    {
        camaraMenu.transform.position = Vector3.Lerp(camaraMenu.transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }

    IEnumerator Transiciones()
    {
        currentView = views[1];
        yield return new WaitForSeconds(1.5f);
        currentView = views[2];
        yield return new WaitForSeconds(1.5f);
        camaraMenu.SetActive(false);
        UI.SetActive(true);
        yield return null;
    }
}
