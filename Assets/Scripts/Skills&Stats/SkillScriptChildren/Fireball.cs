using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : SkillBehavior
{
    private float fireballForce = 20;
    [SerializeField] private GameObject fireballPrefab;
    public GameObject fireballObj;

    public override void OnActivate()
    {
        skillManager.obtainedSkills[2] = data;
        skillManager.fireball = true;
    }

    public override void OnDeactivate()
    {
        skillManager.fireball = false;
        Destroy(this.gameObject);
    }


    public override void OnCast()
    {
        Vector3 _spawnPos = new Vector3(skillManager.gameObject.transform.position.x, skillManager.gameObject.transform.position.y + 3, skillManager.gameObject.transform.position.z);
        fireballObj = Instantiate(fireballPrefab, _spawnPos, fireballPrefab.transform.rotation);
        
        Rigidbody _rb = fireballObj.GetComponent<Rigidbody>();
        FireballAttack _fbAttack = fireballObj.GetComponent<FireballAttack>();
        _fbAttack.damage = skillManager.attack.spellDamage;
        _rb.AddForce(skillManager.gameObject.transform.forward * fireballForce, ForceMode.Impulse); 
        _rb.AddForce(skillManager.gameObject.transform.up * fireballForce, ForceMode.Impulse);
    }

    public override void OnUpgrade(int _rank)
    {
        //Increased damage
    }
}
