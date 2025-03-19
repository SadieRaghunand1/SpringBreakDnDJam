using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurryHat : SkillBehavior
{
    public override void OnActivate()
    {
        base.OnActivate();
        if (!skillManager.blurryHat)
        {

            skillManager.obtainedSkills[0] = data;
            skillManager.blurryHat = true;
            skillManager.playerController.speed *= 2; //We will change the amount of speed multiplier
        }
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
        if (skillManager.blurryHat)
        {
            skillManager.blurryHat = false;
            skillManager.playerController.speed /= 2;
        }
    }

    public override void OnUpgrade(int _rank)
    {
        //Speed increase
    }
}
