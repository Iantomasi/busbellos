using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool isPaused = false;

    [SerializeField]
    private GameObject pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeMe();
            }
            else
            {
                PauseMe();
            }
        }
    }

    public void PauseMe()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        isPaused = true;
    }

    public void ResumeMe()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        isPaused = false;
    }
}
