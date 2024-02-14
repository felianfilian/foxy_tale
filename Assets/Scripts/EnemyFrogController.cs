using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool movingRight;

    public Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public Transform leftPoint, rightPoint;

    void Update()
    {
        
    }
}
