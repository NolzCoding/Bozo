using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : MonoBehaviour
{

    private bool shouldGoDown = false;
    private Vector3 des;

    void Start()
    {
        des = new Vector3(0, -5, 0) + gameObject.transform.position;
    }

    void FixedUpdate()
    {
        
        if (shouldGoDown)
        {
            transform.position = Vector3.Lerp(transform.position, des, 0.1f * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            /*transform.Translate(2 * Time.deltaTime, -0.05f, 0);

            Destroy(gameObject, 2);*/

            shouldGoDown = true;
            Destroy(gameObject, 3);

        }
    } 
}
