using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lastXPos;

    public Transform target;
    public Transform farBackground, middleBackground;
    public Transform minHeight, maxHeight;

    private float camHeight, camWidth;

    void Start()
    {
        lastXPos = transform.position.x;
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

        float amountToMoveX = transform.position.x - lastXPos;
        farBackground.position += new Vector3(amountToMoveX, 0f, 0f);
        middleBackground.position += new Vector3(amountToMoveX, 0f, 0f) * 0.5f;

        lastXPos = transform.position.x;
    }
}
