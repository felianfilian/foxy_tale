using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    public int currentHealth;
    private int maxHealth;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        maxHealth = UIController.Instance.hearts.Length * 2;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
        UIController.Instance.UpdateHealthDisplay();
    }
}
