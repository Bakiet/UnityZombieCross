using UnityEngine;
using System.Collections;

public class SASendMessageOnClick : SAOnClickAction {

	public GameObject Reciver;
	public string MethodName;
	public bool useload=false;

	void Start (){

		if (useload) {
			Reciver.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
		}
	}


	protected override void OnClick() {
		Reciver.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
	}
}
