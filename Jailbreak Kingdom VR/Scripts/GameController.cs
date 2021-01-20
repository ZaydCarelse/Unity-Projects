using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DoorButtonRaise dRaise;
    public Text infoText;
    public Player player;
    public Transform hostageContainer;
    public int hostagesRemaining;

    private float restartTimer = 20f;

    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "USE THE BEACON TO OPEN THE JAIL CELL\nAND SET YOUR FRIENDS FREE!";
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
                infoText.text = "RESCUE YOUR FRIENDS BY LOOKING AT THEM\nAND HITTING THE GOOGLE CARDBOARD TRIGGER!";
                infoText.text += "\nHOSTAGES REMAINING: " + hostagesRemaining;
            } else
            {
                infoText.text = "CONGRATULATIONS! YOU RESCUED THEM ALL!\nNOW GET OUT AND LOCK THE JAIL BACK UP!";
            }
        }

        if (!player.enteredCastle && hostagesRemaining <= 0 && dRaise.doorRaised)
        {
            infoText.text = "YOU DID IT! WHAT A MIGHTY HERO YOU ARE!";
            restartTimer -= Time.deltaTime;
            if(restartTimer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
