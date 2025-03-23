using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 8)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void Update()
    {
        transform.Translate(transform.forward * 10 * Time.deltaTime);
    }
}
