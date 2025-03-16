using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
     // Start is called before the first frame update
    void Awake()
    {
        InitValues();
    }

    void InitValues()
    {
        if(FindAnyObjectByType<PlayerController>() == null)
        {
            GameObject _player = Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
            _player.GetComponent<HealthAndStats>().InitValuesOnLoad();
        }
        else
        {
            FindAnyObjectByType<HealthAndStats>().InitValuesOnLoad();
        }
    }
}
