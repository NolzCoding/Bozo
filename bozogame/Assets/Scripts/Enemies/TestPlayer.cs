using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    private float health = 200;
    private Rigidbody2D rb;
    private bool _grounded = false;
    private bool _dash = false;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(5 * x, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && _grounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, 6);
            _grounded = false;
        }

        if (Input.GetButton("Fire3"))
        {
            
            if (!_dash)
            {
                StartCoroutine(StartDash());
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _grounded = true;
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        transform.localScale = transform.localScale - new Vector3(0.0025f, 0.0025f, 0f);
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {

        if (_dash)
        {
            
            transform.Translate(15 * Time.deltaTime,0,0);
        }
        
    }

    private void OnParticleCollision(GameObject other)
    {
        takeDamage(1f);
    }
    
    IEnumerator StartDash()
    {
        _dash = true;
        yield return new WaitForSeconds(0.1f);
        _dash = false;
    }
    
}
