using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeEnemy : EnemyBase
{
    
    private bool _isreloading = false;
    public float projectileSpeed = 10;
    public GameObject projectile;
    private float gravity = Physics.gravity.y;
    
    
    
    // Start is called before the first frame update
    

    // Update is called once per frame

    private void LateUpdate()
    {
        Debug.Log("test");
        if (_isSpraying && !_isreloading)
        {
            StartCoroutine(Reload());
            Shoot();
        }
        base.Update();
    }

    
    
    IEnumerator Reload()
    {
        _isreloading = true;
       
        yield return new WaitForSeconds(3f);
     
        _isreloading = false;
        
    }


    private void Shoot()
    {
        
        
        float distance = player.transform.position.x - transform.position.x;
        Vector3 directionalVector = player.transform.position - transform.position;

        float v2 = projectileSpeed * projectileSpeed;
        float v4 = v2 * v2;

        float x = player.transform.position.x;
        float x2 = x * x;
        float y = player.transform.position.y;

        float theta = 0.5f*Mathf.Asin((gravity * distance) / (projectileSpeed * projectileSpeed));
        Vector3 releaseVector = (Quaternion.AngleAxis(theta * Mathf.Rad2Deg, -Vector3.forward) * directionalVector).normalized;
        Debug.DrawRay(transform.position, releaseVector*5, Color.cyan, 0.5f);

        Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        instantiatedProjectile.velocity = releaseVector * projectileSpeed;
        
    }


}
