using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsPanel : MonoBehaviour
{
    [Header("Button Effects:")]
    public AudioSource buttonPress;

    [Header("Toggle:")]
    public GameObject toggleOn;
    public GameObject toggleOff;
    public AudioManager audioManager;
    public bool audioOn;

    [Header("Options Button:")]
    public bool optionsOpen = false;

    [Header("AudioMixer:")]

    public Transform dialogueBox;

    private void Start()
    {
        toggleOn.SetActive(true);
        toggleOff.SetActive(false);
        audioManager.isMute = false;
        audioOn = true;
        dialogueBox.localPosition = new Vector2(0, -Screen.height);
    }

    public void OptionsToggle()
    {
        if (!optionsOpen)
        {
            buttonPress.Play();
            Enable();
        }
        else
        {
            buttonPress.Play();
            CloseDialogue();
        }
    }


    public void Enable()
    {
        dialogueBox.LeanMoveLocalY(0f, 1.5f).setEaseOutExpo();
        optionsOpen = true;
    }

    public void CloseDialogue()
    {
        dialogueBox.LeanMoveLocalY(-Screen.height, 1.5f).setEaseInExpo();
        optionsOpen = false;
    }

    public void AudioButton()
    {
        if (audioOn)
        {
            buttonPress.Play();
            toggleOn.SetActive(false);
            toggleOff.SetActive(true);
            audioOn = false;
            audioManager.isMute = true;
        }
        else
        {
            buttonPress.Play();
            toggleOn.SetActive(true);
            toggleOff.SetActive(false);
            audioOn = true;
            audioManager.isMute = false;
        }
    }
}
