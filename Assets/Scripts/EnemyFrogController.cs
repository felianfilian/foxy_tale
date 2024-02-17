using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveTime = 3f;
    public float waitTime = 2f;

    public Animator anim;
    public Transform leftPoint, rightPoint;
    public SpriteRenderer theSR;

    private bool movingRight;
    private float moveCount;
    private float waitCount;

    private Rigidbody2D theRB;
    

    private void Start()
    {
        movingRight = true;
        moveCount = moveTime;

        theRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            EnemyMove();
            if(moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        } else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            if(waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
            }
            anim.SetBool("isMoving", false);
        }
    }

    public void EnemyMove()
    {
        if (movingRight)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            theSR.flipX = true;
            if (transform.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            theSR.flipX = false;
            if (transform.position.x < leftPoint.position.x)
            {
                movingRight = true;
            }
        }
    }
}
