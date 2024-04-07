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

    PlayerHealth playerHealth; 
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        //Debug.Log(healthPiece0Colllected);
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
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
        if (healthPieceIndex == 3 && healthPiece3Collected)
        {
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
        if (healthPieceIndex == 4 && healthPiece4Collected)
        {
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
        if (healthPieceIndex == 5 && healthPiece5Collected)
        {
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
        if (healthPieceIndex == 6 && healthPiece6Collected)
        {
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
        if (healthPieceIndex == 7 && healthPiece7Collected)
        {
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
        if (healthPieceIndex == 8 && healthPiece8Collected)
        {
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
        if (healthPieceIndex == 9 && healthPiece9Collected)
        {
            //playerHealth.IncreasePublicHeartPieces();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (healthPieceIndex == 0)
            {
                healthPiece0Colllected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 1)
            {
                healthPiece1Colllected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 2)
            {
                healthPiece2Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 3)
            {
                healthPiece3Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 4)
            {
                healthPiece4Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 5)
            {
                healthPiece5Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 6)
            {
                healthPiece6Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 7)
            {
                healthPiece7Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 8)
            {
                healthPiece8Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
            if (healthPieceIndex == 9)
            {
                healthPiece9Collected = true;
                playerHealth.IncreasePublicHeartPieces();
                Destroy(gameObject);
            }
        }
    }
}
