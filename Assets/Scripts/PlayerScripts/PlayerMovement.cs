using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{
    #region Global Variables
    public static bool isPanelEnabled = false; 
    public static bool hasDoubleJump = false;
    public static bool hasDash = false;
    public static bool hasWallJump = false;
    public static bool hasChip1 = false;
    public static bool hasChip2 = false;
    public static bool hasChip3 = false;
    public static bool hasChip4 = false;
    [Header("MovementUpgradeTests")]
    public bool testDoubleJump = false; 
    public bool testDash = false;  
    public bool testWallJump = false;
    public bool testChip1 = false;
    public bool testChip2 = false;
    public bool testChip3 = false;
    public bool testChip4 = false;
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
    public AudioClip dashSound;
    public float dashVolume = 0.6f;


    private SpriteRenderer spriteRenderer;
    [Header("IFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int noOfFlashes;
    public AudioClip getHitSound;
    public float getHitVolume;

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

    [Header("RespawnLocations")]
    public Transform[] locations;
    public static int index = 0;
    public float newPositionDelay = 0.5f; 
    public static bool gotHitByTrap = false; 

    public float wallJumpAnimDelay = 0.5f;

    int currentCurrency;

    public static int amountOfKeys = 0;
    public Transform respawnPoint;
    public static bool coroutineStart = false; 
    #endregion
    void Awake()
    {
        //UIShop shop = FindObjectOfType<UIShop>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        #region Test Variables
        if (testDoubleJump)
        {
            hasDoubleJump = true; 
            
        }
        else if (!testDoubleJump)
        {
            hasDoubleJump = false;
        }
        if (testDash)
        {
            hasDash = true;
        }
        else if (!testDash)
        {
            hasDash = false;
        }
        if (testWallJump)
        {
            hasWallJump = true;
        }
        else
        {
            hasWallJump = false;
        }
        
        if (testChip1)
        {
            hasChip1 = true;
        }
        else if (!hasChip1)
        {
            hasChip1 = false;
        }
        if (testChip2)
        {
            hasChip2 = true;
        }
        else if (!testChip2)
        {
            hasChip2 = false;
        }
        if (testChip3)
        {
            hasChip3 = true;
        }
        else if (!testChip3)
        {
            hasChip3 = false;
        }
        if (testChip4)
        {
            hasChip4 = true;
        }
        else if (!testChip4)
        {
            hasChip4 = false;
        }
        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (SavePoint.saveIndex)
        {
            case 0:
                if (SavePoint.hasSaved)
                {
                    if (transform.position != respawnPoint.position)
                    {
                        transform.position = respawnPoint.position;

                    }

                }
                break;
            case 1:
                if (SavePoint.hasSaved)
                {
                    transform.position = respawnPoint.position;
                }
                break;

            
        }
        Physics2D.IgnoreLayerCollision(8, 7, false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (InfoCanvas.isShowingInfo)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }
        if (UIShop.isEnabled) { return; }
        if (isPanelEnabled) { return;  }
        if (PauseMenu.isPaused) { return; }
        if (gotHitByTrap) { return; }
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
        Debug.Log("Is dead " + LevelLoader.isDead);
        Debug.Log("is showing info " + InfoCanvas.isShowingInfo);
        Debug.Log("shop is enabled " + UIShop.isEnabled);
        Debug.Log("is panel enabled " + isPanelEnabled);
        Debug.Log("is paused " + PauseMenu.isPaused);
        Debug.Log("Got hit by trap " + gotHitByTrap);
        Debug.Log("isDashing " + isDashing);
        if (LevelLoader.isDead)
        {
            animator.SetTrigger("isDead");
            LevelLoader.isDead = false;
            LevelLoader.localIsDead = true;
            Debug.Log("triggered");
            return; 
        }
        if (InfoCanvas.isShowingInfo) { return; }
        if (LevelLoader.isDead) { return; }
        if (UIShop.isEnabled) { return; }
        if (isPanelEnabled) { return; }
        if (PauseMenu.isPaused) { return; }
        if (gotHitByTrap) { return; }
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
        if(Input.GetKeyDown(KeyCode.Space) && isTouchingFront && hasWallJump)
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
            animator.SetBool("wallJump", true);
            Debug.Log(moveInput);
            Invoke("ResetToIdle", wallJumpAnimDelay);
        }

        if (totalJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            
            if (hasDoubleJump && totalJumps == 1 )
            {
                animator.SetTrigger("doubleJump");
                GetComponent<AudioSource>().PlayOneShot(dashSound, dashVolume);
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

        if (coroutineStart)
        {
            StartCoroutine(Invulnerability());
            coroutineStart = false; 
        }
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
    private IEnumerator Dash()
    {
        
        if (hasDash && !gotHitByTrap)
        {
            GetComponent<AudioSource>().PlayOneShot(dashSound, dashVolume);
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
            GetComponent<AudioSource>().PlayOneShot(getHitSound, getHitVolume);
            StartCoroutine(Invulnerability());
            playerHealth.health--;
        }

        if (collision.gameObject.tag == "Boss")
        {
            GetComponent<AudioSource>().PlayOneShot(getHitSound, getHitVolume);
            StartCoroutine(Invulnerability());
            playerHealth.health--;
        }

        if (collision.gameObject.tag == "Trap")
        {
            GetComponent<AudioSource>().PlayOneShot(getHitSound, getHitVolume);
            StartCoroutine(Invulnerability());
            playerHealth.health--;
            //SetNewPosition();
            Invoke("SetNewPosition", newPositionDelay);
            rb.velocity = Vector2.zero;
            gotHitByTrap = true; 
        }

        if (collision.gameObject.tag == "HeartPiece")
        {
            //HealthPieceCanvas.showHealthPieceCanvas = true;
            playerHealth.heartPieces++;
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Door")
        {
            if (amountOfKeys > 0)
            {
                Destroy(collision.gameObject);
                amountOfKeys--;
                
            }
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            GetComponent<AudioSource>().PlayOneShot(getHitSound, getHitVolume);
            StartCoroutine(Invulnerability());
            playerHealth.health--;
        }

        if (collision.gameObject.tag == "Killbox")
        {
            playerHealth.health = 0; 
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(Invulnerability());
            playerHealth.health--;
        }*/
        if (collision.gameObject.tag == "Chip")
        {
            Destroy(collision.gameObject);
            if (!hasChip1 && !hasChip2 && !hasChip3 && !hasChip4)
            {
                hasChip1 = true;
                Debug.Log("chip 1");
            }
            else if (hasChip1 && !hasChip2 && !hasChip3 && !hasChip4)
            {
                hasChip2 = true;
                Debug.Log("chip 2");
            }
            else if (hasChip1 && hasChip2 && !hasChip3 && !hasChip4)
            {
                hasChip3 = true;
                Debug.Log("chip 3");
            }
            else if (hasChip1 && hasChip2 && hasChip3 && !hasChip4)
            {
                hasChip4 = true;
                Debug.Log("chip 4");
            }
        }
        if (collision.gameObject.tag == "HeartPiece")
        {
            playerHealth.heartPieces++;
            Destroy(collision.gameObject);
        }
    }

    private void SetNewPosition()
    {
        transform.position = locations[index].position;
    }
    private IEnumerator Invulnerability()
    {
        Debug.Log("Starting iFrames");
        Physics2D.IgnoreLayerCollision(8, 7, true);
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 11, true);
        //PlayerHealth.healthLocked = true; 
        //Debug.Log(PlayerHealth.healthLocked);
        for (int i = 0; i < noOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / noOfFlashes * 2);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / noOfFlashes * 2);
        }
        Physics2D.IgnoreLayerCollision(8, 7, false);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 11, false);
        //PlayerHealth.healthLocked = false;
        //Debug.Log(PlayerHealth.healthLocked);
    }

    private void ResetToIdle()
    {
        animator.SetBool("wallJump", false);
    }
}
