using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFur : SkillBehavior
{
    public float radius = 50;  //Can be changed

    public override void OnActivate()
    {
        skillManager.obtainedSkills[0] = data;
        skillManager.bearFur = true;
    }

    public override void OnDeactivate()
    {
        skillManager.bearFur = false;
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase range
    }
}
