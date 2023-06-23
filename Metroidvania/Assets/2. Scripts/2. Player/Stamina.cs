using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour
{
    public Image barra;
    public PlayerMovement playerMovement;


    public float staminaMaxima;

    void Update()
    {
        barra.fillAmount = playerMovement.stamina / staminaMaxima;
    }
}
