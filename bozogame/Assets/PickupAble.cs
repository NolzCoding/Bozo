using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{
    public float healthGiven = 0.01f;
    private bool shouldSmooth;
    public SpriteRenderer renderer;
    private float des = 10;
    public float time = 0.2f;

    private void Start()
    {
        
        
    }

    private void Update()
    {
        if (shouldSmooth)
        {
            var newcol = Mathf.Lerp(renderer.color.b, des, time * Time.deltaTime);
            renderer.color = new Color(newcol, newcol, newcol);
            print(newcol);
            if (newcol < 11)
            {
                shouldSmooth = false;
            }
        }
    }


    public void onPlayerPickup()
    {
        Debug.Log("edede");
        Destroy(gameObject);
        shouldSmooth = true;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
    
}
