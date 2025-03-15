using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth
{
    public int bossID;
    public override void CheckDead()
    {
        if(health <= 0)
        {
            FindAnyObjectByType<HealthAndStats>().CheckBossDeath(bossID);
            Destroy(gameObject);
        }
    }
}
