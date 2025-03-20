using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianHelmet : SkillBehavior
{
    public override void OnActivate()
    {
        skillManager.obtainedSkills[0] = data;
        skillManager.barbarianHelmet = true;
    }

    public override void OnDeactivate()
    {
        skillManager.barbarianHelmet = false;
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increases the chance to revive
    }
}
