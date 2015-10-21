using UnityEngine;
using System.Collections;

public class SendAdtoLoad : MonoBehaviour {

	public GameObject Reciver;
	public string MethodName;
	// Use this for initialization
	void Start () {
		Reciver.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
