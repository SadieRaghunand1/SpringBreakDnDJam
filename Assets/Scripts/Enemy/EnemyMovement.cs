using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyState
    {
        PATROL,
        //ATTACK,
        CHASE,
        CHARMED,
        IDLE
    }


    private NavMeshAgent agent;
    public EnemyState enemyState;
    private GameObject player;

    public GameObject[] patrolPts;
    private int ptIndex = 0;

    public bool debugging;

    private SpawnerEnemy spawner;
    private GameObject targetEnemy;

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
            //ChangePatrolPt();
        }
        
    }

   
    void InitValues()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerController>().gameObject;
        spawner = FindAnyObjectByType<SpawnerEnemy>();

        int _idle = Random.Range(0, 3);
        if(_idle == 0 || _idle == 2)
        {
            enemyState = EnemyState.PATROL;
        }
        else if(_idle == 1)
        {
            enemyState = EnemyState.IDLE;
        }
       // enemyState = EnemyState.PATROL;
    }

    void StateMachine()
    {
        if(enemyState == EnemyState.PATROL)
        {
            //Move
            agent.SetDestination(patrolPts[ptIndex].transform.position);
            ChangePatrolPt();
        }
        else if (enemyState == EnemyState.CHASE)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (enemyState == EnemyState.CHARMED)
        {
            CharmedMovement();
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

    public void ChooseEnemyCharmed ()
    {
        int _index = Random.Range(0, spawner.enemyObjSpawned.Count);
        targetEnemy = spawner.enemyObjSpawned[_index];
    }

    void CharmedMovement()
    {
        if (targetEnemy != null)
            agent.SetDestination(targetEnemy.transform.position);
    }

}
