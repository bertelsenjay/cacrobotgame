using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        WeaponUpgrade,
        HeartPiece1,
        HeartPiece2,
        Light

    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.WeaponUpgrade: return 150;
            case ItemType.HeartPiece1: return 25;
            case ItemType.HeartPiece2: return 75;
            case ItemType.Light: return 100; 

        }
    }
}
