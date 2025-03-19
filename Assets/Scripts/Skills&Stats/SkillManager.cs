using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    /// <summary>
    /// This script holds the functions for turning on and off skills, incuding replacing them
    /// There is one bool for each skill
    /// The player has an array of skills they currently hold, organized by type per index
    /// The plyer can only hold one skill of each type (hat, buff, spell, skill) at once
    /// If they choose one of a type they have already, it replaces that one, in teh array and previous functionality must be turned off, which should be moved to the scriptable object itself if possible (OnActivate, OnDeactiivate)
    /// Upgrades will be using the same bool, will just affect functionality when chosen
    /// </summary>



    [SerializeField] private ScriptObjSkills[] masterListOfSkillsAvailable;

    [Header("Skill bools - Hats")]
    public bool blurryHat; // 0
    public bool flowerPot; //1
    public bool barbarianHelmet; //5
    public bool wizardHat; //6
    public bool bearFur; //7

    [Header("Skill bools - Buffs")]
    public bool rage; //8
    public bool attackSpeed; //9
    public bool propellorHat; //3, now BIRDS OF PREY
    public bool wingedHelmet; //4, now APOLLO's SHOES
    //NEED ONE FOR INTELLIGENCE

    [Header("Skill bools - Spells")]
    public bool doubleAttack; //10
    public bool steadyHands; //11
    public bool fireball; //12
    public bool moonbeam; //13
    public bool eldritchBlast; //14

    [Header("Skill bools - Skills")]
    public bool knightHelmet; //2, this is THE WHOLE BEAN now
    public bool increasedStamina; //15
    public bool rayOfFrost; //16
    public bool vineWhip; //17
    public bool charmPerson; //18

    [Header("Skills player has")]
    public ScriptObjSkills[] obtainedSkills; //0 - Hat, 1 - Buff, 2 - Spell, 3 - Skill
    public SkillBehavior[] skillBehavior;
    public GameObject[] skillObj;

    [Header("Other")]
    public HealthAndStats healthAndStats;
    public Rigidbody rb;
    public PlayerController playerController;
    public Attack attack;



    //These need container methods to be accessed by the buttons

   

    public void OnStartRemove()
    {
        StatIncrease _statIncrease = FindAnyObjectByType<StatIncrease>();

       for(int i = 0; i < obtainedSkills.Length; i++)
        {
            for(int j = 0; j < _statIncrease.statsToChoose.Count; j++)
            {
                if (obtainedSkills[i] == _statIncrease.statsToChoose[j])
                {
                    _statIncrease.statsToChoose.RemoveAt(j);
                }
            }
        }
    }
    /// <summary>
    /// Knight helmet: increase defense by doubling health
    /// </summary>
    public void IncreaseDefense()
    {
        if(!knightHelmet)
        {
            //obtainedSkills.Add(masterListOfSkillsAvailable[2]);
            wingedHelmet = true;
            healthAndStats.health *= 2;
        }
        
    } //END IncreaseDefense()

    /// <summary>
    /// Propellor: decrease mass of player to mimic glide effect
    /// </summary>
    public void DecreaseGravity()
    {
        if(!propellorHat)
        {
            //obtainedSkills.Add(masterListOfSkillsAvailable[3]);
            propellorHat = true;
            rb.mass /= 2;
        }
        
    } //END DecreaseGravity()

    /// <summary>
    /// Blurry hat: increase speed, double speed
    /// </summary>
    public void IncreaseSpeed()
    {
        if(!blurryHat)
        {
            //obtainedSkills.Add(masterListOfSkillsAvailable[0]);
            blurryHat = true;
            playerController.speed *= 2;
        }
        
    } //END IncreaseSpeed()

    /// <summary>
    /// Flower Pot
    /// </summary>
    public void TurnOnFlowerPot()
    {
        if(!flowerPot)
        {
            //obtainedSkills.Add(masterListOfSkillsAvailable[1]);
            flowerPot = true;
            StartCoroutine(attack.FlowerPotAttack());
        }
        
    } //END TurnOnFLowerPot()

    /// <summary>
    /// Winged helmet
    /// </summary>
    public void TurnOnWingedHelmet()
    {
        if (!wingedHelmet)
        {
            //obtainedSkills.Add(masterListOfSkillsAvailable[4]);
            wingedHelmet = true;
        }
        
    } //END TurnOnWingedHelmet()

    /// <summary>
    /// Reset all skills
    /// </summary>
    public void OnDeath()
    {

        if(blurryHat)
        {
            playerController.speed /= 2;
        }

        blurryHat = false;
        flowerPot = false;
        knightHelmet = false;
        propellorHat = false;
        wingedHelmet = false;

        healthAndStats.health = 1;
        rb.mass = 1;

    } //END OnDeath()

   

}
