using UnityEngine;
using System.Collections;

public class collisionplus : MonoBehaviour {

	public GameObject wood = null;

	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter()
	{

	}
	void OnCollisionExit()
	{
		if(wood.name == gameObject.name){
			Destroy (gameObject);
		}
		if (gameObject.name == "Wood2 (28)") {
			Destroy (gameObject);
		}


	}
}
