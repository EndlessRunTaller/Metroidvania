using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GameObject.Find("puerta 1"));
    }
}
