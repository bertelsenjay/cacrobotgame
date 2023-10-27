using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Rope : MonoBehaviour
{
    public int sceneIndex = 1;
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>(); 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SpawnManager.spawnIndex = 2;
                levelLoader.LoadNextLevel(sceneIndex);
            }
        }
    }
}
