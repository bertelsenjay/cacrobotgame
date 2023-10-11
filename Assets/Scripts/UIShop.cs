using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    public static bool isEnabled = false;
    
    public int currentCurrency;
    public static int publicCurrentCurrency = 0; 
    int itemIndex;
    public TextMeshProUGUI currencyText; 
    public GameObject[] buttons;
    public TextMeshProUGUI[] priceTexts;
    public int[] upgradePrices;
    PlayerHealth playerHealth;
    // 0 is Weapon Upgrade


    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        currentCurrency = publicCurrentCurrency; 
    }
    private void Start()
    {
        GetComponent<Canvas>().enabled = false; 
    }
    public void LoseCurrency(int amount)
    {
        if (currentCurrency - amount < 0)
        {
            return;
        }
        else if (currentCurrency - amount >= 0)
        {
            currentCurrency -= amount;
        }
    }
    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
        publicCurrentCurrency += amount; 
    }

    public void SetItemIndex(int index)
    {
        itemIndex = index;
    }

    public void PurchaseItem()
    {
        switch (itemIndex)
        {
            case 0: // change static boolean
                if (currentCurrency >= upgradePrices[0])
                {
                    currentCurrency -= upgradePrices[0];
                    playerHealth.heartPieces++;
                    priceTexts[0].text = "Sold";
                    buttons[0].GetComponent<Button>().interactable = false;
                }
                break;
            case 1:
                if (currentCurrency >= upgradePrices[1])
                {
                    currentCurrency -= upgradePrices[1];
                    playerHealth.heartPieces++;
                    priceTexts[1].text = "Sold";
                    buttons[1].GetComponent<Button>().interactable = false;
                }
                break;
            case 2:
                if (currentCurrency >= upgradePrices[2])
                {
                    currentCurrency -= upgradePrices[2];
                    PlayerMovement.amountOfKeys++;
                    priceTexts[2].text = "Sold";
                    buttons[2].GetComponent<Button>().interactable = false;
                }
                break;
        }
    }

    public void DebugButton()
    {
        Debug.Log("ButtonPressed");
    }

    public void CloseShopMenu()
    {
        isEnabled = false;
    }

    private void Update()
    {
        currencyText.text = "$" + currentCurrency.ToString();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("CloseShopMenu", 0.05f);
            //CloseShopMenu();
        }
        if (isEnabled)
        {
            if (GetComponent<Canvas>().enabled == true)
            {
                return;
            }
            GetComponent<Canvas>().enabled = true;
        }
        else if (!isEnabled)
        {
            GetComponent<Canvas>().enabled = false;
        }

    }
}
