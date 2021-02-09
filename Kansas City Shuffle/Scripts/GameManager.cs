using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay Components:")]
    public GameObject coin;
    public Cup[] cups;
    public PlayerController player;

    [Header("UI Elements:")]
    public int coinsCollected = 5;
    public int multiplier = 5;
    public int streak = 0;
    public TextMeshProUGUI infoText;
    public GameObject infoTextParent;
    public TextMeshProUGUI coinPurse;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI streakCounter;

    public bool turnActive = false;
    public bool beginPressed = false;

    public Vector3 coinStart;

    public Cup targetCup;




    // Start is called before the first frame update
    void Start()
    {
        coinStart =coin.transform.position;
        coinPurse.text = "Coins: " + coinsCollected;
        multiplierText.text = "Multiplier: " + (multiplier - 5);
        //Add the Scene Management to load the game or menu scene

        /* resetTimer -= Time.deltaTime;
         * if(resetTimer <= 0f){
         * SceneManager.LoadScene("Main");
         * } */
    }

    // Update is called once per frame
    void Update()
    {
        if (player.picked)
        {
            if (player.won && turnActive)
            {
                PlayerWon();
            } else if (!player.won && turnActive)
            {
                PlayerLost();
            }
        }

        multiplierText.text = "Multiplier: " + (multiplier - 5);
        streakCounter.text = "Streak: " + streak;
    }

    public void PlayerWon()
    {
        infoTextParent.gameObject.SetActive(true);
        infoText.text = "You've won. Let's make this harder.";
        coinsCollected += (multiplier - 5);
        coinPurse.text = "Coins: " + coinsCollected;
        multiplier++;
        streak++;
        turnActive = false;
        targetCup = null;
        beginPressed = false;
    }

    public void PlayerLost()
    {
        infoTextParent.gameObject.SetActive(true);
        infoText.text = "You Lose! It seems I'll have a shiney new toy to play with soon. MUHAHAHAHAHA!";
        coinsCollected -= (multiplier - 5);
        coinPurse.text = "Coins: " + coinsCollected;
        turnActive = false;
        targetCup = null;
        streak = 0;
        beginPressed = false;
    }

    public void PickACup()
    {
        if (!beginPressed)
        {
            beginPressed = true;
            infoTextParent.gameObject.SetActive(false);
            for (int i = 0; i < cups.Length; i++)
            {
                cups[i].targetPosition = cups[i].cupStart;
            }
            player.picked = false;
            player.won = false;
            StartCoroutine(ShuffleRoutine());
        }
    }

    public IEnumerator ShuffleRoutine()
    {
        yield return new WaitForSeconds(1f);
        foreach (Cup cup in cups)
        {
            cup.MoveUp();
        }

        yield return new WaitForSeconds(0.5f);

        targetCup = cups[Random.Range(0, cups.Length)];
        targetCup.coin = coin;

        coin.transform.position = new Vector3(targetCup.transform.position.x, coin.transform.position.y, targetCup.transform.position.z);

        yield return new WaitForSeconds(1.0f);

        foreach (Cup cup in cups)
        {
            cup.MoveDown();
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < multiplier; i++)
        {
            Cup cup1 = cups[Random.Range(0, cups.Length)];
            Cup cup2 = cup1;

            while (cup2 == cup1)
            {
                cup2 = cups[Random.Range(0, cups.Length)];
            }

            Vector3 cup1Position = cup1.targetPosition;
            cup1.targetPosition = cup2.targetPosition;
            cup2.targetPosition = cup1Position;

            yield return new WaitForSeconds(0.75f);
        }

        player.canPick = true;
        turnActive = true;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
