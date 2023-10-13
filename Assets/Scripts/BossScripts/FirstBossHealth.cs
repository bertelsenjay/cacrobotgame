using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossHealth : MonoBehaviour
{
    public int health = 50;
    public int maxHealth = 50; 

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); 
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    public float GetLocalScale(int health, int maxHealth)
    {
        return (float)health / (float)maxHealth;
    }
}
