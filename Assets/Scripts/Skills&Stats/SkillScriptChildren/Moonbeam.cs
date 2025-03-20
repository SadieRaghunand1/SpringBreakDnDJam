using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonbeam : SkillBehavior
{
    private float beamDuration = 1f;

    public override void OnActivate()
    {
        skillManager.obtainedSkills[2] = data;
        skillManager.moonbeam = true;
    }

    public override void OnDeactivate()
    {
        skillManager.moonbeam = false;
        Destroy(this.gameObject);
    }


    public override void OnCast()
    {
        //Similar functionlity to steady hands, but choose random enemy.  
        spawner = FindAnyObjectByType<SpawnerEnemy>();
        int _randEnemy = Random.Range(0, spawner.enemyObjSpawned.Count);

        EnemyHealth _lockedEnemy = spawner.enemyObjSpawned[_randEnemy].GetComponent<EnemyHealth>();
        Debug.Log(_lockedEnemy.gameObject.name + "moonbeamed");
        _lockedEnemy.LoseHealth(skillManager.attack.spellDamage);

        //Visuals
        skillManager.moon.enabled = true;
        skillManager.moon.SetPosition(0, skillManager.moon.gameObject.transform.position);
        skillManager.moon.SetPosition(1, _lockedEnemy.transform.position);
        StartCoroutine(HideMoonbeam());
    }

    public override void OnUpgrade(int _rank)
    {
        //Inc number of enemies attacked and spell damage
    }

    private IEnumerator HideMoonbeam()
    {
        yield return new WaitForSeconds(beamDuration);
        skillManager.moon.enabled = false;
    }
}
