using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float jumpForce = 0;

    [SerializeField] private LayerMask jumpableGround;


    [Header("ModernHuman")] [SerializeField]
    private float sprintCooldown = 0;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        Move(moveSpeed);
        Jump(jumpForce);

        if (transform.CompareTag("Modern"))
        {
            if (Input.GetKey(KeyCode.K))
            {
                if (sprintCooldown == 0)
                {
                    StartCoroutine(Sprint());
                    StartSprintCooldown();
                }
            }
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


    private IEnumerator Sprint()
    {
        moveSpeed *= 2;
        yield return new WaitForSeconds(5f);
        moveSpeed /= 2;
        sprintCooldown = 10;
    }

    private void StartSprintCooldown()
    {
        sprintCooldown -= Time.deltaTime;
    }
}