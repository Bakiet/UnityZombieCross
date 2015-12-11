using UnityEngine;
using System.Collections;
using Soomla.Store;

public class SASendMessageOnClick : SAOnClickAction {

	public GameObject Reciver;
	public string MethodName;




	protected override void OnClick() {

				Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);

	}
}
