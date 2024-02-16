using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveTime = 3f;
    public float waitTime = 2f;

    public Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public Transform enemyPos;
    public Transform leftPoint, rightPoint;

    private bool movingRight;
    private float moveCount;
    private float waitCount;

    private void Start()
    {
        movingRight = true;
        moveCount = moveTime;
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
        } else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            if(waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
            }
        }
    }

    public void EnemyMove()
    {
        if (movingRight)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            theSR.flipX = true;
            if (enemyPos.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            theSR.flipX = false;
            if (enemyPos.position.x < leftPoint.position.x)
            {
                movingRight = true;
                Debug.Log(enemyPos.position.x + " - " + leftPoint.position.x);
            }
        }
    }
}
