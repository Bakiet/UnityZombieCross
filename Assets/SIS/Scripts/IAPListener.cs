/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;
using Soomla;
using Soomla.Store;
using SIS;

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
		/// 
		/// game_master my_game_master;
		/// 
        public bool debug;

		//game_master my_game_master;

		private game_uGUI my_game_uGUI; 


        //subscribe to the most important IAP events
        void OnEnable()
        {
			GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
			if(gui != null){
				my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
				
			}

		
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
			GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
			if(gui != null){
				my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
				
			}



			//my_game_master = (game_master)game_master.game_master_obj.GetComponent("game_master");
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
					my_game_uGUI.Update_virtual_money(1000);
                    ShopManager.ShowMessage("1000 coins were added to your balance!");

                    //you could also get the information from the VirtualItem directly:
                    /*
                    ShopManager.ShowMessage((virtualItem as VirtualCurrencyPack).CurrencyAmount +
                                " " + (virtualItem as VirtualCurrencyPack).CurrencyItemId +
                                " were added to your balance!");
                    */
                    break;
                case "coin_pack":
					my_game_uGUI.Update_virtual_money(2500);
                    ShopManager.ShowMessage("2500 coins were added to your balance!");
                    break;
                case "big_coin_pack":
					my_game_uGUI.Update_virtual_money(6000);
                    ShopManager.ShowMessage("6000 coins were added to your balance!");
                    break;
                case "huge_coin_pack":
					my_game_uGUI.Update_virtual_money(12000);
                    ShopManager.ShowMessage("12000 coins were added to your balance!");
                    break;
				case "rich_coin_pack":
					my_game_uGUI.Update_virtual_money(24000);
					ShopManager.ShowMessage("24000 coins were added to your balance!");
					break;
				case "millionaire_coin_pack":
					my_game_uGUI.Update_virtual_money(48000);
					ShopManager.ShowMessage("48000 coins were added to your balance!");
					break;
				case "no_ads":
					ShopManager.ShowMessage("Ads disabled!");
	                    break;
                case "abo_monthly":
                    ShopManager.ShowMessage("Subscribed to monthly abo!");
                    break;

                //section for in game content
                //items section
               
                case "health":					
				my_game_uGUI.Update_lives(5);
			
				ShopManager.ShowMessage("A pack of 5 lives added to your inventory!");

				break;
				case "healthx2":
				my_game_uGUI.Update_lives(10);
				ShopManager.ShowMessage("A pack of 10 lives added to your inventory!");

					break;
				case "healthx3":
				my_game_uGUI.Update_lives(15);
				ShopManager.ShowMessage("A pack of 15 lives added to your inventory!");
					break;
			case "hell_bike":
					ShopManager.ShowMessage("Speed boost bought!");
                    break;
			case "neon_bike":
				ShopManager.ShowMessage("Speed boost bought!");
				break;
			case "monster_bike":
				ShopManager.ShowMessage("Speed boost bought!");
				break;
			case "nightmare_bike":
				ShopManager.ShowMessage("Speed boost bought!");
				break;
			case "party_bike":
				ShopManager.ShowMessage("Speed boost bought!");
				break;
			case "super_bike":
				ShopManager.ShowMessage("Speed boost bought!");
				break;
			case "bike":
				ShopManager.ShowMessage("Speed boost bought!");
				break;
				
			case "hell_upgrade_level_3":
			case "hell_upgrade_level_2":
			case "hell_upgrade_level_1":
			case "neon_upgrade_level_3":
			case "neon_upgrade_level_2":
			case "neon_upgrade_level_1":
			case "monster_upgrade_level_3":
			case "monster_upgrade_level_2":
			case "monster_upgrade_level_1":
			case "nightmare_upgrade_level_3":
			case "nightmare_upgrade_level_2":
			case "nightmare_upgrade_level_1":
			case "party_upgrade_level_3":
			case "party_upgrade_level_2":
			case "party_upgrade_level_1":
			case "super_upgrade_level_3":
			case "super_upgrade_level_2":
			case "super_upgrade_level_1":
			case "bike_upgrade_level_3":
			case "bike_upgrade_level_2":
			case "bike_upgrade_level_1":
				ShopManager.ShowMessage("upgraded!");
                    break;

       
			case "blue_bike":
				ShopManager.ShowMessage("Blue bike unlocked!");
                    break;
			case "peace_bike":
				ShopManager.ShowMessage("Backpack unlocked!");
                    break;
			case "summer_bike":
				ShopManager.ShowMessage("Ammo belt unlocked!");
                    break;
			case "sunshine_bike":
				ShopManager.ShowMessage("Jetpack unlocked!");
                    break;


			case "hell_effect":
				ShopManager.ShowMessage("Jetpack unlocked!");
				break;
			case "neon_effect":
				ShopManager.ShowMessage("Jetpack unlocked!");
				break;
			case "monster_effect":
				ShopManager.ShowMessage("Jetpack unlocked!");
				break;
			case "nightmare_effect":
				ShopManager.ShowMessage("Jetpack unlocked!");
				break;
			case "party_effect":
				ShopManager.ShowMessage("Jetpack unlocked!");
				break;
			case "super_effect":
				ShopManager.ShowMessage("Jetpack unlocked!");
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