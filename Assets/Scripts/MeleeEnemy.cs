using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    // Video Tutorial https://www.youtube.com/watch?v=qgX941I-YqE

    #region Public Variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling = false;
    private float intTimer;
    private bool hasBeenSet = false; 
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
        intTimer = timer;
        SelectTarget(); 
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(target);
        if (!attackMode)
        {
            Move(); 
        }

        if (!InsideOfLimits() && !inRange)
        {
            SelectTarget();
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(raycast.position, Vector2.right, raycastLength, raycastMask);
            RaycastDebugger();
        }

        if (hit.collider != null)
        {
            Debug.Log("Starting Enemy Logic");
            EnemyLogic(); 
        }
        else if (hit.collider == null)
        {
            inRange = false;
            Debug.Log("Null Collider");
        }

        if (!inRange)
        {
            
            StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position); 
        if (distance > attackDistance)
        {

            StopAttack(); 
        }
        else if (attackDistance >= distance && !cooling)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("HammerBotWalkAnimation"))
        //{
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            //Debug.Log("Moving");
            //Debug.Log(targetPosition);
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        Debug.Log(target);
        //}
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
        Debug.Log("Successful Attack");
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
        Debug.Log("Attack Stopped");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
            target = collision.transform;
            hasBeenSet = true;
            Flip();
            Debug.Log("Triggered!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            hasBeenSet = false;
        }
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true; 
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;  
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);
        if (distanceToLeft > distanceToRight && target != leftLimit && !inRange && !hasBeenSet)
        {
            target = leftLimit;
            Debug.Log("Left");
        }
        else 
        {
            if (target != rightLimit && !inRange && !hasBeenSet)
            {
                target = rightLimit;
                Debug.Log("Right");
            }
            
        }

        Flip(); 
    }
    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f; 
        }
        else
        {
            rotation.y = 180f; 
        }
        
        transform.eulerAngles = rotation;
    }
}
