using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;


    public void LoseHealth()
    {
        health--;

        if(health <= 0)
        {
            Debug.Log("Die");

            //Temp: Destroy
            Destroy(gameObject);
        }
    }
}
