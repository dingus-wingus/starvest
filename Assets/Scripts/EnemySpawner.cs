/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Spawns Enemies at the edges of the screen and keeps track of which enemies are active
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public int enemyTypesPerStage;
    public int maxEnemiesPresent = 2;

    [Header("Enemies")]
    public List<GameObject> enemyPrefabs;
    private List<GameObject> stageEnemies = new List<GameObject>();
    public List<GameObject> enemiesPresent = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        SetStageEnemies();

        InvokeRepeating("SpawnEnemy", 1, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemy in enemiesPresent.ToList())
        {
            if (enemy.activeSelf == false)
            {
                Debug.Log("Enemy Died");
                enemiesPresent.Remove(enemy);
                levelManager.OnEnemyDeath(100);

                if (enemiesPresent.Count <= 0)
                {
                    StartCoroutine(SpawnEnemyInOneSecond());
                }

                Destroy(enemy);
            }
        }
    }

    /// <summary>
    /// calls SpawnEnemy() after 1 second
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnEnemyInOneSecond()
    {
        yield return new WaitForSeconds(1);
        SpawnEnemy();
    }

    /// <summary>
    /// Sets the enemies that will spawn this stage
    /// </summary>
    public void SetStageEnemies()
    {
        List<GameObject> enemyPrefabsCopy = new List<GameObject>();

        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            enemyPrefabsCopy.Add(enemyPrefab);
        }

        stageEnemies.Clear();

        for (int i = 0; i < enemyTypesPerStage; i++)
        {
            int randomEnemyIndex = Random.Range(0, enemyPrefabsCopy.Count-1);
            stageEnemies.Add(enemyPrefabsCopy[randomEnemyIndex]);

            enemyPrefabsCopy.Remove(enemyPrefabsCopy[randomEnemyIndex]);
        }
        enemyPrefabsCopy.Clear();

        for (int i = 0; i < stageEnemies.Count; i++)
        {
            print(stageEnemies[i].ToString());
        }
    }

    /// <summary>
    /// Spawns enemies equal to enemiesSpawnedPerCycle. Stops spawning if maxEnemiesPresent is reached
    /// </summary>
    public void SpawnEnemy()
    {
        int previousSpawnRegion = 0;

        for (int i = 0; i < enemiesSpawnedPerCycle; i++)
        {
            if (enemiesPresent.Count >= maxEnemiesPresent)
            {
                Debug.Log("Too Many Enemies!");
                return;
            }
            
            GameObject selectedPrefab = stageEnemies[Random.Range(0, stageEnemies.Count)];
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

            var enemy = Instantiate(selectedPrefab);

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

            previousSpawnRegion = spawnRegion;

            enemiesPresent.Add(enemy);
        }
    }
}
