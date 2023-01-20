using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    // Start is called before the first frame update

    private TestPlayer _testPlayer;
    private Rigidbody2D playerrigid;
    
    void Start()
    {
        playerrigid = transform.parent.GetComponent<Rigidbody2D>();
        _testPlayer = gameObject.transform.parent.gameObject.GetComponent<TestPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log(playerrigid.velocity.y + " y vel");
            if (playerrigid.velocity.y <= -7 && _testPlayer.haspower)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
