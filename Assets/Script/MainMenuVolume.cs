using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuVolume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas VolumeMenuCanvas;

    [SerializeField]
    Button VolumeMenuButton;

    [SerializeField]
    Slider volumeSlider;

    bool isPressed = true;

    [SerializeField]
    Toggle Mute;
    void Start()
    {

        VolumeMenuCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

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
        VolumeMenuCanvas.enabled = false;
    }

    public void MainMenuQuit()
    {
        Application.Quit();
        Debug.Log("Application is Quitting");
    }


    public void optionsResume()
    {
        VolumeMenuCanvas.enabled = true;
    }


    public void backToMainMenu()
    {
        VolumeMenuCanvas.enabled = false;
    }
}
