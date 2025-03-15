using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    private GameObject prefabToSpawn;

    [Header("Spawn time varables")]
    public float maxTime;
    public float minTime;
    private float timeS;

    private void Start()
    {
        StartCoroutine(TimeSpawns());
    }


    void SpawnEnemy()
    {
        Debug.Log("Spawn");
        prefabToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        Instantiate(prefabToSpawn, transform.position, prefabToSpawn.transform.rotation);
    }

    IEnumerator TimeSpawns()
    {
        float timeS = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeS);
        SpawnEnemy();
    }
}
