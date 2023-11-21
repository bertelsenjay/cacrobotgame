using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPiece : MonoBehaviour
{
    // Start is called before the first frame update

    public int healthPieceIndex;

    public static bool healthPiece0Colllected = false;
    public static bool healthPiece1Colllected = false;
    public static bool healthPiece2Collected = false;
    public static bool healthPiece3Collected = false;
    public static bool healthPiece4Collected = false;
    public static bool healthPiece5Collected = false;
    public static bool healthPiece6Collected = false;
    public static bool healthPiece7Collected = false;
    public static bool healthPiece8Collected = false;
    public static bool healthPiece9Collected = false;
    void Start()
    {
        Debug.Log(healthPiece0Colllected);
        if (healthPieceIndex == 0 && healthPiece0Colllected)
        {
            Destroy(gameObject);
            
        }
        if (healthPieceIndex == 1 && healthPiece1Colllected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 2 && healthPiece2Collected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 3 && healthPiece3Collected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 4 && healthPiece4Collected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 5 && healthPiece5Collected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 6 && healthPiece6Collected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 7 && healthPiece7Collected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 8 && healthPiece8Collected)
        {
            Destroy(gameObject);
        }
        if (healthPieceIndex == 9 && healthPiece9Collected)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (healthPieceIndex == 0)
            {
                healthPiece0Colllected = true;
                Debug.Log(healthPiece0Colllected);
            }
            if (healthPieceIndex == 1)
            {
                healthPiece1Colllected = true;
            }
            if (healthPieceIndex == 2)
            {
                healthPiece2Collected = true;
            }
            if (healthPieceIndex == 3)
            {
                healthPiece3Collected = true; 
            }
            if (healthPieceIndex == 4)
            {
                healthPiece4Collected = true;
            }
            if (healthPieceIndex == 5)
            {
                healthPiece5Collected = true; 
            }
            if (healthPieceIndex == 6)
            {
                healthPiece6Collected = true; 
            }
            if (healthPieceIndex == 7)
            {
                healthPiece7Collected = true; 
            }
            if (healthPieceIndex == 8)
            {
                healthPiece8Collected = true;
            }
            if (healthPieceIndex == 9)
            {
                healthPiece9Collected = true; 
            }
        }
    }
}
