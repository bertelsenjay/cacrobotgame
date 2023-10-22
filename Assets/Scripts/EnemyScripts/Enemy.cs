using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool hasUpgrade = false; 
    public int maxHealth = 10;
    public int moneyWorth = 0;
    public float flashDelay;
    UIShop shop;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip deathSound; 
    public int currentHealth;
    public bool isBoss = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shop = FindObjectOfType<UIShop>(); 
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDelay);
        spriteRenderer.color = Color.white; 
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
        StartCoroutine(FlashRed());
    }
    void Die()
    {
        //audioSource.PlayOneShot(deathSound);
        
        Destroy(gameObject);
        Debug.Log("Dead");
        shop.AddCurrency(moneyWorth);
        if (gameObject.name == "Boss(Clone)")
        {
            BossSpawn.hasDied1 = true;
        }

    }

    public void GetLocalScale()
    {
        
        HealthBar.scale = (float)currentHealth / (float)maxHealth;
    }

}
