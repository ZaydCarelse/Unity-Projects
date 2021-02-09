using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Gameplay:")]
    public bool canPick = false;
    public bool picked = false;
    public bool won = false;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPick == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    Cup cup = hit.transform.GetComponent<Cup>();
                    if (cup != null)
                    {
                        cup.MoveUp();
                        picked = true;
                        won = (cup.coin != null);
                        canPick = false;
                        gm.targetCup.coin = null;
                    }
                }
            }
        }
    }
}
