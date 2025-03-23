using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartRun : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void BeginRun()
    {
        SceneManager.LoadScene(1);
    }
}
