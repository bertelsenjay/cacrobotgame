using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public int noOfHearts;
    //public GameObject player; 
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int heartPieces = 0;
    public TextMeshProUGUI heartText; 
    //public static bool healthLocked = false;

    
    

    private void Awake()
    {
        
    }
    private void Update()
    {
        heartText.text = "Heart Pieces: " + heartPieces;
        if (heartPieces >= 4)
        {
            heartPieces -= 4;
            noOfHearts++;
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
        }
    }

    

    public void LoseHealth(int damage)
    {
        //if (healthLocked) { return; }
        health -= damage;
    }

    
}
