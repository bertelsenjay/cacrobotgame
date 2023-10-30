using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    // comment
    Animator animator; 
    SpriteRenderer spriteRenderer;
    public float initialTimer = 0.2f;
    float timer;
    public float attackRate;
    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = initialTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (InfoCanvas.isShowingInfo) { return; }
        if (UIShop.isEnabled) { return; }
        if (PauseMenu.isPaused) { return; }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && timer < 0 && !PlayerMovement.isPanelEnabled)
            {
                nextAttackTime = Time.time + 1f / attackRate;
                spriteRenderer.enabled = true;
                animator.SetTrigger("Attack");
                timer = initialTimer;
            }
        }
        
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            spriteRenderer.enabled = false;
        }
    }
}
