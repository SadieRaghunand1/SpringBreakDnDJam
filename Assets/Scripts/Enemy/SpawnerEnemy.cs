using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    //Manages spawning enemies per area and detecting player entrance into an area

    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private EnemyChaseTrigger[] correspondingAreas;

    [SerializeField] private GameObject[] enemyPrefab;
    private GameObject prefabToSpawn;
    public GameObject[] areaPatrolPts;
    private GameObject enemy;
    public List<EnemyMovement> enemiesSpawned = new List<EnemyMovement>();
    public List<GameObject> enemyObjSpawned = new List<GameObject>();
   
    [Header("Spawn time variables")]
    public float maxTime;
    public float minTime;
    private float timeS;
    public int numToSpawn;
    public int counter;

    private void Start()
    {
        StartCoroutine(TimeSpawns());
    }

    /*private void OnTriggerEnter(Collider other)
    {
        ChangeEnemyStates(other);
    }*/
    void SpawnEnemy(Vector3 _spawnPos, EnemyChaseTrigger _area)
    {
        //Debug.Log("Spawn");
        prefabToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        enemy = Instantiate(prefabToSpawn, _spawnPos, prefabToSpawn.transform.rotation);
        EnemyMovement _enemyMove = enemy.GetComponent<EnemyMovement>();
        _enemyMove.patrolPts = _area.areaPatrolPts;
        enemiesSpawned.Add(_enemyMove);
        enemyObjSpawned.Add(enemy);
        _area.assignedEnemies.Add(_enemyMove);
        counter++;
        StartCoroutine(TimeSpawns());

        //If player has bear fur, and distance is in range, set enemy to attack immediatly
        if(FindAnyObjectByType<BearFur>() != null)
        {
            BearFur _bearFur = FindAnyObjectByType<BearFur>();
            PlayerController _player = FindAnyObjectByType<PlayerController>();
            if (Mathf.Abs(transform.position.x - _player.gameObject.transform.position.x) < _bearFur.radius && Mathf.Abs(transform.position.z - _player.gameObject.transform.position.z) < _bearFur.radius)
            {
                _enemyMove.enemyState = EnemyMovement.EnemyState.CHASE;
            }
        }
    }

    void IterateSpawnPoints()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnEnemy(spawnPoints[i].transform.position, correspondingAreas[i]);
        }
    }

    IEnumerator TimeSpawns()
    {
        timeS = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeS);
        if(counter < numToSpawn)
        {
            IterateSpawnPoints();
            //SpawnEnemy();
        }
        
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

    public void ClearLevelEnemies()
    {
        for(int i = 0; i < enemiesSpawned.Count; i++)
        {
            if (enemiesSpawned[i] != null)
            {
                Destroy(enemiesSpawned[i].gameObject);
            }
            
        }
    }
}
