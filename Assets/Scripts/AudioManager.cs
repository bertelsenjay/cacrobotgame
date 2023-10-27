using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource; 
    public AudioClip normalEnemyDeath;
    public float normalEnemyDeathVolume = 1.0f;
    public AudioClip bossDeathSound;
    public float bossDeathVolume = 1.0f;
    public AudioClip playerDeathSound;
    public float playerDeathVolume = 1.0f;
    public static bool enemyDeathTrigger;
    public static bool bossDeathTrigger; 
    public static bool playerDeathTrigger;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (enemyDeathTrigger)
        {
            enemyDeathTrigger = false;
            audioSource.PlayOneShot(normalEnemyDeath, normalEnemyDeathVolume);
        }
        if (playerDeathTrigger)
        {
            playerDeathTrigger = false;
            audioSource.PlayOneShot(playerDeathSound, playerDeathVolume);
        }
    }
}
