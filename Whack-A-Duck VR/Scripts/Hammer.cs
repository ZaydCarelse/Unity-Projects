using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 offset = new Vector3(0, 0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime);
    }

    public void Hit(Vector3 targetPosition)
    {
        transform.position = targetPosition + offset;
    }
}
