using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Transforms:")]
    public Transform enemyPrefab;
    public Transform spawnPoint;

    [Header("Timer:")]
    public float timeBetweenWaves = 5f;
    public float countDown = 2f;
    public Text waveCountdownText;

    [Header("Waves:")]
    private int waveNumber = 1;

    private void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;

        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.0}", countDown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        PlayerStats.waves++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);   
    }
}
