using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleOutsideButton : MonoBehaviour
{
    public static CastleOutsideButton instance;
    public ParticleSystem portalOutside;
    public bool isInside = false;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
