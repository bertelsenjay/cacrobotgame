using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{
    public static bool isPanelEnabled = false; 
    public static bool hasDoubleJump = false;
    public static bool hasDash = false;
    public static bool hasWallJump = false; 
    [Header("MovementUpgradeTests")]
    public bool testDoubleJump = false; 
    public bool testDash = false;  
    public bool testWallJump = false;
    private int totalJumps = 1;

    PlayerHealth playerHealth; 
    Animator animator;
    public GameObject textPanel; 
    private float moveInput;
    [Header("Movement")]
    public float speed;
    public float jumpForce;


    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping; 

    private bool isGrounded = false;
    [Header("GroundChecks")]
    public Transform feetPos;
    public float checkRadius;
    public float wallJumpCheckRadius; 
    public LayerMask whatIsGround; 
    Rigidbody2D rb;

    private bool canDash = true;
    private bool isDashing;
    [Header("Dashing")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashingCooldown;


    private SpriteRenderer spriteRenderer;
    [Header("IFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int noOfFlashes;

    [Header("WallJump")]
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed = 2f;

    bool wallJumping;
    public float xWallForce; 
    public float yWallForce;
    public float wallJumpTime;

    int moveDirection = 0;
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
        if (testWallJump)
        {
            hasWallJump = true;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 7, false);
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
        if (!wallJumping)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        
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
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, wallJumpCheckRadius, whatIsGround);

        if (isTouchingFront && !isGrounded && moveInput != 0 && hasWallJump)
        {
            wallSliding = true;
            spriteRenderer.flipX = true;
        }
        else
        {
            wallSliding = false;
            spriteRenderer.flipX = false;
        }

        if (wallSliding)
        {
            animator.SetBool("isSliding", true); 
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        if (!wallSliding)
        {
            animator.SetBool("isSliding", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isTouchingFront)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if(wallJumping)
        {
            
            if (moveInput == -1)
            {
                moveDirection = -1;
            }
            else if (moveInput == 1)
            {
                moveDirection = 1; 
            }
            else if (moveInput == 0)
            {
                if (transform.eulerAngles == new Vector3(0, 0, 0))
                {
                    moveDirection = 1;
                }
                else if (transform.eulerAngles == new Vector3(0, 180, 0))
                {
                    moveDirection = -1;
                }
            }
             
            rb.velocity = new Vector2(xWallForce * -moveDirection, yWallForce);
            animator.SetTrigger("wallJump");
            Debug.Log(moveInput);
            
        }

        if (totalJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            
            if (hasDoubleJump && totalJumps == 1 )
            {
                animator.SetTrigger("doubleJump");
            }
            if (!wallSliding)
            {
                totalJumps--;
                isJumping = true;

                //Debug.Log("Jump");
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }
            
            
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

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
    private IEnumerator Dash()
    {
        if (hasDash)
        {
            animator.SetTrigger("Dash");
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
            yield return new WaitForSeconds(iFrameDuration / noOfFlashes * 2);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / noOfFlashes * 2);
        }
        Physics2D.IgnoreLayerCollision(8, 7, false);
    }
}
