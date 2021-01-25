using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [Header("Components")]
    public AudioSource buttonPress;

    public void OnButtonPress()
    {
        buttonPress.Play();
    }
}
