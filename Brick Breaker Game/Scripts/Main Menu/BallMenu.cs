using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMenu : MonoBehaviour
{
    [Header("Components:")]
    public Transform paddle;
    public Rigidbody2D ballRb;
    public GameObject ball;

    [Header("Game Manager:")]
    public bool inPlay;

    [Header("Movement:")]
    public float speed;

    [Header("Audio")]
    public AudioSource hitBrickSound;
    public AudioSource ballLaunch;
    public AudioSource hitWallSound;

    void Start()
    {

    }

    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.transform.position;

            if (Input.GetButtonDown("Jump") && !inPlay)
            {
                inPlay = true;
                ballRb.AddForce(Vector2.up * speed, ForceMode2D.Force);
                ballLaunch.Play();
            }
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

            Brick brick = other.gameObject.GetComponent<Brick>();

        }

        if (other.gameObject.tag == "Wall")
        {
            hitWallSound.Play();
        }
    }
}
