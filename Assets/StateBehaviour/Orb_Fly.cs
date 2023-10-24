using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Fly : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    FirstBoss boss; 
    public float speed = 2.5f;
    public float attackRange = 1.5f;
    public float minimumDistance;
    public Transform bossLocation; 
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
        if (Vector2.Distance(bossLocation.position, player.position ) < minimumDistance)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, target, -speed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }
        //Vector2 newPosition = Vector2.MoveTowards(rb.position, target, -speed * Time.fixedDeltaTime);
        //rb.MovePosition(newPosition);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
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
}
