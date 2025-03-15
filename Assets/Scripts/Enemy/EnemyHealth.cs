using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] protected int health;


    public void LoseHealth()
    {
        health--;

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
