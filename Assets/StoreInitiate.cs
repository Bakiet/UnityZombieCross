using UnityEngine;
using System.Collections;
using Soomla.Store;

	public class StoreInitiate : MonoBehaviour {

	bool initiated;
		// Use this for initialization
		void Start () {

			//StoreInventory.RefreshLocalInventory();
			if (initiated == false) {
				StoreEvents.OnSoomlaStoreInitialized ();
				initiated = true;
			}
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
