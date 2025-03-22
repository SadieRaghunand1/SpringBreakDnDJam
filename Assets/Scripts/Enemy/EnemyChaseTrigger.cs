using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseTrigger : MonoBehaviour
{
    public List<EnemyMovement> assignedEnemies;
    public GameObject[] areaPatrolPts;

    private void OnTriggerEnter(Collider other)
    {
        ChangeEnemyStateChase(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeEnemyStateExitChase(other);
    }

    void ChangeEnemyStateChase(Collider _other)
    {
        if(_other.gameObject.layer == 8)
        {
            for (int i = 0; i < assignedEnemies.Count; i++)
            {
                if (assignedEnemies[i] != null)
                {
                    assignedEnemies[i].enemyState = EnemyMovement.EnemyState.CHASE;
                }
            }
        }
        
    }

    void ChangeEnemyStateExitChase(Collider _other)
    {
        

        if (_other.gameObject.layer == 8)
        {
            for (int i = 0; i < assignedEnemies.Count; i++)
            {
                int _idle = Random.Range(0, 2);
                if (assignedEnemies[i] != null)
                {
                    if(_idle == 0)
                    {
                        assignedEnemies[i].enemyState = EnemyMovement.EnemyState.PATROL;
                    }
                    else if(_idle == 1)
                    {
                        assignedEnemies[i].enemyState = EnemyMovement.EnemyState.IDLE;
                    }
                    
                }
            }
        }
    }
}
