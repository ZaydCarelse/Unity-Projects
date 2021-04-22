using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMenu : MonoBehaviour
{
    [Header("Movement:")]
    public float speed;

    [Header("Constraints:")]
    public float rightScreenEdge;
    public float leftScreenEdge;

    [Header("Components:")]
    public CameraShake cameraShake;
    public BallMenu ball;

    [Header("Audio:")]
    public AudioSource paddleHitSound;

    void Start()
    {

    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");

        //Moves paddle based on the input received on the Horizontal axis
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        #region BoundsCheck
        //Checks to see if the paddle is in the bounds of the screen
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        } 
        
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (ball.inPlay)
            {
                paddleHitSound.Play();
            }

            Rigidbody2D ballRB = other.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = other.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            ballRB.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;

            if (hitPoint.x < paddleCenter.x)
            {
                ballRB.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), ball.speed));
            }
            else
            {
                ballRB.AddForce(new Vector2(Mathf.Abs(difference * 200), ball.speed));
            }
        }
    }
}
