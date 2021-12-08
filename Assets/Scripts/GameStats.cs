using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1000;

    public static int Lives;
    public int startLives = 5;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
