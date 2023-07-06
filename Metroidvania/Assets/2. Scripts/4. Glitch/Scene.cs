using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public int numeroScene;


    private void Start()
    {
        if(numeroScene == 1)
        {
            SceneManager.LoadScene(numeroScene);
        }
        else
        {
            Debug.Log("No");
        }

    }
}
