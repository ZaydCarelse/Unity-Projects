using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Variables:")]
    public int coinCount = 0;
    public TextMeshProUGUI coinUI;
    public AudioSource coinCollectSound;
    public AudioSource gameOverSound;
    public GameObject quitSure;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitSure.SetActive(true);
            PlayerController.instance.canInput = false;
        }

        coinUI.text = coinCount.ToString();
    }

    public void ReturnToGame()
    {
        PlayerController.instance.canInput = true;
        quitSure.SetActive(false);
    }
}
