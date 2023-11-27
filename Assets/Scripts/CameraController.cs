using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 lastPos;

    public Transform target;
    public Transform farBackground, middleBackground;
    public Transform minHeight, maxHeight;

    private float camHeight, camWidth;

    void Start()
    {
        lastPos = transform.position;
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

        void Update()
    {
        float minPosY = minHeight.position.y + camHeight;
        float maxPosY = maxHeight.position.y - camHeight;

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); 
        float clampedY = Mathf.Clamp(target.position.y, minPosY, maxPosY);
        transform.position = new Vector3(target.position.x, clampedY, transform.position.z);

        // float amountToMoveX = transform.position.x - lastXPos;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f;

        lastPos = transform.position;
    }
}
