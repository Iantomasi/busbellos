using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuVolume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas PauseMenuCanvas, VolumeMenuCanvas;

    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    Toggle Mute;
    void Start()
    {
        PauseMenuCanvas.enabled = false;
        VolumeMenuCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuCanvas.enabled = true;
            VolumeMenuCanvas.enabled = false;
        }
    }

    public void ChangeVolume()
    {
        if (Mute.isOn)
        {
            // Toggle is checked, so mute the volume
            AudioListener.volume = 0;
        }
        else
        {
            // Toggle is unchecked, so set the volume to the slider value
            AudioListener.volume = volumeSlider.value;
        }
    }


    public void MainMenuResume()
    {
        PauseMenuCanvas.enabled = false;
        VolumeMenuCanvas.enabled = false;
    }

    public void MainMenuQuit()
    {
        Application.Quit();
        Debug.Log("Application is Quitting");
    }


    public void optionsResume()
    {
        PauseMenuCanvas.enabled = false;
        VolumeMenuCanvas.enabled = true;
    }


    public void backToMainMenu()
    {
        PauseMenuCanvas.enabled = true;
        VolumeMenuCanvas.enabled = false;
    }
}
