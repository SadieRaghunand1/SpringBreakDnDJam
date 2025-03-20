using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineWhip : SkillBehavior
{
    public override void OnActivate()
    {
        skillManager.obtainedSkills[3] = data;
        skillManager.vineWhip = true;
        StartCoroutine(skillManager.StartVineWhip());
    }

    public override void OnDeactivate()
    {
        skillManager.vineWhip = false;
        StopCoroutine(skillManager.StartVineWhip());
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //reach to middle, then back
    }

    
}
