using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Info:")]
    public static int EnemiesAlive = 0;

    [Header("Transforms:")]
    public Transform enemyPrefab;
    public Transform spawnPoint;

    [Header("Timer:")]
    public float timeBetweenWaves = 5f;
    public float countDown = 2f;
    public Text waveCountdownText;

    [Header("Waves:")]
    private int waveNumber = 1;
    public Wave[] waves;

    private void Update()
    {
        if (EnemiesAlive > 0)
            return;

        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.0}", countDown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.waves++;

        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.spawnAmount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.spawnRate);
        }

        waveNumber++;

        if (waveNumber == waves.Length)
        {
            Debug.Log("Level Complete!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
