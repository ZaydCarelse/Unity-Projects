using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [Header("Beam Movement:")]
    public Quaternion wantedRotation = Quaternion.Euler(0, 180f, 0);
    private float rotateSpeed = 250f;

    [Header("Components:")]
    public AudioSource hitSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateOnHit()
    {
        Quaternion currentRotation = transform.rotation;
        transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
        hitSound.Play();
    }
}
