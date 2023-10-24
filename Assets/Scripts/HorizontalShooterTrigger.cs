using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalShooterTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HorizontalShooterEnemy.canFire = true;
            HorizontalShooterEnemy.isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HorizontalShooterEnemy.canFire = false;
            HorizontalShooterEnemy.isAttacking = false;
        }
    }
}
