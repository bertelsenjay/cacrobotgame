using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalShooterEnemy : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player; 
    private bool canFire; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 fireDirection = (transform.position - player.transform.position).normalized;
        if (fireDirection.x > 0f && canFire)
        {
            Instantiate(bullet, fireDirection, Quaternion.identity);
            Debug.Log("Instantiated");
        }
        else if (fireDirection.x < 0f && canFire)
        {
            Instantiate(bullet, fireDirection, Quaternion.identity);
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
