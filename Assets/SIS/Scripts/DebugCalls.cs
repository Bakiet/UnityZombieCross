/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SIS;
using Soomla;
using Soomla.Store;

/// <summary>
/// simple script that contains methods for testing purposes.
/// You shouldn't implement this script in production versions
/// <summary>
public class DebugCalls : MonoBehaviour
{
    /// <summary>
    /// clears storage variables
    /// </summary>
    public void Clear()
    {
        //allow first game start
        KeyValueStorage.DeleteKeyValue(IAPManager.firstStartKey);

        //unequip all
        string[] allEquipped = IAPManager.GetAllEquipped();
        for (int i = 0; i < allEquipped.Length; i++)
            StoreInventory.UnEquipVirtualGood(allEquipped[i]);

        //unpurchase all
        string[] allPurchased = IAPManager.GetAllPurchased();
        for (int i = 0; i < allPurchased.Length; i++)
        {
            int balance = 0;
		//	IAPManager.RestoreTransactions(true);
            try { balance = StoreInventory.GetItemBalance(allPurchased[i]); }
            catch (VirtualItemNotFoundException) { }

            if (balance > 0)
                StoreInventory.TakeItem(allPurchased[i], balance);
        }

        //remove currency
        List<IAPCurrency> currencies = IAPManager.GetCurrency();
        for (int i = 0; i < currencies.Count; i++)
        {
            int balance = 0;

            try { balance = StoreInventory.GetItemBalance(currencies[i].name); }
            catch (VirtualItemNotFoundException) { }

            if (balance > 0)
                StoreInventory.TakeItem(currencies[i].name, balance);
        }

        //restart all
        IAPManager.GetInstance().Start();
    }


    /// <summary>
    /// increases player level by 1
    /// and unlocks new shop items
    /// <summary>
    public void LevelUp()
    {
        //get current level
        int level = 0;
        string data = KeyValueStorage.GetValue("level");
        if (!string.IsNullOrEmpty(data))
            level = int.Parse(data);

        //increase level by 1 and set it
        level++;
        KeyValueStorage.SetValue("level", level.ToString());

        //refresh shop items
        if (ShopManager.GetInstance())
            ShopManager.UnlockItems();

        Debug.Log("Leveled up to level: " + level + "! Shop Manager tried to unlock new items.");
    }

}
