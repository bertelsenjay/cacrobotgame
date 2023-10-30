using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    public GameObject player;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private GameObject bulletInstance; 
    public float bulletSpeed = 1.5f;
    public AudioClip shootSound;
    public float shootVolume = 0.5f; 
    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask attackMask;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void MeleeAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        if (colInfo != null)
        {
            PlayerMovement.coroutineStart = true;
            playerHealth.health--;
        }

    }

    public void Shoot()
    {
        Vector2 fireDirection = (player.transform.position - transform.position);
        fireDirection.Normalize();
        Vector2 bulletSpawn = bulletSpawnPoint.position;
        bulletInstance = Instantiate(bullet, bulletSpawn, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(fireDirection.x * bulletSpeed, 0);
        
    }
}
