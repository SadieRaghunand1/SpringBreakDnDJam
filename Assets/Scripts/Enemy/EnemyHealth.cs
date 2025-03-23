using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] protected float health;
    private Attack playerAttack;
    private ExitRoom exitRoom;

    [SerializeField] private AudioSource attacked;
    public void Start()
    {
        playerAttack = FindAnyObjectByType<Attack>();
        exitRoom = FindAnyObjectByType<ExitRoom>();
    }

    public virtual void LoseHealth(float _damage)
    {
        health -= _damage;
        attacked.Play();
        CheckDead();
    }

    public virtual void CheckDead()
    {
        
        if (health <= 0)
        {
            Debug.Log("Die");
            playerAttack.killed++;
            if(playerAttack.killed == exitRoom.goalKill)
            {
                Debug.Log("All enemies dead");
            }
            //exitRoom.StopGame();
            //Temp: Destroy
            Destroy(gameObject);
        }
    }
}
