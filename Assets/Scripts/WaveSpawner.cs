using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    public int wavesToBeat = 50;

    private float countdown;
    private int waveIndex = 0;

    [Header("Scaling")]
    public float healthScale = 1f;
    public int valueScale = 1;

    void Start()
    {
        countdown = 2f;
        EnemiesAlive = 0;
    }

    void Update()
    {
        if ((EnemiesAlive > 0) && (GameManager.Difficulty == 0))
        {
            return;
        }

        if (waveIndex == wavesToBeat)
        {
            gameManager.WinLevel();
            this.enabled = false;
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

        // Override settings for enemies
        Enemy waveEnemy = wave.enemy.GetComponent<Enemy>();
        waveEnemy.value = (waveIndex + 1) * valueScale;
        waveEnemy.startHealth = 100f + (healthScale * waveIndex);

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        PlayerStats.Rounds++;
        
        waveIndex++;


    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
