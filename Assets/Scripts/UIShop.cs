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
    PlayerMovement playerMovement;
    public static bool hasPurchased1 = false;
    public static bool hasPurchased2 = false;
    public static bool hasPurchased3 = false;
    // 0 is Weapon Upgrade


    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerMovement = FindObjectOfType<PlayerMovement>(); 
        currentCurrency = publicCurrentCurrency; 
    }
    private void Start()
    {
        GetComponent<Canvas>().enabled = false; 

        if (hasPurchased1)
        {
            priceTexts[0].text = "Sold";
            buttons[0].GetComponent<Button>().interactable = false;
        }
        if (hasPurchased2)
        {
            priceTexts[1].text = "Sold";
            buttons[1].GetComponent<Button>().interactable = false;
        }
        if (hasPurchased3)
        {
            priceTexts[2].text = "Sold";
            buttons[2].GetComponent<Button>().interactable = false;
        }
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
    
    public void LoseMoneyOnDeath()
    {
        playerMovement.currentMoney -= 20;
        publicCurrentCurrency -= 20;
        if (currentCurrency < 0)
        {
            currentCurrency = 0;
        }
        if (publicCurrentCurrency < 0)
        {
            publicCurrentCurrency = 0;
        }
    }

    public void PurchaseItem()
    {
        switch (itemIndex)
        {
            case 0: // change static boolean
                if (playerMovement.currentMoney >= upgradePrices[0])
                {
                    playerMovement.currentMoney -= upgradePrices[0];
                    playerHealth.IncreasePublicHeartPieces();
                    priceTexts[0].text = "Sold";
                    buttons[0].GetComponent<Button>().interactable = false;
                }
                break;
            case 1:
                if (playerMovement.currentMoney >= upgradePrices[1])
                {
                    playerMovement.currentMoney -= upgradePrices[1];
                    playerHealth.IncreasePublicHeartPieces();
                    priceTexts[1].text = "Sold";
                    buttons[1].GetComponent<Button>().interactable = false;
                }
                break;
            case 2:
                if (playerMovement.currentMoney >= upgradePrices[2])
                {
                    playerMovement.currentMoney -= upgradePrices[2];
                    Enemy.hasUpgrade = true;
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
        currencyText.text = "$" + publicCurrentCurrency.ToString();
        
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
