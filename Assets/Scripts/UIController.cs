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
        for(int i = 0; i < PlayerHealthController.Instance.maxHealth; i++)
        {
            hearts[i].sprite = heartEmpty;
        }
    }
}
