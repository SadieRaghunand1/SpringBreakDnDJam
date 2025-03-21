using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatIncrease : MonoBehaviour
{
    //Change of plans: Use this for skills, not stats

    //0 - 3 - Strength
    //4 - 7 - Dexterity
    //8 - 11 - Intelligence
    //12 - 15 - Wisdom
    //16 - 19 - Charisma


    [SerializeField] private Canvas statIncCanvas;
    private int statIncAmount;
    public List<ScriptObjSkills> statsToChoose; 
    public ScriptObjSkills empty;
    public ScriptObjSkills[] displayedChoices;
    private HealthAndStats healthAndStats;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI[] title;
    [SerializeField] private TextMeshProUGUI[] desc;
    [SerializeField] private TextMeshProUGUI[] stat;

    private void Start()
    {
        displayedChoices = new ScriptObjSkills[3];
        healthAndStats = FindAnyObjectByType<HealthAndStats>();
        //Debug
        //RandomizeStatInc();
    }

    public void RandomizeStatInc()
    {
        int[] _chosenIndx = new int[5];
        ScriptObjSkills _statRolled;
        //Clear choices if they are filled already
        for (int i = 0; i < displayedChoices.Length; i++)
        {
            displayedChoices[i] = null;
        }

        //Choose new choices
        for(int i = 0; i < displayedChoices.Length; i++)
        {
            if(statsToChoose.Count > 1)
            {
                switch(ChooseStatToChooseSkill())
                {
                    case 0:
                        _chosenIndx[i] = Random.Range(16, 20);
                        break;
                    case 1:
                        _chosenIndx[i] = Random.Range(4, 8);
                        break;
                    case 2:
                        _chosenIndx[i] = Random.Range(8, 12);
                        break;
                    case 3:
                        _chosenIndx[i] = Random.Range(0, 4);
                        break;
                    case 4:
                        _chosenIndx[i] = Random.Range(12, 16);
                        break;
                }
                Debug.Log("index = " + _chosenIndx[i]);
                //Check if there are no more unique skills to pull from, fill in empty
                if (statsToChoose[_chosenIndx[i]] == null)
                {
                    Debug.Log("Empty");
                    _statRolled = statsToChoose[statsToChoose.Count];
                    displayedChoices[i] = _statRolled;
                   // PopulateStatOptions();

                }
                else
                {
                    _statRolled = statsToChoose[_chosenIndx[i]];


                    //statsToChoose[_chosenIndx[i]] = null;
                    statsToChoose.RemoveAt(_chosenIndx[i]);
                    displayedChoices[i] = _statRolled;
                }
            }
            else
            {
                //_statRolled = statsToChoose[statsToChoose.Count - 1];
                displayedChoices[i] = empty;
                //PopulateStatOptions();
                
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
            stat[i].text = displayedChoices[i].statAssociated.ToString();
        }
    }

    //Selection based off stats
    int ChooseStatToChooseSkill()
    {
        int _probability = Random.Range(0, 101);
        int _statID;
        //0 - 36, 37 - 64, 65 - 79, 80 - 92, 93 - 100

        if(_probability >= 0 && _probability <= 36)
        {
            _statID = healthAndStats.statArray[0];
        }
        else if(_probability > 36 && _probability <= 64)
        {
            _statID = healthAndStats.statArray[1];
        }
        else if(_probability > 64 && _probability <= 79)
        {
            _statID = healthAndStats.statArray[2];
        }
        else if(_probability > 79 && _probability <= 92)
        {
            _statID = healthAndStats.statArray[3];
        }
        else
        {
            _statID = healthAndStats.statArray[4];
        }

        return _statID;
    }

}
