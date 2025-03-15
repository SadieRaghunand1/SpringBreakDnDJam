using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndStats : MonoBehaviour
{
    private Transform startPos;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void InitValuesOnLoad()
    {
        startPos = GameObject.FindWithTag("StartPos").transform;
        transform.position = startPos.position;
    }
    public void Die()
    {
        Debug.Log("Die");

        //Temp, rn this causes the issue of several players in scene so will need to spawn in player, not put in scene automatically
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }
}
