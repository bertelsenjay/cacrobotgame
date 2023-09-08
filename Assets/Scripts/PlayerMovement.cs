using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{
    public static bool isPanelEnabled = false; 
    public static bool hasDoubleJump = false;
    public static bool hasDash = false;
    public bool testDoubleJump = false; 
    public bool testDash = false;  
    private int totalJumps = 1;

    PlayerHealth playerHealth; 
    Animator animator;
    public GameObject textPanel; 
    public float speed;
    private float moveInput;
    public float jumpForce;


    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping; 

    private bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround; 
    Rigidbody2D rb;

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashingCooldown;


    private SpriteRenderer spriteRenderer;
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int noOfFlashes;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        if (testDoubleJump)
        {
            hasDoubleJump = true; 
            
        }
        if (testDash)
        {
            hasDash = true;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPanelEnabled) { return;  }
        if (isDashing)
        {
            return; 
        }
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        if (isPanelEnabled) { return; } 
        if (isDashing)
        {
            return; 
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded && hasDoubleJump && !isJumping)
        {
            totalJumps = 2;
            
        }
        else if (isGrounded && !hasDoubleJump && !isJumping)
        {
            totalJumps = 1;
            //Debug.Log("Has single jump");
        }
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        /*if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            Debug.Log("Jump");
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }*/
        if (totalJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            
            if (hasDoubleJump && totalJumps == 1)
            {
                animator.SetTrigger("doubleJump");
            }
            totalJumps--; 
            isJumping = true;
            
            Debug.Log("Jump");
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false; 
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            isJumping = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    private IEnumerator Dash()
    {
        if (hasDash)
        {
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0;
            if (transform.eulerAngles.y == 0)
            {
                rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            }
            else if (transform.eulerAngles.y == 180)
            {
                rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
            }
            
            yield return new WaitForSeconds(dashingTime);
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true; 
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(Invulnerability());
            playerHealth.health--;
        }
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 7, true);
        for (int i = 0; i < noOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        Physics2D.IgnoreLayerCollision(8, 7, false);
    }
}
