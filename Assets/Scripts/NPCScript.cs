using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Rendering;

public class NPCScript : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public int chipRequiredIndex;
    public int chipNeeded; 
    bool hasCorrectChip;
    public string[] dialogue;
    public string[] dialogueWithChip; 
    
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
            if (dialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                PlayerMovement.isPanelEnabled = true;
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index] && !hasCorrectChip )
        {
            continueButton.SetActive(true);
        }
        if (dialogueText.text == dialogueWithChip[index] && hasCorrectChip)
        {
            continueButton.SetActive(true);
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
        else if (hasCorrectChip)
        {
            foreach (char letter in dialogueWithChip[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
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
        else if (index < dialogueWithChip.Length -1 && hasCorrectChip)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }
}
