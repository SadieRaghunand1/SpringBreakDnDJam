using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWholeBean : SkillBehavior
{
    //Evasion rate


    public override void OnActivate()
    {
        base.OnActivate();
        Debug.Log("The Whole Bean?");
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
        Debug.Log("Only half the bean");
    }

    public override void OnUpgrade(int _rank)
    {
        Debug.Log("Increase rate of evasion");
    }

}
