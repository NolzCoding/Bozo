using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Granade : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject particle;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   

    private void OnCollisionEnter2D(Collision2D col)
    { 
        var player = GameObject.FindWithTag("Player");
        
        var dis = Vector2.Distance(player.transform.position, transform.position);
        
        
        if (dis < 5)
        {
            var degree = Vector2.Angle(transform.position, player.transform.position);
            var direct = (Vector2)(Quaternion.Euler(0,0,degree) * Vector2.right);
            player.GetComponent<Rigidbody2D>().AddForce(direct);
        }
        
        
        Destroy(Instantiate(particle, transform.position, quaternion.identity), 5f);
        Destroy(gameObject);

    }
}
