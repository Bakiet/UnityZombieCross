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
	//public float time = 0f;
	public bool isColliderwithMoto = false;
	public bool isAutomaticFrontWheel = false;
	public bool isAutomaticBackWheel = false;
	public GameObject ObjectToCollided;
	public GameObject ObjectToCollided2;

	public AudioClip Sound;
	private	string	identifier				= "";		// Use to identify the slow motion
	public bool UsedSlowMotion =false;
	public	float	delay					= 1;		// Delay to start Slow Motion
	public	float	desiredFreezeDuration	= 5;		// Duration in seconds of the slow motion
	public	float desiredTimeScale		= 0.5f;		    // Desired game speed 0 stops game, 1 full speed
	public	float desiredEndTimeScale		= 1;		// Desired game speed when slow motion ends 0 stops game, 1 full speed
	public	Action	callback	= null;		// Action To execute when slow motion ends
	private int count = 0;

	public float DamageScale = 1.0f;
	
	public float DamageThreshold = 1.0f;
	
	private D2D_Damageable damageable;

	private float damage;

	void Start(){

		//countTimes = 1;

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
	
	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
		damage = collision.relativeVelocity.magnitude * DamageScale;

		if (isColliderwithMoto) {
			if (ObjectToCollided != null || ObjectToCollided2 != null) {
				if (collision.gameObject.name == ObjectToCollided.name || collision.gameObject.name == ObjectToCollided2.name) {
					

					
					if (UsedSlowMotion) {
						count = count + 1;
						if (count == 1) {
							SlowMotionController.AddSlowMotion (desiredFreezeDuration, desiredTimeScale, delay);
						}
					}
					
					if (damage >= DamageThreshold) {
						if (damageable == null)
							damageable = GetComponent<D2D_Damageable> ();
						
						damageable.InflictDamage (damage);
						//AudioSource.PlayClipAtPoint (Sound, gameObject.transform.position);
					}
				} else {
				}
			}
			
		} else {

			
			if (UsedSlowMotion) {
				count = count + 1;
				if (count == 1) {
					SlowMotionController.AddSlowMotion (desiredFreezeDuration, desiredTimeScale, delay);
				}
			}
			
			if (damage >= DamageThreshold) {
				if (damageable == null)
					damageable = GetComponent<D2D_Damageable> ();
				
				damageable.InflictDamage (damage);
				//AudioSource.PlayClipAtPoint (Sound, gameObject.transform.position);
			}
		}


	}

}