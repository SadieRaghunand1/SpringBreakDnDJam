using System.Collections;
using System.Collections.Generic;
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
    public int levelCount;
    private int lobbyBuildIndx = 0;


    [Header("Stats")]
    public int charisma; //0
    public int dexterity; //1
    public int intelligence; //2
    public int strength; //3
    public int wisdom; //4
    public int constitution; //Always at 1, cannot change
    public int[] statArray; //index 0 is highest, last is lowest.  Contains the id for each stat as listed above

    [Header("Skills")]
    [SerializeField] private SkillManager skillManager;
    public int reviveRate = 5;
    public int dodgeRate = 10;

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
        
        //Temp for debugging menus
        Cursor.lockState = CursorLockMode.None;
        InitStats();
        //scenesVisitedThisRun = new List<int>();

    }

    public void InitValuesOnLoad()
    {
        levelCount++;
        startPos = GameObject.FindWithTag("StartPos").transform;
        transform.position = startPos.position;
        scenesVisitedThisRun.Add(SceneManager.GetActiveScene().buildIndex);
        skillManager.OnStartRemove();
        statsManager = FindAnyObjectByType<StatsManager>();
        for (int i = 0; i < scenesVisitedThisRun.Count; i++)
        {
            //Debug.Log("Scenes: " + scenesVisitedThisRun[i]);
        }
    }

    void InitStats()
    {
        //Time crunching there is likely a way to do better than this but for now; if time later fix + reorganize

        List<int> _standardArray = new List<int>{ 15, 14, 13, 12, 10 }; //Get rid of 8, bc lowest will be 1 - con
        int _b;
       
        //Charisma
        _b = Random.Range(0, _standardArray.Count);
        charisma = _standardArray[_b];
        _standardArray.RemoveAt(_b);
        switch(charisma)
        {
            case 15:
                statArray[0] = 0;
                break;
            case 14:
                statArray[1] = 0;
                break;
            case 13:
                statArray[2] = 0;
                break;
            case 12:
                statArray[3] = 0;
                break;
            case 10:
                statArray[4] = 0;
                break;

        }

        //Dexterity
        _b = Random.Range(0, _standardArray.Count);
        dexterity = _standardArray[_b];
        _standardArray.RemoveAt(_b);
        switch (dexterity)
        {
            case 15:
                statArray[0] = 1;
                break;
            case 14:
                statArray[1] = 1;
                break;
            case 13:
                statArray[2] = 1;
                break;
            case 12:
                statArray[3] = 1;
                break;
            case 10:
                statArray[4] = 1;
                break;

        }

        //Intelligence
        _b = Random.Range(0, _standardArray.Count);
        intelligence = _standardArray[_b];
        _standardArray.RemoveAt(_b);
        switch (intelligence)
        {
            case 15:
                statArray[0] = 2;
                break;
            case 14:
                statArray[1] = 2;
                break;
            case 13:
                statArray[2] = 2;
                break;
            case 12:
                statArray[3] = 2;
                break;
            case 10:
                statArray[4] = 2;
                break;

        }

        //Strength
        _b = Random.Range(0, _standardArray.Count);
        strength = _standardArray[_b];
        _standardArray.RemoveAt(_b);
        switch (strength)
        {
            case 15:
                statArray[0] = 3;
                break;
            case 14:
                statArray[1] = 3;
                break;
            case 13:
                statArray[2] = 3;
                break;
            case 12:
                statArray[3] = 3;
                break;
            case 10:
                statArray[4] = 3;
                break;

        }

        //Wisdom
        _b = Random.Range(0, _standardArray.Count);
        wisdom = _standardArray[_b];
        _standardArray.RemoveAt(_b);
        switch (wisdom)
        {
            case 15:
                statArray[0] = 4;
                break;
            case 14:
                statArray[1] = 4;
                break;
            case 13:
                statArray[2] = 4;
                break;
            case 12:
                statArray[3] = 4;
                break;
            case 10:
                statArray[4] = 4;
                break;

        }


    }

    public void IncreaseStat(int _statID)
    {
        switch(_statID)
        {
            case 0:
                charisma += incAmount;
                break;
            case 1:
                dexterity += incAmount;
                break;
            case 2:
                intelligence += incAmount;
                break;
            case 3:
                strength += incAmount;
                break;
            case 4:
                wisdom += incAmount;
                break;
        }

        //Need to take into account if stats surpass others, their placement in statArray should change
        for (int i = 0; i < statArray.Length; i++)
        {
            if (statArray[i] == _statID && i != 0)
            {
                int _temp = statArray[i - 1];
                statArray[i - 1] = _statID;
                statArray[i] = _temp;
            }
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

        if(skillManager.knightHelmet && Dodge())
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
        Debug.Log("Boss dead at all");
        if (!bossDefeated[_bossID])
        {
            Debug.Log("Boss down");
            //First trigger menu
            statsManager.OpenStatMenu();
            //Then trigger bool check
            bossDefeated[_bossID] = true;
        }
        else
        {
            /*if (_bossID == 0) //First boss
            {
                SceneManager.LoadScene(8);
            }*/
        }
        FindAnyObjectByType<ExitRoom>().bossDead = true;


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
            Debug.Log("Revive");
            return true; //Survive
        }
        else
        {
            return false; //Die
        }
    }

    //Note, dodge and revive are very similar functionality wise, branding in game will be beeded to deistinguish them
    bool Dodge()
    {
        int _score = Random.Range(0, 101);
        if (_score <= dodgeRate)
        {
            health = 1;
            Debug.Log("Dodge");
            return true;
        }
        else
        {
            return false;
        }
    }
}
