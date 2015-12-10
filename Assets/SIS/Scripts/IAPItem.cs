/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Soomla;
using Soomla.Store;

namespace SIS
{
    /// <summary>
    /// shop item properties, this class basically stores all
    /// necessary variables for visualizing a product in your shop UI 
    /// </summary>
    public class IAPItem : MonoBehaviour
    {
        /// <summary>
        /// ID of the product
        /// </summary>
        [HideInInspector]
        public string productId;

        /// <summary>
        /// product name
        /// </summary>
        public Text title;

        /// <summary>
        /// product description
        /// </summary>
        public Text description;

        /// <summary>
        /// boolean for setting all labels to uppercase
        /// </summary>
        public bool uppercase = false;

        /// <summary>
        /// icon sprite variable
        /// </summary>
        public Image icon;

        /// <summary>
        /// price label, displaying real money or currency costs
        /// </summary>
        public Text price;

        /// <summary>
        /// buy button that invokes the actual purchase
        /// </summary>
        public GameObject buyButton;

        /// <summary>
        /// buy trigger, used for making the buy button visible
        /// (optional - can be used for 'double tap to purchase')
        /// </summary>
        public GameObject buyTrigger;

        /// <summary>
        /// label that displays text while this item is locked
        /// </summary>
        public Text lockedLabel;

        /// <summary>
        /// widgets that will be de-activated when unlocking this item
        /// </summary>
        public GameObject[] hideOnUnlock;

        /// <summary>
        /// widgets that will be activated when unlocking this item
        /// </summary>
        public GameObject[] showOnUnlock;

        /// <summary>
        /// additional widgets that will be activated on sold items
        /// </summary>
        public GameObject sold;

        /// <summary>
        /// additional widgets that will be activated on equipped items
        /// </summary>
        public GameObject selected;

        /// <summary>
        /// button for equipping this item
        /// </summary>
        public GameObject selectButton;

        /// <summary>
        /// button for unequipping this item
        /// </summary>
        public GameObject deselectButton;

        //selection checkbox, cached for triggering other checkboxes
        //in the same group on selection/deselection
        private Toggle selCheck;

        /// <summary>
        /// type of in app purchase for this item
        /// </summary>
        [HideInInspector]
        public IAPType type = IAPType.SingleUseVG;


        //set up delegates and selection checkboxes
        void Start()
        {
            //if a selection of this item is possible
            if (selectButton)
            {
                //get checkbox component
                selCheck = selectButton.GetComponent<Toggle>();

                if (selCheck) selCheck.group = transform.parent.GetComponent<ToggleGroup>();
            }
        }


        //if we have a possible purchase confirmation set up or pending,
        //hide the buy button when disabling this item to reset it
        void OnDisable()
        {
            if (buyTrigger)
                ConfirmPurchase(false);
        }


        /// <summary>
        /// initialize virtual or real item properties
        /// based on IAPObject info set in IAP Settings editor.
        /// Called by ShopManager
        /// </summary>
        public void Init(IAPObject prod)
        {
            //cache
            type = prod.type;
            string name = prod.title;
            string descr = prod.description.Replace("\\n", "\n");
            string lockText = prod.req.labelText;

            //store the item id for later purposes
            productId = prod.id;
            //set icon to the matching sprite
            if (icon) icon.sprite = prod.icon;

            //when 'uppercase' has been checked,
            //convert title and description text to uppercase,
            //otherwise just keep and set them as they are
            if (uppercase)
            {
                name = name.ToUpper();
                descr = descr.ToUpper();
                lockText = lockText.ToUpper();
            }

            //set descriptive labels
            if (title) title.text = name;
            if (description) description.text = descr;
            
            //set price value
            if (IAPManager.IsMarketItem(productId))
                price.text = prod.realPrice.ToString();
            else if (!string.IsNullOrEmpty(prod.virtualPrice.name))
                price.text = prod.virtualPrice.amount.ToString();

            //set locked label text in case a requirement has been set
            if (lockedLabel && !string.IsNullOrEmpty(prod.req.entry)
                && !string.IsNullOrEmpty(prod.req.labelText))
                lockedLabel.text = lockText;
        }


        /// <summary>
        /// overwrite real money item properties with online data
        /// Called by ShopManager
        /// </summary>
        public void Init(MarketItem prod)
        {
            //cache
            string name = prod.MarketTitle;
            string descr = prod.MarketDescription.Replace("\\n", "\n");
            
            //normally, the online item name received from Google or Apple
            //has the application name attached, so we exclude that here
            int cap = name.IndexOf("(");
            if (cap > 0)
                name = name.Substring(0, cap - 1);

            //when 'uppercase' has been checked,
            //convert title and description text to uppercase,
            //otherwise just keep and set them as they are
            if (uppercase)
            {
                name = name.ToUpper();
                descr = descr.ToUpper();
            }

            if (title) title.text = name;
            if (description) description.text = descr;

            price.text = prod.MarketPriceAndCurrency;
        }


        /// <summary>
        /// unlocks this item by hiding the 'locked' gameobject
        /// and setting up the default state. Called by ShopManager
        /// </summary>
        public void Unlock()
        {
            for (int i = 0; i < hideOnUnlock.Length; i++)
                hideOnUnlock[i].SetActive(false);

            for (int i = 0; i < showOnUnlock.Length; i++)
                showOnUnlock[i].SetActive(true);
        }


        /// <summary>
        /// show the buy button based on the bool passed in.
        /// This simulates 'double tap to purchase' behavior,
        /// and only works when setting a buyTrigger button
        /// </summary>
        public void ConfirmPurchase(bool selected)
        {
            if (!selected)
                buyButton.SetActive(false);
        }


        /// <summary>
        /// when the buy button has been clicked, here we try to purchase this item
        /// maps to the corresponding purchase methods of IAPManager
        /// </summary>
        public void Purchase()
        {
            IAPManager.PurchaseProduct(productId);

            //hide buy button once a purchase was made
            //only when an additional buy trigger was set
            if (buyTrigger)
                ConfirmPurchase(false);
        }


        /// <summary>
        /// set this item to 'purchased' state
        /// </summary>
        public void Purchased()
        {
            //in case we restored an old purchase on a
            //locked item, we have to unlock it first
            Unlock();

            //activate the select button
            if (selectButton) selectButton.SetActive(true);

            //initialize variables for a good with upgrades
            bool hasUpgrade = false;
            string nextUpgrade = "";
            string goodId = productId;
            if (type == IAPType.UpgradeVG)
                goodId = (StoreInfo.GetItemByItemId(goodId) as UpgradeVG).GoodItemId;

            //in case this good has upgrades, here we find the next upgrade
            //and replace displayed item data in the store with its upgrade details
            UpgradeVG firstUpgrade = StoreInfo.GetFirstUpgradeForVirtualGood(goodId);
            if (firstUpgrade != null)
            {
                //find next upgrade id
                if (type != IAPType.UpgradeVG)
                    nextUpgrade = firstUpgrade.ItemId;
                else
                    nextUpgrade = (StoreInfo.GetItemByItemId(productId) as UpgradeVG).NextItemId;

                //this item has an upgrade left, replace its data
                if (!string.IsNullOrEmpty(nextUpgrade))
                {
                    hasUpgrade = true;
                    Init(IAPManager.GetIAPObject(nextUpgrade));
                }
            }

            //activate the sold gameobject
            if (sold) sold.SetActive(!hasUpgrade);

            //hide both buy trigger and buy button
            //don't hide the buy trigger/button if there is another upgrade to this item
            if (buyTrigger)
            {
                buyTrigger.SetActive(hasUpgrade);
                buyButton.SetActive(false);
            }
            else
                buyButton.SetActive(hasUpgrade);
        }


        /// <summary>
        /// handles selection state for this item, but this method
        /// gets called on other radio buttons within the same group too.
        /// Called by selectButton's Toggle component
        /// </summary>
        public void IsSelected(bool thisSelect)
        {
            //if this object has been selected
            if (thisSelect)
            {
                //equip this good
                string goodId = productId;
                if(type == IAPType.UpgradeVG)
                    goodId = (StoreInfo.GetItemByItemId(goodId) as UpgradeVG).GoodItemId;

                StoreInventory.EquipVirtualGood(goodId);

                //if we have a deselect button or a 'selected' gameobject, show them
                //and hide the select button for ignoring further selections              
                if (deselectButton) deselectButton.SetActive(true);
                if (selected) selected.SetActive(true);

                Toggle toggle = selectButton.GetComponent<Toggle>();
                if (toggle.group)
                {
                    //hacky way to deselect all other toggles, even deactivated ones
                    //(toggles on deactivated gameobjects do not receive onValueChanged events)
                    IAPItem[] others = toggle.group.GetComponentsInChildren<IAPItem>(true);
                    for (int i = 0; i < others.Length; i++)
                    {
                        if (others[i].selCheck.isOn && others[i] != this)
                        {
                            others[i].IsSelected(false);
                            break;
                        }
                    }
                }

                toggle.isOn = true;
                selectButton.SetActive(false);
            }
            else
            {
                //if another object has been selected, show the
                //select button for this item and hide the 'selected' state
                if (!deselectButton) selectButton.SetActive(true);
                if (selected) selected.SetActive(false);
            }
        }


        //called when deselecting this item via deselectButton
        public void Deselect()
        {
            //hide the deselect button and 'selected' state
            deselectButton.SetActive(false);
            if (selected) selected.SetActive(false);

            //tell our checkbox component that this object isn't checked
            if (selCheck) selCheck.isOn = false;
            //unequip this good
            StoreInventory.UnEquipVirtualGood(productId);
            //re-show the select button
            selectButton.SetActive(true);
        }
    }
}
