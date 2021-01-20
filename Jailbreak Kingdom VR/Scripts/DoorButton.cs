using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Door door;
    public static DoorButton instance;
    public bool doorRaised;
    public ParticleSystem buttonParticles;
    public AudioSource doorOpenSound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonParticles.Stop();
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
