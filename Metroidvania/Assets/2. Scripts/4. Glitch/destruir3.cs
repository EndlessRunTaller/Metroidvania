using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir3 : MonoBehaviour
{ public GameObject panel;
    public GameObject texto;
    public GameObject puerta;
    private void OnCollisionEnter(Collision collision)
    {
      
        Time.timeScale = 0f;
        panel.SetActive(true);
        texto.SetActive(true);
        puerta.SetActive(false);


    }
    public void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            texto.SetActive(false);
        }
    }
}