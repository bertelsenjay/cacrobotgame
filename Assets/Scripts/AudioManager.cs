using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource; 
    public AudioClip normalEnemyDeath;
    public AudioClip bossDeathSound;
    public AudioClip playerDeathSound;
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
            audioSource.PlayOneShot(normalEnemyDeath);
        }
        if (playerDeathTrigger)
        {
            playerDeathTrigger = false;
            audioSource.PlayOneShot(playerDeathSound);
        }
    }
}
