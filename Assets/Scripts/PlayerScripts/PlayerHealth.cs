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
    //public static bool healthLocked = false;

    
    

    private void Awake()
    {
        health = publicHealth;
        noOfHearts = publicNoOfHearts;
        heartPieces = publicHeartPieces;
        shop = FindObjectOfType<UIShop>();
    }
    private void Update()
    {
        
        publicHealth = health;
        heartText.text = "Heart Pieces: " + heartPieces;
        if (heartPieces >= 4)
        {
            heartPieces -= 4;
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
            LevelLoader.isDead = true;

            health = noOfHearts;
            publicHealth = noOfHearts;
            shop.LoseMoneyOnDeath();
        }
    }

    

    public void LoseHealth(int damage)
    {
        //if (healthLocked) { return; }
        health -= damage;
        
    }

    
}
