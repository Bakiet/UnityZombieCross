/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Soomla;
using Soomla.Store;

namespace SIS
{
    /// <summary>
    /// instantiates & initializes shop items in the scene,
    /// unlocks/locks and equips shop items based on previous purchases/selections.
    /// </summary>
    public class ShopManager : MonoBehaviour
    {
        //static reference of this script
        private static ShopManager instance;
		
        /// <summary>
        /// window for showing feedback on IAPListener events to the user
        /// </summary>
        public GameObject errorWindow;
        /// <summary>
        /// text component of the errorWindow gameobject
        /// </summary>
        public Text message;

        /// <summary>
        /// store the relation between an IAP Group set in the IAP Settings Editor and its
        /// "parent" transform. This is because IAP Manager is a prefab that exists during
        /// scene changes, thus can't keep scene-specific data like transforms. 
        /// </summary>
        [HideInInspector]
        public List<Container> containers = new List<Container>();

        /// <summary>
        /// instantiated shop items, ordered by their ID
        /// </summary>
        public Dictionary<string, IAPItem> IAPItems = new Dictionary<string, IAPItem>();


        /// <summary>
        /// initialization called by IAP Manager in Awake()
        /// </summary>
        public void Init()
        {
            instance = this;

            InitShop();
            SetItemState();
            UnlockItems();
        }


        /// <summary>
        /// if there is no IAP Manager in the scene,
        /// Shop Manager will try to instantiate the prefab
        /// </summary>
        void Start()
        {
            if (!IAPManager.GetInstance())
            {
                Debug.LogWarning("ShopManager: Could not find IAP Manager prefab. Have you placed it in the first scene "
                               + "of your app and started from there? Instantiating copy.");
                GameObject obj = Instantiate(Resources.Load("IAP Manager", typeof(GameObject))) as GameObject;
                //remove clone tag from its name. not necessary, but nice to have
                obj.name = obj.name.Replace("(Clone)", "");
            }
        }
		

        /// <summary>
        /// returns a static reference to this script
        /// </summary>
        public static ShopManager GetInstance()
        {
            return instance;
        }


        //instantiates shop item prefabs
        void InitShop()
        {

            //reset
            IAPItems.Clear();

            //get list of all shop groups from IAPManager
            List<IAPGroup> list = IAPManager.GetIAPs();
            int index = 0;

            //loop over groups
            for (int i = 0; i < list.Count; i++)
            {
                //cache current group
                IAPGroup group = list[i];
                Container container = GetContainer(group.id);

                //skip group if prefab or parent wasn't set
                if (container == null || container.prefab == null || container.parent == null)
                {
                    //Debug.LogWarning("Setting up Shop, but prefab or parent of Group: '"
                    //                 + group.name + "' isn't set. Skipping group.");
                    continue;
                }

                //loop over items
                for (int j = 0; j < group.items.Count; j++)
                {
                    //cache item
                    IAPObject obj = group.items[j];
                    //instantiate shop item in the scene and attach it to the defined parent transform
                    GameObject newItem = (GameObject)Instantiate(container.prefab);
                    newItem.transform.SetParent(container.parent, false);
                    newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    //rename item to force ordering as set in the IAP Settings editor
                    newItem.name = "IAPItem " + string.Format("{0:000}", index + j);
                    //get IAPItem component of the instantiated item
                    IAPItem item = newItem.GetComponent<IAPItem>();
                    if (item == null) continue;

                    //add IAPItem to dictionary for later lookup
                    IAPItems.Add(obj.id, item);

                    //upgrades overwrite, an IAP Item gets replaced with its current level
                    List<UpgradeVG> upgrades = StoreInfo.GetUpgradesForVirtualGood(obj.id);
                    if (upgrades != null && upgrades.Count > 0)
                    {
                        for (int k = 0; k < upgrades.Count; k++)
                            IAPItems.Add(IAPManager.GetIAPObject(upgrades[k].ItemId).id, item);

                        string currentUpgrade = "";
                        if (obj.type != IAPType.VirtualCurrencyPack)
                            currentUpgrade = StoreInventory.GetGoodCurrentUpgrade(obj.id);

                        if (!string.IsNullOrEmpty(currentUpgrade))
                            obj = IAPManager.GetIAPObject(currentUpgrade);
                    }
                   
                    //initialize and set up item properties based on the associated IAPObject
                    //they could get overwritten by online data later
                    item.Init(obj);
                }

                index += group.items.Count;
            }
        }


        /// <summary>
        /// sets up shop items based on previous purchases, meaning we
        /// set them to 'purchased' thus not purchasable in the UI.
        /// Also equip the items that were equipped by the player before
        /// </summary>
        public static void SetItemState()
        {
            //get array of purchased item ids, look them up in our
            //shop item dictionary and set them to purchased
            string[] allPurchased = IAPManager.GetAllPurchased();
            for (int i = 0; i < allPurchased.Length; i++)
            {
                if (instance.IAPItems.ContainsKey(allPurchased[i]))
                    instance.IAPItems[allPurchased[i]].Purchased();
            }

            //get array of equipped item ids, look them up in our
            //shop item dictionary and set the checkbox component to selected
            string[] allEquipped = IAPManager.GetAllEquipped();
            for (int i = 0; i < allEquipped.Length; i++)
                if (instance.IAPItems.ContainsKey(allEquipped[i]))
                    instance.IAPItems[allEquipped[i]].IsSelected(true);
        }


        /// <summary>
        /// unlocks items if the requirement for them has been met. You can
        /// call this method at runtime whenever the player made some
        /// progress, to ensure your shop items reflect the current state
        /// </summary>
        public static void UnlockItems()
        {
            //get list of all shop groups from IAPManager
            List<IAPGroup> list = IAPManager.GetIAPs();

            //loop over groups
            for (int i = 0; i < list.Count; i++)
            {
                //cache current group
                IAPGroup group = list[i];

                //loop over items
                for (int j = 0; j < group.items.Count; j++)
                {
                    //cache IAP object
                    IAPObject obj = group.items[j];
                    if (obj.req == null) continue;

                    //cache reference to IAP item instance
                    IAPItem item = GetIAPItem(obj.id);

                    //check if the item reference is empty or set to purchased already
                    if (item == null || obj.type == IAPType.VirtualCurrencyPack ||
                        StoreInventory.GetItemBalance(obj.id) > 0) continue;

                    //check if a requirement is set up for this item,
                    //then unlock if the requirement has been met
                    if (!string.IsNullOrEmpty(obj.req.entry) &&
                        IAPManager.IsRequirementMet(obj.req))
                    {
						if(StoreInventory.GetItemBalance(obj.req.entry)<=0 && item.productId == obj.req.entry + "_upgrade")
						{
							//still lock
						}
						else{
							item.Unlock();
						}
                    }
                }
            }
        }


        /// <summary>
        /// method for overwriting shop item's properties with online IAP data
        /// from Google's or Apple's servers (those in the developer console).
        /// When we receive the online item list of products from IAPManager,
        /// we loop over our products and check if 'Fetch' was checked in the
        /// IAP Settings editor, then simply reinitialize the items with new info
        /// </summary>
        public static void OverwriteWithFetch(List<MarketItem> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                string id = IAPManager.GetIAPIdentifier(products[i].ProductId);
                IAPObject item = IAPManager.GetIAPObject(id);
                if (item != null && item.fetch && instance.IAPItems.ContainsKey(id))
                    instance.IAPItems[id].Init(products[i]);
            }
        }


        //show feedback/error window with text received through an event:
        //this gets called in IAPListener's HandleSuccessfulPurchase method with some feedback,
        //or automatically with the error when a purchase failed 
        public static void ShowMessage(string text)
        {
            if (!GetInstance() || !instance.errorWindow) return;

            if(instance.message) instance.message.text = text;
            instance.errorWindow.SetActive(true);
        }


        /// <summary>
        /// returns IAPItem shop item reference
        /// </summary>
        public static IAPItem GetIAPItem(string id)
        {
            if (instance.IAPItems.ContainsKey(id))
                return instance.IAPItems[id];
            else
                return null;
        }


        /// <summary>
        /// returns container for a specific group id
        /// </summary>
        public Container GetContainer(string id)
        {
            for (int i = 0; i < containers.Count; i++)
            {
                if (containers[i].id.Equals(id))
                    return containers[i];
            }
            return null;
        }
    }


    /// <summary>
    /// correlation between IAP group
    /// and scene-specific properties
    /// </summary>
    [System.Serializable]
    public class Container
    {
        public string id;
        public GameObject prefab;
        public Transform parent;
    }
}