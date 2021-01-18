using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DoorButtonRaise dRaise;
    public TextMesh infoText;
    public Player player;
    public Transform hostageContainer;
    public int hostagesRemaining;

    private float restartTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "Use the beacon to open the jail cell\nand set your friends free!";
    }

    // Update is called once per frame
    void Update()
    {
        hostagesRemaining = hostageContainer.GetComponentsInChildren<Hostage>().Length;

        if (player.enteredCastle)
        {
            int hostagesRemaining = hostageContainer.GetComponentsInChildren<Hostage>().Length;

            if (hostagesRemaining > 0)
            {
                infoText.text = "Rescue your friends by looking at them\nand hitting the Google Cardboard trigger!";
                infoText.text += "\nHostages Remaining: " + hostagesRemaining;
            } else
            {
                infoText.text = "Congratulations! You rescued them all.\nNow get out of there and close the jail!";
            }
        }

        if (!player.enteredCastle && hostagesRemaining <= 0 && dRaise.doorRaised)
        {
            infoText.text = "You did it! What a mighty hero you are!";
            restartTimer -= Time.deltaTime;
            if(restartTimer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
