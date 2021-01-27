﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Components:")]
    public Transform player;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        transform.position = new Vector3(player.position.x, player.position.y + yOffset, transform.position.z); 
    }
}
