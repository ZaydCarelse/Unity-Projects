using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleInsideButton : MonoBehaviour
{
    public static CastleInsideButton instance;
    public ParticleSystem portalInside;
    public bool isInside = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
      
    }
    
}
