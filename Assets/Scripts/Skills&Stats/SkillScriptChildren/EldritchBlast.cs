using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldritchBlast : SkillBehavior
{

    public override void OnActivate()
    {
        skillManager.obtainedSkills[2] = data;
        skillManager.eldritchBlast = true;
    }

    public override void OnDeactivate()
    {
        skillManager.eldritchBlast = false;
        Destroy(this.gameObject);
    }

    public override void OnCast()
    {
        for(int i = 0; i < skillManager.blastPoints.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(skillManager.blastPoints[i].transform.position, skillManager.blastPoints[i].transform.TransformDirection(Vector3.forward), out hit, 10))

            {
                if (hit.collider.gameObject.GetComponent<EnemyHealth>() != null)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                    Debug.Log("Eldricth");

                    hit.collider.gameObject.GetComponent<EnemyHealth>().LoseHealth(skillManager.attack.spellDamage);
                } 
               

                
            }
            
        }
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase number of beams
    }
}
