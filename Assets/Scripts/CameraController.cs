using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lastXPos;

    public Transform target;
    public Transform farBackground, middleBackground;

    void Start()
    {
        lastXPos = transform.position.x;
    }

        void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z); 
        float amountToMoveX = transform.position.x - lastXPos;
        farBackground.position += new Vector3(amountToMoveX, 0f, 0f);
        middleBackground.position += new Vector3(amountToMoveX, 0f, 0f) * 0.5f;

        lastXPos = transform.position.x;
    }
}
