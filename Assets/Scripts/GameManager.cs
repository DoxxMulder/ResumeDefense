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

    public float timeBetweenWaves = 20f;

    private float countdown = 2f;
    private float spawnDelay = 0.5f;
    private int waveIndex = 0;

    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
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
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void EndGame()
    {
        Debug.Log("Game Over!");
    }
}
