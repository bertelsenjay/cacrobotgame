using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalChip : MonoBehaviour
{
    public GameObject winCanvas;
    public float loadCreditsDelay = 6f;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    

    private void Start()
    {
        winCanvas = GameObject.Find("FinalChipCanvas");
        winCanvas.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        InfoCanvas.isShowingInfo = true;
        winCanvas.SetActive(true);
        Invoke("LoadCredits", loadCreditsDelay);
        
    }

    public void LoadCredits()
    {
        InfoCanvas.isShowingInfo = false;
        SceneManager.LoadScene(6);
    }
}
