using UnityEngine;
using System.Collections;

namespace Soomla.Store {

	public class StoreInitiate : MonoBehaviour {

		// Use this for initialization
		void Start () {

			//StoreInventory.RefreshLocalInventory();
			
			StoreEvents.OnSoomlaStoreInitialized();
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}