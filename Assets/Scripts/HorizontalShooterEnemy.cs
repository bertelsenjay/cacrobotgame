using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalShooterEnemy : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    public float bulletSpeed;
    public float bulletDelay;
    public Transform spawnPoint; 
    private float timer; 
    private GameObject bulletSpawn;
    Rigidbody2D rb; 
    private bool canFire; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = bulletDelay; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 fireDirection = (player.transform.position - transform.position);
        fireDirection.Normalize();
        timer -= Time.deltaTime;
        Vector2 spawnPointLocation = spawnPoint.position; 
        if (fireDirection.x > 0f && canFire && timer <= 0)
        {
            bulletSpawn = Instantiate(bullet, spawnPointLocation, Quaternion.identity);
            bulletSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(fireDirection.x * bulletSpeed, 0);
            Debug.Log("Instantiated");
            timer = bulletDelay;
        }
        else if (fireDirection.x < 0f && canFire && timer <= 0)
        {
            bulletSpawn = Instantiate(bullet, spawnPointLocation, Quaternion.identity);
            bulletSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(fireDirection.x * bulletSpeed, 0);
            timer = bulletDelay; 
            Debug.Log("Instantiated");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Exited Trigger");
            canFire = false; 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is in trigger");
            canFire = true;
        }
    }
}
