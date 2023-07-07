using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMovimiento : MonoBehaviour
{
    public InputManager inputManager;
    private void Start()
    {
        inputManager.GlithTecla();
    }
}
