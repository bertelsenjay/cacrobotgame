using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource; 
    public AudioClip normalEnemyDeath;
    public AudioClip bossDeathSound; 
    public static bool enemyDeathTrigger;
    public static bool bossDeathTrigger; 

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
    }
}
