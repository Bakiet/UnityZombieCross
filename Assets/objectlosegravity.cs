using UnityEngine;
using System.Collections;

public class objectlosegravity : MonoBehaviour {

	public GameObject ObjectLoseGravity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D obj)
	{	if(ObjectLoseGravity)
		{
			if (obj.gameObject.name == "FrontWheel") {
				ObjectLoseGravity.GetComponent<BoxCollider2D>().enabled =false;
			}
		}
	}
}
