using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public static PlayButton instance;

    private void Awake()
    {
        instance = this;    
    }

    public void PlayButtonPress()
    {
        SceneManager.LoadScene("Main");
    }
}
