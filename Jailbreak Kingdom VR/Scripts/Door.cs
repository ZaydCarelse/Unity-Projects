using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private Vector3 targetPosition;
    public Vector3 loweredPosition;
    public Vector3 raisedPosition;
    public float speed = 1f;
    public bool isRaised = true;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

    public void LowerDoor()
    {
        targetPosition = loweredPosition;
        isRaised = false;
    }

    public void RaiseDoor()
    {
        targetPosition = raisedPosition;
        isRaised = true;
    }
}
