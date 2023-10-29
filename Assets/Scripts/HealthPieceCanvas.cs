using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPieceCanvas : MonoBehaviour
{
    public GameObject healthPieceCanvas;
    public static bool showHealthPieceCanvas = false;
    public float hideCanvasDelay = 2.5f; 

    private void Start()
    {
        healthPieceCanvas = GameObject.Find("HealthPiecePopup");
        healthPieceCanvas.SetActive(false);
    }

    private void Update()
    {
        if (showHealthPieceCanvas)
        {
            showHealthPieceCanvas = false;
            healthPieceCanvas.SetActive(true);
            Invoke("HideCanvas", hideCanvasDelay);
        }
    }

    public void HideCanvas()
    {
        healthPieceCanvas.SetActive(false);
    }
}
