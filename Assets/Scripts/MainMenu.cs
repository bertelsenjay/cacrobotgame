using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Canvas confirmationCanvas;
    public Canvas newGameCanvas; 
    private void Start()
    {
        confirmationCanvas.enabled = false;
        newGameCanvas.enabled = false;
    }
    public void NewGame()
    {
        Debug.Log("New game created");
    }

    public void Continue()
    {
        Debug.Log("Continuing"); 
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void ShowNewGameConfirmation()
    {
        newGameCanvas.enabled = true; 
    }

    public void CancelNewGameConfirmation()
    {
        newGameCanvas.enabled = false;
    }

    public void ShowConfirmation()
    {
        confirmationCanvas.enabled = true;
        Debug.Log("Confirmation Shown");
    }

    public void CancelConfirmation()
    {
        confirmationCanvas.enabled = false; 
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }
}
