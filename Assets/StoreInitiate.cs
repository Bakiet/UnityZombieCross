using UnityEngine;
using System.Collections;
using Soomla.Store;
using Grow.Highway;
using Grow.Sync;
using Grow.Insights;
using Grow.Gifting;

	public class StoreInitiate : MonoBehaviour {

	bool initiated;
		// Use this for initialization
		void Start () {

		GrowHighway.Initialize();
		
		// Make sure to make this call AFTER initializing HIGHWAY
		GrowInsights.Initialize();
		
		// Make sure to make this call AFTER initializing HIGHWAY,
		// and BEFORE initializing STORE/PROFILE/LEVELUP
		bool modelSync = true;     // Remote Economy Management - Synchronizes your game's
		// economy model between the client and server - enables
		// you to remotely manage your economy.
		
		bool stateSync = true; // Synchronizes the users' balances data with the server
		// and across his other devices.
		// Must be TRUE in order to use LEADERBOARDS.
		
		// State sync and Model sync can be enabled/disabled separately.
		GrowSync.Initialize(modelSync, stateSync);
		
		// LEADERBOARDS requires no initialization,
		// but it depends on SYNC initialization with stateSync=true
		
		// Make sure to make this call AFTER initializing SYNC,
		// and BEFORE initializing STORE/PROFILE/LEVELUP
		GrowGifting.Initialize();

			//StoreInventory.RefreshLocalInventory();
			if (initiated == false) {
				//StoreEvents.OnSoomlaStoreInitialized ();
				initiated = true;
			}
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
