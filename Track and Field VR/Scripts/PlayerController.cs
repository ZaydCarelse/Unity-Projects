using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement variables:")]
    public float speed = 5.5f;
    public float jumpForce = 450f;
    public float coolDown = 1.5f;
    private float jumpTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves the player forward
        transform.position += speed * Vector3.forward * Time.deltaTime;

        //makes the player jump
        jumpTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            if (jumpTimer <= 0f)
            {
                jumpTimer = coolDown;
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }
    }
}
