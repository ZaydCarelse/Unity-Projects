using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Economy:")]
    public static int Money;
    public int startMoney = 400;

    void Start()
    {
        Money = startMoney;    
    }


}
