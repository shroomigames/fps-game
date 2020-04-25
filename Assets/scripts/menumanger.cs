using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanger : MonoBehaviour
{
    string scene;

    public void resart()
    {
        //gets the scene name
         string scene = SceneManager.GetActiveScene().name;
        //loads it
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
