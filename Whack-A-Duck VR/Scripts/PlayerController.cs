using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Data:")]
    public int score = 0;
    public int hiScore;

    [Header("External References:")]
    public Hammer hammer;
    public ParticleSystem hitEffect;
    public ParticleSystem hiScoreFestive;
    public AudioSource hitSound;
    public AudioSource hiScoreCelebration;
    public AudioSource hiScoreFireworks;

    private Vector3 leftPos = new Vector3(-2.5f, 4f, 0f);
    private Vector3 rightPos = new Vector3(2.5f, 4f, 0f);
    private Vector3 backPos = new Vector3(0f, 4f, 2.5f);
    private bool hiScoreSoundPlayed = false;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("HISCORE") <= 1)
        {
            PlayerPrefs.SetInt("HISCORE", 15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.GetComponent<Duck>() != null)
                {
                    Duck duck = hit.transform.GetComponent<Duck>();
                    duck.OnHit();
                    hammer.Hit(duck.transform.position);
                    hitSound.Play();
                    Instantiate(hitEffect, hit.transform.position, Quaternion.identity);

                    score++;

                    if (score > PlayerPrefs.GetInt("HISCORE", 0))
                    {

                        PlayerPrefs.SetInt("HISCORE", score);
                        GameManager.instance.hiscoreText.text = "HISCORE:" + score.ToString();
                        Instantiate(hiScoreFestive, leftPos, Quaternion.Euler(-90f, 0f, 0f));
                        Instantiate(hiScoreFestive, rightPos, Quaternion.Euler(-90f, 0f, 0f));
                        Instantiate(hiScoreFestive, backPos, Quaternion.Euler(-90f, 0f, 0f));
                        GameManager.instance.congratsText.text = "LOOKS LIKE YOU CRUSHED THE HISCORE! WELL DONE!";
                        if (!hiScoreSoundPlayed)
                        {
                            hiScoreCelebration.Play();
                            hiScoreFireworks.Play();
                            hiScoreSoundPlayed = true;
                        }

                    }
                }
            }
        }
    }
}
