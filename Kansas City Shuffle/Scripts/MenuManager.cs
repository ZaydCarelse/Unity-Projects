using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void OnButtonClick()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void MuteAudio()
    {
        if (!MusicManager.instance.isMute)
        {
            AudioListener.volume = 0;
            MusicManager.instance.isMute = true;
        }
        else
        {
            AudioListener.volume = 1;
            MusicManager.instance.isMute = false;
        }
    }

    public void AppQuit()
    {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
    }
}
