using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : MonoBehaviour
{

    

    void Start()
    {
     
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            transform.Translate(15 * Time.deltaTime, 1, 1);

            Destroy(gameObject, 5);
        }
    } 
}
