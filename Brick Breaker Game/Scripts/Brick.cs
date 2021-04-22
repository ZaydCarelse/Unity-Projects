using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points;
    public int brickHitPoints;
    public Sprite hitSprite;

    public void BreakBrick()
    {
        brickHitPoints--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
