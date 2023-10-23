using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public bool wallChip = false;
    public bool doubleJumpChip = false;
    public bool dashChip = false;



    private void Update()
    {
        if (wallChip && PlayerMovement.hasWallJump)
        {
            Destroy(gameObject);
        }
        if (doubleJumpChip && PlayerMovement.hasDoubleJump)
        {
            Destroy(gameObject);
        }
        if (dashChip && PlayerMovement.hasDash)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (wallChip)
            {
                PlayerMovement.hasWallJump = true;
            }
            if (doubleJumpChip)
            {
                PlayerMovement.hasDoubleJump = true;
            }
            if (dashChip)
            {
                PlayerMovement.hasDash = true;
            }
            Destroy(gameObject);
        }
    }
}
