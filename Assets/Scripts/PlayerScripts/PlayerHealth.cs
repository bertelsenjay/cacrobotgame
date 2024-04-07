using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public static int publicHealth = 5;
    public int noOfHearts;
    public static int publicNoOfHearts = 5; 
    //public GameObject player; 
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int heartPieces = 0;
    public static int publicHeartPieces = 0; 
    public TextMeshProUGUI heartText;
    UIShop shop;
    public Canvas healthCanvas;
    public Canvas bossHealthCanvas;
    public static int amountKilled; 
    //public static bool healthLocked = false;

    
    

    private void Awake()
    {
        health = publicHealth;
        noOfHearts = publicNoOfHearts;
        heartPieces = publicHeartPieces;
        shop = FindObjectOfType<UIShop>();
        healthCanvas.enabled = true;
    }
    private void Update()
    {
        
        publicHealth = health;
        heartText.text = "Heart Pieces: " + publicHeartPieces;
        if (publicHeartPieces >= 4)
        {
            //heartPieces -= 4;
            publicHeartPieces -= 4; 
            noOfHearts++;
            publicNoOfHearts++;
            health = noOfHearts;
        }
        if (health > noOfHearts)
        {
            health = noOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < noOfHearts)
            {
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health <= 0 && !LevelLoader.localIsDead)
        {
            AudioManager.playerDeathTrigger = true;
            LevelLoader.isDead = true;

            health = noOfHearts;
            publicHealth = noOfHearts;
            shop.LoseMoneyOnDeath();
            healthCanvas.enabled = false;
            bossHealthCanvas.enabled = false;
        }
        if (amountKilled >= 2)
        {
            health++;
            amountKilled -= 2; 
        }
    }

    

    public void LoseHealth(int damage)
    {
        //if (healthLocked) { return; }
        health -= damage;
        
    }

    public void IncreasePublicHeartPieces()
    {
        publicHeartPieces++;
        Debug.LogError("Success!");
    }

    
}
