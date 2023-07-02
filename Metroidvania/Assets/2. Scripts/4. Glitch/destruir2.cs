using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GameObject.Find("puerta 2"));
    }
}
