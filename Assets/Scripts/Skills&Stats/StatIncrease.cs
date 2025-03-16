using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class StatIncrease : MonoBehaviour
{
    //Change of plans: Use this for skills, not stats



    [SerializeField] private Canvas statIncCanvas;
    private int statIncAmount;
    [SerializeField] private ScriptObjSkills[] statsToChoose;
    private ScriptObjSkills[] displayedChoices;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI[] title;
    [SerializeField] private TextMeshProUGUI[] desc;
    [SerializeField] private TextMeshProUGUI[] inc;

    private void Start()
    {
        displayedChoices = new ScriptObjSkills[3];
        //Debug
        RandomizeStatInc();
    }

    void RandomizeStatInc()
    {
        int[] _chosenIndx = new int[5];
        //Clear choices if they are filled already
        for(int i = 0; i < displayedChoices.Length; i++)
        {
            displayedChoices[i] = null;
        }

        //Choose new choices
        for(int i = 0; i < displayedChoices.Length; i++)
        {
            _chosenIndx[i] = Random.Range(0, statsToChoose.Length);
           
            ScriptObjSkills _statRolled = statsToChoose[_chosenIndx[i]];
            displayedChoices[i] = _statRolled;
            //Check that choices are new, not already rolled
            for(int j = 0; j < i; j++)
            {
                if (displayedChoices[j] == _statRolled)
                {
                    displayedChoices[i] = null;
                    i--;
                    break;
                }
            }
        }

        PopulateStatOptions();
    }


    void PopulateStatOptions()
    {
        for(int i = 0; i < displayedChoices.Length; i++)
        {
            title[i].text = displayedChoices[i].statName;
            desc[i].text = displayedChoices[i].statDesc;
        }
    }
}
