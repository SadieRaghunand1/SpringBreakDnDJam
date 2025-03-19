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

    public virtual void OnUpgrade(int _rank)
    {

    }
}
