using UnityEngine;
using System.Collections;

public class Motorcycle_Controller2D : MonoBehaviour {
	

	private  string ACHIEVEMENT_ID_First_Freeze = "CgkIq6GznYALEAIQDg";
	private  string ACHIEVEMENT_ID_First_Buy = "CgkIq6GznYALEAIQDQ";
	private  string ACHIEVEMENT_ID_First_Burn = "CgkIq6GznYALEAIQDA";
	
	private  string ACHIEVEMENT_ID_First_Drown = "CgkIq6GznYALEAIQCA";
	private  string ACHIEVEMENT_ID_First_Death = "CgkIq6GznYALEAIQBw";
	private  string ACHIEVEMENT_ID_First_Explotion = "CgkIq6GznYALEAIQBg";
	private  string ACHIEVEMENT_ID_First_FrontFlip = "CgkIq6GznYALEAIQBA";
	private  string ACHIEVEMENT_ID_First_BackFlip = "CgkIq6GznYALEAIQAg";
	
	private  string INCREMENTAL_ACHIEVEMENT_ID_Two_FrontFlip = "CgkIq6GznYALEAIQBQ";
	private  string INCREMENTAL_ACHIEVEMENT_ID_Two_BackFlip = "CgkIq6GznYALEAIQAw";
	
	private  string INCREMENTAL_ACHIEVEMENT_ID_Veteran = "CgkIq6GznYALEAIQCw";
	private  string INCREMENTAL_ACHIEVEMENT_ID_Assassin = "CgkIq6GznYALEAIQCg";
	private  string INCREMENTAL_ACHIEVEMENT_ID_Sergeant = "CgkIq6GznYALEAIQCQ";

	public float explodeDuration = 5f;
	public float explosionTime = 1;
	
	private RaycastHit hit;
	public float SpeedMotorMobile = 50.0f;
	public float SpeedMotor = 3.0f;
	private int count;
	public GameObject ObjectToVelocity;
	public static GameObject bike;
	public GameObject ObjectToCollidedOne;
	public float DistToCollided;
	public GameObject ObjectToCollidedTwo;
	public GameObject ObjectToCollidedThree;
	public GameObject ObjectToCollidedFour;
	public GameObject ObjectToCollidedFive;
	public GameObject ObjectToCollidedSix;
	public GameObject  ObjectToCollidedSeven;
	public GameObject ObjectToCollidedEight;
	
	public ParticleSystem dirt;
	
	public bool is2D = false;
	
	private float rotMin = -360f;
	private float rotMax = 360f;
	
	
	private int live;
	//var my_game_uGUI:game_uGUI;
	
	private game_uGUI my_game_uGUI; 
	
	
	int front;
	int back;
	
	public float acceleration = 0.15f;
	
	
	public float inAirRotationSpeedWithoutAcc = 10.0f;
	
	private float vertical;
	
	bool isShow = false; 
	//public GameObject Explosion1;
	//public GameObject Soul;
	//if this is activated the controlls will be got from touches else it'll be keyboard or joystick buttons
	public bool forMobile = false;
	
	
	public bool usingAccelerometer = false;
	public bool usingButtons = false;
	
	//used for mobile to detect which button was touched
	public Transform mobileButtons;
	public Transform Stage_uGUI;
	public GUITexture throttleTexture;
	public GUITexture brakeTexture;
	public GUITexture leftTexture;
	public GUITexture rightTexture;
	public GUITexture pauseTexture;
	public GUITexture restartTexture;
	
	//used to determine when player is crashed
	public static bool crash = false;
	public static bool crashed = false;
	
	//used to enable/disable motorcycle controlling
	public static bool isControllable = true;
	
	//used to count scores
	public static int score = 0;
	
	
	
	public float RightAccelerometer;
	public float LeftAccelerometer;
	public float speed = 60.0f;
	public float speedSuper = 60.0f;
	public float groundedWeightFactor = 20.0f;
	public float inAirRotationSpeed = 10.0f;
	public float  wheelieStrength = 170.0f;
	
	
	
	private bool onGround = false;
	private bool inAir = false;
	
	//used to start/stop dirt particles
	//public var dirt: ParticleSystem;
	public GameObject fire;
	
	//used for showing score particles when flips are done
	public ParticleSystem backflipParticle;
	public ParticleSystem frontflipParticle;
	//used to show scores
	public GUIText scoreText;
	public Color scoreTextColor;	
	
	public float endTime;
	
	//used to determine when flip is done
	private bool flip = false;

	private HingeJoint2D[] hingeJoints;
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject boots;
	public GameObject knee;
	public GameObject leg;
	public GameObject Body2D;

	/*public HingeJoint leftHand;
	public HingeJoint rightHand;
	public HingeJoint leftFoot;
	public HingeJoint rightFoot;
	public ConfigurableJoint hips;*/
	
	private bool accelerate = false;
	private bool brake = false;	
	private bool left = false;
	private bool right = false;
	private bool pause = false;
	private bool restart = false;
	private bool leftORright = false;			
	
	
	private AudioSource audioSource;
	public AudioSource audioXP;
	private float pitch;
	
	
	public Rigidbody2D frontWheel;
	public Rigidbody2D rearWheel;
	
	
	
	public GameObject Car;
	//Car = GameObject.Find("Car"); 	
	public GameObject CarBody;	
	public GameObject CenterOfMass;	
	public GameObject Smoke;	
	public GameObject Ensemble;

	
	//Vehicle properties
	public bool UserControlled = true;
	public float MaxSpeed = 50.0f;
	public static float CurrentSpeed;
	public float CurrentSpeedInKmph;
	public float Acceleration = 15.0f;
	private float Velocity = 0.0f;
	private ParticleAnimator SmokeEmmiter;
	private float CurrentVelocity;
	public static bool CarMoveLeft;
	public static bool CarMoveRight;
	public static bool CarHandbrake;
	public static bool CarFlip;
	public static bool Reset;
	public GameObject[] Wheels;
	public float[] WheelRadius;
	public float[] WheelTorqueAmount;
	
	public static float axisH = 0f;
	public static float axisV = 0f;
	
	void Awake()
	{
		SmokeEmmiter = Smoke.GetComponent<ParticleAnimator>();
		WheelRadius = new float[Wheels.Length];
	}
	void Start()
	{
		CarBody = GameObject.Find("Body2D");
		CenterOfMass = GameObject.Find("CoM2D");
		Smoke = GameObject.Find("Smoke");
		Ensemble = GameObject.Find("Ensemble2D");

		endTime = Time.time + endTime;
		
		if(GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>()){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
		
		crash = false;
		crashed = false;
		isControllable = true;
		mobileButtons = GameObject.Find ("mobile buttons").transform;
		throttleTexture = mobileButtons.FindChild ("throttle").GetComponent<GUITexture>();
		brakeTexture = mobileButtons.FindChild ("brake").GetComponent<GUITexture>();
		leftTexture = mobileButtons.FindChild ("left").GetComponent<GUITexture>();
		rightTexture = mobileButtons.FindChild("right").GetComponent<GUITexture>();
		
		backflipParticle = GameObject.Find ("backflip particle").GetComponent<ParticleSystem>();
		frontflipParticle = GameObject.Find ("frontflip particle").GetComponent<ParticleSystem>();
		scoreText = GameObject.Find ("score text").GetComponent<GUIText>();
		scoreText.text = "SCORE : " + score;
		//change score text color
		scoreText.material.color = scoreTextColor; 	
		
		Camera.main.GetComponent<CameraFollow2D>().target = CarBody.transform;	
		
		audioSource = CarBody.GetComponent<AudioSource>();		
		
		//ORIGINAL 2D MOTOR	
		
		CarMoveLeft = false;
		CarMoveRight = false;
		CarHandbrake = false;
		CarFlip = false;
		Reset = false;
		
		//axisH = 0;
		axisV = 0.2f;
		
		//Center of mass
		CarBody.GetComponent<Rigidbody2D>().centerOfMass = CenterOfMass.transform.localPosition;
		
		
		//Get radius for each wheel
		for(var i = 0; i <= (Wheels.Length-1); i++)
		{
			WheelRadius[i] = Wheels[i].GetComponent<CircleCollider2D>().radius;
		}
		
		//CalculateVelocity();
	}
	
	void DestroyBike(){
		/*GameObject soul = Resources.Load("prefabs/CFXM2_Soul") as GameObject;
		Instantiate(soul, CarBody.position, Quaternion.identity);
		*/
	
		GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
		Instantiate(soul, CarBody.transform.position, Quaternion.identity);
		GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
		Instantiate(explotion, CarBody.transform.position, Quaternion.identity);
		/*GameObject explotion = Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke") as GameObject;
		Instantiate(explotion, CarBody.position, Quaternion.identity);*/
		
		Camera.main.GetComponent<CameraFollow2D>().target = CarBody.transform; //make camera to follow biker's hips				
		
		/*Destroy(leftHand);
		Destroy(rightHand); 
		Destroy(leftFoot);
		Destroy(rightFoot); 
		Destroy(hips);*/
		CarBody.transform.Rotate (Vector3.right * 180);
		//Destroy(body);
		/*GameObject body2 = GameObject.Find("body");
		Rigidbody gameObjectsRigidBody = body2.AddComponent<Rigidbody>();
		gameObjectsRigidBody.mass = 3;
		for (int i = 0; i < 5; i++) {
			Instantiate (body2);
		}*/
		
		
		isControllable = false;
		crashed = true;
	}
	
	void FixedUpdate ()
	{      
		
		if (isControllable) {
			//if (usingAccelerometer) {
			RotateVehicle ();
			if (!crash && !crashed) {	
				
				if (speed > 80) {
					if (fire) {
						Instantiate (fire, CarBody.transform.position, Quaternion.identity);
						fire.transform.position = CarBody.transform.position;
					}
				} else {
					//Destroy(fire);
					//fire.Stop ();
				}
				if (accelerate) {
					rearWheel.freezeRotation = false; //allow rotation to rear wheel
					//rearWheel.GetComponent.<Rigidbody2D>().AddTorque (0, parseInt(inAirRotationSpeed * 180 * Time.deltaTime));  
					
					if(forMobile){
						//CurrentVelocity = Acceleration * inAirRotationSpeed * Time.deltaTime * wheelieStrength;
						CurrentVelocity = Acceleration * InputGetAxis("Vertical") * Time.deltaTime * SpeedMotorMobile;
						//	CurrentVelocity = Acceleration * Input.GetAxisRaw ("Vertical") * Time.deltaTime * 10;
						//Input.acceleration.x
						//rearWheel.AddTorque (new Vector3 (0, 0, -speed * Time.deltaTime), ForceMode.Impulse);
						Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
					}
					else{
						CurrentVelocity = Acceleration * Input.GetAxis("Vertical") * Time.deltaTime * SpeedMotor;
						Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
					}
					for(var i = 0; i <= (Wheels.Length-1); i++)
					{
						//Wheels[i].GetComponent.<Rigidbody2D>().AddTorque(-0.2f * (Velocity / WheelRadius[i]) * 10);
						Wheels[i].GetComponent<Rigidbody2D>().AddTorque(-0.2f * (Velocity / WheelRadius[i]) * 10);
					}
					
					
					//	rearWheel.GetComponent.<Rigidbody2D>().AddTorque (parseInt(-speed * Time.deltaTime),0);	
					
					//	rearWheel.GetComponent.<Rigidbody2D>().AddTorque (3f,0f,ForceMode2D.Impulse);						
					//	CarBody.GetComponent.<Rigidbody2D>().AddTorque (0, parseInt(inAirRotationSpeed * 180 * Time.deltaTime));  
					//rearWheel.AddTorque (Vector2.left -speed * Time.deltaTime), ForceMode.Impulse);	//add rotational speed to rear wheel
					
					
					if (onGround) {//if motorcycle is standing on object tagged as "Ground"			
						if (!dirt.isPlaying)
							dirt.Play (); //play dirt particle
						
						//dirt.transform.position = rearWheel.position; //allign dirt to rear wheel
						
					} 
				} 
				if (brake){
					rearWheel.freezeRotation = true; //disable rotation for rear wheel if player is braking								
				}
				
				else{			
					rearWheel.freezeRotation = false; //enable rotation for rear wheel if player isn't braking
				}
				
				if(left)
				{
					/*for(var i = 0; i <= (Wheels.length-1); i++)
					{
						Wheels[i].GetComponent.<Rigidbody2D>().AddTorque(-0.2f * (Velocity / WheelRadius[i]) * 10);
					}*/
					CarBody.GetComponent<Rigidbody2D>().AddTorque (inAirRotationSpeed * 80 * Time.deltaTime,0);    
					
				}
				if (right)
				{
					
					CarBody.GetComponent<Rigidbody2D>().AddTorque (80 * -inAirRotationSpeed * Time.deltaTime,0);   
					
				}
				
			
				if (Physics.Raycast (rearWheel.transform.position, -CarBody.transform.up,out hit, 0.4f)) { // cast ray to know if motorcycle is in air or grounded
					if (hit.collider.tag == "Ground") //if motorcycle is standig on object taged as "Ground"
						onGround = true;
					else
						onGround = false;
					
					inAir = false;									
				} else {
					onGround = false;
					inAir = true;
				}
			}
			//}
			
		}
		else dirt.Stop ();
		
		GetUserInput();		 
		
		//   CalculateVelocity();
		
		GetCurrentspeed();
		
		/*   if(UserControlled == true)
        {
        	for(var i = 0; i <= (Wheels.length-1); i++)
			{
				Wheels[i].GetComponent.<Rigidbody2D>().AddTorque(-0.2f * (Velocity / WheelRadius[i]) * 10);
			}
        }*/
	}
	void SetRotationMinMax(){
		rotMin = CarBody.transform.rotation.x - 360f;
		rotMax = CarBody.transform.rotation.x + 360f;
	}
	
	void RotateVehicle()
	{
		// Verify if the user want to rotate the vehicle front and if the vehicle is running.
		if((vertical > 0) && (CarBody.GetComponent<Rigidbody2D>().velocity.x > acceleration * 2)){
			
			left = true;
			//CarBody.GetComponent.<Rigidbody2D>().AddTorque (0, parseInt(inAirRotationSpeed * 180 * Time.deltaTime)); 
			
			
			//	CarBody.GetComponent.<Rigidbody2D>().AddTorque (parseInt(inAirRotationSpeed * 30 * Time.deltaTime),0); 
			
		}
		// Verify if the user want to rotate the vehicle backwards and if the vehicle is running.
		else if((vertical < 0) && (CarBody.GetComponent<Rigidbody2D>().velocity.x > acceleration * 2)){
			
			right = true;
			//	CarBody.GetComponent.<Rigidbody2D>().AddTorque (parseInt(180 * -inAirRotationSpeed * Time.deltaTime),0);   
			
			//	CarBody.GetComponent.<Rigidbody2D>().AddTorque (parseInt(30 * -inAirRotationSpeed * Time.deltaTime),0);   
			
		}
	}
	
	void setVerticalAxis(int vertical){
		this.vertical = vertical;
	}
	
	void Update()
	{
		float timeLeft = endTime - Time.time;
		if (timeLeft < 0) {
			timeLeft = 0;
		}
		if (timeLeft <= 0) {
			isControllable = true;
		} else {
			isControllable = false;
		}
		
		if (isControllable) {
			
			//RotateVehicle ();
			
			
			if (!crash && !crashed) {
			
				//if(Physics2D.Raycast(frontWheel.position,body.transform.position, out hit, (int)DistToCollided))
				if (Physics.Raycast (frontWheel.position, CarBody.transform.position, out hit, DistToCollided)) {
					if (ObjectToVelocity != null) {
						if (hit.collider.gameObject.name == ObjectToVelocity.name) {
							speed = speedSuper;
						}
					}
					if (ObjectToCollidedOne != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedOne.name) {
							DestroyBike ();					
						}
					}
					if (ObjectToCollidedTwo != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedTwo.name) {
							DestroyBike ();					
						}
					}
					if (ObjectToCollidedThree != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedThree.name) {
							DestroyBike ();					
						}
					}
					if (ObjectToCollidedFour != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedFour.name) {
							DestroyBike ();					
						}
					}
					if (ObjectToCollidedFive != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedFive.name) {
							DestroyBike ();					
						}
					}
					if (ObjectToCollidedSix != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedSix.name) {
							DestroyBike ();					
						}
					}
					if (ObjectToCollidedSeven != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedSeven.name) {
							DestroyBike ();					
						}
					}
					if (ObjectToCollidedEight != null) {
						if (hit.collider.gameObject.name == ObjectToCollidedEight.name) {
							DestroyBike ();					
						}
					}
				}
				
				//	GameObject weel = GameObject.Find ("front wheel").GetComponent<Collider>();
				
				//if (forMobile) {
				mobileButtons = GameObject.Find ("mobile buttons").transform;
				
				var touches = Input.touches;
				
				accelerate = false;
				brake = false;
				left = false;
				right = false;
				pause = false;
				restart = false;
				leftORright = false;							
				
				
				float angle  = 360.0f; // Degree per time unit
				float time  = 1.0f; // Time unit in sec
				Vector3 axis = Vector3.left; // Rotation axis, here it the yaw axis
				
				leftTexture = mobileButtons.FindChild ("left").GetComponent<GUITexture> ();
				rightTexture = mobileButtons.FindChild ("right").GetComponent<GUITexture> ();
				
				throttleTexture = mobileButtons.FindChild ("throttle").GetComponent<GUITexture> ();
				brakeTexture = mobileButtons.FindChild ("brake").GetComponent<GUITexture> ();
				
				
				leftTexture.enabled = false;
				rightTexture.enabled = false;
				
				leftTexture.enabled = true;
				rightTexture.enabled = true;
				
				throttleTexture.enabled = true;
				brakeTexture.enabled = true;
				
				
				
				foreach (var touch in touches) {	
					
					//if (touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended) {																							
					if (throttleTexture.HitTest (touch.position)) //if touch position is inside throttle texture
						
						accelerate = true;
					
					if (brakeTexture.HitTest (touch.position)) //if touch position is inside brake texture
						
						brake = true;
					
					
					
					if (leftTexture.HitTest (touch.position)) //left button is touched
						
						left = true;
					
					
					if (rightTexture.HitTest (touch.position)) //right button is touched
						
						right = true;
					
					
					//if (left || right) //left or right button is touched
					//	leftORright = true;						
					//}
					
				}
				
				if (Input.touchCount == 0) {
					
				}
			/*	
				if (Input.acceleration.x > RightAccelerometer) {
					setVerticalAxis (-1);
				} else if (Input.acceleration.x < RightAccelerometer) {
					setVerticalAxis (1);
				} else {
					setVerticalAxis (0);
				}
				*/
				
				//} else {
				//detect which keys are pressed. keys relevant to "Horizontal" and "Vertical" keywords are set in: Edit -> Project Settings -> Input
				if(!forMobile){
					if (Input.GetAxisRaw ("Horizontal") != 0)
						leftORright = true;
					else
						leftORright = false;
					
					if (Input.GetAxisRaw ("Horizontal") > 0) {
						//setVerticalAxis(-1);
						right = true;
					} else {
						//setVerticalAxis(1);
						right = false;
					}
					if (Input.GetAxisRaw ("Horizontal") < 0) {
						left = true;
						//setVerticalAxis(1);
					} else {
						//setVerticalAxis(-1);
						left = false;
					}
					if (Input.GetAxisRaw ("Vertical") > 0 || Input.GetKey (KeyCode.Joystick1Button2))
						accelerate = true;
					else
						accelerate = false;				
					
					if (Input.GetAxisRaw ("Vertical") < 0 || Input.GetKey (KeyCode.Joystick1Button1))
						brake = true;
					else
						brake = false;	
				}
				
				//----------------------------------
				//}
				
				
				if (CarBody.transform.rotation.eulerAngles.z > 210 && CarBody.transform.rotation.eulerAngles.z < 220)					
					flip = true; 																						
				
				if (CarBody.transform.rotation.eulerAngles.z > 320 && flip) { //backflip is done
					if (my_game_uGUI) {
						my_game_uGUI.Update_int_score (100);
						
					}
					audioXP.Play ();
					flip = false;				
					backflipParticle.Emit (1);
					
					
					/*makeclick Achievement = new makeclick ();
				Achievement.SENDACHIEVEMENT (ACHIEVEMENT_ID_First_BackFlip);
				Achievement.SENDACHIEVEMENTINCREMENT (INCREMENTAL_ACHIEVEMENT_ID_Two_BackFlip, 1);
					*/
					//score += 100;
					//scoreText.text = "SCORE : " + score;
				}
				
				if (CarBody.transform.rotation.eulerAngles.z < 30 && flip) { //frontflip is done			
					if (my_game_uGUI) {
						my_game_uGUI.Update_int_score (100);
					}
					audioXP.Play ();
					flip = false;
					frontflipParticle.Emit (1);
					
					/*				makeclick Achievement = new makeclick ();
				Achievement.SENDACHIEVEMENT (ACHIEVEMENT_ID_First_FrontFlip);
				Achievement.SENDACHIEVEMENTINCREMENT (INCREMENTAL_ACHIEVEMENT_ID_Two_FrontFlip, 1);
*/
					//score += 150;	
					//scoreText.text = "SCORE : " + score;					
				}
				
				
				//changing engine sound pitch depending rear wheel rotational speed
				if (accelerate) {
					/*pitch = rearWheel.angularVelocity.sqrMagnitude / speed;
				pitch *= Time.deltaTime * 2;
				pitch = Mathf.Clamp (pitch + 1, 0.5f, 1.8f);	*/		
				} else {
					//				pitch = audioSource.pitch;
					//pitch = Mathf.Clamp (pitch - Time.deltaTime * 2, 0.5f, 1.8f);																
				}
				
				//manipulating engine sound pitch
				//pitch = Mathf.Clamp (pitch - Time.deltaTime * 2, 0.5f, 1.8f);
				//pitch = Mathf.Clamp (pitch + Time.deltaTime * 2, 0.5f, 1.8f);
				//audioSource.pitch = pitch; 
				if (restart) {
					score = 0;
					Application.LoadLevel (Application.loadedLevel);
				}
				//if player is crashed and "R" is pressed or touch is detected on mobile, than restart current level
				if ((Input.GetKeyDown (KeyCode.R) || (Input.touchCount >= 2 && Input.GetTouch (0).phase == TouchPhase.Began)) && crashed) {
					score = 0;
					Application.LoadLevel (Application.loadedLevel);
				}
				if ((Input.GetKeyDown (KeyCode.X) || (Input.touchCount >= 2 && Input.GetTouch (0).phase == TouchPhase.Began))) {
				
					handling("");
				}
				if(Input.GetKeyUp (KeyCode.X)){

					unhandling("");

					/*hingeJoints = Body2D.GetComponents<HingeJoint2D>();	
					StartCoroutine(Coroutine(4,0.40f));
					StartCoroutine(Coroutine(3,1.10f));
					StartCoroutine(Coroutine(1,1.50f));*/

				}


				if (pause) {
					{
						isShow = !isShow;
					}
					
					//*** Pause happens here. This code below is exactly what pauses the game.
					//Pause game if panel is shown.
					if (isShow)
						Time.timeScale = 0;
					else
						Time.timeScale = 1;
				}
				if (Checkpoint.lastPoint) {
					if ((Input.GetKeyDown (KeyCode.C) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)) && crashed) {
						Checkpoint.Reset ();
						
						Destroy (gameObject);
					}
				}
			}
			
			if(crash && !crashed) //if player just crashed
			{											
				if(is2D)//if there is activated is2D checkbox on motorcycle, than you need to assign "CameraFollow2D.cs" script to camera
				{
					
					/*	makeclick Achievement = new makeclick();
				Achievement.SENDACHIEVEMENT(ACHIEVEMENT_ID_First_Death);
				*/
					GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
					Instantiate(soul, CarBody.transform.position, Quaternion.identity);
					GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
					Instantiate(explotion, CarBody.transform.position, Quaternion.identity);
					
					Camera.main.GetComponent<CameraFollow2D>().target = CarBody.transform; //make camera to follow biker's hips	
					
					
					//var explosionPos = transform.position;
					
					/*		
				Destroy(leftHand);
				Destroy(rightHand); 
				Destroy(leftFoot);
				Destroy(rightFoot); 
				Destroy(hips);*/
					CarBody.transform.Rotate (Vector3.right * 180);
					//	Destroy(CarBody);
					
					Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Ensemble2D"), LayerMask.NameToLayer ("Ragdoll"),false);
					
				}
				else
				{
					Camera.main.GetComponent<CameraFollow2D>().target = CarBody.transform; //make camera to follow biker's hips	
					
					//disable hinge joints, so biker detaches from motorcycle
					/*	Destroy(leftHand);
					Destroy(rightHand);
					Destroy(leftFoot);
					Destroy(rightFoot);
					Destroy(hips);
				*/
					//turn on collision between ragdoll and motorcycle
						Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Ensemble2D"), LayerMask.NameToLayer ("Ragdoll"),false);
				}					
				
				
				isControllable = false;
				crashed = true;
				//update lives
				if(my_game_uGUI){
					my_game_uGUI.Update_lives(-1);
					//my_game_uGUI.Update_lives(live);
				}
			}
			
			
		}
		Vector3 temp = SmokeEmmiter.force;
		temp.y = (SmokeEmmiter.force.y) * 0.5f;
		SmokeEmmiter.force = temp;
		//	transform.Translate(Input.acceleration.x, 0, -Input.acceleration.y);
		//SmokeEmmiter.force.y = Velocity * 20f;
	}

	public void handling(string handlingName)
	{
		hingeJoints = Body2D.GetComponents<HingeJoint2D>();

		boots.GetComponent<Rigidbody2D>().AddTorque (-1080,0); 

		hingeJoints[1].enabled = false;
		hingeJoints[3].enabled = false;
		hingeJoints[4].enabled = false;
		if(handlingName == ""){
		
		}
	}
	public void unhandling(string handlingName)
	{

		hingeJoints[1].enabled = true;
		hingeJoints[3].enabled = true;
		hingeJoints[4].enabled = true;

	}
	private IEnumerator Coroutine (int arrayjoin,float time) 
	{

		yield return new WaitForSeconds(time);
		//hingeJoints[arrayjoin].enabled = true;
		yield break;
		
	}
	
	//Simulate key press for touch steering
	public float InputGetAxis(string axis) 
	{		
		/*	float v = Input.GetAxis(axis);
		if (Mathf.Abs(v) > 0.005) return v;
		if (axis=="Horizontal") return axisH;
		if (axis=="Vertical") return axisV;
		*/
		float v = Input.GetAxis(axis);
		if(Mathf.Abs(v) > 0.005f) 
		{
			return v;
		}
		if(axis == "Horizontal") 
		{ 
			return axisH;
		}
		if(axis == "Vertical") 
		{ 
			return axisV;
		}
		return 0.0f;
	}
	
	/*function CalculateVelocity()
{
	if(Gui2D.TouchButtonsEnabledGlobal == true)
	{
		CurrentVelocity = Acceleration * InputGetAxis("Horizontal") * Time.deltaTime * 10;
		Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
	}
	
	if(Gui2D.TouchButtonsEnabledGlobal == false)
	{
		CurrentVelocity = Acceleration * Input.GetAxis("Horizontal") * Time.deltaTime * 10;
		Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
		
		if(Input.GetAxis("Horizontal") < 0)
		{
			CarMoveLeft = true;
			CarMoveRight = false;
		}
		
		else if(Input.GetAxis("Horizontal") > 0)
		{
			CarMoveLeft = false;
			CarMoveRight = true;
		}
		
		else
		{
			CarMoveLeft = false;
			CarMoveRight = false;
		}
	}
	
}*/
	
	void GetUserInput()
	{
		//Get input for the handbrake
		if(Input.GetKey(KeyCode.Space) || CarHandbrake == true)
		{
			for(var i = 0; i <= (Wheels.Length-1); i++)
			{
				Wheels[i].GetComponent<Rigidbody2D>().fixedAngle = true;
			}
		}
		
		
		else
		{
			CarHandbrake = false;
			for(var j = 0; j <= (Wheels.Length-1); j++)
			{
				Wheels[j].GetComponent<Rigidbody2D>().fixedAngle = false;
			}
		}
		
		if(Input.GetKey(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
		if(Input.GetKey(KeyCode.Z) || CarFlip == true) FlipCar();
		
	}
	
	void FlipCar()
	{
		//Flip the car
		Ensemble.transform.rotation = Quaternion.LookRotation(Ensemble.transform.forward);
	//	Car.transform.position.y += 0.2f;
	}
	
	void GetCurrentspeed()
	{
		//This converts rigidbody2D velocity magnitude to km/h
		CurrentSpeed = CarBody.GetComponent<Rigidbody2D>().velocity.magnitude * 3.6f;
		CurrentSpeedInKmph = CurrentSpeed;
		//Debug.Log("CurrentSpeed: "+CurrentSpeed+" km/h");
	}
}
