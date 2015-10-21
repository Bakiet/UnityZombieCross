using UnityEngine;
using System.Collections;

public class Bomb2 : MonoBehaviour {
	
	public GameObject Explotion;
	public Rigidbody body;	
	public float radius = 100.0f;    //provides a radius at which the explosive will effect rigidbodies
	public float power = 100.0f;
	public static bool Collider = false;
	public static bool Collision = false;
	public int time = 3;
	GameObject bomb;
	GameObject wood;
	
	void OnCollisionEnter (Collision collision)
	{
		
		Invoke("MyWaitingFunction",time);	
	}	
	void MyWaitingFunction()
	{
		
		Vector3 grenadeOrigin = transform.position;
		bomb = GameObject.Find ("Bomb 1");
		Explotion.SetActive (true);
		Explotion.transform.position = body.position;
		
		wood = GameObject.Find ("Wood2");
		
		bomb.GetComponent<Rigidbody>().isKinematic = false; 
		bomb.GetComponent<Rigidbody> ().useGravity = true;
		
		wood.GetComponent<Rigidbody>().isKinematic = false; 
		wood.GetComponent<Rigidbody> ().useGravity = true;
		
		Collider[] colliders = Physics.OverlapSphere (grenadeOrigin, radius);
		foreach (Collider hit in colliders) {  //for loop that says if we hit any colliders, then do the following below
							
			if (hit.GetComponent<Rigidbody>()) {										
				CFX_SpawnSystem.Instantiate (Explotion);
				
				
				hit.GetComponent<Rigidbody>().AddExplosionForce(power, grenadeOrigin, radius, 1.0f);
				Destroy (bomb);
			}

		}

	}
	
	
	void Start () {
		Explotion.SetActive (false);
	}
	void Update () {
		
	}
}