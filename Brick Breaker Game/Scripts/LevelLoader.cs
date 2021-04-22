using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public Animator transition;
    public int pickLevelIndex;

    public void LoadLevel()
    {
        StartCoroutine(LoadLvl());
    }

    IEnumerator LoadLvl()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
    }

    public void FadeReset()
    {
        transition.ResetTrigger("Start");
    }
}
