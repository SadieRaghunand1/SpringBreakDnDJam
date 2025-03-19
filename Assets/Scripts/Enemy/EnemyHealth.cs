using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] protected float health;


    public void LoseHealth(float _damage)
    {
        health -= _damage;

        CheckDead();
    }

    public virtual void CheckDead()
    {
        if (health <= 0)
        {
            Debug.Log("Die");

            //Temp: Destroy
            Destroy(gameObject);
        }
    }
}
