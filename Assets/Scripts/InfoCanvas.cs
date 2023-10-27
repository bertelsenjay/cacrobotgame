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
    [SerializeField] private CanvasGroup myUIGRoup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    [SerializeField] private float fadeInSpeed;
    [SerializeField] private float fadeOutSpeed;
    public static bool isShowingInfo = false; 

    private void Start()
    {
        HideUIStart();
    }
    private void Update()
    {
        if (wallJump && wallJumpHide && once)
        {
            ShowUI();
            Invoke("HideUI", hideDelay);
            once = false;
        }
        if (doubleJump && doubleJumpHide && once)
        {
            ShowUI();
            Invoke("HideUI", hideDelay);
            once = false;
        }
        if (dash && dashHide && once)
        {

            ShowUI();
            Invoke("HideUI", hideDelay);
            once = false;
        }

        if (fadeIn)
        {
            if (myUIGRoup.alpha < 1)
            {
                myUIGRoup.alpha += (Time.deltaTime * fadeInSpeed);
                if (myUIGRoup.alpha >= 1)
                {

                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            Debug.Log("Fading out");
            if (myUIGRoup.alpha >= 0)
            {
                myUIGRoup.alpha -= (Time.deltaTime * fadeOutSpeed);
                if (myUIGRoup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void HideUIStart()
    {
        myUIGRoup.alpha = 0f;
    }

    public void HideUI()
    {
        fadeOut = true; 
        isShowingInfo = false;
    }

    public void ShowUI()
    {
        fadeIn = true;
        isShowingInfo = true;
    }
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
