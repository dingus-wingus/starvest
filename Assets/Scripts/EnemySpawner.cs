using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    public LevelManager levelManager;

    [Header("Spawning Parameters")]
    public Vector2 horizontalRange;
    public Vector2 verticalRange;

    public float spawnRate;
    public int enemiesSpawnedPerCycle;

    [Header("Enemies")]
    public GameObject[] enemyPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int previousSpawnRegion = 0;

        for (int i = 0; i < enemiesSpawnedPerCycle; i++)
        {
            if (levelManager.enemiesPresent >= levelManager.enemyLimit)
            {
                Debug.Log("Too Many Enemies!");
                return;
            }

            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            int spawnRegion = Random.Range(1, 4);

            if (spawnRegion == previousSpawnRegion)
            {
                spawnRegion = Random.Range(1, 3);
                if (spawnRegion == previousSpawnRegion)
                {
                    spawnRegion++;
                }
            }

            Vector3 spawnPosition = Vector3.zero;

            Instantiate(enemy);

            if (spawnRegion == 1)
            {
                spawnPosition.x = Random.Range(horizontalRange.x, horizontalRange.y);
                spawnPosition.y = verticalRange.x;
            }
            if (spawnRegion == 2)
            {
                spawnPosition.x = Random.Range(horizontalRange.x, horizontalRange.y);
                spawnPosition.y = verticalRange.y;
            }
            if (spawnRegion == 3)
            {
                spawnPosition.x = horizontalRange.x;
                spawnPosition.y = Random.Range(verticalRange.x, verticalRange.y);
            }
            if (spawnRegion == 4)
            {
                spawnPosition.x = horizontalRange.y;
                spawnPosition.y = Random.Range(verticalRange.x, verticalRange.y);
            }

            enemy.transform.position = spawnPosition;
            enemy.GetComponent<EnemyController>().levelManager = levelManager;
            previousSpawnRegion = spawnRegion;
        }
    }
}
