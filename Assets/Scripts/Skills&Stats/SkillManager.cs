using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Skill bools")]
    public bool blurryHat;
    public bool flowerPot;
    public bool knightHelmet;
    public bool propellorHat;
    public bool wingedHelmet;

    [Header("Other")]
    [SerializeField] private HealthAndStats healthAndStats;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerController playerController;

    //These need container methods to be accessed by the buttons


    /// <summary>
    /// Knight helmet: increase defense by doubling health
    /// </summary>
    public void IncreaseDefense()
    {
        wingedHelmet = true;
        healthAndStats.health *= 2;
    } //END IncreaseDefense()

    /// <summary>
    /// Winged helmet: decrease mass of player to mimic glide effect
    /// </summary>
    public void DecreaseGravity()
    {
        propellorHat = true;
        rb.mass /= 2;
    } //END DecreaseGravity()

    /// <summary>
    /// Blurry hat: increase speed, double speed
    /// </summary>
    public void IncreaseSpeed()
    {
        blurryHat = true;
        playerController.speed *= 2;
    } //END IncreaseSpeed()

    /// <summary>
    /// Flower Pot
    /// </summary>
    public void TurnOnFlowerPot()
    {
        flowerPot = true;
    } //END TurnOnFLowerPot()

    /// <summary>
    /// Winged helmet
    /// </summary>
    public void TurnOnWingedHelmet()
    {
        wingedHelmet = true;
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
