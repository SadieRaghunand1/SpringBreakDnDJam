using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScythesEdge : SkillBehavior
{
    public override void OnActivate()
    {
        skillManager.obtainedSkills[1] = data;
        skillManager.scythesEdge = true;
    }

    public override void OnDeactivate()
    {
        skillManager.scythesEdge = false;
    }

    public override void OnUpgrade(int _rank)
    {
        ///////////////////////
    }
}
