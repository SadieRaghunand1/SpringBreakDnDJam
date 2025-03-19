using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWholeBean : SkillBehavior
{
    //Evasion rate


    public override void OnActivate()
    {
        skillManager.knightHelmet = true;
    }

    public override void OnDeactivate()
    {
        skillManager.knightHelmet = false;
        Destroy(this.gameObject);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increase rate of evasion
    }

}
