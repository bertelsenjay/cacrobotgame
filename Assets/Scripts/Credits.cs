using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Credits : MonoBehaviour
{
    public GameObject endButton;

    private void Start()
    {
        endButton.SetActive(false);
    }

    public void SetButtonActive()
    {
        endButton.SetActive(true); 
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
