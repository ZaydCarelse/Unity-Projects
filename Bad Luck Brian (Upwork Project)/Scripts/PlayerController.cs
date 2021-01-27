using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. Manages the player movement and flipping
/// 2. Player Animations
/// </summary>
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Player Components:")]
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Animator anim;
    public AudioSource playerJump;

    [Header("Player Variables:")]
    public int speedBoost; // Set to 5
    public float jumpSpeed; // Set to 600
    bool isJumping;
    public bool isGrounded;
    public Transform feet;
    public float feetRadius;
    public LayerMask whatIsGround;
    public float boxWidth;
    public float boxHeight;
    public bool canInput = true;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInput)
        {
            //isGrounded = Physics2D.OverlapCircle(feet.position, feetRadius, whatIsGround);

            isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth, boxHeight), 360.0f, whatIsGround);

            float playerSpeed = Input.GetAxisRaw("Horizontal");
            playerSpeed *= speedBoost;
            if (playerSpeed != 0)
            {
                MoveHorizontal(playerSpeed);
            }
            else
            {
                StopMoving();
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(feet.position, feetRadius);

        Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight, 0));
    }

    void MoveHorizontal(float playerSpeed)
    {
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);

        //Flips the player sprite depending on the player input
        if (playerSpeed < 0)
        {
            sr.flipX = true;
        } else if(playerSpeed > 0)
        {
            sr.flipX = false;
        }
        if(!isJumping)
            anim.SetInteger("State", 1);
    }

    public void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

        if (!isJumping)
            anim.SetInteger("State", 0);
    }

    void Jump()
    {
        if (isGrounded)
        {
            isJumping = true;

            rb.AddForce(new Vector2(0, jumpSpeed));

            anim.SetInteger("State", 2);

            playerJump.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
