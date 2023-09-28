using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public int attackDamage = 5;
    public int upgradedAtttackDamage = 8; 
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused) {  return; }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        if (PlayerMovement.isPanelEnabled) { return;  }
        animator.SetTrigger("Attack");
        Debug.Log("Attacked");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log(hitEnemies.Length + " enemies");
        foreach (Collider2D enemy in hitEnemies)
        {
            if (Enemy.hasUpgrade == false)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                Debug.Log("Did Damage");
            }
            else if (Enemy.hasUpgrade == true)
            {
                enemy.GetComponent<Enemy>().TakeDamage(upgradedAtttackDamage);
                Debug.Log("Did Damage");
            }
             
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
