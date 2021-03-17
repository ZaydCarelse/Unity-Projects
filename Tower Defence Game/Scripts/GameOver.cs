using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text wavesText;
    public SceneFader sceneFader;
    public string menuScene = "MainMenu";

    void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();    
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuScene);
        Time.timeScale = 1f;
    }
}
