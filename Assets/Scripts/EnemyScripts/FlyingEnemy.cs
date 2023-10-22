using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

public class FlyingEnemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int moneyWorth = 0;
    UIShop shop;
    AudioSource audioSource;
    public AudioClip hurtSound;
    public int currentHealth;
    AIPath path;
    public GameObject player; 
    public float closeDistance; 

    private void Awake()
    {
        path = GetComponent<AIPath>();
        shop = FindObjectOfType<UIShop>(); 
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth; 
    }
    // Start is called before the first frame update
    void Start()
    {
        path.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        float playerDistance = playerDirection.magnitude;
        playerDirection.Normalize();
        if (playerDistance <= closeDistance)
        {
            path.canMove = true;
        }
        else
        {
            path.canMove = false;
        }
    }

    public void TakeDamage(int damage)
    {
        audioSource.PlayOneShot(hurtSound);
        currentHealth -= damage; 
        if (currentHealth <= 0)
        {
            Invoke("Die", 0.25f);
            AudioManager.enemyDeathTrigger = true;
        }
    } 

    public void Die()
    {
        Destroy(gameObject);
        shop.AddCurrency(moneyWorth);

    }
}
