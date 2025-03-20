using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedInc : SkillBehavior
{
    

    public override void OnActivate()
    {
        skillManager.obtainedSkills[1] = data;
        skillManager.attackSpeed = true;
    }

    public override void OnDeactivate()
    {
        skillManager.attackSpeed = false;
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase speed multiplier
    }

    
}
