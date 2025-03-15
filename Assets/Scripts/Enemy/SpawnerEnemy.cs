using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    //Manages spawning enemies per area and detecting player entrance into an area

    [SerializeField] private GameObject[] enemyPrefab;
    private GameObject prefabToSpawn;
    public GameObject[] areaPatrolPts;
    private GameObject enemy;
    private List<EnemyMovement> enemiesSpawned = new List<EnemyMovement>();

    [Header("Spawn time varables")]
    public float maxTime;
    public float minTime;
    private float timeS;

    private void Start()
    {
        StartCoroutine(TimeSpawns());
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeEnemyStates(other);
    }
    void SpawnEnemy()
    {
        Debug.Log("Spawn");
        prefabToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        enemy = Instantiate(prefabToSpawn, transform.position, prefabToSpawn.transform.rotation);
        EnemyMovement _enemyMove = enemy.GetComponent<EnemyMovement>();
        _enemyMove.patrolPts = areaPatrolPts;
        enemiesSpawned.Add(_enemyMove);
    }

    IEnumerator TimeSpawns()
    {
        timeS = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeS);
        SpawnEnemy();
    }

    void ChangeEnemyStates(Collider _other)
    {
        if(_other.gameObject.layer == 8)
        {
            for(int i = 0; i < enemiesSpawned.Count; i++)
            {
                enemiesSpawned[i].enemyState = EnemyMovement.EnemyState.CHASE;
            }
        }
    }
}
