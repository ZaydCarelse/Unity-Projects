using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            ducks[Random.Range(0, ducks.Length)].Rise();

            spawnDuration -= spawnDecrease;
            if(spawnDuration < minSpawnDuration)
            {
                spawnDuration = minSpawnDuration;
            }
            spawnTimer = spawnDuration;
        }

        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f)
        {
            infoText.text = "HIT ALL THE DUCKS!\nTIME: " + Mathf.Floor(gameTimer);
        }
    }
}
