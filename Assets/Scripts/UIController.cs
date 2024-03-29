using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public UnityEngine.UI.Image[] hearts;
    public Sprite heartFull, heartHalf, heartEmpty;

    public Text gemText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateHealthDisplay();
        UpdateGemCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        int actualHealth = PlayerHealthController.instance.currentHealth;
        int heartCounter = 0;
        for (int i = 0; i < hearts.Length; i++)
        {
            heartCounter = (i + 1) * 2;
            if (heartCounter<= actualHealth)
            {
                hearts[i].sprite = heartFull;
            } else if (heartCounter-1 == actualHealth)
            {
                hearts[i].sprite = heartHalf;
            } else
            {
                hearts[i].sprite = heartEmpty;
            }
            
        }       
    }

    public void UpdateGemCount()
    {
        gemText.text = LevelManager.instance.gemsCollected.ToString();
    }

}
