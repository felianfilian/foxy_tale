using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;

    public float waitToRespawn = 2;

    private void Awake()
    {
        instance = this;
    }
}
