using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackDistance;



    private void Update()
    {
        InputAttack();
    }

    void InputAttack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Shoot");
            AttackSword();
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
                //Debug.Log("Did Hit");

                EnemyHealth _enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
                _enemy.LoseHealth();
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
        }
       
    }
}
