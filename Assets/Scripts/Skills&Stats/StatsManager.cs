using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    //Manages pass between of player being spawned in bc buttons in scene that need parameters

    private HealthAndStats player;
    private SkillManager skillManager;
    [SerializeField] private GameObject statMenu;
    [SerializeField] private GameObject skillMenu;
    [SerializeField] private StatIncrease skillCanvas;

    private void Start()
    {
        player = FindAnyObjectByType<HealthAndStats>();
        skillManager = FindAnyObjectByType<SkillManager>();
    }

    /// <summary>
    /// Manages pass between of player being spawned in bc buttons in scene that need parameters
    /// </summary>
    /// <param name="_statID"></param>
    public void HoldIncreaseStats(int _statID)
    {
        player.IncreaseStat(_statID);
    }

    public void HoldSkillToggles(int _skillInx)
    {
        int _skillID = skillCanvas.displayedChoices[_skillInx].skillIndex;
        Debug.Log(_skillID);
        
        switch(_skillID)
        {
            case 1: //Knight helmet
                skillManager.IncreaseDefense();
                break;
            case 2: //Propellor hat
                skillManager.DecreaseGravity(); 
                break;
            case 3: //Blurry hat
                skillManager.IncreaseSpeed();
                break;
            case 4: //Flower pot
                skillManager.TurnOnFlowerPot();
                break;
            case 5: //Winged helmet
                skillManager.TurnOnWingedHelmet();
                break;
        }
    }

    public void OpenStatMenu()
    {
        statMenu.SetActive(true);
    }
    public void CloseStatMenu()
    {
        statMenu.SetActive(false);
    }
}
