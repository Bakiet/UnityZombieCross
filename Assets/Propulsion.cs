using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Propulsion : MonoBehaviour {

	public Rigidbody body;	
	public static bool Collider = false;
	public static bool Collision = false;
	public float time = 3f;
	public float radius = 100.0f;  
	public bool collisionEnter;
	public bool triggerEnter;
	public float timeEffect = 3f;


	public bool isHit;

	public GameObject ObjectToCollided;

	public GameObject ObjectToLoseGravity;
	public GameObject EffectLoseGravity;
	public bool DestroyLoseGravity;

	public GameObject ObjectToLoseGravity2;
	public GameObject EffectLoseGravity2;
	public bool DestroyLoseGravity2;

	public GameObject ObjectToLoseGravity3;
	public GameObject EffectLoseGravity3;
	public bool DestroyLoseGravity3;

	public GameObject ObjectToLoseGravity4;
	public GameObject EffectLoseGravity4;
	public bool DestroyLoseGravity4;

	GameObject bomb;
	GameObject wood;
	GameObject wood2;
	GameObject wood3;
	GameObject wood4;

	public	string	identifier				= "";		// Use to identify the slow motion
	public bool UsedSlowMotion;
	public	float	delay					= 1;		// Delay to start Slow Motion
	public	float	desiredFreezeDuration	= 5;		// Duration in seconds of the slow motion
	public	float desiredTimeScale		= 0.5f;		    // Desired game speed 0 stops game, 1 full speed
	public	float desiredEndTimeScale		= 1;		// Desired game speed when slow motion ends 0 stops game, 1 full speed
	public	Action	callback	= null;		// Action To execute when slow motion ends
	private int count = 0;

	void OnTriggerEnter(Collider collider)
	{
		//if (triggerEnter == true) {
			Invoke ("MyWaitingFunction", time);
			//if(TimestriggerEnter == 1){
			//	triggerEnter = false;
			//}
			//if(TimestriggerEnter < timestrigger){
			//	triggerEnter = false;
			//}
			
		//}
	}

	void OnCollisionEnter (Collision collision)
	{

		//if (collisionEnter == true) {
			Invoke ("MyWaitingFunction", time);
			//if(TimescollisionEnter == 1){
			//collisionEnter = true;
			//}

		//}
	}	
	void MyWaitingFunction()
	{	
		//ObjectToCollided = body.name;

		if (ObjectToLoseGravity != null) {
			wood = ObjectToLoseGravity;
		}
		if (ObjectToLoseGravity2 != null) {
			wood2 = ObjectToLoseGravity2;
		}
		if (ObjectToLoseGravity3 != null) {
			wood3 = ObjectToLoseGravity3;
		}
		if (ObjectToLoseGravity4 != null) {
			wood4 = ObjectToLoseGravity4;
		}


		Invoke ("TimeEffectExecute", timeEffect);


	}

	void TimeEffectExecute()
	{
		Vector3 grenadeOrigin = transform.position;
		Collider[] colliders = Physics.OverlapSphere (grenadeOrigin, radius);

		foreach (Collider hit in colliders) {

			if (hit.gameObject.name == ObjectToCollided.name) {
				
				if(UsedSlowMotion)
				{
					count = count + 1;
					if(count == 1){
						SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);
					}
				}

				if (bomb != null) {
					bomb.GetComponent<Rigidbody> ().isKinematic = false; 
					bomb.GetComponent<Rigidbody> ().useGravity = true;
					//Destroy (bomb);
					
				}

			


				if (EffectLoseGravity != null) {
					EffectLoseGravity.SetActive (true);
					if(body != null){
						GameObject position = ObjectToLoseGravity;
						if(position != null){
						EffectLoseGravity.transform.position = position.transform.position;
							CFX_SpawnSystem.Instantiate (EffectLoseGravity);}
						
					}
					
				}
				if (EffectLoseGravity2 != null) {
					EffectLoseGravity2.SetActive (true);
					if(body != null){
						GameObject position2 = ObjectToLoseGravity2;
						EffectLoseGravity2.transform.position = position2.transform.position;
						CFX_SpawnSystem.Instantiate (EffectLoseGravity2);
					}
					
				}
				if (EffectLoseGravity3 != null) {
					EffectLoseGravity3.SetActive (true);
					if(body != null){
						GameObject position3 = ObjectToLoseGravity3;
						EffectLoseGravity3.transform.position = position3.transform.position;
						CFX_SpawnSystem.Instantiate (EffectLoseGravity3);
					}
					
				}
				if (EffectLoseGravity4 != null) {
					EffectLoseGravity4.SetActive (true);
					if(body != null){
						GameObject position4 = ObjectToLoseGravity4;
						EffectLoseGravity4.transform.position = position4.transform.position;
						CFX_SpawnSystem.Instantiate (EffectLoseGravity4);
					}
					
				}

			
				if (wood != null) {
					wood.GetComponent<Rigidbody> ().isKinematic = false; 
					wood.GetComponent<Rigidbody> ().useGravity = true;
					if(DestroyLoseGravity){
						Destroy(wood);
					}
				}
				if (wood2 != null) {
					wood2.GetComponent<Rigidbody> ().isKinematic = false; 
					wood2.GetComponent<Rigidbody> ().useGravity = true;
					if(DestroyLoseGravity2){
						Destroy(wood2);
					}
				}
				if (wood3 != null) {
					wood3.GetComponent<Rigidbody> ().isKinematic = false; 
					wood3.GetComponent<Rigidbody> ().useGravity = true;
					if(DestroyLoseGravity3){
						Destroy(wood3);
					}
				}
				if (wood4 != null) {
					wood4.GetComponent<Rigidbody> ().isKinematic = false; 
					wood4.GetComponent<Rigidbody> ().useGravity = true;
					if(DestroyLoseGravity4){
						Destroy(wood4);
					}
				}


			}
			else{}
		} 
	}

	
	
	void Start () {
//		Explotion.SetActive (false);
	//	GameObject effect= GameObject.Find ("CFXM2_GroundWoodHit Bigger Dark");
	//	effect.SetActive (false);
//		EffectLoseGravity.SetActive (false);
		//EffectLoseGravity2.SetActive (false);
		//EffectLoseGravity3.SetActive (false);
		//EffectLoseGravity4.SetActive (false);
	}
	void Update () {
		
	}
}
