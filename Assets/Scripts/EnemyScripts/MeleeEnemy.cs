using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    // Video Tutorial https://www.youtube.com/watch?v=qgX941I-YqE

    #region Public Variables
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea; 
    #endregion

    #region Private Variables
    private Animator anim;
    private float distance;
    private bool attackMode;
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

            EnemyLogic(); 
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

    /*private void OnTriggerEnter2D(Collider2D collision)
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
    }*/


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

    public void SelectTarget()
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
    public void Flip()
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
