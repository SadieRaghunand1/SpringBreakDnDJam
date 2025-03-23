using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinRoom : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            HealthAndStats healthAndStats = FindAnyObjectByType<HealthAndStats>();
            for(int i = 0; i < healthAndStats.bossDefeated.Length; i++)
            {
                healthAndStats.bossDefeated[i] = false;
            }

            SceneManager.LoadScene(1);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            HealthAndStats healthAndStats = FindAnyObjectByType<HealthAndStats>();
            Destroy(healthAndStats.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
