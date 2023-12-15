using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite cpOn;
    public Sprite cpOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            theSR.sprite = cpOn;
        }
    }

    public void ResetCheckpoints()
    {
        theSR.sprite = cpOff;
    }
}
