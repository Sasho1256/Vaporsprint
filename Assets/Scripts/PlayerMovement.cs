using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal; //horizontal input
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //animation
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        //returns -1, 0 or 1 depending on movement direction
        horizontal = Input.GetAxisRaw("Horizontal");
        animator = GetComponent<Animator>();

        if (!GameOver.gameOver)
        {
            if (rb.velocity.x == 0f)
            {
                //if player is not moving set animation to idle
                animator.SetBool("Movement", false);
            }
            else
            {
                //if player is moving set animation to walking
                animator.SetBool("Movement", true);
            }

            //allow player to jump if they are touching the ground
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                FindObjectOfType<AudioManager>().Play("Jump");
            }

            //if button is released and player is still moving upwards reduce velocity by 50%
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            //flip character on direction change
            Flip();
        } else
        {
            animator.SetBool("Movement", false);
            rb.velocity = Vector2.zero;
        }
        
    }

    private void FixedUpdate()
    {   
        if (!GameOver.gameOver)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}