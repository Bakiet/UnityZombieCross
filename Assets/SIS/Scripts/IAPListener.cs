/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;
using Soomla;
using Soomla.Store;

namespace SIS
{
    /// <summary>
    /// script that listens to purchases and other IAP events,
    /// here we tell our game what to do when these events happen
    /// <summary>
    public class IAPListener : MonoBehaviour
    {
        /// <summary>
        /// whether this script should print debug messages
        /// </summary>
        public bool debug;


        //subscribe to the most important IAP events
        void OnEnable()
        {
            IAPManager.firstStartEvent += HandleFirstStart;
            StoreEvents.OnItemPurchased += HandleSuccessfulPurchase;
            StoreEvents.OnGoodEquipped += HandleItemEquipped;
            StoreEvents.OnGoodUnEquipped += HandleItemUnequipped;
            StoreEvents.OnGoodUpgrade += HandleItemUpgrade;
        }


        //unsubscribe from IAP events on destruction
        void OnDisable()
        {
            IAPManager.firstStartEvent -= HandleFirstStart;
            StoreEvents.OnItemPurchased -= HandleSuccessfulPurchase;
            StoreEvents.OnGoodEquipped -= HandleItemEquipped;
            StoreEvents.OnGoodUnEquipped -= HandleItemUnequipped;
            StoreEvents.OnGoodUpgrade -= HandleItemUpgrade;
        }


        /// <summary>
        /// handle purchases, for real money or ingame currency
        /// </summary>
        public void HandleSuccessfulPurchase(PurchasableVirtualItem virtualItem, string payload)
        {
            //get global identifier
            string id = IAPManager.GetIAPIdentifier(virtualItem.ItemId);
            if (debug) Debug.Log("IAPListener: HandleSuccessfulPurchase: " + id);

            //get instantiated shop item based on the IAP id
            IAPItem item = null;
            if (ShopManager.GetInstance())
                item = ShopManager.GetIAPItem(id);

            //if the purchased item was non-consumable,
            //additionally block further purchase of the shop item
            if (item != null && !IAPManager.GetIAPObject(id).isConsumable())
                item.Purchased();

            switch (id)
            {
                //section for in app purchases
                case "coins":
                    ShopManager.ShowMessage("1000 coins were added to your balance!");

                    //you could also get the information from the VirtualItem directly:
                    /*
                    ShopManager.ShowMessage((virtualItem as VirtualCurrencyPack).CurrencyAmount +
                                " " + (virtualItem as VirtualCurrencyPack).CurrencyItemId +
                                " were added to your balance!");
                    */
                    break;
                case "coin_pack":
                    ShopManager.ShowMessage("2500 coins were added to your balance!");
                    break;
                case "big_coin_pack":
                    ShopManager.ShowMessage("6000 coins were added to your balance!");
                    break;
                case "huge_coin_pack":
                    ShopManager.ShowMessage("12000 coins were added to your balance!");
                    break;
                case "no_ads":
                    ShopManager.ShowMessage("Ads disabled!");
                    break;
                case "abo_monthly":
                    ShopManager.ShowMessage("Subscribed to monthly abo!");
                    break;

                //section for in game content
                //items section
                case "bullets":
                    ShopManager.ShowMessage("Bullets were added to your inventory!");
                    break;
                case "health":
                    ShopManager.ShowMessage("Medikits were added to your inventory!");
                    break;
                case "energy":
                    ShopManager.ShowMessage("Energy was added to your inventory!");
                    break;
                case "bonus":
                    ShopManager.ShowMessage("Bonus level unlocked!");
                    break;
                case "speed":
                    ShopManager.ShowMessage("Speed boost bought!");
                    break;
                case "speed_up1":
                case "speed_up2":
                case "speed_up3":
                    ShopManager.ShowMessage("Speed boost upgraded!");
                    break;

                //armory section
                case "uzi":
                    ShopManager.ShowMessage("Uzi unlocked!");
                    break;
                case "ak47":
                    ShopManager.ShowMessage("AK47 unlocked!");
                    break;
                case "m4":
                    ShopManager.ShowMessage("M4 unlocked!");
                    break;

                //customize section
                case "hat":
                    ShopManager.ShowMessage("Hat unlocked!");
                    break;
                case "backpack":
                    ShopManager.ShowMessage("Backpack unlocked!");
                    break;
                case "belt":
                    ShopManager.ShowMessage("Ammo belt unlocked!");
                    break;
                case "jetpack":
                    ShopManager.ShowMessage("Jetpack unlocked!");
                    break;
                case "booster":
                    ShopManager.ShowMessage("Double XP unlocked!");
                    break;
            }
        }


        // called the first time your app launches.
        // use this method to predefine items according to your game logic
        void HandleFirstStart()
        {
            if (debug) Debug.Log("IAPListener: Game started for the first time.");

            //we should start with the pistol equipped already
            StoreInventory.EquipVirtualGood("pistol");
        }


        //called when a purchased shop item gets equipped
        void HandleItemEquipped(EquippableVG item)
        {
            if (debug) Debug.Log("IAPListener:  Equipped: " + item.ItemId);
        }


        //called when an equipped shop item gets unequipped
        void HandleItemUnequipped(EquippableVG item)
        {
            if (debug) Debug.Log("IAPListener: Unequipped: " + item.ItemId);
        }


        //called when a shop item gets upgraded
        void HandleItemUpgrade(VirtualGood good, UpgradeVG upgrade)
        {
            if (debug) Debug.Log("Upgraded: " + good.ItemId + " to " + upgrade.ItemId);
        }
    }
}