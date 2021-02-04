using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Running Motion Variables:")]
    public float bounceAmp = 0.1f;
    public float bounceFreq = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.Cos(transform.position.z * bounceFreq) * bounceAmp,
            transform.localPosition.z);
    }
}
