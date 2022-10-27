using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 10;

    public static int Rounds;

    public static int LifeLostToEnemyFromWave;
    public static int TotalKills = 0;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
        TotalKills = 0;
    }
}
