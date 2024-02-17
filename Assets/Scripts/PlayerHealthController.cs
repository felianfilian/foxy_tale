using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public float invincibilityLength = 1f;

    public int maxHealth;
    private float invincibilityCounter;

    public GameObject deathEffect;

    private SpriteRenderer theSR;

    private void Awake()
    {
        instance = this;

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
                Instantiate(deathEffect, transform.position, transform.rotation);
                AudioManager.instance.PlaaySFX(8);
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibilityCounter = invincibilityLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
                PlayerComtroller.instance.KnockBack();
            }
            UIController.Instance.UpdateHealthDisplay();
            AudioManager.instance.PlaaySFX(9);
        }
        
    }

    public void HealthChange(int amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            LevelManager.instance.RespawnPlayer();
        } else if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        UIController.Instance.UpdateHealthDisplay();
    }
}
