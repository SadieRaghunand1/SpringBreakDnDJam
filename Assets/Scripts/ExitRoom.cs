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
    public int goalKill;

    public bool bossDead;
    public bool bossRoom;

    private void Start()
    {
        statIncrease = FindAnyObjectByType<StatIncrease>();
        attack = FindAnyObjectByType<Attack>();
        attack.exitRoom = this;
    }


    private void OnCollisionEnter(Collision collision)
    {
        StopGame(collision);
    }

    public void StopGame(Collision _collision)
    {
        if(attack.killed >= goalKill && _collision.gameObject.layer == 8 && !bossRoom) 
        {
            Debug.Log(attack.killed + " " + goalKill);
            statIncrease.RandomizeStatInc();
            spawnEnemy.ClearLevelEnemies();
            statsManager.OpenSkillMenu();
            attack.killed = 0;
        }

        if(bossRoom && _collision.gameObject.layer == 8 && bossDead)
        {
            Debug.Log(attack.killed + " " + goalKill);
            
            spawnEnemy.ClearLevelEnemies();
            
            attack.killed = 0;

            statsManager.ChangeSceneToNextArea();
        }
 
    }

}
