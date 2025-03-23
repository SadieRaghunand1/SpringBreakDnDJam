using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{

    public enum Area
    {
        FOREST,
        DUNGEON
            //Leaves room for expansion
    }

    //Manages spawning enemies per area and detecting player entrance into an area

    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private EnemyChaseTrigger[] correspondingAreas;

    [SerializeField] private GameObject[] enemyPrefab;
    private GameObject prefabToSpawn;
    public GameObject[] areaPatrolPts;
    private GameObject enemy;
    public List<EnemyMovement> enemiesSpawned = new List<EnemyMovement>();
    public List<GameObject> enemyObjSpawned = new List<GameObject>();

    [SerializeField] private ExitRoom exitRoom;
   
    [Header("Spawn time variables")]
    public float maxTime;
    public float minTime;
    private float timeS;
    public int numToSpawn;
    public int counter;

    HealthAndStats healthAndStats;

    [Header("Area indicators")]
    public Area area;

    private void Start()
    {
        StartCoroutine(TimeSpawns());
        SkillManager _skillManager = FindAnyObjectByType<SkillManager>();
        healthAndStats = FindAnyObjectByType<HealthAndStats>();

        //Set num to spawn, 4-6 is base
        numToSpawn = Random.Range(4, 7);
        //Check for bosses killed
        for(int i = 0; i < healthAndStats.bossDefeated.Length; i++)
        {
            if (healthAndStats.bossDefeated[i] == true)
            {
                numToSpawn += Random.Range(1, 3);
            }
        }

        //Factor in number of runs
        numToSpawn += (int)(healthAndStats.numOfRuns * Random.Range(1f, 1.5f));

        //Take into account rooms on this run
        numToSpawn += healthAndStats.scenesVisitedThisRun.Count;

        //Take into account if in prison
        if(area == Area.DUNGEON)
        {
            numToSpawn += Random.Range(4, 6);
        }


        exitRoom = FindAnyObjectByType<ExitRoom>();
        if(_skillManager.scythesEdge)
        {
            numToSpawn /= 2;
            
        }

        exitRoom.goalKill = numToSpawn;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        ChangeEnemyStates(other);
    }*/
    void SpawnEnemy(Vector3 _spawnPos, EnemyChaseTrigger _area)
    {
        //Debug.Log("Spawn");
        if(healthAndStats.numOfRuns > 1 || healthAndStats.levelCount > 2)
        {
            if(healthAndStats.levelCount < 4)
            {
                prefabToSpawn = enemyPrefab[Random.Range(0, healthAndStats.levelCount)];
            }
            else
            {
                prefabToSpawn = enemyPrefab[Random.Range(0, Random.Range(0, enemyPrefab.Length))];
            }
            
        }
        else
        {
            prefabToSpawn = enemyPrefab[0];
        }
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
            if(counter >= numToSpawn)
            {
                return;
            }
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
