using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Rendering;

public class NPCScript : MonoBehaviour
{
    public bool isNPC = true;
    public bool isShop = true; 
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public int chipRequiredIndex;
    public int chipNeeded; 
    bool hasCorrectChip;
    bool hasSpokenWithChip = false;
    public string[] dialogue;
    public string[] dialogueWithChip;
    public string[] dialogueAfterChip; 
    
    private int index;
    public GameObject continueButton; 
    public float wordSpeed;
    public bool playerIsClose; 
    // Update is called once per frame
    void Update()
    {
        if (chipNeeded == 1 && PlayerMovement.hasChip1)
        {
            hasCorrectChip = true;
        }
        else if (chipNeeded == 2  && PlayerMovement.hasChip2)
        {
            hasCorrectChip = true;
        }
        else if (chipNeeded == 3 && PlayerMovement.hasChip3)
        {
            hasCorrectChip = true;
        }
        else if (chipNeeded == 4 && PlayerMovement.hasChip4)
        {

        }

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy && isNPC)
            {
                ZeroText();
                
            }
            else
            {
                if (isNPC)
                {
                    dialoguePanel.SetActive(true);
                    PlayerMovement.isPanelEnabled = true;
                    StartCoroutine(Typing());
                }

             }
            if (isShop)
            {
                OpenShopMenu();
            }
        }

        if (dialogueText.text == dialogue[index] && !hasCorrectChip )
        {
            continueButton.SetActive(true);
        }
        else if (dialogueText.text == dialogueWithChip[index] && hasCorrectChip)
        {
            continueButton.SetActive(true);
        }
        else if (dialogueText.text == dialogueAfterChip[index] && hasCorrectChip)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        PlayerMovement.isPanelEnabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }

    IEnumerator Typing()
    {
        if (!hasCorrectChip)
        {
            foreach (char letter in dialogue[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
        else if (hasCorrectChip && hasSpokenWithChip)
        {
            foreach (char letter in dialogueAfterChip[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
        else if (hasCorrectChip)
        {
            foreach (char letter in dialogueWithChip[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
            if (index >= dialogueWithChip.Length - 1)
            {
                hasSpokenWithChip = true;
            }
        }
        
    }
    public void NextLine()
    {
        continueButton.SetActive(false);
        if (index < dialogue.Length - 1 && !hasCorrectChip)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else if (index < dialogueAfterChip.Length - 1 && hasCorrectChip && hasSpokenWithChip)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else if (index < dialogueWithChip.Length -1 && hasCorrectChip && !hasSpokenWithChip)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            Debug.Log("Text zeroed");
            ZeroText();
        }
    }
    public void OpenShopMenu()
    {
        Debug.Log("Shop Opened");
        UIShop.isEnabled = true;
    }
}
