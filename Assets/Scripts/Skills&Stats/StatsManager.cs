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

    [SerializeField] private int bossBuildInx;
    [SerializeField] private int nextAreaIndx;
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
        Debug.Log("Clicked");
        GameObject _tempObj;
        //skillCanvas.displayedChoices[_skillInx].skillBehavior.skillManager = skillManager;
        if (skillCanvas.displayedChoices[_skillInx].skillType == ScriptObjSkills.SkillType.HAT)
        {
            _tempObj = Instantiate(skillCanvas.displayedChoices[_skillInx].skillBehavior.gameObject);
            _tempObj.transform.parent = player.gameObject.transform;

            if (skillManager.skillBehavior[0]!= null)
            {
                skillManager.skillBehavior[0].OnDeactivate();
                Destroy(skillManager.skillObj[0]);
            }
            
            skillManager.skillObj[0] = _tempObj;
            //skillManager.skillBehavior[0] = skillCanvas.displayedChoices[_skillInx].skillBehavior;
            skillManager.skillBehavior[0] = skillManager.skillObj[0].GetComponent<SkillBehavior>();
            skillManager.skillBehavior[0].OnActivate();
        }
        else if(skillCanvas.displayedChoices[_skillInx].skillType == ScriptObjSkills.SkillType.BUFF)
        {
            _tempObj = Instantiate(skillCanvas.displayedChoices[_skillInx].skillBehavior.gameObject);
            _tempObj.transform.parent = player.gameObject.transform;

            if (skillManager.skillBehavior[1] != null)
            {
                skillManager.skillBehavior[1].OnDeactivate();
                //Destroy(skillManager.skillObj[1]);
            }

            skillManager.skillObj[1] = _tempObj;
            //skillManager.skillBehavior[1] = skillCanvas.displayedChoices[_skillInx].skillBehavior;
            skillManager.skillBehavior[1] = skillManager.skillObj[1].GetComponent<SkillBehavior>();
            skillManager.skillBehavior[1].OnActivate();
        }
        else if(skillCanvas.displayedChoices[_skillInx].skillType == ScriptObjSkills.SkillType.SPELL)
        {
            _tempObj = Instantiate(skillCanvas.displayedChoices[_skillInx].skillBehavior.gameObject);
            _tempObj.transform.parent = player.gameObject.transform;

            if (skillManager.skillBehavior[2] != null)
            {
                skillManager.skillBehavior[2].OnDeactivate();
               // Destroy(skillManager.skillObj[2]);
            }

            skillManager.skillObj[2] = _tempObj;
            //skillManager.skillBehavior[2] = skillCanvas.displayedChoices[_skillInx].skillBehavior;
            skillManager.skillBehavior[2] = skillManager.skillObj[2].GetComponent<SkillBehavior>();
            skillManager.skillBehavior[2].OnActivate();
        }
        else if(skillCanvas.displayedChoices[_skillInx].skillType == ScriptObjSkills.SkillType.SKILL)
        {
            _tempObj = Instantiate(skillCanvas.displayedChoices[_skillInx].skillBehavior.gameObject);
            _tempObj.transform.parent = player.gameObject.transform;


            if (skillManager.skillBehavior[3] != null)
            {
                skillManager.skillBehavior[3].OnDeactivate();
               //Destroy(skillManager.skillObj[3]);
            }

            skillManager.skillObj[3] = _tempObj;
            //skillManager.skillBehavior[3] = skillCanvas.displayedChoices[_skillInx].skillBehavior;
            skillManager.skillBehavior[3] = skillManager.skillObj[3].GetComponent<SkillBehavior>();
            skillManager.skillBehavior[3].OnActivate();
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
        Debug.Log("Stat menu closed");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        statMenu.SetActive(false);

        //Load next area
        ChangeSceneToNextArea();
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

    /// <summary>
    /// Change scene for normal enemies in an area, NOT BOSS
    /// </summary>
    void ChangeSceneOnPlayer()
    {
        int _loadSceneInx;
        //Debug.Log("Enter change scene");
        int _currentScene = SceneManager.GetActiveScene().buildIndex;
        for(int i = 0; i < buildIndices.Count; i++)
        {
            if (buildIndices[i] == _currentScene)
            {
                buildIndices.RemoveAt(i);
                break;
            }
        }

        if(buildIndices.Count <= 0)
        {
            _loadSceneInx = bossBuildInx;
        }
        else
        {
            _loadSceneInx = buildIndices[Random.Range(0, buildIndices.Count)];
        }
           

        
        while(_loadSceneInx == 0)
        {
            Random.Range(0, buildIndices.Count);
        }
        Debug.Log(_loadSceneInx);
         SceneManager.LoadScene(_loadSceneInx);

        
    }

    /// <summary>
    /// After kill boss, next area indx should be for the first scene of the next area, if end game then go to end screen
    /// </summary>
    void ChangeSceneToNextArea()
    {
        SceneManager.LoadScene(nextAreaIndx);
    }
}
