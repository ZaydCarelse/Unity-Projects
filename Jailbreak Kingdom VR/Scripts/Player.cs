using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    private Vector3 targetPosition;
    public Vector3 castlePosition;
    public Vector3 startPosition;
    public float speed = 0.5f;
    public bool enteredCastle = false;
    public ParticleSystem poof;
    private Vector3 poofPosition;
    public AudioSource poofSound;
    private bool isOpen = false;
    public AudioSource doorSound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.parent.position;
        startPosition = transform.parent.position;
        CastleOutsideButton.instance.portalOutside.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.transform.GetComponent<DoorButton>() != null)
            {
                hit.transform.GetComponent<DoorButton>().OnLookLower();
                DoorButtonRaise.instance.particleSystemRaised.Stop();
                if (!isOpen)
                {
                    DoorButton.instance.buttonParticles.Play();
                    DoorButton.instance.doorOpenSound.Play();
                    doorSound.Play();
                    isOpen = true;
                }
            } 
            
            else if (hit.transform.GetComponent<DoorButtonRaise>() != null)
            {
                hit.transform.GetComponent<DoorButtonRaise>().OnLookRaise();
                DoorButton.instance.buttonParticles.Stop();

                if (isOpen)
                {
                    DoorButtonRaise.instance.particleSystemRaised.Play();
                    DoorButtonRaise.instance.doorButtonRaisedSound.Play();
                    doorSound.Play();
                    isOpen = false;
                }

            }

            else if (hit.transform.GetComponent<CastleInsideButton>() != null && !Door.instance.isRaised)
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
                    if (hit.transform.GetComponent<Hostage>() != null)
                    {
                        Instantiate(poof, hostageHit.transform.position, Quaternion.identity);
                        poofSound.Play();
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
        CastleInsideButton.instance.portalInside.Stop();
        CastleOutsideButton.instance.portalOutside.Play();
    }

    private void MoveOutsideCastle()
    {
        targetPosition = startPosition;
        enteredCastle = false;
        CastleInsideButton.instance.portalInside.Play();
        CastleOutsideButton.instance.portalOutside.Stop();
    }
}
