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

    public void CloseButton()
    {
        exitButtonInfo.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
