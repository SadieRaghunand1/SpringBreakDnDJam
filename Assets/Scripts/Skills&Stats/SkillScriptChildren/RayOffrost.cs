using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayOffrost : SkillBehavior
{
    public override void OnActivate()
    {
        skillManager.obtainedSkills[3] = data;
        skillManager.rayOfFrost = true;
        StartCoroutine(skillManager.TimeRayCasts());
    }

    public override void OnDeactivate()
    {
        skillManager.rayOfFrost = false;
        StopCoroutine(skillManager.TimeRayCasts());
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase duration
    }

}
