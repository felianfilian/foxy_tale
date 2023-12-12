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
        knockBackForce = 4f;
    }

    void Update()
    {
        if(knockBackCounter <= 0)
        {
            Move();
        } else
        {
            KnockBackMove();
        }
    }

    public void Move()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if (isGrounded)
        {
            canDoubleJump = true;
        }
        Jump();
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

    public void KnockBackMove()
    {
        knockBackCounter -= Time.deltaTime;
        if (!theSR.flipX)
        {
            theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
        }
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce*2);
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
