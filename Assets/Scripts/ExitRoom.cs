using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRoom : MonoBehaviour
{
    [SerializeField] private StatsManager statsManager;
    private StatIncrease statIncrease;
    [SerializeField] private SpawnerEnemy spawnEnemy;
    private Attack attack;
    [SerializeField] private int goalKill;

    private void Start()
    {
        statIncrease = FindAnyObjectByType<StatIncrease>();
        attack = FindAnyObjectByType<Attack>();
        attack.exitRoom = this;
    }

   
    public void StopGame()
    {
        if(attack.killed >= goalKill) 
        {
            Debug.Log(attack.killed + " " + goalKill);
            statIncrease.RandomizeStatInc();
            spawnEnemy.ClearLevelEnemies();
            statsManager.OpenSkillMenu();
            attack.killed = 0;
        }
 
    }

}
