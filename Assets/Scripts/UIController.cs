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

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateHealthDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = heartEmpty;
        }
        int actualHealth = PlayerHealthController.Instance.currentHealth;
        for (int i = 0; i < actualHealth; i++)
        {
            int index = Mathf.Abs(i / 2);
             if(actualHealth % 2 == 0)
            {
                hearts[i].sprite = heartFull;
            } else
            {
                hearts[i].sprite = heartHalf;
            }
            
        }
    }
}
