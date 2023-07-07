using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2 : MonoBehaviour
{
    public Muros[] muros;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            muros[1].InGraffiti = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            muros[1].InGraffiti = false;
        }
    }

}
