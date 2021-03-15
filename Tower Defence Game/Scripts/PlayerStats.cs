using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Economy:")]
    public static int Money;
    public int startMoney = 400;

    [Header("Player:")]
    public static int Lives;
    public int startLives = 10;
    public static int waves;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        waves = 0;
    }


}
