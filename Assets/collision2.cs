using UnityEngine;
using System.Collections;

public class collision2 : MonoBehaviour {
	// Use this for initialization
	public GameObject Hit;
	public GameObject Blood;
	public Rigidbody body;
	public float radius = 100.0f;
	//GameObject objectname;

	// Use this for initialization
	void Start () {
		Hit.SetActive (false);
		Blood.SetActive (false);
	
	}

	void OnCollisionEnter (Collision collision)
	{
//		if(collision.gameObject.GetComponent<Rigidbody>().name != "Cube 1"){
		//	if(collision.gameObject.GetComponent<Rigidbody>().name == "front wheel"){
				
				//objectname = GameObject.Find ("urban_zombie_mobile6");
				//Vector3 zombie = transform.position;
				
				
			//	Collider[] colliders = Physics.OverlapSphere (zombie, radius);
				//foreach (Collider hit in colliders) {  //for loop that says if we hit any colliders, then do the following below
					
				if (collision.gameObject.name == "front wheel") {

			//	if (hit.gameObject.name == "front wheel") {
				//	if (hit.GetComponent<Rigidbody>().name == "front wheel") {	
						CFX_SpawnSystem.Instantiate (Hit);		
						
						Hit.SetActive (true);
						Hit.transform.position = body.position;
						
						Blood.SetActive (true);
						Blood.transform.position = body.position;
						//hit.GetComponent<Rigidbody>().AddExplosionForce(power, grenadeOrigin, radius, 1.0f);
						Destroy (body);	
						CFX_SpawnSystem.Instantiate (Blood);
					}
					/*if (Blood.GetComponent<Rigidbody>()) {	
						CFX_SpawnSystem.Instantiate (Blood);	
						//Destroy (zombieobject);
					}*/
					
				//}
			//}
		//}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
