using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectible;
    [Range(0, 100)] public float chanceToDrop = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.parent.gameObject.SetActive(false);
            PlayerComtroller.instance.Bounce();
            Instantiate(deathEffect, collision.transform.position, collision.transform.rotation);
        }
    }
}
