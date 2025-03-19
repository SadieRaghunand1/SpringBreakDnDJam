using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndStats : MonoBehaviour
{
    public int health = 1;
    private Transform startPos;
    private int incAmount = 2;
    private StatsManager statsManager;
    [SerializeField] private Attack attack;

    [Header("Loading")]
    public List<int> scenesVisitedThisRun;
    private int lobbyBuildIndx = 0;
    

    [Header("Stats")]
    public int charisma; //1
    public int dexterity; //2
    public int intelligence; //3
    public int strength; //4
    public int wisdom; //5
    public int constitution; //Always at 1, cannot change


    [Header("Skills")]
    [SerializeField] private SkillManager skillManager;
    public int reviveRate;

    [Header("BossIndicators")]
    public bool[] bossDefeated;


    private void Awake()
    {
       // Debug.Log(this.gameObject.name);
        scenesVisitedThisRun = new List<int>();
        
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        scenesVisitedThisRun = new List<int>();
        statsManager = FindAnyObjectByType<StatsManager>();
        //Temp for debugging menus
        Cursor.lockState = CursorLockMode.None;
        //scenesVisitedThisRun = new List<int>();

    }

    public void InitValuesOnLoad()
    {
        startPos = GameObject.FindWithTag("StartPos").transform;
        transform.position = startPos.position;
        scenesVisitedThisRun.Add(SceneManager.GetActiveScene().buildIndex);
        skillManager.OnStartRemove();
        for(int i = 0; i < scenesVisitedThisRun.Count; i++)
        {
            //Debug.Log("Scenes: " + scenesVisitedThisRun[i]);
        }
    }

    public void IncreaseStat(int _statID)
    {
        switch(_statID)
        {
            case 1:
                charisma += incAmount;
                break;
            case 2:
                dexterity += incAmount;
                break;
            case 3:
                intelligence += incAmount;
                break;
            case 4:
                strength += incAmount;
                break;
            case 5:
                wisdom += incAmount;
                break;
        }

        statsManager.CloseStatMenu();
           
    }
    public void Die()
    {
       // Debug.Log("Die");

        
        if(skillManager.barbarianHelmet && Revive())
        {
            return;
        }

        health--;
        if(health <= 0)
        {
            skillManager.OnDeath();
            //Temp, rn this causes the issue of several players in scene so will need to spawn in player, not put in scene automatically
            SceneManager.LoadScene(lobbyBuildIndx);
            ResetEverythingOnDeath();
        }

        
    }


    public void CheckBossDeath(int _bossID) //Boss id refers to the index that will be checked
    {
        if (!bossDefeated[_bossID])
        {
            //First trigger menu
            statsManager.OpenStatMenu();
            //Then trigger bool check
            bossDefeated[_bossID] = true;
        }


    }

    void ResetEverythingOnDeath()
    {
        health = 1;
        attack.killed = 0;
        attack.StopAllCoroutines();
    }

    bool Revive()
    {
        int _score = Random.Range(0, 101);
        if(_score <= reviveRate)
        {
            health = 1;
            return true; //Survive
        }
        else
        {
            return false; //Die
        }
    }
}
