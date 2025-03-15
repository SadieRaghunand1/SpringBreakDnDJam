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
        CHASE
    }


    private NavMeshAgent agent;
    public EnemyState enemyState;
    private GameObject player;

    [SerializeField] private GameObject[] patrolPts;

    // Start is called before the first frame update
    void Start()
    {
        InitValues();
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }

    void InitValues()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerController>().gameObject;
    }

    void StateMachine()
    {
        if(enemyState == EnemyState.PATROL)
        {
            //Move
        }
        else if (enemyState == EnemyState.CHASE)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
