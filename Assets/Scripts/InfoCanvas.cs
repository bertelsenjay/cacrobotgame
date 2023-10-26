using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InfoCanvas : MonoBehaviour
{
    public bool wallJump = false;
    public bool doubleJump = false;
    public bool dash = false;
    public static bool wallJumpHide = false;
    public static bool doubleJumpHide = false;
    public static bool dashHide = false;
    public float hideDelay = 5f;
    private bool once = true;
    private void Update()
    {
        if (wallJump && wallJumpHide && once)
        {
            Invoke("SetInactive", hideDelay);
            once = false;
        }
        if (doubleJump && doubleJumpHide && once)
        {
            Invoke("SetInactive", hideDelay);
            once = false;
        }
        if (dash && dashHide && once)
        {
            Invoke("SetInactive", hideDelay);
            once = false;
        }
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
