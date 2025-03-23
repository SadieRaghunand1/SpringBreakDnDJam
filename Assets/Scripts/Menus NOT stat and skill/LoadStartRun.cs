using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadStartRun : MonoBehaviour
{
    HealthAndStats healthAndStats;

    [SerializeField] private TextMeshProUGUI strTxt;
    [SerializeField]private TextMeshProUGUI dextTxt;
    [SerializeField] private TextMeshProUGUI conTxt;
    [SerializeField] private TextMeshProUGUI intTxt;
    [SerializeField] private TextMeshProUGUI wisTxt;
    [SerializeField] private TextMeshProUGUI charTxt;

    [SerializeField] private TextMeshProUGUI totalRuns;
    [SerializeField] private TextMeshProUGUI longestRun;

    private void Start()
    {
        healthAndStats = FindAnyObjectByType<HealthAndStats>();
        strTxt.text = "Strength: " + healthAndStats.strength.ToString();
        dextTxt.text = "Dexterity: " + healthAndStats.dexterity.ToString();
        conTxt.text = "Constitution: " + healthAndStats.constitution.ToString();
        intTxt.text = "Intelligence: " + healthAndStats.intelligence.ToString();
        wisTxt.text = "Wisdom: " + healthAndStats.wisdom.ToString();
        charTxt.text = "Charisma: " + healthAndStats.charisma.ToString();

        totalRuns.text = "Total runs: " + healthAndStats.numOfRuns.ToString();
        longestRun.text = "Longest run : " + healthAndStats.longestRun.ToString() + " rooms";

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Cursor.lockState = CursorLockMode.None;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            BeginRun();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Quit to menu
            Destroy(healthAndStats.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void BeginRun()
    {
        FindAnyObjectByType<HealthAndStats>().numOfRuns++;
        SceneManager.LoadScene(2);
    }
}
