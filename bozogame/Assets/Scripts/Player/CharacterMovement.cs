using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    bool Jump = false;
    public Rigidbody2D m_Rigidbody2D;
    private int up = 3; 
    public int dashdistance = 10;
    private bool _dash = false;
    private float dir = 1f;
    private float cooldowntime = 5;
    private float cooldown = 0;
    private bool watercontact = false;
    private int upwardsf = 0;
    public float maxhp = 100;
    public float waterdamage = 15;
    

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float movex = Input.GetAxisRaw("Horizontal");
        m_Rigidbody2D.velocity = new Vector2(20 * movex, m_Rigidbody2D.velocity.y);

       if (Input.GetKeyDown("space") && IsGrounded())
        {

            
            m_Rigidbody2D.velocity = new Vector2(1 * movex, 20);
            up = 1;
        }
       
      /* if (Input.GetKeyDown("space") && Jump == true)
        {
            Debug.Log("go");
            m_Rigidbody2D.velocity = new Vector2(1 * movex, 20);
            up = 1;

        }
       */
        else if (Input.GetKeyDown("space") && up == 1)
        {
            m_Rigidbody2D.velocity = new Vector2(1 * movex, 20);
            up = 2;


        }
        else if (Input.GetKeyDown("space") && up == 2)
        {
            Debug.Log("hi");
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -40);
            up = 3;
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

        if (movex != 0)
        {
            dir = movex;
        }

        if (maxhp <= 0)
        {
            gameObject.SetActive(false);
        }


    }

    


    public void FixedUpdate()
    {

        if (_dash)
        {
            transform.Translate(40 * Time.deltaTime * dir, 0, 0);

        }
    }

    IEnumerator StartDash()
    {
        _dash = true;
        yield return new WaitForSeconds(0.1f);
        _dash = false;
    }



    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {

            Jump = true;
            Debug.Log("Jump");
        }

        if (col.gameObject.tag == "Water")
        {
            up = 1;
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 15);
            Jump = true;
            maxhp -= waterdamage;
            watercontact = true;
            Debug.Log("hi1");

        }
    }


    public LayerMask groundLayer;

    bool IsGrounded()
    {

        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.7f, groundLayer.value))
        {
            return true;
        }

        return false;
    }


}
