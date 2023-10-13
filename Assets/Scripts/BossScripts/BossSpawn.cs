using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawn : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossTriggerArea;
    public Transform bossSpawnPoint;
    public static bool hasDied1 = false;
    public static bool hasDied2 = false;
    public static bool hasDied3 = false;
    bool hasSpawned1 = false;
    bool hasSpawned2 = false;
    bool hasSpawned3 = false;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == bossTriggerArea && !hasSpawned1 && !hasDied1)
        {
            Instantiate(boss, bossSpawnPoint.position, Quaternion.identity);
            hasSpawned1 = true;
        }
    }
}
