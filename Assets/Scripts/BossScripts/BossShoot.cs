using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject player; 
    public GameObject blueBullet;
    public GameObject purpleBullet;
    public GameObject redBullet;
    public Transform blueSpawnPoint;
    public Transform purpleSpawnPoint;
    public Transform redSpawnPoint;
    private GameObject blueBulletSpawn;
    private GameObject purpleBulletSpawn;
    private GameObject redBulletSpawn;
    public float bulletSpeed = 1.5f;
    public AudioClip shootSound;
    public float shootVolume = 0.5f; 

    public void Shoot()
    {
        Debug.Log("Successful Shot");
        GetComponent<AudioSource>().PlayOneShot(shootSound, shootVolume);
        Vector2 fireDirection = (player.transform.position - transform.position);
        fireDirection.Normalize();
        Vector2 blueSpawn = blueSpawnPoint.position;
        Vector2 purpleSpawn = purpleSpawnPoint.position;
        Vector2 redSpawn = redSpawnPoint.position;

        blueBulletSpawn = Instantiate(blueBullet, blueSpawn, Quaternion.identity);
        purpleBulletSpawn = Instantiate(purpleBullet, purpleSpawn, Quaternion.identity);
        redBulletSpawn = Instantiate(redBullet, redSpawn, Quaternion.identity);
        blueBulletSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(fireDirection.x * bulletSpeed, 0);
        purpleBulletSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(fireDirection.x * bulletSpeed, 0);
        redBulletSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(fireDirection.x * bulletSpeed, 0);
    }
}
