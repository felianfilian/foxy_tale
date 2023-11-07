using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    private float moveSpeed;
    public Rigidbody2D theRB;

    void Start()
    {
        moveSpeed = 10;
    }

    void Update()
    {
        theRB.velocity = new Vector2 (Input.GetAxisRaw("Horitontal") * moveSpeed, theRB.velocity.y);
    }
}
