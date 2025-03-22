using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Timing
    private float timeBwAttacks;
    private float timeMax = 10;
    private float timeMin = 0;


    private int chanceToHit;
    private float attackDistance = 50;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeAttack());
    }

    void AttackPlayer()
    {
        anim.SetBool("isPunching", true);
        Debug.Log("Enemy attacks");
        RaycastHit hit;
       // enemyMovement.enemyState = EnemyMovement.EnemyState.ATTACK;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, attackDistance))

        {
            if (hit.collider.gameObject.layer == 8 && enemyMovement.enemyState != EnemyMovement.EnemyState.CHARMED)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                HealthAndStats healthAndStats = hit.collider.GetComponent<HealthAndStats>();
                healthAndStats.Die();
            }

            else if(hit.collider.gameObject.layer == 8 && enemyMovement.enemyState == EnemyMovement.EnemyState.CHARMED)
            {
                EnemyHealth _enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
                _enemyHealth.LoseHealth(1);
                Debug.Log("Enemy hit bc one is charmed");
            }

        }

        StartCoroutine(EndAnimation());
        
    }

    private IEnumerator TimeAttack()
    {
        timeBwAttacks = Random.Range(timeMin, timeMax);
        yield return new WaitForSeconds(timeBwAttacks);
        if (enemyMovement.enemyState == EnemyMovement.EnemyState.CHASE || enemyMovement.enemyState == EnemyMovement.EnemyState.CHARMED)
        {
            
            AttackPlayer();
            
        }
        StartCoroutine(TimeAttack());
    }

    private IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        //yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).);
        anim.SetBool("isPunching", false);
    }

}
