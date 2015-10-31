using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Motorcycle_Controller : MonoBehaviour
{

	private const string ACHIEVEMENT_ID_First_Freeze = "CgkIq6GznYALEAIQDg";
	private const string ACHIEVEMENT_ID_First_Buy = "CgkIq6GznYALEAIQDQ";
	private const string ACHIEVEMENT_ID_First_Burn = "CgkIq6GznYALEAIQDA";

	private const string ACHIEVEMENT_ID_First_Drown = "CgkIq6GznYALEAIQCA";
	private const string ACHIEVEMENT_ID_First_Death = "CgkIq6GznYALEAIQBw";
	private const string ACHIEVEMENT_ID_First_Explotion = "CgkIq6GznYALEAIQBg";
	private const string ACHIEVEMENT_ID_First_FrontFlip = "CgkIq6GznYALEAIQBA";
	private const string ACHIEVEMENT_ID_First_BackFlip = "CgkIq6GznYALEAIQAg";
	
	private const string INCREMENTAL_ACHIEVEMENT_ID_Two_FrontFlip = "CgkIq6GznYALEAIQBQ";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Two_BackFlip = "CgkIq6GznYALEAIQAw";

	private const string INCREMENTAL_ACHIEVEMENT_ID_Veteran = "CgkIq6GznYALEAIQCw";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Assassin = "CgkIq6GznYALEAIQCg";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Sergeant = "CgkIq6GznYALEAIQCQ";


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
	public GameObject ObjectToCollidedSeven;
	public GameObject ObjectToCollidedEight;

	public int live;
	game_uGUI my_game_uGUI;

	private float rotMin = -360f;
	private float rotMax = 360f;

	int front, back;

	public float acceleration = 0.15f;
	public float frontForce = 15.0f; // Amount of force to rotate front. 
	public float backForce = 15.0f; // Amount of force to rotate back.

	private float vertical;

	bool isShow = false; 
	//public GameObject Explosion1;
	//public GameObject Soul;
	//if this is activated the controlls will be got from touches else it'll be keyboard or joystick buttons
	public bool forMobile = false;
	
	public bool is2D = false;
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
	
	//used to change motorcycle characteristics

	public Rigidbody body;
	public Rigidbody frontFork;
	public Rigidbody rearFork;
	public Rigidbody frontWheel;
	public Rigidbody rearWheel;

	public float RightAccelerometer;
	public float LeftAccelerometer;
	public float speed = 60.0f;
	public float speedSuper = 60.0f;
	public float groundedWeightFactor = 20.0f;
	public float inAirRotationSpeed = 10.0f;
	public float wheelieStrength = 15.0f;

	public float inAirRotationSpeedWithoutAcc = 10.0f;
	//used to make biker detach from bike when crashed
	public HingeJoint leftHand;
	public HingeJoint rightHand;
	public HingeJoint leftFoot;
	public HingeJoint rightFoot;
	public ConfigurableJoint hips;

	//used for lean backward/forward, changes hips' targetposition value
	public Vector3 leanBackwardTargetPosition;
	public Vector3 leanForwardTargetPosition;
	public float leanSpeed = 2.0f;

	//used to start/stop dirt particles
	public ParticleSystem dirt;
	public GameObject fire;
	
	//used for showing score particles when flips are done
	public ParticleSystem backflipParticle;
	public ParticleSystem frontflipParticle;	
	
	//used to show scores
	public GUIText scoreText;
	public Color scoreTextColor;
	
	//used to determine if motorcycle is grounded or in air
	private RaycastHit hit;
	private bool onGround = false;
	private bool inAir = false;
	
	//used to manipulate engine sound pitch
	private AudioSource audioSource;
	public AudioSource audioXP;
 	private float pitch;
	
	//used to determine when flip is done
	private bool flip = false;			 	
	
	//used for knowing input	
	private bool accelerate = false;
	private bool brake = false;	
	private bool left = false;
	private bool right = false;
	private bool pause = false;
	private bool restart = false;
	private bool leftORright = false;			
	private float endTime;



	//start function is called once when game starts
	void Start ()
	{
		endTime = Time.time + 5;
		if(GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>()){
		my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();

		}
		Input.multiTouchEnabled = true;
		//reset static variables
		crash = false;
		crashed = false;
		isControllable = true;


		//find textures
		mobileButtons = GameObject.Find ("mobile buttons").transform;
		throttleTexture = mobileButtons.FindChild ("throttle").GetComponent<GUITexture>();
		brakeTexture = mobileButtons.FindChild ("brake").GetComponent<GUITexture>();
		leftTexture = mobileButtons.FindChild ("left").GetComponent<GUITexture>();
		rightTexture = mobileButtons.FindChild("right").GetComponent<GUITexture>();
//		pauseTexture = mobileButtons.FindChild ("pause").GetComponent<GUITexture>();
	//	restartTexture = mobileButtons.FindChild("restart").GetComponent<GUITexture>();

		/*Soul=GameObject.Find ("Soul");
		Explosion1=GameObject.Find ("ExplosionMoto");
		Soul.SetActive (false);
		Explosion1.SetActive (false);*/
	
		//find particles
		backflipParticle = GameObject.Find ("backflip particle").GetComponent<ParticleSystem>();
		frontflipParticle = GameObject.Find ("frontflip particle").GetComponent<ParticleSystem>();

		scoreText = GameObject.Find ("score text").GetComponent<GUIText>();
		scoreText.text = "SCORE : " + score;

		//change score text color
		scoreText.material.color = scoreTextColor; 		
		
		//adding motorcycle body as a follow target for camera
		if (is2D) {//if there is activated is2D checkbox on motorcycle, than you need to assign "CameraFollow2D.cs" script to camera
			//Camera.main.GetComponent<CameraControl>().target = body.transform;
			Camera.main.GetComponent<CameraFollow2D>().target = body.transform;
		} else {
			Camera.main.GetComponent<SmoothFollow> ().target = body.transform;
		}
		
		//ignoring collision between motorcycle wheels and body
		Physics.IgnoreCollision (frontWheel.GetComponent<Collider>(), body.GetComponent<Collider>());
		Physics.IgnoreCollision (rearWheel.GetComponent<Collider>(), body.GetComponent<Collider>());
		
		//ignoring collision between motorcycle and ragdoll
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Motorcycle"), LayerMask.NameToLayer ("Ragdoll"),true);
		
		//ignoring collision between motorcycle colliders
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Motorcycle"), LayerMask.NameToLayer ("Motorcycle"),true);
		
		//used to manipulate engine sound pitch
		audioSource = body.GetComponent<AudioSource>();		
		
		//setting wheels max angular rotation speed
		rearWheel.GetComponent<Rigidbody> ().maxAngularVelocity = speed;
		frontWheel.GetComponent<Rigidbody>().maxAngularVelocity = speed;
	}
	
	void DestroyBike(){
		GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
		Instantiate(soul, body.position, Quaternion.identity);
		
		GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
		Instantiate(explotion, body.position, Quaternion.identity);
		
		Camera.main.GetComponent<CameraFollow2D>().target = leftHand.transform; //make camera to follow biker's hips				
		
		Destroy(leftHand);
		Destroy(rightHand); 
		Destroy(leftFoot);
		Destroy(rightFoot); 
		Destroy(hips);
		body.transform.Rotate (Vector3.right * 180);
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
	
//  Update is called once per frame
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
			RotateVehicle ();
			//Physics.Raycast (ray, hit, 100);
			//if(Physics.Raycast(frontWheel.position,-body.transform.up, out hit, DistToCollided))
			if (!crash && !crashed) {
				//if(Physics2D.Raycast(frontWheel.position,body.transform.position, out hit, (int)DistToCollided))
				if (Physics.Raycast (frontWheel.position, body.transform.position, out hit, DistToCollided)) {
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

			if (forMobile) {
				mobileButtons = GameObject.Find ("mobile buttons").transform;
				//throttleTexture = mobileButtons.FindChild ("throttle").GetComponent<GUITexture>();
				//brakeTexture = mobileButtons.FindChild ("brake").GetComponent<GUITexture>();

				//pauseTexture = mobileButtons.FindChild ("pause").GetComponent<GUITexture>();
				//restartTexture = mobileButtons.FindChild("restart").GetComponent<GUITexture>();



				//pauseTexture.enabled = true;
				//restartTexture.enabled = true;

				var touches = Input.touches;
				
				accelerate = false;
				brake = false;
				left = false;
				right = false;
				pause = false;
				restart = false;
				leftORright = false;							
				
				
				//use accelerometer for rotatin motorcycle left and right
				//if(usingAccelerometer)
				//{

				float angle = 360.0f; // Degree per time unit
				float time = 1.0f; // Time unit in sec
				Vector3 axis = Vector3.left; // Rotation axis, here it the yaw axis

				leftTexture = mobileButtons.FindChild ("left").GetComponent<GUITexture> ();
				rightTexture = mobileButtons.FindChild ("right").GetComponent<GUITexture> ();

				throttleTexture = mobileButtons.FindChild ("throttle").GetComponent<GUITexture> ();
				brakeTexture = mobileButtons.FindChild ("brake").GetComponent<GUITexture> ();

				throttleTexture.enabled = true;
				brakeTexture.enabled = true;

				leftTexture.enabled = false;
				rightTexture.enabled = false;

				leftTexture.enabled = true;
				rightTexture.enabled = true;



				foreach (var touch in touches) {		
					if (touch.phase == TouchPhase.Began) {
						SetRotationMinMax ();
					}
					if (touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended) {																							
						if (throttleTexture.HitTest (touch.position)) //if touch position is inside throttle texture
							
							accelerate = true;
							
						if (brakeTexture.HitTest (touch.position)) //if touch position is inside brake texture
							
							brake = true;
						

						if (leftTexture.HitTest (touch.position)) //left button is touched

							left = true;

							
						if (rightTexture.HitTest (touch.position)) //right button is touched
							
							right = true;


						if (left || right) //left or right button is touched
							leftORright = true;						
					}
						
				}
					
				if (Input.touchCount == 0) {
						
				}

				if (Input.acceleration.x > RightAccelerometer) {
					setVerticalAxis (-1);
				} else if (Input.acceleration.x < RightAccelerometer) {
					setVerticalAxis (1);
				} else {
					setVerticalAxis (0);
				}

				//}

				/*	if(usingButtons)
				{
					throttleTexture = mobileButtons.FindChild ("throttle").GetComponent<GUITexture>();
					brakeTexture = mobileButtons.FindChild ("brake").GetComponent<GUITexture>();


					leftTexture = mobileButtons.FindChild ("left").GetComponent<GUITexture>();
					rightTexture = mobileButtons.FindChild("right").GetComponent<GUITexture>();


					throttleTexture.enabled = true;
					brakeTexture.enabled = true;

					leftTexture.enabled = true;
					rightTexture.enabled = true;


					//setVerticalAxis(-1);


					//detect which mobile buttons are pressed and make decisions accordingly
					foreach (var touch in touches)
					{						
						if(touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended)
						{																							
							if(throttleTexture.HitTest (touch.position)) //if touch position is inside throttle texture
								accelerate = true;
							
							if(brakeTexture.HitTest (touch.position)) //if touch position is inside brake texture
								//body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) * inAirRotationSpeed * 1080 * Time.deltaTime));   
								brake = true;

							if(leftTexture.HitTest (touch.position)) //left button is touched

								body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) * inAirRotationSpeed * 1080 * Time.deltaTime));   
													
							if(rightTexture.HitTest (touch.position)) //right button is touched

								body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) * -inAirRotationSpeed * 1080 * Time.deltaTime));   
										
							
							if(left || right) //left or right button is touched
								leftORright = true;						
						}
						
					}
					
					if(Input.touchCount == 0)
					{
						
					}
				}
				*/
			} else {
				//detect which keys are pressed. keys relevant to "Horizontal" and "Vertical" keywords are set in: Edit -> Project Settings -> Input
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


				//----------------------------------
			}
		

			if (body.rotation.eulerAngles.z > 210 && body.rotation.eulerAngles.z < 220)					
				flip = true; 																						
						
			if (body.rotation.eulerAngles.z > 320 && flip) { //backflip is done
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
			
			if (body.rotation.eulerAngles.z < 30 && flip) { //frontflip is done			
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
			
			//if any horizontal key (determined in edit -> project settings -> input)  is pressed or if "formobile" is activated, left or right buttons are touched or accelerometer is used
			if (leftORright) {
				if (left)//left horizontal key is pressed or left button is touched on mobile or using accelerometer
					hips.targetPosition = Vector3.Lerp (hips.targetPosition, leanBackwardTargetPosition, leanSpeed * Time.deltaTime); //lean backward

				if (right)//right horizontal key is pressed or if "formobile" is activated, right button is touched or using accelerometer
					hips.targetPosition = Vector3.Lerp (hips.targetPosition, leanForwardTargetPosition, leanSpeed * Time.deltaTime); //lean forward
			}
			
			//changing engine sound pitch depending rear wheel rotational speed
			if (accelerate) {
				pitch = rearWheel.angularVelocity.sqrMagnitude / speed;
				pitch *= Time.deltaTime * 2;
				pitch = Mathf.Clamp (pitch + 1, 0.5f, 1.8f);			
			} else {
				//pitch = audioSource.pitch;
				pitch = Mathf.Clamp (pitch - Time.deltaTime * 2, 0.5f, 1.8f);																
			}

			//manipulating engine sound pitch
			//pitch = Mathf.Clamp (pitch - Time.deltaTime * 2, 0.5f, 1.8f);
			pitch = Mathf.Clamp (pitch + Time.deltaTime * 2, 0.5f, 1.8f);
			audioSource.pitch = pitch; 
			if (restart) {
				score = 0;
				Application.LoadLevel (Application.loadedLevel);
			}
			//if player is crashed and "R" is pressed or touch is detected on mobile, than restart current level
			if ((Input.GetKeyDown (KeyCode.R) || (Input.touchCount >= 2 && Input.GetTouch (0).phase == TouchPhase.Began)) && crashed) {
				score = 0;
				Application.LoadLevel (Application.loadedLevel);
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
	}
		if(crash && !crashed) //if player just crashed
			{											
				if(is2D)//if there is activated is2D checkbox on motorcycle, than you need to assign "CameraFollow2D.cs" script to camera
				{

			/*	makeclick Achievement = new makeclick();
				Achievement.SENDACHIEVEMENT(ACHIEVEMENT_ID_First_Death);
				*/
				GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));;
				Instantiate(soul, body.position, Quaternion.identity);

				GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));;
				Instantiate(explotion, body.position, Quaternion.identity);

				Camera.main.GetComponent<CameraFollow2D>().target = leftHand.transform; //make camera to follow biker's hips

					
				//var explosionPos = transform.position;
		
						
				Destroy(leftHand);
				Destroy(rightHand); 
				Destroy(leftFoot);
				Destroy(rightFoot); 
				Destroy(hips);
				body.transform.Rotate (Vector3.right * 180);
				Destroy(body);
				/*GameObject body2 = GameObject.Find("body");
				Rigidbody gameObjectsRigidBody = body2.AddComponent<Rigidbody>();
				gameObjectsRigidBody.mass = 3;*/


				}
				else
				{
					Camera.main.GetComponent<SmoothFollow>().target = leftHand.transform; //make camera to follow biker's hips
					
					//disable hinge joints, so biker detaches from motorcycle
					Destroy(leftHand);
					Destroy(rightHand);
					Destroy(leftFoot);
					Destroy(rightFoot);
					Destroy(hips);
				
					//turn on collision between ragdoll and motorcycle
					Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Motorcycle"), LayerMask.NameToLayer ("Ragdoll"),false);
				}					
				if(!is2D) //disable all physics constraints if 2D isn't activated for motorcycle in inspector menu, so physics calculation will occur on all axis
				{
//					body.constraints = RigidbodyConstraints.None;
					frontFork.constraints = RigidbodyConstraints.None;
					frontWheel.constraints = RigidbodyConstraints.None;
					rearFork.constraints = RigidbodyConstraints.None;
					rearWheel.constraints = RigidbodyConstraints.None;							
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
	

	public void setVerticalAxis(int vertical){
		this.vertical = vertical;
	}

	//physics are calculated in FixedUpdate function
	void FixedUpdate ()
	{			



		if (isControllable) {
			//if (usingAccelerometer) {
				//RotateVehicle ();
			if (!crash && !crashed) {	
				
				if (speed > 80) {
					if (fire) {
						Instantiate (fire, body.position, Quaternion.identity);
						fire.transform.position = body.position;
					}
				} else {
					//Destroy(fire);
					//fire.Stop ();
				}
				if (accelerate) {
					rearWheel.freezeRotation = false; //allow rotation to rear wheel
					rearWheel.AddTorque (new Vector3 (0, 0, -speed * Time.deltaTime), ForceMode.Impulse);	//add rotational speed to rear wheel

			
					if (onGround) {//if motorcycle is standing on object tagged as "Ground"			
						if (!dirt.isPlaying)
							dirt.Play (); //play dirt particle
						
						dirt.transform.position = rearWheel.position; //allign dirt to rear wheel
					
					} else
						dirt.Stop ();
				
				} else
					dirt.Stop ();
			
				if (brake)
					rearWheel.freezeRotation = true; //disable rotation for rear wheel if player is braking								
			else			
					rearWheel.freezeRotation = false; //enable rotation for rear wheel if player isn't braking
	        	
				//if (left) {
					//left horizontal key (determined in edit -> project settings -> input) is pressed or left button is touched on mobile if "formobile" is activated
				//if (!inAir) { //rotate left the motorcycle body
					//body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) * groundedWeightFactor * 100 * Time.deltaTime)); 
			if(left)
			{

				body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) + inAirRotationSpeed * 180 * Time.deltaTime));  
				  
			}
			if (right)
			{

				body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) - inAirRotationSpeed * 180 * Time.deltaTime));  
				   
			}
				

				if (Physics.Raycast (rearWheel.position, -body.transform.up, out hit, 0.4f)) { // cast ray to know if motorcycle is in air or grounded
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
																	
	}
	void SetRotationMinMax(){
		rotMin = body.rotation.x - 360f;
		rotMax = body.rotation.x + 360f;
	}
	public void RotateVehicle()
	{
		// Verify if the user want to rotate the vehicle front and if the vehicle is running.
		if((vertical > 0) && (body.GetComponent<Rigidbody>().velocity.x > acceleration * 2)){
			// Verify if the vehicle is on the air or if the wheelies are allowed when the vehicle is on the ground.
			//if(!grounded || wheelie){
				// Verify if the vehicle doesn't pass the rotation force permitted.

			body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) * inAirRotationSpeed * 30 * Time.deltaTime));   

			//if(body.GetComponent<Rigidbody>().angularVelocity.x > (-frontForce * 10))
					// Add the front force to rotate the vehicle.

				//body.GetComponent<Rigidbody>().AddTorque((Vector3)-frontForce);

			//	Vector3 v3 = Vector3.Lerp(transform.position, body.position, Time.deltaTime * -frontForce);

			//body.GetComponent<Rigidbody>().AddTorque(Vector3.Lerp(transform.position, body.position, Time.deltaTime * -frontForce));

			//}
		}
		// Verify if the user want to rotate the vehicle backwards and if the vehicle is running.
		else if((vertical < 0) && (body.GetComponent<Rigidbody>().velocity.x > acceleration * 2)){

			body.AddTorque (new Vector3 (0, 0, (forMobile ? Mathf.Abs(Input.acceleration.x) : 1) * -inAirRotationSpeed * 180 * Time.deltaTime));   
			// Verify if the vehicle is on the air or if the wheelies are allowed when the vehicle is on the ground.
			//if(!grounded || wheelie){
				// Verify if the vehicle doesn't pass the rotation force permitted.
			//if(body.GetComponent<Rigidbody>().angularVelocity.x < (backForce * 10))
					// Add the backward force to rotate the vehicle.

			//	body.GetComponent<Rigidbody>().AddTorque(Vector3.Lerp(transform.position, body.position, Time.deltaTime * backForce));
				//body.GetComponent<Rigidbody>().AddTorque(backForce);
			//}
		}
	}

}