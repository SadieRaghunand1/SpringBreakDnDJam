using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : SkillBehavior
{
    private float attackMult = 1.5f;

    public override void OnActivate()
    {
        skillManager.obtainedSkills[1] = data;
        skillManager.rage = true;
        skillManager.attack.attackDamage *= attackMult;
    }

    public override void OnDeactivate()
    {
        skillManager.rage = false;
        skillManager.attack.attackDamage /= attackMult;
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase the multiplier
    }
}
