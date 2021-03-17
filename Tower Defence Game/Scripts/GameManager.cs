using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game State:")]
    public static bool gameEnded;
    public GameObject gameOverUI;

    void Start()
    {
        Time.timeScale = 1f;
        gameEnded = false;
    }

    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;

        gameOverUI.SetActive(true);

        Time.timeScale = 0f;
    }
}
