/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;
using Soomla.Store;

namespace SIS_Demo
{
    /// <summary>
    /// spawns the character based on selections in the shop
    /// </summary>
    public class GameHandler : MonoBehaviour
    {
        /// <summary>
        /// spawn position for the character
        /// </summary>
        public Transform spawnPos;

        /// <summary>
        /// death zone object reference
        /// </summary>
        public Transform deathZone;

        /// <summary>
        /// reference to all character prefabs
        /// </summary>
        public GameObject[] characters;


        //equips the correct/selected character
        IEnumerator Start()
        {
            //wait one frame, because SOOMLA initializes itself in Start()
            yield return new WaitForEndOfFrame();

            //this code runs after SOOMLA has been initialized
            //set selected character to the first one by default
            GameObject selectedChar = characters[0];

            //check for other character selections in the storage
            if (StoreInventory.IsVirtualGoodEquipped("box_teal"))
                selectedChar = characters[1];
            else if (StoreInventory.IsVirtualGoodEquipped("box_yellow"))
                selectedChar = characters[2];
            else if (StoreInventory.IsVirtualGoodEquipped("box_pink"))
                selectedChar = characters[3];
            else
            {
                //we didn't select a character yet, meaning this app runs for the first time
                //give and equip the white box by default and refresh shop
                StoreInventory.GiveItem("box_white", 1);
                StoreInventory.EquipVirtualGood("box_white");
                SIS.ShopManager.SetItemState();
            }

            //instantiate the selected character in the game and set death zone reference
            GameObject character = (GameObject)Instantiate(selectedChar, spawnPos.position, Quaternion.identity);
            deathZone.GetComponent<FollowAxis>().target = character.transform;

            //initialize game variables
            GetComponent<DemoManager>().Init();
        }
    }
}
