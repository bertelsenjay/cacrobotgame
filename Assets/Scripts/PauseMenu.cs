using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Canvas canvas;
    LevelLoader levelLoader;
    [SerializeField] private CanvasGroup myUIGRoup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    [SerializeField] private float fadeInSpeed;
    [SerializeField] private float fadeOutSpeed;
    public static bool isPaused = false; 
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>(); 
        canvas = GetComponent<Canvas>();
        HideUIStart();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false && !UIShop.isEnabled)
        {
            canvas.enabled = true;
            ShowUI();
            Debug.Log(UIShop.isEnabled);
            //Debug.Log("Showing UI");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true && !UIShop.isEnabled)
        {
            canvas.enabled = false;
            HideUI();
           //Debug.Log("Hiding UI");
        }
        if (fadeIn)
        {
            canvas.enabled = true;
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
                    canvas.enabled = false;
                }
            }
        }

        if (myUIGRoup.alpha > 0)
        {
            //canvas.enabled = true;

        }
        else if (myUIGRoup.alpha == 0)
        {
            //canvas.enabled = false;
        }

        
        
    }

    public void LoadMainMenu()
    {
        levelLoader.LoadNextLevel(0);
    }

    public void ShowUI()
    {
        fadeIn = true;
        isPaused = true; 
        //Time.timeScale = 0f; 
    }

    public void HideUI()
    {
        fadeOut = true;
        isPaused = false;
        //Time.timeScale = 1f;
    }

    public void HideUIStart()
    {
        myUIGRoup.alpha = 0f;
    }
}
