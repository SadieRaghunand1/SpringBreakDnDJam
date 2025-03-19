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
        skillManager.steadyHands = true;

    }

    public override void OnDeactivate()
    {
        skillManager.steadyHands = false;
        Destroy(this.gameObject);
    }

    public override void OnCast()
    {
        for(int i = 0; i < spawner.enemiesSpawned.Count; i++)
        {
            float _thisDistance = Vector3.Distance(this.transform.parent.transform.position, spawner.enemiesSpawned[i].gameObject.transform.position);

            if(closestDistanceComp == 0 || _thisDistance < closestDistanceComp)
            {
                closestDistanceComp = _thisDistance;
                closestEnemy = spawner.enemiesSpawned[i].gameObject.transform;
            }
        }
        lockedEnemy = closestEnemy.gameObject.GetComponent<EnemyHealth>();
        Debug.Log(lockedEnemy.gameObject.name + "Auto tagets");
        lockedEnemy.LoseHealth(skillManager.attack.attackDamage);
        StartCoroutine(CastCooldown());
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
