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
    public int currentHealth; 
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shop = FindObjectOfType<UIShop>(); 
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
        
            currentHealth -= damage;
        if (currentHealth <= 0 )
        {
            Die(); 
        }
        StartCoroutine(FlashRed());
    }
    void Die()
    {
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
