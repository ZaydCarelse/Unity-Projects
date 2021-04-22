using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [Header("Components:")]
    public Transform paddle;
    public Transform explosion;
    public GameManager gm;
    public CameraShake cameraShake;
    public Rigidbody2D ballRb;
    public GameObject fireTrail;
    public GameObject ball;

    [Header("PowerUps:")]
    public Transform extraLives;
    public Transform damageLives;
    public Transform speedUp;
    public Transform pointsCollectable;

    [Header("Game Manager:")]
    public bool inPlay;

    [Header("Movement:")]
    public float speed;

    [Header("Audio")]
    public AudioSource destroyBrickSound;
    public AudioSource hitBrickSound;
    public AudioSource ballLaunch;
    public AudioSource hitWallSound;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        fireTrail.SetActive(false);
    }

    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if (!inPlay)
        {
            transform.position = paddle.transform.position;

            if (Input.GetButtonDown("Jump") && !inPlay)
            {
                fireTrail.SetActive(true);
                inPlay = true;
                ballRb.AddForce(Vector2.up * speed, ForceMode2D.Force);
                ballLaunch.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            ballRb.velocity = Vector2.zero;
            inPlay = false;
            fireTrail.SetActive(false);
            gm.UpdateLives(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Brick")
        {
            var seq = LeanTween.sequence();
            seq.append(LeanTween.scale(other.gameObject, new Vector3(1.15f, 1.15f, 1), 0.01f).setEaseOutBounce());
            seq.append(LeanTween.scale(ball, new Vector3(0.5f, 0.5f, 1), 0.1f).setEaseOutElastic());
            seq.append(LeanTween.color(ball, Color.yellow, 0.01f));
            seq.append(LeanTween.scale(ball, new Vector3(0.38f, 0.38f, 1), 0.125f).setEaseOutElastic());
            seq.append(LeanTween.color(ball, Color.white, 0.125f));
            seq.append(LeanTween.scale(other.gameObject, new Vector3(1f, 1f, 1), 0.125f).setEaseOutBounce());

            StartCoroutine(cameraShake.Shake(0.2f, 0.025f));

            Brick brick = other.gameObject.GetComponent<Brick>();
            if (brick.brickHitPoints > 1)
            {
                brick.BreakBrick();
                hitBrickSound.Play();
            }
            else
            {
                int randChance = Random.Range(1, 101);
                if (randChance < 10)
                {
                    Transform extraLivesObject = Instantiate(extraLives, other.transform.position, other.transform.rotation);
                }
                else if (randChance > 95)
                {
                    Transform damageLivesObject = Instantiate(damageLives, other.transform.position, other.transform.rotation);
                }
                else if (randChance > 30 && randChance < 40)
                {
                    Transform speedUpObject = Instantiate(speedUp, other.transform.position, other.transform.rotation);
                }
                else if (randChance > 60 && randChance < 80)
                {
                    Transform pointsObject = Instantiate(pointsCollectable, other.transform.position, other.transform.rotation);
                }

                gm.UpdateScore(brick.points);
                Transform explosionEffect = Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                destroyBrickSound.Play();
                Destroy(explosionEffect.gameObject, 2f);
                gm.UpdateNumberOfBricks();

            }
        }

        if (other.gameObject.tag == "Wall")
        {
            hitWallSound.Play();
        }
    }
}
