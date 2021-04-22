using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;


public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    [Header("Button Effects:")]
    public AudioSource buttonPress;

    [Header("Options Button:")]
    public OptionsButton optionsButton;

    private void Awake()
    {
        optionsButton = FindObjectOfType<OptionsButton>();
        optionsButton.gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        buttonPress.Play();
        SceneManager.LoadScene("Level01");
    }

    public void Options()
    {
        buttonPress.Play();
        SceneManager.LoadScene("Options");
    }

    public void LeaderBoard()
    {
        buttonPress.Play();
        SceneManager.LoadScene("LeaderBoard");
    }

    public void QuitGame()
    {
        buttonPress.Play();
        Application.Quit();
    }

    public void OpenLinkJSPlugin()
    {
#if !UNITY_EDITOR
		openWindow(https://twitter.com/zaydcarelse);
#endif

#if UNITY_EDITOR
        Application.OpenURL("https://twitter.com/zaydcarelse");
#endif

        buttonPress.Play();
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);
}
