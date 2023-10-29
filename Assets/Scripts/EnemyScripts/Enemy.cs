using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool hasUpgrade = false; 
    public int maxHealth = 10;
    public int moneyWorth = 0;
    UIShop shop;
    AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public int currentHealth;
    public bool isBoss = false;
    public GameObject upgradeChip;
    public Transform spawnPoint; 
    
    // Start is called before the first frame update
    void Start()
    {
        shop = FindObjectOfType<UIShop>(); 
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

   

    public void TakeDamage(int damage)
    {
        
        Debug.Log("CallingFunction");
        audioSource.PlayOneShot(hurtSound);
            currentHealth -= damage;
        if (currentHealth <= 0 && !isBoss)
        {
            Invoke("Die", 0.25f);
            AudioManager.enemyDeathTrigger = true;
        }
        else if (currentHealth <= 0 && isBoss)
        {
            Die();
        }
        
    }
    public void Die()
    {
        //audioSource.PlayOneShot(deathSound);
        PlayerHealth.amountKilled++;
        Destroy(gameObject);
        Debug.Log("Dead");
        shop.AddCurrency(moneyWorth);
        if (gameObject.name == "FirstBoss")
        {
            BossSpawn.hasDied1 = true;
            Instantiate(upgradeChip, spawnPoint.position, Quaternion.identity);
        }
        if (gameObject.name == "MeleeEnemy")
        {
            Instantiate(upgradeChip, spawnPoint.position, Quaternion.identity);
        }
        if (gameObject.name == "MaliciousOrbSheet")
        {
            Instantiate(upgradeChip, spawnPoint.position, Quaternion.identity);
        }

    }

    public void GetLocalScale()
    {
        
        HealthBar.scale = (float)currentHealth / (float)maxHealth;
    }

}
