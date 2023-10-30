using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject tutorialCanvas;

    private void Start()
    {
        tutorialCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tutorialCanvas.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tutorialCanvas.SetActive(false);
    }
}
