using UnityEngine;
using System.Collections;
using Soomla.Store;

public class SASendMessageOnClick : SAOnClickAction {

	public GameObject Reciver;
	public string MethodName;
	public bool ifrate = false;
	public bool ifstart = false;


	void start(){
		Reciver = GameObject.Find ("_Controller");
		if (ifstart) {

			if (MethodName == "SmartBottom" || MethodName == "StartInterstitialAd" || MethodName == "B2Hide") {
				if (StoreInventory.GetItemBalance ("no_ads") <= 0) {
					Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
				}
			} else {
				Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	protected override void OnClick() {
		Reciver = GameObject.Find ("_Controller");
		if (ifrate) {
			if (Application.loadedLevelName == "W1_Stage_4" || Application.loadedLevelName == "W1_Stage_9" || Application.loadedLevelName == "W1_Stage_14" || Application.loadedLevelName == "W2_Stage_4" || Application.loadedLevelName == "W2_Stage_9" || Application.loadedLevelName == "W2_Stage_14" || Application.loadedLevelName == "W3_Stage_4" || Application.loadedLevelName == "W3_Stage_9" || Application.loadedLevelName == "W3_Stage_14") {
				Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
			}
		} else {
			if (MethodName == "SmartBottom" || MethodName == "StartInterstitialAd" || MethodName == "B2Hide") {
				if (StoreInventory.GetItemBalance ("no_ads") <= 0) {
					Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
				}
			} else {
				Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
