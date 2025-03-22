using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] protected float health;
    private Attack playerAttack;
    private ExitRoom exitRoom;

    public void Start()
    {
        playerAttack = FindAnyObjectByType<Attack>();
        exitRoom = FindAnyObjectByType<ExitRoom>();
    }

    public virtual void LoseHealth(float _damage)
    {
        health -= _damage;

        CheckDead();
    }

    public virtual void CheckDead()
    {
        
        if (health <= 0)
        {
            Debug.Log("Die");
            playerAttack.killed++;
            exitRoom.StopGame();
            //Temp: Destroy
            Destroy(gameObject);
        }
    }
}
