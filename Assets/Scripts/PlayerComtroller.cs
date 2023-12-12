using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    public static PlayerComtroller instance;

    private float moveSpeed;
    private float jumpForce;
    private float knockBackLength;
    private float knockBackForce;
    private float knockBackCounter;

    private bool isGrounded;
    private bool canDoubleJump;

    public Animator anim;
    public Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public Transform groundCheckPoint; // Ground Point of the Player
    public LayerMask whatIsGround; // Ground Layer

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        moveSpeed = 10;
        jumpForce = 15;
        knockBackLength = 0.5f;
        knockBackForce = 8f;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if (isGrounded)
        {
            canDoubleJump = true;
        }

        ChangeDirection();

        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
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
