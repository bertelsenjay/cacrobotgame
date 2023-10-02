using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Map : MonoBehaviour
{

    Canvas canvas;
    [SerializeField] private CanvasGroup myUIGRoup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    [SerializeField] private float fadeInSpeed;
    [SerializeField] private float fadeOutSpeed;
    [SerializeField] private float resetDelay; 
    public bool isMap; 
    // Start is called before the first frame update
    void Start()
    {

        canvas = GetComponent<Canvas>();
        HideUIStart();
    }

    // Update is called once per frame
    void Update()
    {

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
            if (myUIGRoup.alpha >= 0)
            {
                myUIGRoup.alpha -= (Time.deltaTime * fadeOutSpeed);
                if (myUIGRoup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.M) && isMap)
        {
            

            ShowUI();
        }
        if (Input.GetKeyUp(KeyCode.M) && isMap)
        {
            
            HideUI();
        }

        if (PlayerMovement.gotHitByTrap && !isMap)
        {
            
            ShowUI();
            ResetTrapHit();
            Invoke("HideUI", resetDelay);
            //Invoke("ResetTrapHit", resetDelay + 1);
        }
    }

    public void ShowUI()
    {
        fadeIn = true;
        
    }

    public void HideUI()
    {
        fadeOut = true;
         
    }

    public void HideUIStart()
    {
        myUIGRoup.alpha = 0f; 
    }

    public void ResetTrapHit()
    {
        PlayerMovement.gotHitByTrap = false;
    }
    /*public void FadeIn()
    {
        if (fadeIn)
        {
            if (myUIGRoup.alpha < 1)
            {
                myUIGRoup.alpha += Time.deltaTime;
                if (myUIGRoup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }

    public void FadeOut()
    {
        if (fadeOut)
        {
            if (myUIGRoup.alpha >= 0)
            {
                myUIGRoup.alpha -= Time.deltaTime;
                if (myUIGRoup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }*/
}
