using UnityEngine;
using System.Collections;

public class checkExplosion : MonoBehaviour {
	
	public GameObject Explotion;
	public Rigidbody body;	
	public float radius = 100.0f;    //provides a radius at which the explosive will effect rigidbodies
	public float power = 100.0f;
	public static bool Collider = false;
	public static bool Collision = false;
	public float time = 3f;
	public string ObjectToCollided;
	public string ObjectToExploted;
	public string ObjectToLoseGravity;
	GameObject bomb;
	GameObject wood;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		
	}
	
	void OnTriggerEnter(Collider collider)
	{
	//	if (collider.gameObject.name == "Trigger")
	//	{		
			trigger();
	//	}
	}
	
	void trigger()
	{	
		//ObjectToCollided = body.name;
		Vector3 grenadeOrigin = transform.position;
		bomb = GameObject.Find (ObjectToExploted);
		Explotion.SetActive (true);
		Explotion.transform.position = body.position;
		
		wood = GameObject.Find (ObjectToLoseGravity);
		
		bomb.GetComponent<Rigidbody> ().isKinematic = false; 
		bomb.GetComponent<Rigidbody> ().useGravity = true;
		
		wood.GetComponent<Rigidbody> ().isKinematic = false; 
		wood.GetComponent<Rigidbody> ().useGravity = true;
		
		Collider[] colliders = Physics.OverlapSphere (grenadeOrigin, radius);
		foreach (Collider hit in colliders) {
			
			if (hit.gameObject.name == ObjectToCollided) {
				
				CFX_SpawnSystem.Instantiate (Explotion);
				hit.GetComponent<Rigidbody> ().AddExplosionForce (power, grenadeOrigin, radius, 1.0f);
				Destroy (bomb);
			}
			else{}
		} 
		
	}

}
