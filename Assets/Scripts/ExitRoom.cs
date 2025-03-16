using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRoom : MonoBehaviour
{
    [SerializeField] private StatsManager statsManager;
    private StatIncrease statIncrease;
    [SerializeField] private SpawnerEnemy spawnEnemy;

    private void Start()
    {
        statIncrease = FindAnyObjectByType<StatIncrease>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopGame(collision);
    }

    void StopGame(Collision _collision)
    {
        if(_collision.gameObject.layer == 8)
        {
            statIncrease.RandomizeStatInc();
            spawnEnemy.ClearLevelEnemies();
            statsManager.OpenSkillMenu();
        }
 
    }

}
