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
    public int coinsCollected = 0;
    public int multiplier = 1;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI coinPurse;


    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "Pick the correct cup!";
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
            if (player.won)
            {
                infoText.text = "You Win!";
                coinsCollected += multiplier;
                coinPurse.text = "Coins: " + coinsCollected;
            } else
            {
                infoText.text = "You Lose!";
                coinsCollected -= multiplier;
                coinPurse.text = "Coins: " + coinsCollected;
            }
        }
    }

    public void PickACup()
    {
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].targetPosition = cups[i].cupStart;
        }
        StartCoroutine(ShuffleRoutine());
    }

    private IEnumerator ShuffleRoutine()
    {
        yield return new WaitForSeconds(1f);
        foreach (Cup cup in cups)
        {
            cup.MoveUp();
        }

        yield return new WaitForSeconds(0.5f);

        Cup targetCup = cups[Random.Range(0, cups.Length)];
        targetCup.coin = coin;

        coin.transform.position = new Vector3(targetCup.transform.position.x, coin.transform.position.y, targetCup.transform.position.z);

        yield return new WaitForSeconds(1.0f);

        foreach (Cup cup in cups)
        {
            cup.MoveDown();
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < 5; i++)
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
    }
}
