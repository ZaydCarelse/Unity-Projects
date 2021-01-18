using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 targetPosition;
    public Vector3 castlePosition;
    public Vector3 startPosition;
    public float speed = 0.5f;
    public bool enteredCastle = false;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.parent.position;
        startPosition = transform.parent.position;
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
            } 
            
            else if (hit.transform.GetComponent<DoorButtonRaise>() != null)
            {
                hit.transform.GetComponent<DoorButtonRaise>().OnLookRaise();
            }

            else if (hit.transform.GetComponent<CastleInsideButton>() != null)
            {
                MoveToCastle();
            }

            else if (hit.transform.GetComponent<CastleOutsideButton>() != null)
            {
                MoveOutsideCastle();
            }

            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                RaycastHit hostageHit;
                if (Physics.Raycast(transform.position, transform.forward, out hostageHit))
                {
                    if(hit.transform.GetComponent<Hostage>() != null)
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }

            transform.parent.position = Vector3.Lerp(transform.parent.position, targetPosition, Time.deltaTime * speed);
        }

        
    }

    private void MoveToCastle()
    {
        targetPosition = castlePosition;
        enteredCastle = true;
    }

    private void MoveOutsideCastle()
    {
        targetPosition = startPosition;
        enteredCastle = false;
    }
}
