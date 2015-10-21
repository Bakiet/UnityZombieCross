using UnityEngine;
using System.Collections;

public class rounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
		// Spin the object around the world origin at 20 degrees/second.
		transform.Rotate (0, 0, Time.deltaTime * 500);
	}


}
