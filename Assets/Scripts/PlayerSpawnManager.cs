using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
     // Start is called before the first frame update
    void Start()
    {
        InitValues();
    }

    void InitValues()
    {
        if(FindAnyObjectByType<PlayerController>() == null)
        {
            Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
        }
        else
        {
            FindAnyObjectByType<HealthAndStats>().InitValuesOnLoad();
        }
    }
}
