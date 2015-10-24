/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

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
				ShopManager.ShowMessage("1000 coins to unlock items.");

                    //you could also get the information from the VirtualItem directly:
                    /*
                    ShopManager.ShowMessage((virtualItem as VirtualCurrencyPack).CurrencyAmount +
                                " " + (virtualItem as VirtualCurrencyPack).CurrencyItemId +
                                " were added to your balance!");
                    */
                    break;
				case "coin_pack":
				ShopManager.ShowMessage("2500 coins! saving of 10%");
                    break;
			case "big_coin_pack":
				ShopManager.ShowMessage("6000 coins! big saving of 20%");
                    break;
                case "huge_coin_pack":
				ShopManager.ShowMessage("12000 coins! huge saving of 30% ");
                    break;
			case "rich_coin_pack":
				ShopManager.ShowMessage("24000 coins! huge saving of 40%");
				break;
			case "millionaire_coin_pack":
				ShopManager.ShowMessage("48000 coins! huge saving of 50%");
				break;
                case "no_ads":
                    ShopManager.ShowMessage("Ads disabled!");
                    break;
             /*   case "abo_monthly":
                    ShopManager.ShowMessage("Subscribed to monthly abo!");
                    break;*/

                //section for in game content
                //items section
			case "health":
				ShopManager.ShowMessage("A pack of 5 lives");
                    break;
			case "healthx2":
				ShopManager.ShowMessage("A pack of 10 lives");
                    break;
			case "healthx3":
				ShopManager.ShowMessage("A pack of 15 lives");
                    break;
                case "bonus":
                    ShopManager.ShowMessage("Bonus level unlocked!");
                    break;

			case "smoke_effect_purple":
				ShopManager.ShowMessage("Push your bike with purple smoke");
				break;
			case "blood_effect":
				ShopManager.ShowMessage("Push your bike with zombie blood");
				break;
			case "fire_effect":
				ShopManager.ShowMessage("Push your bike with flame of fire ");
				break;
			case "ice_effect":
				ShopManager.ShowMessage("Push your bike with frozen ice");
				break;
			case "electric_effect":
				ShopManager.ShowMessage("Push your bike with electric ray");
				break;
			case "wave_effect":
				ShopManager.ShowMessage("BPush your bike with power wave");
				break;
			case "neon_effect":
				ShopManager.ShowMessage("Push your bike with neon glow");
				break;
             /*   case "speed":
                    ShopManager.ShowMessage("Speed boost bought!");
                    break;
                case "speed_up1":
                case "speed_up2":
                case "speed_up3":
                    ShopManager.ShowMessage("Speed boost upgraded!");
                    break;*/

                //armory section
			case "bike":
                    ShopManager.ShowMessage("Bike unlocked!");
                    break;
			case "super_bike":
				ShopManager.ShowMessage("Super bike unlocked!");
                    break;
			case "party_bike":
				ShopManager.ShowMessage("Nightmare bike unlocked!");
				break;
			case "nightmare_bike":
				ShopManager.ShowMessage("Nightmare bike unlocked!");
                    break;

                //customize section
			case "hell_bike":
				ShopManager.ShowMessage("Hell bike unlocked!");
                    break;
			case "monster_bike":
				ShopManager.ShowMessage("Brutal bike unlocked!");
                    break;
			case "neon_bike":
				ShopManager.ShowMessage("Neon bike unlocked!");
                    break;

			case "test_bike":
				ShopManager.ShowMessage("Neon bike unlocked!");
				break;

            }
        }


        // called the first time your app launches.
        // use this method to predefine items according to your game logic
        void HandleFirstStart()
        {
            if (debug) Debug.Log("IAPListener: Game started for the first time.");

            //we should start with the pistol equipped already
            StoreInventory.EquipVirtualGood("bike");
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