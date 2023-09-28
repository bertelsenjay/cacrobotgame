using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    public int currentCurrency;
    public int itemIndex; 
    // 0 is Weapon Upgrade


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
    }

    public void PurchaseItem()
    {
        switch (itemIndex)
        {
            case 0: // change static boolean
                break;
        }
    }
}
