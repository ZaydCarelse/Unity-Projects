using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource buttonAudio;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.GetComponent<PlayButton>() != null && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                PlayButton.instance.PlayButtonPress();
            }

            if (hit.transform.GetComponent<MuteButton>() && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                MuteAudio();
            }
        }
    }

    public void OnButtonClick()
    {
        buttonAudio.Play();
    }

    public void MuteAudio()
    {
        if (!Music.instance.isMute)
        {
            AudioListener.volume = 0;
            Music.instance.isMute = true;
        }
        else
        {
            AudioListener.volume = 1;
            Music.instance.isMute = false;
        }

    }
    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Application has closed");
    }

}
