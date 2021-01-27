using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Components")]
    public GameObject exitButtonInfo;

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void InfoScene()
    {
        SceneManager.LoadScene("Info");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void ControlsScene()
    {
        SceneManager.LoadScene("Controls");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void CloseButton()
    {
        exitButtonInfo.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MuteAudio()
    {
        if (!MusicController.instance.isMute)
        {
            AudioListener.volume = 0;
            MusicController.instance.isMute = true;
        }
        else
        {
            AudioListener.volume = 1;
            MusicController.instance.isMute = false;
        }
    }
}
