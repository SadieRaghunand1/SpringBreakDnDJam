using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth
{
    public int bossID;
    public override void CheckDead()
    {
        Debug.Log("boss override check death called");
        if(health <= 0)
        {
            FindAnyObjectByType<HealthAndStats>().CheckBossDeath(bossID);
            Destroy(gameObject);
        }
    }

    public override void LoseHealth(float _damage)
    {
        //base.LoseHealth(_damage);

        Debug.Log("Boss hit health = " + health + " damage = " + _damage);
        health -= _damage;
       

        CheckDead();
    }
}
