using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndPlatform : MonoBehaviour
{
    public float countdownTimer = 3.0f;
    public bool reset = false;
    public GameObject congratsText;

    private void Update()
    {
        if (reset)
        {
            CountDown();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.instance.canInput = false;
            PlayerController.instance.StopMoving();
            congratsText.SetActive(true);
            Debug.Log("Thank you for playing!");
            reset = true;
        }
    }

    void CountDown()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0)
        {
            reset = false;
            congratsText.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
    }
}
