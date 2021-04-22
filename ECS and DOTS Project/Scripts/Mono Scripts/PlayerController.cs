using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        dir = new Vector3(xMove, 0, yMove);
        transform.position += dir;
    }
}
