using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    //Manages pass between of player being spawned in bc buttons in scene that need parameters

    private HealthAndStats player;
    private SkillManager skillManager;
    [SerializeField] private GameObject statMenu;
    [SerializeField] private GameObject skillMenu;
    [SerializeField] private StatIncrease skillCanvas;


    [SerializeField] private List<int> buildIndices;
    private void Start()
    {
        InitValues();
    }

    void InitValues()
    {
        player = FindAnyObjectByType<HealthAndStats>();
        skillManager = FindAnyObjectByType<SkillManager>();

        for(int i = 0; i <  player.scenesVisitedThisRun.Count; i++)
        {
            for(int j = 0; j < buildIndices.Count; j++)
            {
                if (player.scenesVisitedThisRun[i] == buildIndices[j])
                {
                    buildIndices.RemoveAt(j);
                }
            }
        }
    }

    /// <summary>
    /// Manages pass between of player being spawned in bc buttons in scene that need parameters
    /// </summary>
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

        CloseSkillMenu();
    }

    public void OpenStatMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        statMenu.SetActive(true);
    }
    public void CloseStatMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        statMenu.SetActive(false);
    }

    public void OpenSkillMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        skillMenu.SetActive(true);
    }

    public void CloseSkillMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        skillMenu.SetActive(false);

        //Load random next room
        ChangeSceneOnPlayer();
    }


    void ChangeSceneOnPlayer()
    {
        
        int _currentScene = SceneManager.GetActiveScene().buildIndex;
        for(int i = 0; i < buildIndices.Count; i++)
        {
            if (buildIndices[i] == _currentScene)
            {
                buildIndices.Remove(i);
                break;
            }
        }

         int _loadSceneInx = Random.Range(0, buildIndices.Count);
        Debug.Log(_loadSceneInx);
         SceneManager.LoadScene(_loadSceneInx);

        
    }
}
