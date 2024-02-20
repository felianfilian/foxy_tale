using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;

    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }

    public void PlaaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].pitch = Random.Range(0.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }
}
