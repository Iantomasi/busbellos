using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void exitTheGame()
    {
        Application.Quit();
        Debug.Log("The game is exiting");
    }
}
