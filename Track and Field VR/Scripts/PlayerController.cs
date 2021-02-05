using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables:")]
    public float maxSpeed = 5.5f;
    public float acceleration = 1f;
    public float jumpForce = 450f;
    public float coolDown = 1.5f;

    public float speed = 0f;
    private float jumpTimer = 0f;
    public GameManager gameManager;
    public AudioSource jumpSound;

    [Header("Gameplay Variables:")]
    public bool reachedFinishLine = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStarted == true)
        {

            if (reachedFinishLine == false)
            {
                //moves the player forward
                speed += acceleration * Time.deltaTime;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
                transform.position += speed * Vector3.forward * Time.deltaTime;

                //makes the player jump
                jumpTimer -= Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
                {
                    if (jumpTimer <= 0f)
                    {
                        jumpTimer = coolDown;
                        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
                        jumpSound.Play();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            speed *= 0.3f;
            other.GetComponent<Beam>().RotateOnHit();
        }

        if(other.tag == "FinishLine")
        {
            reachedFinishLine = true;
        }
    }
}
