using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class drop : MonoBehaviour {
	
	private int countTimes = 0;

	public Rigidbody2D body;	
	public float radius = 1.0f;    //provides a radius at which the explosive will effect rigidbodies
	//public float radiusExplotion = 100.0f;

	public static bool Collider = false;
	public static bool Collision = false;
	public float time = 1f;
	public float timeEffect = 1f;
	public int timeToTouch = 1;
	public bool collisionEnter;
	public bool triggerEnter;
	public int TimescollisionEnter;
	public int TimestriggerEnter;
	private int timescollision;
	private int timestrigger;
	
	public bool isHit;

	public bool isAutomaticFrontWheel = true;
	
	public GameObject ObjectToCollided;

	
	
	public GameObject ObjectToLoseGravity;
	public GameObject EffectLoseGravity;
	public bool DestroyLoseGravity;
	public AudioClip SoundLoseGravity;
	
	public GameObject ObjectToLoseGravity2;
	public GameObject EffectLoseGravity2;
	public bool DestroyLoseGravity2;
	public AudioClip SoundLoseGravity2;
	
	public GameObject ObjectToLoseGravity3;
	public GameObject EffectLoseGravity3;
	public bool DestroyLoseGravity3;
	public AudioClip SoundLoseGravity3;
	
	public GameObject ObjectToLoseGravity4;
	public GameObject EffectLoseGravity4;
	public bool DestroyLoseGravity4;
	public AudioClip SoundLoseGravity4;
	
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
	
	void OnTriggerEnter2D(Collider2D collider)
	{

		Invoke ("MyWaitingFunction", time);

	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		
		if (collisionEnter == true) {
			Invoke ("MyWaitingFunction", time);
			if(TimescollisionEnter == 1){
				collisionEnter = true;
			}
			
		}
	}	
	void MyWaitingFunction()
	{	
		if (isAutomaticFrontWheel) {
			ObjectToCollided = Motorcycle_Controller2D.frontWheelStatic;
			
		}
		else {
			ObjectToCollided = ObjectToCollided;
		}

		
		
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
		Collider2D[] colliders = Physics2D.OverlapCircleAll (grenadeOrigin, radius);
		
		foreach (Collider2D hit in colliders) {
			if(ObjectToCollided != null)
			{
				if (hit.gameObject.name == ObjectToCollided.name) {
					
					if(timeToTouch == countTimes){
						
						if(UsedSlowMotion)
						{
							count = count + 1;
							if(count == 1){
								SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);
							}
						}

						if (bomb != null) {
							bomb.GetComponent<Rigidbody2D> ().isKinematic = false; 

						}
						
						timescollision = timescollision + 1;

						if (EffectLoseGravity != null) {
							EffectLoseGravity.SetActive (true);
							if(body != null){
								GameObject position = ObjectToLoseGravity;
								if(position != null){
									EffectLoseGravity.transform.position = position.transform.position;
									CFX_SpawnSystem.Instantiate (EffectLoseGravity);
									AudioSource.PlayClipAtPoint(SoundLoseGravity,EffectLoseGravity.transform.position);

								}
								
							}
							
						}
						if (EffectLoseGravity2 != null) {
							EffectLoseGravity2.SetActive (true);
							if(body != null){
								GameObject position2 = ObjectToLoseGravity2;
								EffectLoseGravity2.transform.position = position2.transform.position;
								CFX_SpawnSystem.Instantiate (EffectLoseGravity2);
								AudioSource.PlayClipAtPoint(SoundLoseGravity2,EffectLoseGravity2.transform.position);

							}
							
						}
						if (EffectLoseGravity3 != null) {
							EffectLoseGravity3.SetActive (true);
							if(body != null){
								GameObject position3 = ObjectToLoseGravity3;
								EffectLoseGravity3.transform.position = position3.transform.position;
								CFX_SpawnSystem.Instantiate (EffectLoseGravity3);
								AudioSource.PlayClipAtPoint(SoundLoseGravity3,EffectLoseGravity3.transform.position);

							}
							
						}
						if (EffectLoseGravity4 != null) {
							EffectLoseGravity4.SetActive (true);
							if(body != null){
								GameObject position4 = ObjectToLoseGravity4;
								EffectLoseGravity4.transform.position = position4.transform.position;
								CFX_SpawnSystem.Instantiate (EffectLoseGravity4);
								AudioSource.PlayClipAtPoint(SoundLoseGravity4,EffectLoseGravity4.transform.position);

							}
							
						}
						
						
						if (wood != null) {
							wood.GetComponent<Rigidbody2D> ().isKinematic = false; 

							if(DestroyLoseGravity){
								Destroy(wood);
							}
						}
						if (wood2 != null) {
							wood2.GetComponent<Rigidbody2D> ().isKinematic = false; 

							if(DestroyLoseGravity2){
								Destroy(wood2);
							}
						}
						if (wood3 != null) {
							wood3.GetComponent<Rigidbody2D> ().isKinematic = false; 

							if(DestroyLoseGravity3){
								Destroy(wood3);
							}
						}
						if (wood4 != null) {
							wood4.GetComponent<Rigidbody2D> ().isKinematic = false; 

							if(DestroyLoseGravity4){
								Destroy(wood4);
							}
						}
						
						
					}
					else{
						countTimes = countTimes +1;
					}			
				}
				else{}
			}
			
		} 
	}
	
	
	
	void Start () {
		countTimes = 1;
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