using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animator;

    [SerializeField] private LayerMask jumpGround;

    private float moveSpeed = 7f;
    private float jump = 4f;
    private float dirX = 0f;
    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * jump, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isLanded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        }


        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MovementState movementState = 0 ;
        if (dirX == 0f)
        {
            movementState = MovementState.idle;
        }
        else if (dirX > 0f)
        {
            movementState = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            movementState = MovementState.running;
            sprite.flipX = true;
        }

        if (rb.velocity.y > .1f)
        {
            movementState = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
            movementState = MovementState.falling;

        animator.SetInteger("state", (int)movementState);
    }

    private bool isLanded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
