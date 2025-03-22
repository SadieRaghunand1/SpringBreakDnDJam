using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyMovement;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] EnemyMovement em;

    private void Update()
    {
        if (em.enemyState == EnemyState.PATROL)
        {
            animator.SetBool("isPunching", false);
            animator.SetBool("isMoving", true);
        }
        else if (em.enemyState == EnemyState.CHASE)
        {
            animator.SetBool("isPunching", false);
            animator.SetBool("isMoving", true);
        }
        /*else if (em.enemyState == EnemyState.ATTACK)
        {
            animator.SetBool("isPunching", true);
        }*/
        else if (em.enemyState == EnemyState.IDLE)
        {
            animator.SetBool("isPunching", false);
            animator.SetBool("isMoving", false);
        }
    }

}
