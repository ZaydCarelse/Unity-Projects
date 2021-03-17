using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
