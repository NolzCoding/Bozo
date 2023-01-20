using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    private float health = 200;
    private Rigidbody2D rb;
    
    private bool _dash = false;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private float downForce = 7;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    const float k_GroundedRadius = .2f;
    private int spaces = 2;
    private bool m_Grounded;
    private float dir;
    private float cooldowntime = 5;
    private float cooldown = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(5 * x, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (m_Grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                spaces = 1;
            }
            else if (spaces == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                spaces = 0;
            }
            else if (spaces == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -downForce);
                spaces = -1;
            }
        }

        if (Time.time > cooldown)
        {
            if (Input.GetButton("Fire3"))
            {

                if (!_dash)
                {
                    StartCoroutine(StartDash());
                    cooldown = Time.time + cooldowntime;
                }
            }
        }
        
        if (x != 0)
        {
            dir = x;
        }
        
        
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

        CheckGround();

        if (_dash)
        {
            transform.Translate(40 * Time.deltaTime * dir, 0, 0);

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
    
    public LayerMask groundLayer;

    

    private void CheckGround()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {

                if (gameObject.CompareTag("Water"))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
                
                Debug.Log("is Grounded");
                
                m_Grounded = true;
                if (!wasGrounded)
                    spaces = 2;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Pickup"))
        {
            var pickupScript = col.gameObject.GetComponent<PickupAble>();
            takeDamage(pickupScript.healthGiven);
            pickupScript.onPlayerPickup();
        }
    }

    
}
