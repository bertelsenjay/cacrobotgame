using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Boss : StateMachineBehaviour
{
    public float moveSpeed = 2.5f;
    public float attackRange = 3f;
    public float timeBetweenAttackAndShoot = 2.5f;
    private float timer; 
    Transform player;
    Rigidbody2D rb;
    FirstBoss boss;
    private bool hasJustAttacked = false; 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<FirstBoss>(); 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer(); 

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime);
        if (!hasJustAttacked)
        {
            rb.MovePosition(newPos);
        }
        

        if (Vector2.Distance(player.position, rb.position) <= attackRange && !hasJustAttacked)
        {
            animator.SetTrigger("Attack");
            hasJustAttacked = true;
        }
        
        if (hasJustAttacked && timer > timeBetweenAttackAndShoot)
        {
            Debug.Log("Shooting");
            animator.SetTrigger("Shoot");
            hasJustAttacked = false;
            timer = 0;
        }
        else if (hasJustAttacked)
        {
            timer += Time.deltaTime;
        }
        //Debug.Log(timer);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    public void LogToConsole()
    {
        Debug.Log("Testing boss functions");
    }
    
}
