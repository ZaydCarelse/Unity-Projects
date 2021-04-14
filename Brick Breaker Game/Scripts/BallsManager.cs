using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    [Header("Prefabs:")]
    [SerializeField]
    private Ball ballPrefab;

    [Header("Positioning:")]
    public float offset = 0.25f;
    private Ball initialBall;
    private Rigidbody2D initialBallRb;

    [Header("Speed:")]
    public float initialBallSpeed = 250f;

    #region Singleton

    public static BallsManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    #endregion

    public List<Ball> Balls { get; set; }

    private void Start()
    {
        InitBall();
    }

    private void Update()
    {
        if (!GameManager.instance.IsGameStarted)
        {
            //Stick the ball to the paddle
            Vector3 paddlePos = Paddle.instance.gameObject.transform.position;
            Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + offset, paddlePos.z);
            initialBall.transform.position = ballPos;

            if (Input.GetMouseButtonDown(0))
            {
                initialBallRb.isKinematic = false;
                initialBallRb.AddForce(new Vector2(0, initialBallSpeed));
                GameManager.instance.IsGameStarted = true;
            }
        }
    }

    private void InitBall()
    {
        //Get the starting position from the position of the paddle...
        Vector3 paddlePos = Paddle.instance.gameObject.transform.position;
        Vector3 startingPos = new Vector3(paddlePos.x, paddlePos.y + offset, paddlePos.z);

        initialBall = Instantiate(ballPrefab, startingPos, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        //Adding the ball to the balls collection
        this.Balls = new List<Ball>
        {
            initialBall
        };
    }
}
