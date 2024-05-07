using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Parameters")]
    public int score = 0;
    public int enemyLimit;
    public int currentLevel = 0;
    public int enemyKillQuota;

    public int enemiesPresent;

    [Header("Enemy List")]
    public GameObject[] enemyList;
}
