using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizonalmove;    
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    public Transform keyFollowPoint;
    [SerializeField] private float JumpForce;
    private SpriteRenderer sr;
    private bool isJumping;

    public key followingKey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {   
        //horizonalmove = Input.GetAxis("Horizontal") * speed;

        //jump
        if(Input.GetButtonDown("Jump") && !isJumping)
        //&& Mathf.Abs(rb.velocity.y) < 0.001f)
        {            
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        //Move Player
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);

        //Flip Player       
        if (Input.GetAxis("Horizontal") < 0)
        {            
            sr.flipX = false;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = other.transform;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
