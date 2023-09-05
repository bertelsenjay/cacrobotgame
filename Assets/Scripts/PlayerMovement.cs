using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool hasDoubleJump = false;
    public static bool hasDash = false;
    public bool testDoubleJump = false; 
    private int totalJumps = 1; 

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

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        if (testDoubleJump)
        {
            hasDoubleJump = true; 
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
        if (isGrounded && hasDoubleJump && !isJumping)
        {
            totalJumps = 2;
            Debug.Log("Has double jump");
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
    }

}
