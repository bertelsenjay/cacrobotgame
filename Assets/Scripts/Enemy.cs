using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool hasUpgrade = false; 
    public int maxHealth = 10;
    int currentHealth; 
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        
        Debug.Log("CallingFunction");
        
            currentHealth -= damage;
        if (currentHealth <= 0 )
        {
            Die(); 
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Dead");
    }
}
