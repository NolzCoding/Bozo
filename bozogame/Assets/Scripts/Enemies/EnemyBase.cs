using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject particle;
    [DoNotSerializeAttribute]
    public GameObject player;
    
    public float lookDistance = 15f;
    public float sprayDistance = 3f;
    public float stopDistance = 1f;
    public bool _isSpraying;
    
    
    public virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        handleMovement();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //collision.gameObject.GetComponent<news>().takeDamage(10);
            
            var direction = (collision.gameObject.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);

            var particleClone = Instantiate(particle, collision.contacts[0].point, quaternion.identity);
            
            Destroy(particleClone, 4f);

        }
    }*/

    private void handleMovement()
    {
        
        var distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        
        if ( distanceToPlayer< lookDistance)
        {
            if (distanceToPlayer > stopDistance)
            {
                
                if (player.transform.position.x - transform.position.x > 0)
                {
                    transform.Translate(new Vector3(1 * Time.deltaTime,0,0));
                }
                else
                {
                    transform.Translate(new Vector3(-1 * Time.deltaTime,0,0));
                }
                
            }
            
            
            
            if (distanceToPlayer < sprayDistance)
            {
                if (!_isSpraying)
                {
                    _isSpraying = true;
                    StartShoot();
                    Debug.Log("Start");
                }
            }
            else
            {
                if (_isSpraying)
                {
                    _isSpraying = false;
                    StopShoot();
                    Debug.Log("Stop");
                }
            }

        }
        
    }


    public virtual void StartShoot()
    {
        
        
    }
    
    public virtual void StopShoot()
    {
        
        
    }

    
}