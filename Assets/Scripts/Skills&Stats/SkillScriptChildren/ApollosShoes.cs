using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApollosShoes : SkillBehavior
{
    // Start is called before the first frame update
    public override void OnActivate()
    {
        base.OnActivate();
        if (!skillManager.wingedHelmet)
        {
            //obtainedSkills.Add(masterListOfSkillsAvailable[4]);
            skillManager.wingedHelmet = true;
        }
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
        if (skillManager.wingedHelmet)
        {
            skillManager.wingedHelmet = false;
        }
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase distance
    }

}
