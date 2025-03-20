using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizardhat : SkillBehavior
{
    public float spellDamageMult = 1.25f;

    public override void OnActivate()
    {
        skillManager.obtainedSkills[0] = data;
        skillManager.wizardHat = true;
        skillManager.attack.spellDamage *= spellDamageMult;
    }

    public override void OnDeactivate()
    {
        skillManager.wizardHat = false;
        skillManager.attack.spellDamage = 1;
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase multiplier
    }
}
