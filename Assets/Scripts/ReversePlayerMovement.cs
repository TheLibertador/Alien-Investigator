using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
   

    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float jumpForce = 0;

    [SerializeField] private LayerMask jumpableGround;
    
    private float sprintTime = 5f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        rb.gravityScale = -1f;
    }

    private void Update()
    {
        Move(moveSpeed);
        Jump(jumpForce);
        
    }

    private void Move(float moveSpeed)
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
    }

    private void Jump(float jumpForce)
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, .1f, jumpableGround);
    }
    
}
