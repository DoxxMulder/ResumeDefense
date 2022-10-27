using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public static int Difficulty = 0;

    public static bool GameIsOver;      
    
    private void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }


        if (PlayerStats.Lives <= 0)
        {
            PlayerStats.Rounds = PlayerStats.LifeLostToEnemyFromWave;   //Set Rounds variable to *actual* number of waves survived, IE if you lose to the first enemy, you've survived 0 rounds
            EndGame();
        }
        
    }
    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
