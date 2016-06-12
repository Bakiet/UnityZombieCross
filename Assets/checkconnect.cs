using UnityEngine;
using System.Collections;
using unity;
using UnityEngine.UI;


public class checkconnect : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate() {


		if (GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			gameObject.GetComponent<Text>().text = "Sign out";
		} else {
			GooglePlayConnection.Instance.Connect ();
			gameObject.GetComponent<Text>().text = "Sign in";
		}
	}
}
