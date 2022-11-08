using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public int setDifficulty;
    public static int Difficulty;
    public static bool GameIsOver;      
    
    private void Start()
    {
        if (setDifficulty.IsUnityNull() && Difficulty.IsUnityNull())
        {
            Difficulty = PlayerPrefs.GetInt("Difficulty", 0);
        }
        else
        {
            Difficulty = setDifficulty;
        }
        GameIsOver = false;
        Time.timeScale = 1f;
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
