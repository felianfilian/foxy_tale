using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    private float moveSpeed;
    private float jumpForce;

    private bool isGrounded;
    private bool canDoubleJump;

    public Animator anim;
    public Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public Transform groundCheckPoint; // Ground Point of the Player
    public LayerMask whatIsGround; // Ground Layer

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        moveSpeed = 10;
        jumpForce = 15;
    }

    void Update()
    {
        theRB.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if(Input.GetButtonDown("Jump")) { 
            if(isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if(canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
            
        }

        ChangeDirection();

        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void ChangeDirection()
    {
        if(theRB.velocity.x < 0) { 
            theSR.flipX = true;
        } else if(theRB.velocity.x > 0)
        {
            theSR.flipX=false;
        }

    }
}
