using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject boss;
    public Enemy bossEnemy; 
    public static bool hasDied1 = false;
    public static bool hasDied2 = false;
    public static bool hasDied3 = false;
    bool hasSpawned1 = false;
    bool hasSpawned2 = false;
    bool hasSpawned3 = false;
    int currentSceneIndex;

    private void Awake()
    {
        boss.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasDied1 && !hasSpawned1)
        {
            boss.SetActive(true);
            hasSpawned1 = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasDied1 && !hasSpawned1)
        {
            boss.SetActive(true);
            hasSpawned1 = true;
        }
    }

    public void GetLocalScale()
    {
        HealthBar.scale = (float)bossEnemy.currentHealth / (float)bossEnemy.maxHealth;
        Debug.Log("Local scale got");
        Debug.Log(HealthBar.scale);
    }
}
