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
            skillManager.obtainedSkills[1] = data;
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
            Destroy(this.gameObject);
        }
    }

    public override void OnUpgrade(int _rank)
    {
       //We dunno
    }
}
