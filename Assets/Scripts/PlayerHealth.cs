using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public int noOfHearts;
    //public GameObject player; 
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    
    

    private void Awake()
    {
        
    }
    private void Update()
    {
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
        if (health <= 0)
        {
            LevelLoader.isDead = true;
        }
    }

    

    public void LoseHealth(int damage)
    {
        
        health -= damage;
    }

    
}