using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    public static int saveIndex;
    public bool firstEverSavePoint = false; 
    //public int initialSaveIndex = 0;
    public Transform position;
    private GameObject target;
    public static bool hasSaved = false;
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        /*switch (saveIndex)
        {
            case 0:
                if (hasSaved)
                {
                    Debug.Log("transform set");
                    target.transform.position = position.transform.position;

                }
                break;
        }*/
        //saveIndex = initialSaveIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) || firstEverSavePoint)
        {
            hasSaved = true;
            playerHealth.LoseHealth(-8);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                saveIndex = 0;
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                saveIndex = 1;
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                saveIndex = 2;
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                saveIndex = 3;
            }
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                saveIndex = 4;
            }
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                saveIndex = 5;
            }
            if (collision.gameObject.tag == "Player")
            {

                switch (saveIndex)
                {
                    case 0:
                        Debug.Log("Index Set");
                        LevelLoader.savePointIndex = 0;
                        target = collision.gameObject;
                        break;
                    case 1:
                        LevelLoader.savePointIndex = 1;
                        break;
                    case 2:
                        LevelLoader.savePointIndex = 2;
                        break;
                    case 3:
                        LevelLoader.savePointIndex = 3;
                        break;
                    case 4:
                        LevelLoader.savePointIndex = 4;
                        break;
                    case 5:
                        LevelLoader.savePointIndex = 5;
                        break;
                }
            }
        }
        
    }
}
