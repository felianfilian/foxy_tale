using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    public int currentHealth;
    public float invincibilityLength = 1f;

    private int maxHealth;
    private float invincibilityCounter;

    private SpriteRenderer theSR;

    private void Awake()
    {
        Instance = this;

        theSR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        maxHealth = UIController.Instance.hearts.Length * 2;
        currentHealth = maxHealth;
    }

    
    void Update()
    {
    if(invincibilityCounter >= 0)
        {
            invincibilityCounter -= Time.deltaTime;
            if(invincibilityCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }    
    }

    public void DealDamage(int damage)
    {
        if(invincibilityCounter <= 0) {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                invincibilityCounter = invincibilityLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
            }
            UIController.Instance.UpdateHealthDisplay();
        }
        
    }
}
