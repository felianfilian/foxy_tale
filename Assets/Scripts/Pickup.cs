using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum Item { Gem, Health };
    public Item item;
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(item == Item.Gem)
            {
                LevelManager.instance.gemsCollected++;
                UIController.Instance.UpdateGemCount();
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (item == Item.Health && PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.HealthChange(2);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
