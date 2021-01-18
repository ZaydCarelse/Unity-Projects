using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 targetPosition;
    public Vector3 castlePosition;
    public float speed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.GetComponent<DoorButton>() != null)
            {
                hit.transform.GetComponent<DoorButton>().OnLookLower();
            } else if (hit.transform.GetComponent<DoorButtonRaise>() != null)
            {
                hit.transform.GetComponent<DoorButtonRaise>().OnLookRaise();
            }
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
