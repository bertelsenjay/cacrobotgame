using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossWeapon : MonoBehaviour
{
    PlayerHealth playerHealth;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask; 




    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
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
}
