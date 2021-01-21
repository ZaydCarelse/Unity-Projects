using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;

    [Header("Game Management:")]
    public GameObject duckContainer;
    public float spawnDuration = 1.5f;
    public float spawnDecrease = 0.1f;
    public float minSpawnDuration = 0.5f;
    public float gameTimer = 30f;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    private Duck[] ducks;
    private float spawnTimer = 0f;
    private float resetTimer = 10f;

    private void Awake()
    {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        ducks = duckContainer.GetComponentsInChildren<Duck>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f)
        {
            infoText.text = "HIT ALL THE DUCKS!\nTIME: " + Mathf.Floor(gameTimer);

            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                ducks[Random.Range(0, ducks.Length)].Rise();

                spawnDuration -= spawnDecrease;
                if (spawnDuration < minSpawnDuration)
                {
                    spawnDuration = minSpawnDuration;
                }
                spawnTimer = spawnDuration;
            }

            scoreText.text = "SCORE:" + player.score;
        } else
        {
            infoText.text = "GAME OVER!\nWANNA GIVE IT ANOTHER SHOT, CHAMP?";

            scoreText.text = "SCORE:" + player.score;

            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
            {
                SceneManager.LoadScene("Menu");
            } 
        }
    }
}
