using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public void NextScene(string scene)
    {
        Debug.Log("Arrived here");
        SceneManager.LoadScene(scene);
    }
}
