using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text wavesText;

    void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();    
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        //Take the game back to the menu scene
    }
}
