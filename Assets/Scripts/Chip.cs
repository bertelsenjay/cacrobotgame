using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Chip : MonoBehaviour
{
    public bool wallChip = false;
    public bool doubleJumpChip = false;
    public bool dashChip = false;
    public GameObject wallInfo;
    public GameObject doubleJumpInfo;
    public GameObject dashInfo;
    //public float inactiveDelay; 

    private void Start()
    {
        if (doubleJumpChip)
        {
            doubleJumpInfo = GameObject.Find("DoubleJumpInfo");
        }
        if (wallChip)
        {
            wallInfo = GameObject.Find("WallJumpInfo");
        }
        if (dashChip)
        {
            dashInfo = GameObject.Find("DashInfo");
        }
        
    }

    private void Update()
    {
        if (wallChip && PlayerMovement.hasWallJump)
        {
            Destroy(gameObject);
        }
        if (doubleJumpChip && PlayerMovement.hasDoubleJump)
        {
            Destroy(gameObject);
        }
        if (dashChip && PlayerMovement.hasDash)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (wallChip)
            {
                PlayerMovement.hasWallJump = true;
                SetCanvasActive(wallInfo);
                InfoCanvas.wallJumpHide = true; 
            }
            if (doubleJumpChip)
            {
                PlayerMovement.hasDoubleJump = true;
                SetCanvasActive(doubleJumpInfo);
                InfoCanvas.doubleJumpHide = true; 
            }
            if (dashChip)
            {
                PlayerMovement.hasDash = true;
                SetCanvasActive(dashInfo);
                InfoCanvas.dashHide = true; 
            }
            Destroy(gameObject);
        }
    }

    public void SetCanvasActive(GameObject canvas)
    {
        canvas.SetActive(true); 
    }

    public void SetCanvasInactive()
    {
        Debug.Log("Set inactive");
        if (wallChip)
        {
            wallInfo.SetActive(false);
        }
        if (doubleJumpChip)
        {
            doubleJumpInfo.SetActive(false);
        }
        if (dashChip)
        {
            dashInfo.SetActive(false);
        }
    }
}
