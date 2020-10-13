using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Public function that loads a specific scene 
    //as passed as paramter
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
