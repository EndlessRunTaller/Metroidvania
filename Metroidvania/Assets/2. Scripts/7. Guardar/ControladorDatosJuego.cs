using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControladorDatosJuego : MonoBehaviour
{
    public GameObject Scene;
    public string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();

    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";

        Scene = GameObject.FindGameObjectWithTag("SceneManager");
        CargarDatos();
    }

    private void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            Debug.Log("Scene: " + datosJuego.scene);
            Scene.GetComponent<Scene>().numeroScene = datosJuego.scene;
        }
        else
        {

        }
    }

    public void GuardarDatos()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            scene = Scene.GetComponent<Scene>().numeroScene
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        Debug.Log("Archivo Guardado");
    }
}
