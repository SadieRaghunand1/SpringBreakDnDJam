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
    public bool increasedStamina; //15, sprint
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

    [Header("Specific functionality")]
    public float frostDuration = 5;
    public LineRenderer moon;



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
    /// Reset all skills
    /// </summary>
    public void OnDeath()
    {

       /* if(blurryHat)
        {
            playerController.speed /= 2;
        }

        blurryHat = false;
        flowerPot = false;
        knightHelmet = false;
        propellorHat = false;
        wingedHelmet = false;

        healthAndStats.health = 1;
        rb.mass = 1;*/

        for(int i = 0; i < skillBehavior.Length; i++)
        {
            if (skillBehavior[i] != null)
            {
                skillBehavior[i].OnDeactivate();
            }
        }

    } //END OnDeath()

    ////////////////////////////////////////////
    ///Below here is functions relating specifically to different skills' functionalities
    ///

    #region RayOfFrost
    private void RayOfFrostLaunch()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50)) //50 is a placeholder distance

        {
            if (hit.collider.gameObject.layer == 7)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
                Debug.Log("Get Frosted");


                EnemyMovement _enemyMove = hit.collider.gameObject.GetComponent<EnemyMovement>();
                EnemyMovement.EnemyState _previousState = _enemyMove.enemyState;
                _enemyMove.enemyState = EnemyMovement.EnemyState.IDLE;

                StartCoroutine(TimeRayDuration(_enemyMove, _previousState));

            }

        }
    }

    private IEnumerator TimeRayDuration(EnemyMovement _enemyMove, EnemyMovement.EnemyState _returnState)
    {
        yield return new WaitForSeconds(frostDuration);
        _enemyMove.enemyState = _returnState;
    }

    public IEnumerator TimeRayCasts()
    {
        yield return new WaitForSeconds(7); //7 is placeholder
        RayOfFrostLaunch();
        StartCoroutine(TimeRayCasts());
    }


    #endregion
}
