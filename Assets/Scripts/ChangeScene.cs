using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int[] buildIndices;

    private void OnCollisionEnter(Collision collision)
    {
        ChangeSceneOnPlayer(collision);
    }

    void ChangeSceneOnPlayer(Collision _collision)
    {
        if(_collision.gameObject.layer == 8)
        {
            int _loadSceneInx = Random.Range(0, buildIndices.Length);
            SceneManager.LoadScene(_loadSceneInx);
           
        }
    }
}
