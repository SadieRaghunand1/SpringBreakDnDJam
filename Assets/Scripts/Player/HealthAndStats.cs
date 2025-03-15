using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndStats : MonoBehaviour
{
    private Transform startPos;
    private int incAmount = 2;
    private StatsManager statsManager;
    [Header("Stats")]
    public int charisma; //1
    public int dexterity; //2
    public int intelligence; //3
    public int strength; //4
    public int wisdom; //5
    public int constitution; //Always at 1, cannot change

    [Header("BossIndicators")]
    public bool boss1;
    public int boss2;
    public int boss3;
    public int boss4;
    public int boss5;
        


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        statsManager = FindAnyObjectByType<StatsManager>();
        //Temp for debugging menus
        Cursor.lockState = CursorLockMode.None;
    }

    public void InitValuesOnLoad()
    {
        startPos = GameObject.FindWithTag("StartPos").transform;
        transform.position = startPos.position;
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
           
    }
    public void Die()
    {
        Debug.Log("Die");

        //Temp, rn this causes the issue of several players in scene so will need to spawn in player, not put in scene automatically
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }


    public void CheckBossDeath(int bossID)
    {
        //First trigger menu
        statsManager.OpenStatMenu();
        //Then trigger bool check
    }
}
