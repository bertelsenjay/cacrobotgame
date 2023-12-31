using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerEnemy : MonoBehaviour
{
    public GameObject player;
    public float close = 10.0f;
    public float speed = 3.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDirection = player.transform.position - transform.position;

        float playerDist = playerDirection.magnitude;
        float xDirection = player.transform.position.x - transform.position.x;
        if (xDirection < 0)
        {
            xDirection = -1;
        }
        else if (xDirection > 0)
        {
            xDirection = 1;
        }
        playerDirection.Normalize();
        
        if (playerDist <= close)
        {
            rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);
        }
    }
}
