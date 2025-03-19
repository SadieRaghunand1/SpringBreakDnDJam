using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsOfPrey : SkillBehavior
{
    public override void OnActivate()
    {
        base.OnActivate();
        if (!skillManager.propellorHat)
        {
            //obtainedSkills.Add(masterListOfSkillsAvailable[3]);
            skillManager.propellorHat = true;
            skillManager.rb.mass /= 2;
        }
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
        if (skillManager.propellorHat)
        {
            skillManager.propellorHat = false;
            skillManager.rb.mass = 1;
        }
    }

    public override void OnUpgrade(int _rank)
    {
       //We dunno
    }
}
