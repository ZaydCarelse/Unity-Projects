using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float countdownTimer = 3.0f;
    public bool reset = false;

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
            GameManager.instance.gameOverSound.Play();
            PlayerController.instance.canInput = false;
            PlayerController.instance.StopMoving();
            PlayerController.instance.anim.SetInteger("State", -1);
            reset = true;
        }   
    }

    void CountDown()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0)
        {
            reset = false;
            SceneManager.LoadScene("Level01");
        }
    }
}
