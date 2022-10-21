using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountdownText;

    public float timeBetweenWaves = 5f;

    private float countdown = 2f;
    private float spawnDelay = 0.5f;
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
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
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
        EnemiesAlive++;
    }


}
