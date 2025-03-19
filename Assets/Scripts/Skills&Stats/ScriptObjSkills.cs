using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptObjSkills : ScriptableObject
{
    public enum SkillType
    {
        HAT,
        BUFF,
        SPELL,
        SKILL,
        NONE
    }

    public enum StatAssociated
    {
        CHARISMA,
        DEXTERITY,
        INTELLIGENCE,
        STRENGTH,
        WISDOM,
        NONE
    }

    public string statName;
    public string statDesc;
    public int skillIndex;
    public SkillType skillType;
    public StatAssociated statAssociated;
    public SkillBehavior skillBehavior;
}
