using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatIncrease : MonoBehaviour
{
    //Change of plans: Use this for skills, not stats



    [SerializeField] private Canvas statIncCanvas;
    private int statIncAmount;
    public List<ScriptObjSkills> statsToChoose;
    public ScriptObjSkills empty;
    public ScriptObjSkills[] displayedChoices;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI[] title;
    [SerializeField] private TextMeshProUGUI[] desc;

    private void Start()
    {
        displayedChoices = new ScriptObjSkills[3];
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
                _chosenIndx[i] = Random.Range(0, statsToChoose.Count);
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
        }
    }
}
