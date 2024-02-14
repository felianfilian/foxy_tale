using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private void Start()
    {
        movingRight = true;
    }

    void Update()
    {
        if(movingRight)
        {
            theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);
            theSR.flipX = true;
        }
    }
}
