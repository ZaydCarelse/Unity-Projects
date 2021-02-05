using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Display:")]
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI gameTimerText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI hiScoreText;

    [Header("External Elements:")]
    public PlayerController player;
    public Canvas gameUI;
    public Canvas menu;

    [Header("Gameplay Variables:")]
    public float gameTimer = 0f;
    private float resetTimer = 10f;
    public bool gameStarted = false;

    public AudioSource buttonAudio;

    private void Awake()
    {
        hiScoreText.text = "BEST TIME:" + PlayerPrefs.GetFloat("BEST TIME", 100.00f).ToString("n2");
    }

    // Start is called before the first frame update
    void Start()
    {
        menu.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.reachedFinishLine == false)
        {
            gameTimer += Time.deltaTime;
            gameTimerText.text = "Time: " + (gameTimer).ToString("n2");
            speedText.text = "Speed: " + Mathf.Floor(player.speed / 2).ToString();
        }
        else
        {
            if (gameTimer < PlayerPrefs.GetFloat("BEST TIME", 100.00f))
            {

                PlayerPrefs.SetFloat("BEST TIME", gameTimer);
                hiScoreText.text = "BEST TIME: " + gameTimer.ToString("n2");
            }
            infoText.gameObject.SetActive(true);
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void StartGameButton()
    {
        menu.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        gameStarted = true;
        gameTimer = 0f;
    }
    public void OnButtonClick()
    {
        buttonAudio.Play();
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
        if (!MusicManager.instance.isMute)
        {
            AudioListener.volume = 0;
            MusicManager.instance.isMute = true;
        }
        else
        {
            AudioListener.volume = 1;
            MusicManager.instance.isMute = false;
        }
    }
}
