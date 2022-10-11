using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountdownText;
    public GameObject gameOverUI;

    public float timeBetweenWaves = 20f;

    private float countdown = 2f;
    private float spawnDelay = 0.5f;
    private int waveIndex = 0;

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

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);

        if (PlayerStats.Lives <= 0)
        {
            PlayerStats.Rounds = PlayerStats.LifeLostToEnemyFromWave;   //Set Rounds variable to *actual* number of waves survived, IE if you lose to the first enemy, you've survived 0 rounds
            EndGame();
        }
        
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i =0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
        
        Debug.Log("Wave Incoming!");

        PlayerStats.Rounds++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }
}
