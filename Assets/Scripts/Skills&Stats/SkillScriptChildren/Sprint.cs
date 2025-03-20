using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : SkillBehavior
{
    public override void OnActivate()
    {
        skillManager.obtainedSkills[3] = data;
        skillManager.increasedStamina = true;
    }

    public override void OnDeactivate()
    {
        skillManager.increasedStamina = false;
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Sprinting lasts longer, increments of 5 seconds
    }
}
