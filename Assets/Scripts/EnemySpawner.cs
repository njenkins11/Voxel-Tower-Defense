using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefab;
    [SerializeField] private List<float> enemySpawnChance;
    [SerializeField] private int nEnemiesInWave = 0;
    [SerializeField] private float spawnEnemyInWaveWaitTime = 2;
    [SerializeField] private bool isWaveSpawning = false;
    [SerializeField] private float spawnTimer = 20f;
    private float timer = 20;

    void Start()
    {
        timer = spawnTimer;
    }

    private void Update()
    {
        if (timer <= 0 && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StartCoroutine(SpawnWave());
            timer = spawnTimer;
        }
        if (!isWaveSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            timer -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        isWaveSpawning = true;
        nEnemiesInWave++;
        for (int i = 0; i < nEnemiesInWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnEnemyInWaveWaitTime);
        }
        isWaveSpawning = false;
    }

    private void SpawnEnemy()
    {
        float maxRandomValue = enemySpawnChance.Sum();
        float currentRandomValue = 0f;

        for (int i = 0; i < nEnemiesInWave; i++)
        {
            float randomValue = NextFloat(maxRandomValue);
            for (int k = 0; k < enemySpawnChance.Count; k++)
            {
                if (randomValue < enemySpawnChance[k] + currentRandomValue)
                {
                    GameObject enemy = Instantiate(enemyPrefab[k], transform);
                }
                currentRandomValue += enemySpawnChance[k];

            }
            currentRandomValue = 0;
        }
    }

    private float NextFloat(float maximum)
    {
        int maximumInteger = (int)(maximum * 100);
        int randomNumber = Random.Range(0, maximumInteger);
        return (float)randomNumber / 100;
    }

    public float GetTimer(){return timer;}
}
