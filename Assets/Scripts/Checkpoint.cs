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
            
            CheckpointsController.instance.DeactivateCheckpoints();
            theSR.sprite = cpOn;
            CheckpointsController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoints()
    {
        theSR.sprite = cpOff;
    }
}
