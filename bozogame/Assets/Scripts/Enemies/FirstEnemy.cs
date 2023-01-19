using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class FirstEnemy : EnemyBase
{

    public ParticleSystem system;
    private List<ParticleCollisionEvent> eventList = new List<ParticleCollisionEvent>();
    private bool _isreloading = false;
    private float overHead = 0.0f;
    private float lastreload = 0.0f;

    public override void StartShoot()
    {
        lastreload -= overHead;
        system.Play();
        base.StartShoot();
    }
    
    public override void StopShoot()
    {
        overHead = Time.time - lastreload;
        system.Stop();
        base.StopShoot();
    }

    private void LateUpdate()
    {

        if (_isSpraying && !_isreloading)
        {
            if (Time.time - lastreload > 3)
            {
                
                StartCoroutine(Reload());
                
            }
        }

        var angle = ProjectileCalculate();

        Vector3 diff = system.transform.position - player.transform.position;
        diff.Normalize();
 
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float offset = 0;
        
        if (Mathf.Abs(rot_z) < 180)
        {
            offset = -20;
        }
        else
        {
            offset = 20;
        }
        
        system.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90 + +offset);
        //system.transform.rotation = Quaternion.Euler(0f, 0f, angle*360 -90 );
    }

    public override void Start()
    {
        lastreload = Time.time;
        base.Start();

    }


    IEnumerator Reload()
    {
        _isreloading = true;
        system.Stop();
        yield return new WaitForSeconds(3f);
        lastreload = Time.time;

        if (_isSpraying)
        {
            system.Play();
        }
        
        _isreloading = false;
        
    } 

    private float ProjectileCalculate()
    {
        
        Vector3 diff = system.transform.position - player.transform.position;
        diff.Normalize();
        
        var v = 3f;
        var x = diff.x;
        var y = diff.y;
        var g = 0.98f;
        
        var angle = Mathf.Atan((Mathf.Pow(v,2) - Mathf.Sqrt(Mathf.Pow(v,4) - g*((g*Mathf.Pow(x,2)) + (2f*y*Mathf.Pow(v,2) ) )))/g*x);

        /*    
        A = angle
        v = initial velocity (m/s)
        g = gravity (9.81)
        x = x distance (m) - This would be 100 in your case
        y = y vertical distance (m) - This would be 0 in your case as the target is at the same height
        */
        
        print(angle);
        return Mathf.Abs( angle);
        
    }
    
}
