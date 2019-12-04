using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private bool isMuted;
    private Text muteText;
    public Dropdown resDropDown;

    // Menu Buttons
    void Start()
    {
        isMuted = false;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitButton()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }

    // Cutscene Buttons

        public void StartButton()
    {
        SceneManager.LoadScene("In_Game");
    }
    
    // Game Over Buttons

    public void RetryButton()
    {
        SceneManager.LoadScene("In_Game");
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    //Options Buttons

    public void ResolutionDropDown()
    {
        Resolution currentRes = Screen.currentResolution;
        Debug.Log(currentRes);
        resDropDown = GameObject.Find("Resolution Dropdown").GetComponent<Dropdown>();
        if (resDropDown.value == 0)
        {
            // If the first dropdown value, set to 600 x 800 fullscreen
            Screen.SetResolution(600, 800, true);
            Debug.Log("0");
        }
        else if (resDropDown.value == 1)
        {
            // set to 640 x 480 windowed
            Screen.SetResolution(640, 480, false);
            Debug.Log("1");
        }
        else
        {
            // set to 1920 x 1080 windowed
            Screen.SetResolution(1920, 1080, false);
            Debug.Log("2");
        }

    }


    public void MuteButton()
    {
        muteText = GameObject.Find("audiotext").GetComponent<Text>();
        // on click audio mute
        if (isMuted)
        {
            AudioListener.volume = 1f;
            muteText.text = " ";
            isMuted = false;
        }
        else // if muted already, un-mute
        {
            AudioListener.volume = 0f;
            muteText.text = "x";
            isMuted = true;
        }
        Debug.Log(AudioListener.volume);
        
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }


}
