using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyState
    {
        PATROL,
        ATTACK,
        CHASE,
        IDLE
    }


    private NavMeshAgent agent;
    public EnemyState enemyState;
    private GameObject player;

    public GameObject[] patrolPts;
    private int ptIndex = 0;

    public bool debugging;

    // Start is called before the first frame update
    void Start()
    {
        InitValues();
    }

    // Update is called once per frame
    void Update()
    {

        if(!debugging)
        {
            StateMachine();
            ChangePatrolPt();
        }
        
    }

   
    void InitValues()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerController>().gameObject;
        enemyState = EnemyState.PATROL;
    }

    void StateMachine()
    {
        if(enemyState == EnemyState.PATROL)
        {
            //Move
            agent.SetDestination(patrolPts[ptIndex].transform.position);
        }
        else if (enemyState == EnemyState.CHASE)
        {
            agent.SetDestination(player.transform.position);
        }
        else if(enemyState == EnemyState.IDLE)
        {
            ;
        }
    }


    void ChangePatrolPt()
    {
        if(transform.position.x == patrolPts[ptIndex].transform.position.x && transform.position.z == patrolPts[ptIndex].transform.position.z)
        {
            if (ptIndex + 1 == patrolPts.Length)
            {
                ptIndex = 0;
            }
            else
            {
                ptIndex++;
            }
            
        }
    }

}
