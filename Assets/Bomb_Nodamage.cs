using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Bomb_Nodamage : MonoBehaviour {


	private Transform target;
	Transform enemyTransform;	
	Vector2 walkAmount;
	Vector3 upAxis = new Vector3 (0f, 0f, -1f);
	public static int count = 0;
	int zombie_count = 0;
	float distance = 0;


	
	public float range =10f;
	public float stop =0;
	private bool zombiedead=false;

	private int countTimes = 0;
	public GameObject Explotion;
	public bool ExplotionWithThis;
	public Rigidbody2D body;	

	public static bool Collider = false;
	public static bool Collision = false;
	public float time = 3f;
	public float timeEffect = 3f;
	public GameObject ObjectToCollided;
	public GameObject ObjectToCollided2;

	
	
	public GameObject ObjectToLoseGravity;
	public GameObject EffectLoseGravity;
	public GameObject EffectLoseGravity2;
	public bool DestroyLoseGravity;
	public AudioClip SoundLoseGravity;
	

	GameObject bomb;
	GameObject wood;
	GameObject wood2;
	GameObject wood3;
	GameObject wood4;
	
	private static Collider2D hitColliderStatic;
	private static Vector3 grenadeOrigenStatic;
	
	public	string	identifier				= "";		// Use to identify the slow motion
	public bool UsedSlowMotion;
	public	float	delay					= 1;		// Delay to start Slow Motion
	public	float	desiredFreezeDuration	= 5;		// Duration in seconds of the slow motion
	public	float desiredTimeScale		= 0.5f;		    // Desired game speed 0 stops game, 1 full speed
	public	float desiredEndTimeScale		= 1;		// Desired game speed when slow motion ends 0 stops game, 1 full speed
	public	Action	callback	= null;		// Action To execute when slow motion ends

	public static bool UsedSlowMotionActivated =false;
	
	private const string ACHIEVEMENT_ID_First_Explotion = "CgkIq6GznYALEAIQBg";
	game_uGUI my_game_uGUI;

	public float DamageScale = 1.0f;
	
	public float DamageThreshold = 1.0f;
	
	private D2D_Damageable damageable;
	
	Shake.ShakeType shakeType = Shake.ShakeType.explosion;
	Shake cameraShake, objectShake;
	public GameObject cameraObject;
	float maxShake = 0.010f;
	float shakeAmount = 1f;
	float shakeIncrement = 0.1f;
	float addDecayIntensity = 0.5f;
	bool targetIsCamera = true;
	bool addDecay = false;
	public bool ifShake = false;
	

	void StartShake() {
		Shake objectToShake = targetIsCamera == true ? cameraShake : objectShake;
		if(shakeType == Shake.ShakeType.custom) {
			if(addDecay) objectToShake.StartShake( addDecayIntensity, 0, maxShake*(shakeAmount/100), true );
			else objectToShake.StartShake( maxShake*(shakeAmount/100), 0, 0, false );
		} else {
			objectToShake.StartShake(shakeType);
		}
	}

	void MyWaitingFunction()
	{	
		ObjectToCollided = Motorcycle_Controller2D.frontWheelStatic;
		ObjectToCollided2 = Motorcycle_Controller2D.backWheelStatic;

		if(distance != 0){
			if(distance<=range && distance>stop){
				Invoke ("TimeEffectExecute", time);
			}
		}

	}

	void TimeEffectExecute()
	{
		/*Vector3 grenadeOrigin = transform.position;
		Collider2D[] colliders = Physics2D.OverlapCircleAll (grenadeOrigin, radius);
		grenadeOrigenStatic = grenadeOrigin;
		foreach (Collider2D hit in colliders) {
			if(ObjectToCollided != null || ObjectToCollided2 !=null)
			{
				if (hit.gameObject.name == ObjectToCollided.name ||  hit.gameObject.name == ObjectToCollided2.name) {
					*/
						if(ifShake){
							StartShake();
						}
						//hitColliderStatic = hit;
						Invoke ("TimeEffectExecuteAll", timeEffect);
						
			/*	}
				else{}
			}
			
		} */
	}
	
	void TimeEffectExecuteAll()
	{
		makeclick Achievement = new makeclick();
		Achievement.SENDACHIEVEMENT(ACHIEVEMENT_ID_First_Explotion);
		
		if(UsedSlowMotion)
		{
			count = count + 1;
			if (count == 1) {
				SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);
				UsedSlowMotionActivated = true;
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

		}
		EffectLoseGravity.transform.position = body.position;
		EffectLoseGravity2.transform.position = body.position;
		//count = count + 1;
		if (count <= 1) {
			count = count + 1;
		Instantiate (EffectLoseGravity);
		Instantiate (EffectLoseGravity2);

		AudioSource.PlayClipAtPoint(SoundLoseGravity,EffectLoseGravity.transform.position);
			//Destroy(ObjectToLoseGravity);
		ObjectToLoseGravity.GetComponent<SpriteRenderer>().enabled = false;
		ObjectToLoseGravity.GetComponent<BoxCollider2D>().enabled = false;

		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);
			//Invoke ("DestroyObject",0);
			//ObjectToLoseGravity.SetActive(false);
		}
		//Destroy(EffectLoseGravity);
	}
	void DestroyObject(){
		Destroy(ObjectToLoseGravity);
	}
	void Start () {


		count = 0;
		distance = 0;
		D2D_DamageOnCollision.UsedSlowMotionActivated =false;


		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
		
		countTimes = 1;
		if(ifShake){
			cameraShake = cameraObject.GetComponent(typeof(Shake)) as Shake;
		}

	}
	void Update () {
		targetIsCamera = true;
		shakeType = Shake.ShakeType.explosion;
		target = GameObject.FindWithTag ("Player").transform;
		if (GameObject.FindGameObjectWithTag ("Ragdoll") != null) {
			target = GameObject.FindGameObjectWithTag ("Ragdoll").transform;
		}
		distance = Vector3.Distance (enemyTransform.position, target.position);

	}
	void Awake(){
		enemyTransform = gameObject.transform;
		//myTransform = transform; 
	}
	void FixedUpdate(){

		Invoke ("MyWaitingFunction", time);
	}
}
