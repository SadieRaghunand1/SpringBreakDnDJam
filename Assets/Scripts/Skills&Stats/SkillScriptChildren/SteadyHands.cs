using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyHands : SkillBehavior
{
    private Transform closestEnemy;
    private float closestDistanceComp = 0;
    private EnemyHealth lockedEnemy;
    private bool canCast = true;
    private int cooldownTime = 10;

    public override void OnActivate()
    {
        skillManager.obtainedSkills[2] = data;
        skillManager.steadyHands = true;

    }

    public override void OnDeactivate()
    {
        skillManager.steadyHands = false;
        Destroy(this.gameObject);
    }

    public override void OnCast()
    {
        spawner = FindAnyObjectByType<SpawnerEnemy>();
        int _count = 0;
        for (int i = 0; i < spawner.enemiesSpawned.Count; i++)
        {
            if (spawner.enemyObjSpawned[i] != null)
            {
                //Debug.Log("Spawner " + spawner.gameObject.name);
                //Debug.Log("Enemy in question = " + spawner.enemyObjSpawned[i].name);
                //Debug.Log("i = " + i);
                float _thisDistance = Vector3.Distance(this.transform.parent.transform.position, spawner.enemyObjSpawned[i].transform.position);

                if (closestDistanceComp == 0 || _thisDistance < closestDistanceComp || closestEnemy == null)
                {
                    Debug.Log("Change closest i = " + i);
                    closestDistanceComp = _thisDistance;
                    closestEnemy = spawner.enemyObjSpawned[i].transform;
                    _count = i;
                }
            }
            else
            {
                Debug.Log("Null enemy");
            }
                  
        }


        //Debug.Log("Closest enemy is " + closestEnemy.gameObject.name);
        if (closestEnemy != null)
        {
            lockedEnemy = closestEnemy.gameObject.GetComponent<EnemyHealth>();
            Debug.Log(lockedEnemy.gameObject.name + "Auto tagets");
            lockedEnemy.LoseHealth(skillManager.attack.spellDamage);
            StartCoroutine(CastCooldown());
        }
       
    }

    public override void OnUpgrade(int _rank)
    {
        //reduce cooldown
    }

    IEnumerator CastCooldown()
    {
        canCast = false;
        yield return new WaitForSeconds(cooldownTime);
        canCast = true;
    }
}
