using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public Transform enemyPos;
    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private void Start()
    {
        movingRight = true;
    }

    void Update()
    {
        EnemyMove();
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
            }
        }
    }
}
