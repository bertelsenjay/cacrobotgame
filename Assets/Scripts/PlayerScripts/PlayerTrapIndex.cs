using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrapIndex : MonoBehaviour
{
    public int trapIndex;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.index = trapIndex;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.index = trapIndex;
        }
    }

}
