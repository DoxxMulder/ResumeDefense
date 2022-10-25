using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountdownText;

    public GameManager gameManager;

    public float timeBetweenWaves = 5f;

    private float countdown = 2f;
    private int waveIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if ((EnemiesAlive > 0) && (GameManager.Difficulty == 0))
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);

    }
    IEnumerator SpawnWave()
    {
        // Only the first wave is populated, so just keep spawning the first wave entry
        //Wave wave = waves[waveIndex];
        Wave wave = waves[0];
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        PlayerStats.Rounds++;
        
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }


}
