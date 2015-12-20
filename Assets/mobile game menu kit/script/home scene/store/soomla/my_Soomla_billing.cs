using UnityEngine;
using System.Collections;
using Soomla;

namespace Soomla.Store
{
	public class my_Soomla_billing : MonoBehaviour {
		 //DELETE THIS LINE FOR SOOMLA
	public static my_Soomla_billing instance = null;

	// Use this for initialization
	void Awake () {

			if (instance == null) {
				instance = this;
				GameObject.DontDestroyOnLoad (this.gameObject);
				StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
				SoomlaStore.Initialize (new my_Soomla_Assets ());

			} else
				GameObject.Destroy (this.gameObject);


	}
	
	public void onSoomlaStoreInitialized(){
		}

	public void Buy_virutal_money_with_real_money(int profile_number, int quantity_pack,string itemid)
		{
			//Debug.Log ("Buy_virutal_money_with_real_money" + " : " + profile_number + "," + quantity_pack);
			StoreInventory.BuyItem(itemid);
		}

	public void Give_virtual_money_for_free(int profile_number, int quantity)
	{
			//Debug.Log ("Give_virtual_money_for_free" + " : " + profile_number + "," + quantity);
			StoreInventory.GiveItem(my_Soomla_Assets.VIRTUAL_MONEY_PROFILE_0_ID.ToString(), quantity);
	}

	public bool Buy_stuff_with_virtual_money(int profile_number, int stuff_cost,string itemid)
		{
			//Debug.Log("Buy_stuff_with_virtual_money" + " : " + profile_number + "," + stuff_cost);

			bool paid = false;

			if (StoreInventory.GetItemBalance(my_Soomla_Assets.VIRTUAL_MONEY_PROFILE_0_ID.ToString()) >= stuff_cost)
				{
				try
					{
					//StoreInventory.TakeItem(my_Soomla_Assets.VIRTUAL_MONEY_PROFILE_0_ID.ToString(),stuff_cost);
					StoreInventory.TakeItem(my_Soomla_Assets.VIRTUAL_MONEY_PROFILE_0_ID.ToString(),stuff_cost);

					paid = true;
					}
				catch (InsufficientFundsException)
					{
					paid = false;
					}
				}

			return paid;
		}

	public void Remove_all_virtual_money_from_this_profile(int profile_number)
		{
			//Debug.Log ("Remove_all_virtual_money_from_this_profile" + " : " + profile_number);
			//StoreInventory.TakeItem(my_Soomla_Assets.VIRTUAL_MONEY_PROFILE_0_IDprefix+"virtual_money_p"+profile_number.ToString(), StoreInventory.GetItemBalance(my_Soomla_Assets.prefix+"virtual_money_p"+profile_number.ToString()));
			StoreInventory.TakeItem(my_Soomla_Assets.VIRTUAL_MONEY_PROFILE_0_ID.ToString(), StoreInventory.GetItemBalance("Coins"));
		}

	public int Show_how_many_virtual_money_there_is_in_this_profile(int profile_number)
	{
			//Debug.Log ("Show_how_many_virtual_money_there_is_in_this_profile" + " : " + profile_number);
			//return StoreInventory.GetItemBalance(my_Soomla_Assets.prefix+"virtual_money_p"+profile_number.ToString());
			return StoreInventory.GetItemBalance("Coins");
	}
	 //DELETE THIS LINE FOR SOOMLA
}
}
