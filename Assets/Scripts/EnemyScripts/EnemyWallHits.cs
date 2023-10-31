using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallHits : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles == new Vector3(0f, 0f, 0f))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }
        else if (transform.eulerAngles == new Vector3(0f, 180f, 0f))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "b" || collision.gameObject.CompareTag("InvisibleWall"))
        {
            if (transform.eulerAngles == new Vector3(0f, 180f, 0f))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.eulerAngles == new Vector3(0, 0, 0))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
}
