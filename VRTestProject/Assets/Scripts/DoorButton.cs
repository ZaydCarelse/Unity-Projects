using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Door door;
    public bool doorRaised;

    // Start is called before the first frame update
    void Start()
    {
        
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
