using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource buttonAudio;

    public void OnButtonClick()
    {
        buttonAudio.Play();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitApplication()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void MuteAudio()
    {
        if (!Music.instance.isMute)
        {
            AudioListener.volume = 0;
            Music.instance.isMute = true;
        }
        else
        {
            AudioListener.volume = 1;
            Music.instance.isMute = false;
        }
    }

}
