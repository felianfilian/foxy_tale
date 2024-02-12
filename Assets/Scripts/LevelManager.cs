using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;

    public float waitToRespawn = 2;
    public int gemscollected = 0;

    private void Awake()
    {
        instance = this;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerHealthController playHcon = PlayerHealthController.instance;
        PlayerComtroller playCon = PlayerComtroller.instance;
        playCon.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        playCon.gameObject.SetActive(true);
        playCon.transform.position = CheckpointsController.instance.spawnPoint;
        playHcon.currentHealth = playHcon.maxHealth;
        UIController.Instance.UpdateHealthDisplay();
    }
}
