/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Keeps track of current stage and enemies killed
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Level Parameters")]
    public int score = 0;
    public int currentStage = 1;
    public int stageKillQuota;
    public int enemiesKilledThisStage = 0;


    [Header("References")]
    public TMP_Text stageDisplay;
    public TMP_Text killsDisplay;
    public EnemySpawner enemySpawner;

    public void Start()
    {

    }

    /// <summary>
    /// function called when an enemy dies, updates kill count, advances the stage, and updates UI
    /// </summary>
    /// <param name="pointsToAdd"></param>
    public void OnEnemyDeath(int pointsToAdd)
    {
        enemiesKilledThisStage++;
        score += pointsToAdd;

        if (enemiesKilledThisStage >= stageKillQuota)
        {
            AdvanceStage();
        }
        killsDisplay.text = "Kills: " + enemiesKilledThisStage.ToString() + "/" + stageKillQuota.ToString();
    }

    /// <summary>
    /// advances to the next stage and increases the difficulty
    /// </summary>
    private void AdvanceStage()
    {
        if (currentStage >= 5)
        {
            SceneManager.LoadScene(2);
        }

        Debug.Log("Advancing to next Stage");
        currentStage++;
        enemiesKilledThisStage = 0;
        stageDisplay.text = ("Stage " + currentStage.ToString());

        enemySpawner.maxEnemiesPresent++;
        stageKillQuota += 5;
        enemySpawner.enemiesSpawnedPerCycle++;
        enemySpawner.enemyTypesPerStage++;
        enemySpawner.SetStageEnemies();

        killsDisplay.text = "Kills: " + enemiesKilledThisStage.ToString() + "/" + stageKillQuota.ToString();
    }
}
