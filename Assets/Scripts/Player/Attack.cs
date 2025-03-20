using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackDistance;
    public float attackDamage;
    public bool isAttacking = false;
    private bool canAttack = true;

    public int killed;

    int flowerPotSpeed = 1;
    public float spellDamage = 1;

   public ExitRoom exitRoom;

    [SerializeField] private SkillManager skillManager;

  

    private void Update()
    {
        InputAttack();
        InputCastSpell();
    }

    void InputAttack()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            isAttacking = true;
            Debug.Log("Shoot");
            AttackSword();

            StartCoroutine(WaitForAttackAnim());
        }
        else if (!Input.GetMouseButtonDown(0))
        {
            isAttacking = false;
        }
    }


    void InputCastSpell()
    {
        if(Input.GetMouseButtonDown(1) && skillManager.obtainedSkills[2] != null)
        {
            Debug.Log("Right mouse pressed");
            skillManager.skillBehavior[2].OnCast();
        }
    }


    void AttackSword()
    {
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, attackDistance))

        {
            if(hit.collider.gameObject.layer == 7)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                EnemyHealth _enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
                killed++;
                exitRoom.StopGame();
                _enemy.LoseHealth(attackDamage);
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
        }
    }

   

    IEnumerator WaitForAttackAnim()
    {
        canAttack = false;
        yield return new WaitForSecondsRealtime(1f);
        canAttack = true;
    }

    public IEnumerator FlowerPotAttack()
    {
        yield return new WaitForSeconds(flowerPotSpeed);
        AttackSword();
        StartCoroutine(FlowerPotAttack());
    }

    public IEnumerator DoubleAttack()
    {
        AttackSword();
        yield return new WaitForSeconds(0.5f);
        AttackSword();
    }
}
