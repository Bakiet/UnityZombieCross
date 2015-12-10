/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Soomla;
using Soomla.Store;
using Grow.Highway;
using Grow.Sync;


namespace SIS
{
	/// <summary>
	/// SOOMLA IAP cross-platform wrapper for real money purchases,
	/// as well as for virtual ingame purchases (for virtual currency)
	/// </summary>
	public class IAPManager : MonoBehaviour
	{
		/// <summary>
		/// whether this script should print debug messages
		/// </summary>
		public bool debug;
		
        /// <summary>
        /// your server url for remote configurations
        /// </summary>
        public string serverUrl;

        /// <summary>
        /// type for processing remotely hosted configs
        /// </summary>
        public RemoteType remoteType = RemoteType.none;

        /// <summary>
        /// file name of your remotely hosted config file
        /// </summary>
        public string remoteFileName;

		/// <summary>
		/// static reference to this script
		/// </summary>
		private static IAPManager instance;

        /// <summary>
        /// object for downloading hosted configs
        /// </summary>
        private WWW request;

        #pragma warning disable 0414
        /// <summary>
		/// cached online product data
		/// </summary>
        private static List<MarketItem> inventory = new List<MarketItem>();
        #pragma warning restore 0414
        
        /// <summary>
		/// In app products, set in the IAP Settings editor
		/// </summary>
		[HideInInspector]
		public List<IAPGroup> IAPs = new List<IAPGroup>();

		/// <summary>
		/// list of virtual currency,
		/// set in the IAP Settings editor
		/// </summary>
		[HideInInspector]
		public List<IAPCurrency> currency = new List<IAPCurrency>();

		/// <summary>
		/// list of ingame content items,
		/// set in the IAP Settings editor
		/// </summary>
		[HideInInspector]
		public List<IAPGroup> IGCs = new List<IAPGroup>();

		/// <summary>
		/// dictionary of product ids,
		/// mapped to the corresponding IAPObject for quick lookup
		/// </summary>
		public Dictionary<string, IAPObject> IAPObjects = new Dictionary<string, IAPObject>();

        /// <summary>
        /// fired when the game starts for the first time
        /// </summary>
        public static event Action firstStartEvent;

        /// <summary>
        /// string value to look up in storage on first app start
        /// </summary>
        public const string firstStartKey = "SIS_firstStart";

        /// <summary>
        /// string value to look up for the remotely hosted config file
        /// </summary>
        public const string remoteKey = "SIS_remote";


        /// <summary>
        /// returns a static reference to this script
        /// </summary>
        public static IAPManager GetInstance()
        {
            return instance;
        }


		// initialize IAPs and subscribe to important events
		void Awake()
		{
			//make sure we keep one instance of this script in the game
			if (instance)
			{
				Destroy(gameObject);
				return;
			}
			DontDestroyOnLoad(this);

			//set static reference
			instance = this;
			//populate IAP dictionary and arrays with product ids
			InitIds();

			//map delegates to fire corresponding methods
            StoreEvents.OnUnexpectedStoreError += BillingNotSupported;
            StoreEvents.OnMarketItemsRefreshFinished += ProductDataReceived;
            StoreEvents.OnMarketPurchaseCancelled += PurchaseFailed;
            StoreEvents.OnRestoreTransactionsFinished += RestoreSucceeded;
		}


        /// <summary>
        /// Only public for testing, DO NOT call from somewhere else.
        /// Initializes SOOMLA components
        /// </summary>
        public void Start()
        {
            #if !UNITY_EDITOR
                KeyValueStorage.SetValue("soomla.referrer", "SimpleIAP");
                GrowHighway.Initialize();
            #endif

            //If you would like to initialize GrowSync too, do it here.
            //But don't forget to subscribe to the sync events for your own logic.
            //GrowSync.Initialize(modelSync, stateSync);

            KeyValueStorage.DeleteKeyValue("meta.storeinfo");
            SoomlaStore.Initialize(new IAPStoreAssets(this));

            //remote and shop managers
            FirstStart();
            StartCoroutine(RemoteDownload());
            OnLevelWasLoaded(-1);
        }


		/// <summary>
		/// initiate shop manager initialization on scene change
		/// </summary>
		public void OnLevelWasLoaded(int level)
		{
			if(instance != this)
				return;
			
			ShopManager shop = null;
			GameObject shopGO = GameObject.Find("Shop Manager");
			if (shopGO) shop = shopGO.GetComponent<ShopManager>();
			if (shop)
			{
				shop.Init();
				#if !UNITY_EDITOR
				    ShopManager.OverwriteWithFetch(inventory);
				#endif
			}
		}


		// unbind delegates on the active instance
		void OnDestroy()
		{
			if (instance != this)
				return;

            StoreEvents.OnUnexpectedStoreError -= BillingNotSupported;
            StoreEvents.OnMarketItemsRefreshFinished -= ProductDataReceived;
            StoreEvents.OnMarketPurchaseCancelled -= PurchaseFailed;
            StoreEvents.OnRestoreTransactionsFinished -= RestoreSucceeded;
        }


		// Initialize IAP ids:
		// populate IAP dictionary and arrays with product ids
		private void InitIds()
		{
			//create temporary list for all IAPGroups
            List<IAPGroup> idsList = GetIAPs();

			if(idsList.Count == 0)
				Debug.LogError("Initializing IAPManager, but IAP List is empty."
							   + " Did you set up IAPs in the IAP Settings?");

			//loop over all groups
			for (int i = 0; i < idsList.Count; i++)
			{
				//cache current group
				IAPGroup group = idsList[i];
				//loop over items in this group
				for (int j = 0; j < group.items.Count; j++)
				{
					//cache item
					IAPObject obj = group.items[j];
					if (String.IsNullOrEmpty(obj.id))
						Debug.LogError("Found IAP Object in IAP Settings without an ID."
									   + " This will cause errors during runtime.");

					//add this IAPObject to the dictionary of id <> IAPObject
					IAPObjects.Add(obj.id, obj);
				}
			}
		}


        // Initialize currency values on first start
        // and give the default amount specified in the IAP Settings editor
        void FirstStart()
        {
            if(!string.IsNullOrEmpty(KeyValueStorage.GetValue(firstStartKey)))
                return;

            for(int i = 0; i < currency.Count; i++)
                StoreInventory.GiveItem(currency[i].name, currency[i].amount);

            for (int i = 0; i < IGCs.Count; i++)
            {
                for (int j = 0; j < IGCs[i].items.Count; j++)
                {
                    if (IGCs[i].items[j].virtualPrice.amount <= 0)
                        StoreInventory.GiveItem(IGCs[i].items[j].id, 1);
                }
            }

            KeyValueStorage.SetValue(firstStartKey, "false");
            if (firstStartEvent != null)
                firstStartEvent();
        }


		// Once we've received the productList from App Stores,
        // we overwrite the existing shop item values with this online data
		private void ProductDataReceived(List<MarketItem> list)
		{
            //store fetched inventory for later access
            inventory = list;

            #if UNITY_ANDROID
                RestoreTransactions(false);
            #endif

			if (ShopManager.GetInstance())
				ShopManager.OverwriteWithFetch(list);
		}


		/// <summary>
		/// purchase product based on its product id.
		/// If the productId matches "restore", we restore transactions instead.
		/// Our delegates then fire the appropriate succeeded/fail event
		/// </summary>
		public static void PurchaseProduct(string productId)
		{
            if (productId == "restore")
                RestoreTransactions();
            else
            {
                try
                {
                    StoreInventory.BuyItem(productId);
                }
                catch (InsufficientFundsException)
                {
                    PurchaseFailed("Insufficient funds.");
                }
            }
		}


		/// <summary>
		/// restore already purchased user's transactions for non consumable IAPs.
		/// On Android this happens automatically so we just check for an inventory
		/// </summary>
		public static void RestoreTransactions(bool showPopup = true)
		{
			#if UNITY_IPHONE
                SoomlaStore.RestoreTransactions();
			#elif UNITY_ANDROID
				if(inventory == null)
					return;

                //convert list of market productIds received from Google
                List<string> fetched = new List<string>();
                for (int i = 0; i < inventory.Count; i++)
                    fetched.Add(inventory[i].ProductId);

                //remove purchased IAP products that are not returned by Google:
                //this actually means that they are expired or not purchased legally!
                for (int i = 0; i < instance.IAPs.Count; i++)
                {
                    for (int j = 0; j < instance.IAPs[i].items.Count; j++)
                    {
                        IAPObject obj = instance.IAPs[i].items[j];
                        if (obj.isConsumable()) continue;

                        int balance = StoreInventory.GetItemBalance(obj.id);
                        if (balance > 0 && !fetched.Contains(obj.GetIdentifier()))
                            StoreInventory.TakeItem(obj.id, balance);
                    }
                }

                if (showPopup) RestoreSucceeded(true);
			#endif      

			//update ShopManager GUI items
			if(ShopManager.GetInstance())
				ShopManager.SetItemState();
		}
		
		
        //initiates the download process of your remotely hosted
        //config file for virtual products. Differs between types:
        //cached: stores config on the device, changes on next bootup
        //overwrite: only preserves changes in the current session
        private IEnumerator RemoteDownload()
        {
            //build file url
            string url = serverUrl + remoteFileName;

            switch (remoteType)
            {
                case RemoteType.cached:
                    //load cached file string and overwrite virtual IAPs
                    LoadRemoteConfig();
                    //download new config
                    yield return StartCoroutine(Download(url));
                    //save downloaded file
                    SaveRemoteConfig(request.text);
                    break;
                case RemoteType.overwrite:
                    //download new config 
                    yield return StartCoroutine(Download(url));
                    //parse string and overwrite virtual IAPs
                    ConvertToIAPs(request.text);
                    break;
            }
        }


        /// <summary>
        /// loads the downloaded config file for virtual products on the device.
        /// IAP objects will be overwritten with new properties and
        /// changes will be visible after loading the shop scene.
        /// </summary>
        private void LoadRemoteConfig()
        {
            //skip without config file
            string data = KeyValueStorage.GetValue(remoteKey);
            if (string.IsNullOrEmpty(data))
                return;

            //overwrite existing properties
            ConvertToIAPs(data);
        }


        /// <summary>
        /// save remotely hosted, downloaded config file for virtual products.
        /// </summary>
        private void SaveRemoteConfig(string data)
        {
            KeyValueStorage.SetValue(remoteKey, data);
        }


        // downloads the remotely hosted config file
        private IEnumerator Download(string url)
        {
            request = new WWW(url);
            yield return request;

            if (!debug) yield break;

            if (!string.IsNullOrEmpty(request.error))
                Debug.Log("Failed remote config download with error: " + request.error);
            else
                Debug.Log("Downloaded remotely hosted config file: \n" + request.text);
        }


        /// <summary>
        /// converts a (downloaded) config string for virtual products
        /// into JSON nodes and overwrites existing IAP objects with new
        /// properties, after doing a null reference check for empty nodes.
        /// </summary>
        public static void ConvertToIAPs(string jsonText)
        {
            //skip empty strings
            if (string.IsNullOrEmpty(jsonText))
                return;

            //parse string
            JSONObject data = new JSONObject(jsonText);

            //iterate over product ids
            foreach(string key in data.keys)
            {
                //skip non-existing ids
                IAPObject obj = IAPManager.GetIAPObject(key);
                if (obj == null)
                    continue;

                //overwrite IAP properties
                JSONObject node = data[key];
                if (node["title"] != null) obj.title = node["title"].str;
                if (node["description"] != null) obj.description = node["description"].str;

                if (node["virtualPrice"] != null)
                {
                    JSONObject virtualPrice = node["virtualPrice"];
                    IAPCurrency cur = new IAPCurrency();
                    cur.name = virtualPrice["name"].str;
                    cur.amount = (int)virtualPrice["amount"].n;
                    obj.virtualPrice = cur;
                }

                if (node["requirement"] != null)
                {
                    JSONObject requirement = node["requirement"];
                    obj.req.entry = requirement["entry"].str;
                    obj.req.labelText = requirement["labelText"].str;
                    obj.req.target = (int)requirement["target"].n;
                }
            }
        }


		// method that fires a product request error
		private static void BillingNotSupported(int error)
		{
			if(instance.debug)
                Debug.Log("IAPManager reports: BillingNotSupported. Error: " + error);
            ShopManager.ShowMessage("Something went wrong. Errorcode: " + error);
		}


        // method that fires a purchase error
        private static void PurchaseFailed(string error)
        {
            if (instance.debug)
                Debug.Log("IAPManager reports: PurchaseFailed. Error: " + error);
            ShopManager.ShowMessage(error);
        }


        // method that fires a purchase error (overload)
        private static void PurchaseFailed(PurchasableVirtualItem prod)
        {
            PurchaseFailed("User cancelled.");
        }


		// method that fires the restore succeed action 
		private static void RestoreSucceeded(bool success)
		{
            if (success)
                ShopManager.ShowMessage("Restored transactions!");
            else
                RestoreFailed("Restoring transactions failed.");
		}


		// method that fires a restore error
		// through the purchase failed event
		private static void RestoreFailed(string error)
		{
			if(instance.debug) 
                Debug.Log("IAPManager reports: RestoreFailed. Error: " + error);
            ShopManager.ShowMessage(error);
		}


        /// <summary>
        /// returns the global identifier of an in-app product,
        /// specified in the IAP Settings editor
        /// </summary>
        public static string GetIAPIdentifier(string id)
        {
            foreach (IAPObject obj in instance.IAPObjects.Values)
            {		
                if (obj.GetIdentifier() == id)
                    return obj.id;
            }

            return id;
        }


		/// <summary>
		/// returns the list of currencies
		/// defined in the IAP Settings editor
		/// </summary>
		public static List<IAPCurrency> GetCurrency()
		{
			return instance.currency;
		}


		/// <summary>
		/// returns the list of all IAPGroups
		/// defined in the IAP Settings editor
		/// </summary>
		public static List<IAPGroup> GetIAPs()
		{
            List<IAPGroup> list = new List<IAPGroup>();
            list.AddRange(instance.IAPs);
            list.AddRange(instance.IGCs);
            return list;
		}


		/// <summary>
		/// returns a string array of all IAP ids (combined).
		/// </summary>
		public static string[] GetIAPKeys()
		{
			string[] ids = new string[instance.IAPObjects.Count];
			instance.IAPObjects.Keys.CopyTo(ids, 0);
			return ids;
		}


		/// <summary>
		/// returns the IAPObject with a specific id
		/// </summary>
		public static IAPObject GetIAPObject(string id)
		{
			if (!instance || !instance.IAPObjects.ContainsKey(id))
				return null;
			return instance.IAPObjects[id];
		}


        /// <summary>
        /// returns an array of all product ids the user owns.
        /// for upgradeable products, this will only return the current one.
        /// </summary>
        public static string[] GetAllPurchased()
        {
            List<string> list = new List<string>();
            string[] all = GetIAPKeys();
            
            for (int i = 0; i < all.Length; i++)
            {
                IAPObject obj = GetIAPObject(all[i]);

                //checking base product but there is an current upgrade to it
                List<UpgradeVG> upgrades = StoreInfo.GetUpgradesForVirtualGood(obj.id);
                if (upgrades != null && !string.IsNullOrEmpty(StoreInventory.GetGoodCurrentUpgrade(obj.id)))
                        continue;

                //checking upgrade but this is not the current one
                if (obj.type == IAPType.UpgradeVG)
                    if (obj.id != StoreInventory.GetGoodCurrentUpgrade(obj.specific.Split(';')[0]))
                        continue;

                //check for purchase
                if (!obj.isConsumable() && StoreInventory.GetItemBalance(obj.id) > 0)
                    list.Add(obj.id);
            }

            return list.ToArray();
        }


        /// <summary>
        /// returns an array of all product ids the user has equipped.
        /// </summary>
        public static string[] GetAllEquipped()
        {
            List<string> list = new List<string>();
            string[] all = GetIAPKeys();

            for (int i = 0; i < all.Length; i++)
            {
                IAPObject obj = GetIAPObject(all[i]);
                if (obj.type == IAPType.EquippableVG && StoreInventory.IsVirtualGoodEquipped(obj.id))
                    list.Add(all[i]);
            }

            return list.ToArray();
        }


        /// <summary>
        /// returns a boolean indicating the purchase for real money.
        /// </summary>
        public static bool IsMarketItem(string id)
        {
            for (int i = 0; i < instance.IAPs.Count; i++)
                for (int j = 0; j < instance.IAPs[i].items.Count; j++)
                    if (instance.IAPs[i].items[j].GetIdentifier() == id)
                        return true;

            return false;
        }


        /// <summary>
        /// returns whether a requirement has been met.
        /// </summary>
        public static bool IsRequirementMet(IAPRequirement req)
        {
            string data = KeyValueStorage.GetValue(req.entry);
            int value = 0;

            if (!string.IsNullOrEmpty(data))
                value = int.Parse(data);

            //if the requirement exists and is met, return true
            //otherwise return false as default
            if (value >= req.target)
                return true;
            else
                return false;
        }
	}


    /// <summary>
    /// supported billing platforms
    /// </summary>
    public enum IAPPlatform
    {
        GooglePlay = 0,
        Amazon = 1,
        iOSAppStore = 2,
        //WindowsPhone8 = 3
        //Samsung = 4,
        //Nokia = 5
    }
   

	/// <summary>
	/// supported IAP types enum
	/// </summary>
	public enum IAPType
	{
        VirtualCurrencyPack,
		SingleUseVG,
		SingleUsePackVG,
		LifetimeVG,
		EquippableVG,
		UpgradeVG,
	}


    /// <summary>
    /// remotely hosted config type
    /// </summary>
    public enum RemoteType
    {
        none,
        cached,
        overwrite
    }


	/// <summary>
	/// IAP group properties.
	/// Each group holds a list of IAP objects
	/// </summary>
	[System.Serializable]
	public class IAPGroup
	{
		public string id;
		public string name;
		public List<IAPObject> items = new List<IAPObject>();
	}


	/// <summary>
	/// IAP object properties.
	/// This is a meta-class for an IAP item
	/// </summary>
	[System.Serializable]
	public class IAPObject
	{
        public string id;
        public List<IAPIdentifier> localId = new List<IAPIdentifier>();
		public bool fetch = false;
        public IAPType type = IAPType.SingleUseVG;
        public string title;
        public string description;
		public string realPrice;
        public int amount;
        public string specific;
        public Sprite icon;
		public IAPCurrency virtualPrice = new IAPCurrency();
		public IAPRequirement req = new IAPRequirement();

        public bool platformFoldout = false;
        
        public string GetIdentifier()
        {
            string local = null;
            if (localId.Count == 0) return id;

            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    if (StoreSettings.GPlayBP)
                        local = localId[(int)IAPPlatform.GooglePlay].GetIdentifier();
                    else if (StoreSettings.AmazonBP)
                        local = localId[(int)IAPPlatform.Amazon].GetIdentifier();
                    break;
                case RuntimePlatform.IPhonePlayer:
                    local = localId[(int)IAPPlatform.iOSAppStore].GetIdentifier();
                    break;
            }

            if (!string.IsNullOrEmpty(local)) return local;
            else return id;
        }


        public bool isConsumable()
        {
            switch (type)
            {
                case IAPType.LifetimeVG:
                case IAPType.EquippableVG:
                case IAPType.UpgradeVG:
                    return false;
                default:
                    return true;
            }
        }
    }


    /// <summary>
    /// Local identifier for in-app products,
    /// per store platform
    /// </summary>
    [System.Serializable]
    public class IAPIdentifier
    {
        public bool overridden = false;
        public string id;

        public string GetIdentifier()
        {
            if (overridden) return id;
            else return null;
        }
    }


	/// <summary>
	/// IAP currency class with default value
	/// </summary>
	[System.Serializable]
	public class IAPCurrency
	{
        public string name;
        public int amount;
	}


	/// <summary>
	/// IAP unlock requirement, set for an IAPObject
	/// </summary>
	[System.Serializable]
	public class IAPRequirement
	{
		//database entry id
		public string entry;
		//goal/value to reach
		public int target;
		//label text that describes the requirement
		public string labelText;
	}
}