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

    public float timeBetweenWaves = 30f;

    public int wavesToBeat = 50;

    private float countdown;
    private int waveIndex = 0;

    [Header("Scaling")]
    public float healthScale = 1f;
    public int valueScale = 1;

    void Start()
    {
        countdown = timeBetweenWaves;
        EnemiesAlive = 0;
    }

    void Update()
    {
        // If "Easy" difficulty, don't spawn new enemies until the current wave has been defeated
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
