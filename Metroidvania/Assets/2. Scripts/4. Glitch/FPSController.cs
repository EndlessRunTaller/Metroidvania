using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour
{
    private int LimiteFPS = 60;
    public GameObject error;
    public bool cerrarJuego = false;

    public ShaderEffect_BleedingColors ShaderEffect_BleedingColors;
    public ShaderEffect_CorruptedVram shaderEffect_CorruptedVram;


    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
    }
    void Start()
    {
        Application.targetFrameRate = LimiteFPS;
    }

    private void Update()
    {
        if (cerrarJuego)
        {
            StartCoroutine((Crash()));
        }
    }

    IEnumerator BajarFPS()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 10;
        Debug.Log("2");
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 20;
        Debug.Log("3");
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 30;
        Debug.Log("4");
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 40;
        Debug.Log("5");
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 50;
        Debug.Log("6");
        yield return new WaitForSeconds(2);
        cerrarJuego = true;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BajarFPS());
        }
    }

    public IEnumerator Crash()
    {
        while (true)
        {
            Debug.Log("");
        }
    }
}
