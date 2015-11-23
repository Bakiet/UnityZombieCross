using UnityEngine;
using System.Collections;
using Soomla.Store;

public class SendAdtoLoad : MonoBehaviour {

	public GameObject Reciver;
	public string MethodName;
	public int times =0;

	public float endTime;
	// Use this for initialization
	void Start () {
		endTime = Time.time + endTime;


	}
	
	// Update is called once per frame
	void Update () {

		float timeLeft = endTime - Time.time;
		if (timeLeft < 0) {
			timeLeft = 0;
		}
		if (timeLeft <= 0) {
			if (times == 1) {
				if (StoreInventory.GetItemBalance ("no_ads") <= 0) {
				Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
				times = 0;
				}
			}
		} else {

		}

	
	}
}
