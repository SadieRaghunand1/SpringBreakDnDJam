using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    //Manages pass between of player being spawned in bc buttons in scene that need parameters

    private HealthAndStats player;
    [SerializeField] private GameObject statMenu;
    [SerializeField] private GameObject skillMenu;

    private void Start()
    {
        player = FindAnyObjectByType<HealthAndStats>();
    }

    /// <summary>
    /// Manages pass between of player being spawned in bc buttons in scene that need parameters
    /// </summary>
    /// <param name="_statID"></param>
    public void HoldIncreaseStats(int _statID)
    {
        player.IncreaseStat(_statID);
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
