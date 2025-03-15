using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatIncrease : MonoBehaviour
{
    [SerializeField] private Canvas statIncCanvas;
    private int statIncAmount;
    [SerializeField] private ScriptObjSTATS[] statsToChoose;
    private ScriptObjSTATS[] displayedChoices;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI[] title;
    [SerializeField] private TextMeshProUGUI[] desc;
    [SerializeField] private TextMeshProUGUI[] inc;

    private void Start()
    {
        displayedChoices = new ScriptObjSTATS[3];
        //Debug
        RandomizeStatInc();
    }

    void RandomizeStatInc()
    {
        //Clear choices if they are filled already
        for(int i = 0; i < displayedChoices.Length; i++)
        {
            displayedChoices[i] = null;
        }

        //Choose new choices
        for(int i = 0; i < displayedChoices.Length; i++)
        {
            ScriptObjSTATS _statRolled = statsToChoose[Random.Range(0, statsToChoose.Length)];
            displayedChoices[i] = _statRolled;
            //Check that choices are new, not already rolled
           /* for(int j = 0; j < displayedChoices.Length; i++)
            {
                if (displayedChoices[j] == _statRolled)
                {
                    displayedChoices[i] = null;
                    i--;
                    break;
                }
            }*/
        }

        //Debug
        for(int i = 0; i < displayedChoices.Length; i++)
        {
            Debug.Log(displayedChoices[i].statName);
        }
    }
}
