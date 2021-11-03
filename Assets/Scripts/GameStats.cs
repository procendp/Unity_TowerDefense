using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1200;

    void Start()
    {
        Money = startMoney;
    }
}
