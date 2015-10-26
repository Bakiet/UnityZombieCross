using UnityEngine;
using System.Collections;
using Soomla.Store;
using Grow.Highway;
using Grow.Sync;
using Grow.Insights;
using Grow.Gifting;
using Soomla;
using System.Collections.Generic;

	public class StoreInitiate : MonoBehaviour {

	//
	// Various event handling methods
	//
	public void onGoodBalanceChanged(VirtualGood good, int balance, int amountAdded) {
		SoomlaUtils.LogDebug("TAG", good.ID + " now has a balance of " + balance);
	}
	public void onGrowSyncInitialized() {
		Debug.Log("GROW Sync has been initialized.");
	}
	public void onModelSyncFinished(IList<string> modules) {
		Debug.Log("Model Sync has finished.");
	}
	public void onStateSyncFinished(IList<string> changedComponents,
	                                IList<string> failedComponents) {
		Debug.Log("State Sync has finished.");
	}
	
	//
	// Initialize SOOMLA's modules
	//
	void Start () {
		
		// Setup all event handlers - Make sure to set the event handlers before you initialize
		StoreEvents.OnGoodBalanceChanged += onGoodBalanceChanged;
		
		HighwayEvents.OnGrowSyncInitialized += onGrowSyncInitialized;
		HighwayEvents.OnModelSyncFinished += onModelSyncFinished;
		HighwayEvents.OnStateSyncFinished += onStateSyncFinished;
		
		// Make sure to make this call in your earliest loading scene,
		// and before initializing any other SOOMLA/GROW components
		// i.e. before SoomlaStore.Initialize(...)
		GrowHighway.Initialize();
		
		// Make sure to make this call AFTER initializing HIGHWAY,
		// and BEFORE initializing STORE
		bool modelSync = true;     // Remote Economy Management - Synchronizes your game's
		// economy model between the client and server - enables
		// you to remotely manage your economy.
		
		bool stateSync = true;     // Synchronizes the users' balances data with the server
		// and across his other devices.
		
		// State sync and Model sync can be enabled/disabled separately.
		GrowSync.Initialize(modelSync, stateSync);
		
	//	SoomlaStore.Initialize(new IStoreAssets());
		//StoreEvents.OnSoomlaStoreInitialized ();
	

			//StoreInventory.RefreshLocalInventory();
		/*	if (initiated == false) {
				StoreEvents.OnSoomlaStoreInitialized ();
				initiated = true;
			}*/
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
