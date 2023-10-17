using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int nextSceneIndex;
    LevelLoader levelLoader;

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelLoader.LoadNextLevel(nextSceneIndex);
            Debug.Log("Hit Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelLoader.LoadNextLevel(nextSceneIndex);
            Debug.Log("Triggered Player");
        }
    }
}
