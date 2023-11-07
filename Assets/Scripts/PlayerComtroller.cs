using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    private float moveSpeed;
    private float jumpForce;

    public Rigidbody2D theRB;

    void Start()
    {
        moveSpeed = 10;
        jumpForce = 15;
    }

    void Update()
    {
        theRB.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        if(Input.GetButtonDown("Jump")) { 
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    }
}
