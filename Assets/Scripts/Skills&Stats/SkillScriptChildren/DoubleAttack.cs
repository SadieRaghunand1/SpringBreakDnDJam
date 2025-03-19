using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttack : SkillBehavior
{
    public override void OnActivate()
    {
        skillManager.obtainedSkills[2] = data;
        skillManager.doubleAttack = true;
    }

    public override void OnDeactivate()
    {
        skillManager.doubleAttack = false;
        Destroy(this.gameObject);
    }

    public override void OnCast()
    {
        StartCoroutine(skillManager.attack.DoubleAttack());
    }

    public override void OnUpgrade(int _rank)
    {
       //We don't know
    }
}
