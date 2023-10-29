using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Rope : MonoBehaviour
{
    public int sceneIndex = 1;
    public int spawnIndex = 0;
    public GameObject pressECanvas; 
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        pressECanvas.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            pressECanvas.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SpawnManager.spawnIndex = spawnIndex;
                levelLoader.LoadNextLevel(sceneIndex);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressECanvas.SetActive(false);
        }
    }
}
