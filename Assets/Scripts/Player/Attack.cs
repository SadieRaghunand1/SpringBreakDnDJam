using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float flowerDistance;
    public float attackDamage;
    public bool isAttacking = false;
    private bool canAttack = true;

    public int killed;

    int flowerPotSpeed = 1;
    public float spellDamage = 1;

   public ExitRoom exitRoom;

    public SkillManager skillManager;
    public Animator weaponAnim;
  

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
            //Debug.Log("Shoot");
            AttackSword(false);

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


    void AttackSword(bool _flowerPot)
    {

        float _distance;
        if(_flowerPot)
        {
            _distance = flowerDistance;
        }
        else
        {
            _distance = attackDistance;
        }

            RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _distance))

        {
            if(hit.collider.gameObject.layer == 7)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit " + hit.collider.gameObject.name);
                EnemyHealth _enemy;
                if (hit.collider.gameObject.GetComponent<BossHealth>())
                {
                     _enemy = hit.collider.gameObject.GetComponent<BossHealth>();
                }
                else
                {
                    _enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
                }
                    
               // killed++;
                //exitRoom.StopGame();
                _enemy.LoseHealth(attackDamage);
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
        }

        if(!_flowerPot)
        {
            weaponAnim.SetTrigger("isAttackingTrigger");
            if (skillManager.attackSpeed)
            {
                weaponAnim.SetFloat("attackSpeed", skillManager.animMult);
            }
        }
       
    }


    IEnumerator WaitForAttackAnim()
    {
        canAttack = false;
        float _time = weaponAnim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(_time);
        canAttack = true;
    }

    public IEnumerator FlowerPotAttack()
    {
        yield return new WaitForSeconds(flowerPotSpeed);
        AttackSword(true);
        StartCoroutine(FlowerPotAttack());
    }

    public IEnumerator DoubleAttack()
    {
        AttackSword(false);
        yield return new WaitForSeconds(0.5f);
        AttackSword(false);
    }
}
