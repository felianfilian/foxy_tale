using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum Item { Gem, Health };
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(item == Item.Gem)
            {
                LevelManager.instance.gemscollected++;
            }
            if (item == Item.Health)
            {
                PlayerHealthController.instance.HealthChange(2);
            }
            Destroy(gameObject);
        }
    }
}
