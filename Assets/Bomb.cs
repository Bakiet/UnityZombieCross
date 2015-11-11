using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Bomb : MonoBehaviour {
	
	public GameObject Explotion;
	public bool ExplotionWithThis;
	public Rigidbody2D body;	
	public float radius = 1.0f;    //provides a radius at which the explosive will effect rigidbodies
	//public float radiusExplotion = 100.0f;
	public float radiusDead = 3.0f;
	public float power = 100.0f;
	public static bool Collider = false;
	public static bool Collision = false;
	public float time = 3f;
	public float timeEffect = 3f;
	public bool collisionEnter;
	public bool triggerEnter;
	public int TimescollisionEnter;
	public int TimestriggerEnter;
	private int timescollision;
	private int timestrigger;

	public bool isHit;
	public bool isBomb;

	public GameObject ObjectToCollided;
	public GameObject ObjectToExploted;


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
		ObjectToCollided = Motorcycle_Controller2D.frontWheelStatic;
		ObjectToExploted = Explotion;
		bomb = ObjectToExploted;



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
	public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
	{
		var dir = (body.transform.position - expPosition);
		//float calc = 1 - (dir.magnitude / expRadius);
		float calc = 1 - (0.18f / expRadius);
		if (calc <= 0) {
			calc = 0;		
		}
		
		//body.AddForce (dir.normalized * expForce * calc);
		body.AddForce (dir.normalized * expForce * calc);
	}
	void TimeEffectExecute()
	{
		Vector3 grenadeOrigin = transform.position;
		Collider2D[] colliders = Physics2D.OverlapCircleAll (grenadeOrigin, radius);

		foreach (Collider2D hit in colliders) {
			if(ObjectToCollided != null)
			{
				if (hit.gameObject.name == ObjectToCollided.name) {
					
					if(UsedSlowMotion)
					{
						count = count + 1;
						if(count == 1){
							SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);
						}
					}
					if (Explotion != null) {
						Explotion.SetActive (true);
						if(body != null){
							Explotion.transform.position = body.position;
						}
					}
					if (bomb != null) {
						bomb.GetComponent<Rigidbody2D> ().isKinematic = false; 
						//bomb.GetComponent<Rigidbody2D> ().useGravity = true;
						//Destroy (bomb);
						
					}

					timescollision = timescollision + 1;
					if(ExplotionWithThis == true)
					{

						Instantiate(Explotion);
					
						//CFX_SpawnSystem.Instantiate (Explotion);
					}
					if(isHit){
						Vector3 granadeorigin = grenadeOrigin;
						granadeorigin.z = 10;
						granadeorigin.y = granadeorigin.y - 2.0f;
						Vector3 objPos1 = Camera.main.ScreenToWorldPoint(granadeorigin);

						AddExplosionForce(hit.GetComponent<Rigidbody2D> (), power * 100, objPos1, radius);
						//hit.GetComponent<Rigidbody2D> ().AddForceAtPosition (power, grenadeOrigin, ForceMode2D.Force);
					}
					if(isBomb)
					{
						Vector3 granadeorigin = grenadeOrigin;
						granadeorigin.z = 10;
						granadeorigin.y = granadeorigin.y - 2.0f;
						Vector3 objPos1 = Camera.main.ScreenToWorldPoint(granadeorigin);

						AddExplosionForce(bomb.GetComponent<Rigidbody2D> (), power * 100, objPos1, radius);
						//hit.GetComponent<Rigidbody2D> ().AddForceAtPosition (power, grenadeOrigin, ForceMode2D.Force);
						//bomb.GetComponent<Rigidbody2D> ().AddForceAtPosition (power, grenadeOrigin, ForceMode2D.Force);
						//bomb.GetComponent<Rigidbody2D> ().AddExplosionForce (power, grenadeOrigin, radiusExplotion, 1.0f);
					}


					if (EffectLoseGravity != null) {
						EffectLoseGravity.SetActive (true);
						if(body != null){
							GameObject position = ObjectToLoseGravity;
							if(position != null){
							EffectLoseGravity.transform.position = position.transform.position;
								CFX_SpawnSystem.Instantiate (EffectLoseGravity);
								AudioSource.PlayClipAtPoint(SoundLoseGravity,EffectLoseGravity.transform.position);
								if (radius < radiusDead) {
								Motorcycle_Controller2D.crash = true;
								}
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
							if (radius < radiusDead) {
								Motorcycle_Controller2D.crash = true;
							}
						}
						
					}
					if (EffectLoseGravity3 != null) {
						EffectLoseGravity3.SetActive (true);
						if(body != null){
							GameObject position3 = ObjectToLoseGravity3;
							EffectLoseGravity3.transform.position = position3.transform.position;
							CFX_SpawnSystem.Instantiate (EffectLoseGravity3);
							AudioSource.PlayClipAtPoint(SoundLoseGravity3,EffectLoseGravity3.transform.position);
							if (radius < radiusDead) {
								Motorcycle_Controller2D.crash = true;
							}
						}
						
					}
					if (EffectLoseGravity4 != null) {
						EffectLoseGravity4.SetActive (true);
						if(body != null){
							GameObject position4 = ObjectToLoseGravity4;
							EffectLoseGravity4.transform.position = position4.transform.position;
							CFX_SpawnSystem.Instantiate (EffectLoseGravity4);
							AudioSource.PlayClipAtPoint(SoundLoseGravity4,EffectLoseGravity4.transform.position);
							if (radius < radiusDead) {
								Motorcycle_Controller2D.crash = true;
							}
						}
						
					}

				
					if (wood != null) {
						wood.GetComponent<Rigidbody2D> ().isKinematic = false; 
						//wood.GetComponent<Rigidbody2D> ().useGravity = true;
						if(DestroyLoseGravity){
						Destroy(wood);
						}
					}
					if (wood2 != null) {
						wood2.GetComponent<Rigidbody2D> ().isKinematic = false; 
						//wood2.GetComponent<Rigidbody2D> ().useGravity = true;
						if(DestroyLoseGravity2){
							Destroy(wood2);
						}
					}
					if (wood3 != null) {
						wood3.GetComponent<Rigidbody2D> ().isKinematic = false; 
						//wood3.GetComponent<Rigidbody2D> ().useGravity = true;
						if(DestroyLoseGravity3){
							Destroy(wood3);
						}
					}
					if (wood4 != null) {
						wood4.GetComponent<Rigidbody2D> ().isKinematic = false; 
					//	wood4.GetComponent<Rigidbody2D> ().gravityScale = 1;
						if(DestroyLoseGravity4){
							Destroy(wood4);
						}
					}


				}
				else{}
			}
		
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
