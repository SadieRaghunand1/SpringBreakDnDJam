using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Menu should be one of last indeces in build, lobby should be index 0


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            LoadLobby();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
