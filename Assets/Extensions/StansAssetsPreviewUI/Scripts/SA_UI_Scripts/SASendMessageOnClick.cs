using UnityEngine;
using System.Collections;
using Soomla.Store;

public class SASendMessageOnClick : SAOnClickAction {

	public GameObject Reciver;
	public string MethodName;


	protected override void OnClick() {
		if (MethodName == "SmartBottom" || MethodName == "StartInterstitialAd") {
			if (StoreInventory.GetItemBalance ("no_ads") <= 0) {
				Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
			}
		} else {
			Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
		}

	}
}
