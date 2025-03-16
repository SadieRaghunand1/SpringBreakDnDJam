using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private ScriptObjSkills[] masterListOfSkillsAvailable;

    [Header("Skill bools")]
    public bool blurryHat; // 0
    public bool flowerPot; //1
    public bool knightHelmet; //2
    public bool propellorHat; //3
    public bool wingedHelmet; //4

    public List<ScriptObjSkills> obtainedSkills = new List<ScriptObjSkills>();

    [Header("Other")]
    [SerializeField] private HealthAndStats healthAndStats;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerController playerController;

    //These need container methods to be accessed by the buttons

    public void OnStartRemove()
    {
        StatIncrease _statIncrease = FindAnyObjectByType<StatIncrease>();

       for(int i = 0; i < obtainedSkills.Count; i++)
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
            obtainedSkills.Add(masterListOfSkillsAvailable[2]);
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
            obtainedSkills.Add(masterListOfSkillsAvailable[3]);
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
            obtainedSkills.Add(masterListOfSkillsAvailable[0]);
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
            obtainedSkills.Add(masterListOfSkillsAvailable[1]);
            flowerPot = true; 
        }
        
    } //END TurnOnFLowerPot()

    /// <summary>
    /// Winged helmet
    /// </summary>
    public void TurnOnWingedHelmet()
    {
        if (!wingedHelmet)
        {
            obtainedSkills.Add(masterListOfSkillsAvailable[4]);
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
