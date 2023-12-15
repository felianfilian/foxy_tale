using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsController : MonoBehaviour
{
    public static CheckpointsController instance;
    private Checkpoint[] checkpoints;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    
    public void DeactivateCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoints();
        }
    }
}
