using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonRaise : MonoBehaviour
{
    public Door door;
    public static DoorButtonRaise instance;
    public bool doorRaised;
    public ParticleSystem particleSystemRaised;
    public AudioSource doorButtonRaisedSound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        particleSystemRaised.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLookLower()
    {
        door.LowerDoor();
        doorRaised = false;
    }

    public void OnLookRaise()
    {
        door.RaiseDoor();
        doorRaised = true;

    }
}
