using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour
{
    private int LimiteFPS = 60;
    public GameObject error;
    public bool cerrarJuego;
    public int scene;

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
        Application.targetFrameRate = LimiteFPS;
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS -10;
        shaderEffect_CorruptedVram.enabled = true;
        QualitySettings.masterTextureLimit = 0;
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 20;
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 30;
        QualitySettings.shadowCascades = 0;
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 40;
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 50;
        ShaderEffect_BleedingColors.enabled = true;
        QualitySettings.shadowDistance = 0;
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = LimiteFPS - 59;
        QualitySettings.antiAliasing = 0;
        yield return new WaitForSeconds(2);
        cerrarJuego = true;
        Time.timeScale = 0;
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
            Debug.Log("⢐⢐⢐⡐⡐⡐⡐⣐⣐⣐⠔⢖⢢⢑⢒⡢⡫⡐⠶⢐⣐⣐⡐⡐⡐⡐⣐⢐⢐⠨  " +
                "⠐⠀⡕⡐⠌⡨⠐⠀⡂⡐⢜⠔⣁⢨⢉⡉⠻⣮⣢⡁⡢⠐⠀⠅⠅⡂⡂⢇⢂⢂  " +
                "⢈⠂⠇⡂⠅⡂⢅⢑⠐⡜⡰⢸⣿⣿⣿⣿⣗⢿⣿⡄⡂⠅⠅⢅⢑⢐⢐⢰⠐⠀  " +
                "⠠⢑⢐⢐⠡⠨⡐⡐⢰⡹⡬⢸⣿⣿⣿⣻⠿⠸⣿⣿⣦⣅⠅⠅⡂⡂⡂⢺⠨⢈  " +
                "⠨⠐⡄⡂⡊⠔⡐⢨⡪⣞⢊⠐⡡⡙⣿⠠⠀⠀⠢⡛⣿⣿⣷⣥⡂⡂⡊⡸⡈⠀  " +
                "⢈⠂⡇⠢⡈⡂⠢⣿⡮⠒⠀⢦⣤⣴⣻⢼⣶⣿⠅⢀⢃⠻⣿⣟⣿⡶⣔⡌⠀⠅  " +
                "⡠⠑⡸⢐⢰⣢⢇⡻⠕⢐⠀⡹⡟⣭⣜⠥⢾⢻⡑⡀⡂⡂⡙⢿⣽⣿⣿⠃⠅⢅  " +
                "⠢⡁⡂⢧⣷⣿⠽⡨⢈⢐⠨⠘⡎⠐⠒⠊⠀⡺⠐⡀⡂⡂⡂⠅⡻⣽⡝⠀⡑⠜  " +
                "⠐⠔⡐⠸⣟⡵⡑⡐⡐⠀⢅⡑⠸⡴⠤⡄⠊⡇⠈⡔⣴⡖⣶⢳⣿⣺⠃⢌⢐⠁  " +
                "⠀⢑⠬⠬⠼⠥⠧⠴⠶⠯⠷⠥⠕⠵⠤⠤⠶⠥⠦⠭⠭⠤⠾⠽⠿⠦⠮⠴⢉⠀  " +
                "⡇⠀⢠⡞⠛⢷⡀⡞⠋⠷⢠⡞⠛⢳⡄⠀⠀⣿⠀⠠⡾⠋⢻⡄⣾⠋⠹⢀⣾⠋  " +
                "⣇⢀⠸⣇⠀⣾⠑⣇⡀⣤⠸⣇⢀⣸⠇⠁⠀⣿⣀⠘⣯⡀⣸⠏⣿⡀⣠⠜⣿⡀  " +
                "⣋⣛⣀⣙⣋⣋⣀⣙⣙⣉⣀⣙⣋⣋⣀⣀⣁⣉⣉⣁⣈⣋⣋⣀⣈⣋⣋⣀⣈⣛  " +
                "⠀⠀⠀⠀⠀⠀⠈⢢⡠⠠⠑⢮⡾⢸⣿⡇⣿⣿⠟⡁⡢⠠⠔⠀⠀⠀⠀⠀ " +
                "⠀⠀⠀⠀⠀⠀⠀⠀⠘⢎⠨⢐⠈⢝⢿⠿⢛⠠⢂⠂⠒⠁⠀⠀⠀⠀⠀⠀⠀⠀ ");
        }
    }
}
