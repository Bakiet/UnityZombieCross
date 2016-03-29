using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(D2D_Damageable))]
[AddComponentMenu(D2D_Helper.ComponentMenuPrefix + "Damage On Collision")]
public class D2D_DamageOnCollision : MonoBehaviour
{
	//private int countTimes = 0;
	//public int timeToTouch = 1;
	public bool ifkinematic = false;
	public bool iftrash = false;
	public bool usedtime = false;
	public float time = 0f;
	public bool isColliderwithMoto = true;
	public bool isAutomaticBody = true;
	public bool isAutomaticFrontWheel = true;
	public bool isAutomaticBackWheel = true;
	public bool isAutomaticleg = true;
	public bool isAutomatictrunk = true;
	public bool isAutomaticleftarm = true;
	public bool isAutomaticrightarm = true;
	public GameObject HelmetToCollided;
	public GameObject legToCollided;
	public GameObject trunkToCollided;
	public GameObject leftarmToCollided;
	public GameObject rightarmToCollided;
	public GameObject BodyToCollided;
	public GameObject ObjectToCollided;
	public GameObject ObjectToCollided2;
	public bool isAutomaticPoli = true;
	public bool isAutomaticHelmet = true;
	public GameObject PoliToCollided;

	public	string				identifier				= "";		// Use to identify the slow motion
	public	float				delay					= 1;		// Delay to start Slow Motion
	public	float				desiredFreezeDuration	= 5;		// Duration in seconds of the slow motion
	public	float				desiredTimeScale		= 0.5f;		// Desired game speed 0 stops game, 1 full speed
	public	float				desiredEndTimeScale		= 1;		// Desired game speed when slow motion ends 0 stops game, 1 full speed
	public	Action				callback				= null;		// A

	public AudioClip Sound;

	public bool UsedSlowMotion =false;
	public static bool UsedSlowMotionActivated =false;

	public static int count = 0;

	public float DamageScale = 1.0f;
	
	public float DamageThreshold = 1.0f;
	
	private D2D_Damageable damageable;

	private float damage;

	void Update(){
		if (isAutomaticleg) {
			legToCollided = Motorcycle_Controller2D.legStatic;			
		}
		else {
			legToCollided = legToCollided;
		}
		if (isAutomatictrunk) {
			trunkToCollided = Motorcycle_Controller2D.trunkStatic;			
		}
		else {
			trunkToCollided = trunkToCollided;
		}
		if (isAutomaticleftarm) {
			leftarmToCollided = Motorcycle_Controller2D.leftarmStatic;			
		}
		else {
			leftarmToCollided = leftarmToCollided;
		}
		if (isAutomaticrightarm) {
			rightarmToCollided = Motorcycle_Controller2D.rightarmStatic;			
		}
		else {
			rightarmToCollided = rightarmToCollided;
		}
		if (isAutomaticHelmet) {
			HelmetToCollided = Motorcycle_Controller2D.HelmetStatic;			
		}
		else {
			HelmetToCollided = HelmetToCollided;
		}
		if (isAutomaticPoli) {
			PoliToCollided = Motorcycle_Controller2D.PoliStatic;			
		}
		else {
			PoliToCollided = PoliToCollided;
		}
		if (isAutomaticBody) {
			BodyToCollided = Motorcycle_Controller2D.CarBodyStatic;			
		}
		else {
			BodyToCollided = BodyToCollided;
		}
		if (isAutomaticFrontWheel) {
			ObjectToCollided = Motorcycle_Controller2D.frontWheelStatic;
			
		}
		else {
			ObjectToCollided = ObjectToCollided;
		}
		if (isAutomaticBackWheel) {
			ObjectToCollided2 = Motorcycle_Controller2D.backWheelStatic;
			
		}
		else {
			ObjectToCollided2 = ObjectToCollided2;
		}
	}

	void Start(){
		D2D_DamageOnCollision.UsedSlowMotionActivated =false;
		count = 0;
		//countTimes = 1;

	}
	
	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{

		damage = collision.relativeVelocity.magnitude * DamageScale;

		if (isColliderwithMoto) {
			if (ObjectToCollided != null || ObjectToCollided2 != null || BodyToCollided != null || PoliToCollided != null || HelmetToCollided != null) {
				if (ObjectToCollided.name == collision.gameObject.name || ObjectToCollided2.name == collision.gameObject.name || BodyToCollided.name == collision.gameObject.name || PoliToCollided.name == collision.gameObject.name || HelmetToCollided.name == collision.gameObject.name) {
					
					if(ifkinematic){
						gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
					}
					
					if (UsedSlowMotion) {
						count = count + 1;
						if (count == 1) {
							SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);
							UsedSlowMotionActivated = true;
						}
					}
					
					if (damage >= DamageThreshold) {
						if (damageable == null)
							damageable = GetComponent<D2D_Damageable> ();
						

							Invoke ("MyWaitingFunction", time);


					}
				} 
			}
			
		} else {
		
			if (damage >= DamageThreshold) {
				if (damageable == null)
					damageable = GetComponent<D2D_Damageable> ();
			
				Invoke ("MyWaitingFunction", time);

				

			}
		}
	
	}


	void MyWaitingFunction(){
		damageable.InflictDamage (damage);
		//count = count + 1;
		//if (count == 1) {
			AudioSource.PlayClipAtPoint (Sound, gameObject.transform.position);
		//}

		if (iftrash) {
			if(ifkinematic){
			}
			Physics2D.IgnoreCollision(HelmetToCollided.GetComponent<Collider2D>(), gameObject.transform.GetChild (0).GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(PoliToCollided.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(BodyToCollided.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(ObjectToCollided.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(ObjectToCollided2.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());

			Physics2D.IgnoreCollision(legToCollided.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(trunkToCollided.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(leftarmToCollided.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(rightarmToCollided.GetComponent<Collider2D>(),gameObject.transform.GetChild (0).GetComponent<Collider2D>());
		}
			
		Physics2D.IgnoreCollision(HelmetToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(PoliToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(BodyToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(ObjectToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(ObjectToCollided2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(legToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(trunkToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(leftarmToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(rightarmToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());

		//gameObject.transform.GetChild (1).GetComponent<Collider2D>().isTrigger = false;


	}

}