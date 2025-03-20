using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        AttackEnemy(other);
    }

    void AttackEnemy(Collider _other)
    {
        if(_other.gameObject.layer == 7)
        {
            EnemyHealth _enemy = _other.gameObject.GetComponent<EnemyHealth>();
            _enemy.LoseHealth(damage);
        }
        else if(_other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
        
    }
}
