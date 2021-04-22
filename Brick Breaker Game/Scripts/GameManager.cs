using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay Trackers:")]
    public int lives;
    public int score;
    public int numberOfBricks;
    public bool gameOver;

    [Header("UI Fields:")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameOverPanel gop;
    public GameObject winPanelGO;
    public GameOverPanel winP;
    public GameObject winEffect;
    public GameObject fadePanel;
    public OptionsButton optionsButton;

    [Header("Audio:")]
    public AudioSource winSound;
    public AudioSource gameOverSound;

    public LevelLoader lvlLoader;


    private void Awake()
    {
        optionsButton = FindObjectOfType<OptionsButton>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        optionsButton.gameObject.SetActive(false);
        lvlLoader.LoadLevel();
        winEffect.SetActive(false);
        gameOverPanel.SetActive(false);
        livesText.text = "LIVES: " + lives.ToString();
        scoreText.text = "SCORE: " + score.ToString();
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        if (!gameOver)
        {
            lives += changeInLives;
        }

        //Check for 0 lives left and trigger end of game
        if (lives <= 0 && !gameOver)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "LIVES: " + lives.ToString();
    }

    public void UpdateScore(int points)
    {
        score += points;

        scoreText.text = "SCORE: " + score.ToString();
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        Time.timeScale = 1;
        winEffect.SetActive(true);
        gameOver = true;
        winPanelGO.SetActive(true);
        fadePanel.SetActive(true);
        winP.Enable();
        StartCoroutine(DelaySoundWin());
    }

    private void GameOver()
    {
        Time.timeScale = 1;
        gameOver = true;
        gameOverPanel.SetActive(true);
        fadePanel.SetActive(true);
        gop.Enable();
        StartCoroutine(DelaySoundGameOver());
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }

    #region LevelSelect
    public void Level02()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level02");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level03()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level03");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level04()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level04");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level05()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level05");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level06()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level06");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level07()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level07");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level08()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level08");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level09()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level09");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level10()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level10");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level11()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level11");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level12()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level12");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level13()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level13");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level14()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level14");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level15()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level15");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level16()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level16");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level17()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level17");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level18()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level18");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level19()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level19");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level20()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level20");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level21()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level21");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level22()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level22");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level23()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level23");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level24()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level24");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level25()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level25");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level26()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level26");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level27()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level27");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level28()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level28");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level29()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level29");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Level30()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level30");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }
    public void Credits()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Credits");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
        gop.CloseDialogue();
        gameOverPanel.SetActive(false);
        fadePanel.SetActive(false);
    }

    #endregion


    IEnumerator DelaySoundGameOver()
    {
        yield return new WaitForSeconds(1);
        gameOverSound.Play();
        optionsButton.gameObject.SetActive(true);
    }

    IEnumerator DelaySoundWin()
    {
        yield return new WaitForSeconds(1);
        winSound.Play();
        optionsButton.gameObject.SetActive(true);
    }
}
