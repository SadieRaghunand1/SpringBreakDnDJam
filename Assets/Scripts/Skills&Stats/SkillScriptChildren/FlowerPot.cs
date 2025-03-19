using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPot : SkillBehavior
{
    public override void OnActivate()
    {
        base.OnActivate();
        if (!skillManager.flowerPot)
        {

            skillManager.obtainedSkills[0] = data;
            skillManager.flowerPot = true;
            StartCoroutine(skillManager.attack.FlowerPotAttack());
        }

    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
        skillManager.flowerPot = false;
        StopCoroutine(skillManager.attack.FlowerPotAttack());
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Decrease time between attacks
    }
}
