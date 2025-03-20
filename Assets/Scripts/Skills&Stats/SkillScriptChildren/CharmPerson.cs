using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmPerson : SkillBehavior
{
    public override void OnActivate()
    {
        skillManager.obtainedSkills[3] = data;
        skillManager.charmPerson = true;
        StartCoroutine(skillManager.TimeChoosing());
    }

    public override void OnDeactivate()
    {
        skillManager.charmPerson = false;
        StopCoroutine(skillManager.TimeChoosing()); 
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        base.OnUpgrade(_rank);
    }
}
