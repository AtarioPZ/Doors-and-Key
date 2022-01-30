using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public bool isLadder;
    private bool isClimbing;
    private float verticalmove;
    private float speed = 2;

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        verticalmove = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(verticalmove) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed);
        }
        else
            rb.gravityScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}