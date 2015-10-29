using UnityEngine;
using System.Collections;

public class SendAdtoLoad : MonoBehaviour {

	public GameObject Reciver;
	public string MethodName;
	public int times =0;
	// Use this for initialization
	void Start () {
		if (times == 1) {
			Reciver.SendMessage (MethodName, SendMessageOptions.DontRequireReceiver);
			times = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
