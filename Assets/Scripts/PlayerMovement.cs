using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
   

    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float jumpForce = 0;

    [SerializeField] private LayerMask jumpableGround;

    private float sprintCooldown = 0;
    private bool isSprinting = false;
    private float sprintTime = 5f;
    
    private bool isTree;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Move(moveSpeed);
        Jump(jumpForce);

        if (transform.CompareTag("Modern"))
        {
            if (Input.GetKey(KeyCode.K))
            {
                if (sprintCooldown <= 0 && !isSprinting)
                {
                    StartSprinting();
                }
            }
            if (sprintCooldown > 0)
            {
                sprintCooldown -= Time.deltaTime;
            }

            if (isSprinting)
            {
                sprintTime -= Time.deltaTime;
                if (sprintTime <= 0)
                {
                    StopSprinting();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (CompareTag("CaveHuman"))
        {
            if (isTree)
            {
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * moveSpeed);
            }
            else
            {
                rb.gravityScale = 4f;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tree"))
        {
            isTree = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tree"))
        {
            isTree = false;
            rb.gravityScale = 1f;
        }
    }

    private void Move(float moveSpeed)
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
    }

    private void Jump(float jumpForce)
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void StartSprinting()
    {
        isSprinting = true;
        moveSpeed *= 2;
        sprintTime = 5f;
    }

    private void StopSprinting()
    {
        isSprinting = false;
        moveSpeed /= 2;
        sprintCooldown = 10f;
    }
}
