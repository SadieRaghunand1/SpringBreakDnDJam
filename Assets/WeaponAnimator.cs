using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Attack;

public class WeaponAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Attack attack;
    void Update()
    {
        if (attack.isAttacking == true)
        {
            Debug.Log("animate");
            animator.SetBool("isAttacking", true);
            if(attack.skillManager.attackSpeed)
            {
                animator.SetFloat("attackSpeed",attack.skillManager.animMult);
            }
        }
        else
        {

            animator.SetBool("isAttacking", false);
        }
    }
}
