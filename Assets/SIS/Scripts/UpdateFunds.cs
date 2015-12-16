/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SIS;
using Soomla;
using Soomla.Store;

/// <summary>
/// displays currency value in a text component.
/// Also updates this value in case it changed
/// </summary>
public class UpdateFunds : MonoBehaviour
{
    /// <summary>
    /// text reference for displaying the currency value
    /// </summary>
    public Text label;

    /// <summary>
    /// name of currency to display (a currency set in the IAP Editor)
    /// </summary>
    public string currency;

    /// <summary>
    /// time for animating the current start to end value
    /// </summary>
    public float duration = 2;

    //cache current currency value for accessing it later
    private int curValue;
	private game_uGUI my_game_uGUI;


    void OnEnable()
    {
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
	    //subscribe to successful purchase/update event,
	    //it could be that the player obtained currency
        StoreEvents.OnCurrencyBalanceChanged += UpdateValue;

        //get current currency value
        int funds = StoreInventory.GetItemBalance(currency);

		my_game_uGUI.Update_virtual_money(funds);
        //display value in the Text component
//        label.text = funds.ToString();
        //store value
        curValue = funds;
    }


    void OnDisable()
    {
	    //unsubscribe from events
        StoreEvents.OnCurrencyBalanceChanged -= UpdateValue;
    }


    void UpdateValue(VirtualCurrency vc, int balance, int added)
    {
        if(vc.Name != currency) return;
	    //stop existing text animation routines,
	    //we don't want to have two running at the same time
        StopCoroutine("CountTo");

	    //if this gameobject is active and visible in our UI,
	    //start text animation to the current currency value
	    //(if it isn't active, the value will be updated in OnEnable())
        if(gameObject.activeInHierarchy)
            StartCoroutine("CountTo", balance);
    }


    IEnumerator CountTo(int target)
    {
	    //remember current value as starting position
        int start = curValue;
	
	    //over the duration defined, lerp value from start to target value
	    //and set the UILabel text to this value
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            curValue = (int)Mathf.Lerp(start, target, progress);
           // label.text = curValue + "";
            yield return null;
        }

	    //once the duration is over, directly set the value and text
	    //to the targeted value to avoid rounding issues or inconsistency
        curValue = target;
        //label.text = curValue + "";
    }
}
