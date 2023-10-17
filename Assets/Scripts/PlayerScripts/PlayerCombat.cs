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
    public LayerMask bossLayers;
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
                Debug.Log("Pressed left click");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        if (PlayerMovement.isPanelEnabled) { return;  }
        if (UIShop.isEnabled) { return; }
        animator.SetTrigger("Attack");
        Debug.Log("Attacked");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayers);
        //Collider2D[] hitBullets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bulletLayers);
        Debug.Log(hitEnemies.Length + " enemies");
        /*foreach (Collider2D boss in hitBoss)
        {
            if (Enemy.hasUpgrade == false)
            {
                boss.GetComponent<FirstBossHealth>().TakeDamage(attackDamage);
            }
            else if (Enemy.hasUpgrade == true)
            {
                boss.GetComponent<FirstBossHealth>().TakeDamage(upgradedAtttackDamage);
            }

        }*/
        
        
        foreach (Collider2D enemy in hitEnemies)
        {

            if (Enemy.hasUpgrade == false)
            {
                if (enemy.name.Contains("Horizontal"))
                {
                    if (HorizontalShooterEnemy.isClose)
                    {
                        enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                        Debug.Log("Did Damage");
                    }
                }
                else if (enemy.name.Contains("Enemy"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                    Debug.Log("Did Damage");

                }
                else if (enemy.name.Contains("Boss"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                    Debug.Log("Did boss damage");
                }
                
            }
            else if (Enemy.hasUpgrade == true)
            {
                if (enemy.name.Contains("Horizontal"))
                {
                    if (HorizontalShooterEnemy.isClose)
                    {
                        enemy.GetComponent<Enemy>().TakeDamage(upgradedAtttackDamage);
                        Debug.Log("Did Damage");
                    }
                }
                else if (enemy.name.Contains("Enemy"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(upgradedAtttackDamage);
                    Debug.Log("Did Damage");
                }
                else if (enemy.name.Contains("Boss"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(upgradedAtttackDamage);
                    Debug.Log("Did boss damage");
                }


            }

            /*foreach (Collider2D bullet in hitBullets)
            {
                Destroy(bullet);
            }*/
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