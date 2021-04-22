using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [Header("Button Effects:")]
    public AudioSource buttonPress;

    public Transform dialogueBox;
    public CanvasGroup fadePanel;

    public void Enable()
    {
        fadePanel.alpha = 0;
        fadePanel.LeanAlpha(1f, 1f);

        dialogueBox.localPosition = new Vector2(0, -Screen.height);
        dialogueBox.LeanMoveLocalY(0f, 1.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void CloseDialogue()
    {
        fadePanel.LeanAlpha(0f, 1.2f);
        dialogueBox.LeanMoveLocalY(-Screen.height, 0.8f).setEaseInExpo();
    }

    public void MainMenu()
    {
        buttonPress.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
