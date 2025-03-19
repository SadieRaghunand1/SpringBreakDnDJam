using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBehavior : MonoBehaviour
{
    public ScriptObjSkills data;
    public SkillManager skillManager;

    protected void Awake()
    {
        Debug.Log("Start on skill behavior run");
        skillManager = FindAnyObjectByType<SkillManager>();
    }

    public virtual void OnActivate()
    {
        
    }

    public virtual void OnDeactivate()
    {
        
    }

    public virtual void OnCast()
    {
        //This only applies to spells, on this script it will remain empty for those that are not spells
    }

    public virtual void OnUpgrade(int _rank)
    {

    }
}
