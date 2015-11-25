using UnityEngine;
using System.Collections;

public class disappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionExit2D(){
		Destroy (gameObject);
	}
}
