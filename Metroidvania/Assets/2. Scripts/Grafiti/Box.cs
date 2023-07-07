using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Muros[] muros;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            muros[0].InGraffiti = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            muros[0].InGraffiti = false;
        }
    }


}
