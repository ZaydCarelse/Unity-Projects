using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [Header("UI:")]
    public Text livesText;


    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " HP";
    }
}
