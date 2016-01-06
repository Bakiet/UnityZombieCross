using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Soomla.Profile;
using Soomla.Store;
using System.Collections.Generic;
using System;


public class Motorcycle_Controller2D : MonoBehaviour {
	//public GameObject Reciver;
	public Collider2D forwardsBtn; // Collider2D of the forward button.
	public Collider2D backwardsBtn; // Collider2D of the backwards button.
	public Collider2D tiltForwardsBtn; // Collider2D of the tilt forwards button.
	public Collider2D tiltBackwardsBtn; // Collider2D of the tilt backwards button.

	public GameObject CFXM2_Soul;
	public GameObject CFXM_ExplosionTextNoSmoke;
	public GameObject CFXM_GroundSmokeExplosionAlt;

	private const string LEADERBOARD_ID = "CgkIq6GznYALEAIQAA";
	private const string LEADERBOARD_MULTIPLAYER_ID = "CgkIq6GznYALEAIQAQ";

	private int LastNotificationId = 0;
	public bool testing = false;
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

	public static bool checkpoint = false;
	public static Transform lastcheckpoint;
	public int setscore=100;
	public int StartingPitch = 1;
	public float MaxPitch = 3.0f;
	public float TimeToIncrease = 2.0f;
	public float TimeToDecrease = 2.0f;

	public float explodeDuration = 5f;
	public float explosionTime = 1;
	public static bool useUpgrade=false;
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
	
	private float acceleration = 0.15f;
	
	
	public float inAirRotationSpeedWithoutAcc = 10.0f;
	
	private float vertical;
	
	bool isShow = false; 
	//public GameObject Explosion1;
	//public GameObject Soul;
	//if this is activated the controlls will be got from touches else it'll be keyboard or joystick buttons
	public bool forMobile = true;
	
	
	public bool usingAccelerometer = false;
	public bool usingButtons = false;
	
	//used for mobile to detect which button was touched
	public Transform mobileButtons;
	public Transform Stage_uGUI;

	public Button throttleTexture;
	public Button brakeTexture;
	public Button leftTexture;
	public Button rightTexture;
	public GUITexture pauseTexture;
	public GUITexture restartTexture;
	
	//used to determine when player is crashed
	public static bool crash = false;
	public static bool crashed = false;
	public static bool crashSaw = false;
	public static bool crashSawHead = false;
	public static bool crashBurned = false;
	public static bool crashBurn = false;
	public static bool crashDrowned = false;
	public static bool crashDrown = false;
	//used to enable/disable motorcycle controlling
	public static bool isControllable = true;
	public static bool isFinish = false;
	
	//used to count scores
	public static int score = 0;
	public static long scorestatic = 0;
	public static Vector3 position;
	
	
	
	public float RightAccelerometer;
	public float LeftAccelerometer;
	//public float speed = 60.0f;
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
	private WheelJoint2D[] wheelJoints;
	private HingeJoint2D[] leftHandJoints;
	private HingeJoint2D[] rightHandJoints;
	private HingeJoint2D[] bootsJoints;
	private HingeJoint2D[] kneeJoints;
	private HingeJoint2D[] legJoints;
	private HingeJoint2D[] helmetJoints;
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject boots;
	public GameObject knee;
	public GameObject leg;
	public GameObject helmet;
	public GameObject Body2D;

	private GameObject nubes;
	private GameObject edif2;
	private GameObject humo;
	private GameObject edif1;


	/*public HingeJoint leftHand;
	public HingeJoint rightHand;
	public HingeJoint leftFoot;
	public HingeJoint rightFoot;
	public ConfigurableJoint hips;*/
	
	public static bool accelerate = false;
	private bool brake = false;	
	private bool left = false;
	private bool right = false;
	private bool pause = false;
	private bool restart = false;
	private bool leftORright = false;			
	
	
	private AudioSource audioSource;
	public AudioClip audioXP;
	private float pitch;
	
	
	public Rigidbody2D frontWheel;
	public GameObject frontWheelObject;
	public GameObject backWheelObject;
	public static GameObject frontWheelStatic;
	public static GameObject backWheelStatic;
	public Rigidbody2D rearWheel;
	
	
	
	public GameObject Car;
	public static GameObject BodyCarStatic;

	//Car = GameObject.Find("Car"); 	
	public GameObject CarBody;	
	public static GameObject CarBodyStatic;	
	public GameObject Poli;	
	public static GameObject PoliStatic;
	public static GameObject HelmetStatic;


	public GameObject trunk;

	public static GameObject legStatic;
	public static GameObject trunkStatic;
	public static GameObject leftarmStatic;
	public static GameObject rightarmStatic;


	public Transform CarBodyTransform;	
	public static Transform CarBodyTransformStatic;	
	public GameObject CenterOfMass;	
	public GameObject Smoke;	
	public GameObject Ensemble;

	public AudioClip BodyDeadSound;
	public AudioClip BodyDeadBurnSound;
	public AudioClip BodyDeadDrownSound;
	public AudioClip MotoDeadSound;
	public AudioClip BrakeSound;

	
	//Vehicle properties
	public bool UserControlled = true;
	public float MaxSpeed = 50.0f;

	public float BreakMass = 0.0f;

	public float BreakGravity = 0.0f;


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

	private float bikespeedmobile1=2f;
	private float bikespeedmotor1=2f;
	private float bikemaxspeed1=2f;
	private float bikebreakmass1=20f;
	private float bikebreakgravity1=0.5f;
	private float bikeacceleration1=1f;

	private float bikespeedmobile2=2f;
	private float bikespeedmotor2=2f;
	private float bikemaxspeed2=2f;
	private float bikebreakmass2=20f;
	private float bikebreakgravity2=0.5f;
	private float bikeacceleration2=1f;

	private float bikespeedmobile3=2f;
	private float bikespeedmotor3=2f;
	private float bikemaxspeed3=2f;
	private float bikebreakmass3=20f;
	private float bikebreakgravity3=0.5f;
	private float bikeacceleration3=1f;

	/*private float superspeedmobile1=2f;
	private float superspeedmotor1=2f;
	private float supermaxspeed1=2f;
	private float superbreakmass1=20f;
	private float superbreakgravity1=0.5f;
	private float superacceleration1=1f;

	private float superspeedmobile2=2f;
	private float superspeedmotor2=2f;
	private float supermaxspeed2=49;
	private float superbreakmass2=240;
	private float superbreakgravity2=5;
	private float superacceleration2=20;

	private float superspeedmobile3=41;
	private float superspeedmotor3=41;
	private float supermaxspeed3=51;
	private float superbreakmass3=260;
	private float superbreakgravity3=5.5f;
	private float superacceleration3=21;

	private float partyspeedmobile1=32;
	private float partyspeedmotor1=32;
	private float partymaxspeed1=42;
	private float partybreakmass1=170;
	private float partybreakgravity1=2.5f;
	private float partyacceleration1=14;

	private float partyspeedmobile2=34;
	private float partyspeedmotor2=34;
	private float partymaxspeed2=44;
	private float partybreakmass2=190;
	private float partybreakgravity2=3;
	private float partyacceleration2=15;

	private float partyspeedmobile3=36;
	private float partyspeedmotor3=36;
	private float partymaxspeed3=46;
	private float partybreakmass3=210;
	private float partybreakgravity3=3.5f;
	private float partyacceleration3=16;

	private float nightmarespeedmobile1=40;
	private float nightmarespeedmotor1=40;
	private float nightmaremaxspeed1=50;
	private float nightmarebreakmass1=260;
	private float nightmarebreakgravity1=3;
	private float nightmareacceleration1=21;

	private float nightmarespeedmobile2=42;
	private float nightmarespeedmotor2=42;
	private float nightmaremaxspeed2=52;
	private float nightmarebreakmass2=280;
	private float nightmarebreakgravity2=3.5f;
	private float nightmareacceleration2=22;

	private float nightmarespeedmobile3=44;
	private float nightmarespeedmotor3=44;
	private float nightmaremaxspeed3=54;
	private float nightmarebreakmass3=300;
	private float nightmarebreakgravity3=4;
	private float nightmareacceleration3=23;

	private float monsterspeedmobile1=34;
	private float monsterspeedmotor1=34;
	private float monstermaxspeed1=44;
	private float monsterbreakmass1=220;
	private float monsterbreakgravity1=5.5f;
	private float monsteracceleration1=13;

	private float monsterspeedmobile2=36;
	private float monsterspeedmotor2=36;
	private float monstermaxspeed2=46;
	private float monsterbreakmass2=240;
	private float monsterbreakgravity2=6;
	private float monsteracceleration2=14;

	private float monsterspeedmobile3=38;
	private float monsterspeedmotor3=38;
	private float monstermaxspeed3=48;
	private float monsterbreakmass3=260;
	private float monsterbreakgravity3=6.5f;
	private float monsteracceleration3=15;

	private float neonspeedmobile1=36;
	private float neonspeedmotor1=36;
	private float neonmaxspeed1=48;
	private float neonbreakmass1=240;
	private float neonbreakgravity1=3;
	private float neonacceleration1=22;

	private float neonspeedmobile2=38;
	private float neonspeedmotor2=38;
	private float neonmaxspeed2=50;
	private float neonbreakmass2=260;
	private float neonbreakgravity2=3.5f;
	private float neonacceleration2=23;

	private float neonspeedmobile3=40;
	private float neonspeedmotor3=40;
	private float neonmaxspeed3=52;
	private float neonbreakmass3=280;
	private float neonbreakgravity3=4;
	private float neonacceleration3=24;

	private float hellspeedmobile1=38;
	private float hellspeedmotor1=38;
	private float hellmaxspeed1=48;
	private float hellbreakmass1=260;
	private float hellbreakgravity1=5.5f;
	private float hellacceleration1=21;
	
	private float hellspeedmobile2=40;
	private float hellspeedmotor2=40;
	private float hellmaxspeed2=50;
	private float hellbreakmass2=280;
	private float hellbreakgravity2=6;
	private float hellacceleration2=22;
	
	private float hellspeedmobile3=42;
	private float hellspeedmotor3=42;
	private float hellmaxspeed3=52;
	private float hellbreakmass3=300;
	private float hellbreakgravity3=6.5f;
	private float hellacceleration3=23;

	private float testspeedmobile1=36;
	private float testspeedmotor1=36;
	private float testmaxspeed1=48;
	private float testbreakmass1=240;
	private float testbreakgravity1=3;
	private float testacceleration1=22;
	
	private float testspeedmobile2=38;
	private float testspeedmotor2=38;
	private float testmaxspeed2=50;
	private float testbreakmass2=260;
	private float testbreakgravity2=3.5f;
	private float testacceleration2=23;
	
	private float testspeedmobile3=40;
	private float testspeedmotor3=40;
	private float testmaxspeed3=52;
	private float testbreakmass3=280;
	private float testbreakgravity3=4;
	private float testacceleration3=24;
*/

	private GameObject effect = null;
	private GameObject effectnitro = null;
	private GameObject effectburn = null;
	public static GameObject effectstatic = null;
	public static GameObject effectnitrostatic = null;
	public static bool ifnitro = false;
	public static bool offnitro = false;
	private int time = 0;

	private int healtcount = 0;
	private int virtualmoneycount = 0;

	public game_master my_game_master;
	public static int my_item_ID;


	private void callthrottleTexture(){
		accelerate = true;
	}
	private void uncallthrottleTexture(){
		accelerate = false;
	}

	void UpgradeInventory(){

		my_game_master = (game_master)game_master.game_master_obj.GetComponent("game_master");
		//if (!my_game_master == null) {
			int levelupgrade = my_game_master.incremental_item_current_level [my_game_master.current_profile_selected] [my_item_ID];

			//string bikeupgrade = StoreInventory.GetGoodCurrentUpgrade ("bike_upgrade");
			int bikeupgradelevel = 0;
			if (my_item_ID == 0) {
				//bikeupgradelevel = StoreInventory.GetGoodUpgradeLevel ("bike_upgrade");
				bikeupgradelevel = levelupgrade;

			}
			//string superupgrade = StoreInventory.GetGoodCurrentUpgrade ("super_bike_upgrade");
			int superupgradelevel = 0;
			if (my_item_ID == 1) {
				superupgradelevel = levelupgrade;
			}
			//string partyupgrade = StoreInventory.GetGoodCurrentUpgrade ("party_bike_upgrade");
			int partyupgradelevel = 0;
			if (my_item_ID == 2) {
				partyupgradelevel = levelupgrade;
			}
			//string nightmareupgrade = StoreInventory.GetGoodCurrentUpgrade ("nightmare_bike_upgrade");
			int nightmareupgradelevel = 0;
			if (my_item_ID == 3) {
				nightmareupgradelevel = levelupgrade;
			}
			//string monsterupgrade = StoreInventory.GetGoodCurrentUpgrade ("monster_bike_upgrade");
			int monsterupgradelevel = 0;
			if (my_item_ID == 4) {
				monsterupgradelevel = levelupgrade;
			}
			//string neonupgrade = StoreInventory.GetGoodCurrentUpgrade ("neon_bike_upgrade");
			int neonupgradelevel = 0;
			if (my_item_ID == 5) {
				neonupgradelevel = levelupgrade;
			}
			//string hellupgrade = StoreInventory.GetGoodCurrentUpgrade ("hell_bike_upgrade");
			int hellupgradelevel = 0;
			if (my_item_ID == 6) {
				hellupgradelevel = levelupgrade;
			}



			if (this.name == "bike(Clone)") {
				if (bikeupgradelevel != 0) {
					if (bikeupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (bikeupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (bikeupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "super_bike(Clone)") {
				if (superupgradelevel != 0) {
					if (superupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (superupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (superupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "party_bike(Clone)") {
				if (partyupgradelevel != 0) {
					if (partyupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (partyupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (partyupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				} 
			} else if (this.name == "nightmare_bike(Clone)") {
				if (nightmareupgradelevel != 0) {
					if (nightmareupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (nightmareupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (nightmareupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "monster_bike(Clone)") {
				if (monsterupgradelevel != 0) {
					if (monsterupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (monsterupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (monsterupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "neon_bike(Clone)") {
				if (neonupgradelevel != 0) {
					if (neonupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (neonupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (neonupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "hell_bike(Clone)") {
				if (hellupgradelevel != 0) {
					if (hellupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (hellupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (hellupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "blue_bike(Clone)") {
				if (bikeupgradelevel != 0) {
					if (bikeupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (bikeupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (bikeupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "summer_bike(Clone)") {
				if (bikeupgradelevel != 0) {
					if (bikeupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (bikeupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (bikeupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "peace_bike(Clone)") {
				if (bikeupgradelevel != 0) {
					if (bikeupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (bikeupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (bikeupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			} else if (this.name == "sunshine_bike(Clone)") {
				if (bikeupgradelevel != 0) {
					if (bikeupgradelevel == 1) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile1;
						SpeedMotor = SpeedMotor + bikespeedmotor1;
						MaxSpeed = MaxSpeed + bikemaxspeed1;
						BreakMass = BreakMass + bikebreakmass1;
						BreakGravity = BreakGravity + bikebreakgravity1;
						Acceleration = Acceleration + bikeacceleration1;
					}
					if (bikeupgradelevel == 2) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile2;
						SpeedMotor = SpeedMotor + bikespeedmotor2;
						MaxSpeed = MaxSpeed + bikemaxspeed2;
						BreakMass = BreakMass + bikebreakmass2;
						BreakGravity = BreakGravity + bikebreakgravity2;
						Acceleration = Acceleration + bikeacceleration2;
					}
					if (bikeupgradelevel == 3) {
						SpeedMotorMobile = SpeedMotorMobile + bikespeedmobile3;
						SpeedMotor = SpeedMotor + bikespeedmotor3;
						MaxSpeed = MaxSpeed + bikemaxspeed3;
						BreakMass = BreakMass + bikebreakmass3;
						BreakGravity = BreakGravity + bikebreakgravity3;
						Acceleration = Acceleration + bikeacceleration3;
					}
				}
			}
		//}
	}
	public void HorizontalDirection(Vector2 touchPosition, int position){
		
		// Verify if the fordward button is touched.
		if (forwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Began)
		{
			accelerate = true;
			// Verify if the forward button is released.
		}else if (forwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Ended){
			accelerate = false;
		}
		// Verify if the backward button is touched.
		if(backwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Began){
			brake = true;
			// Verify if the backward button is released.
		}else if(backwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Ended){
			brake = false;
		}
	}
	public void VerticalDirection(Vector2 touchPosition, int position){
		// Verify if the tilt forward button is touched.
		if (tiltForwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Began)
		{
			right = true;
			// Verify if the tilt forward button is released.
		}else if (tiltForwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Ended){
			right = false;
		}
		// Verify if the tilt backward button is touched.
		if(tiltBackwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Began){
			left = true;
			// Verify if the tilt backward button is released.
		}else if(tiltBackwardsBtn == Physics2D.OverlapPoint(touchPosition) && Input.GetTouch(position).phase == TouchPhase.Ended){
			left = false;
		}
		
	}
	public void SendScore() {
		//long score = 0;
		//score = Convert.ToInt64(long.Parse(win_screen_int_score_count.text));
		GooglePlayManager.Instance.SubmitScoreById(LEADERBOARD_ID,scorestatic);
		
	}
	public void SENDACHIEVEMENT(string id) {

		GooglePlayManager.Instance.UnlockAchievement (id);

	}
	
	public void SENDACHIEVEMENTINCREMENT(string id,int increment) {

		GooglePlayManager.Instance.IncrementAchievementById (id, increment);

	}
	private void Toast() {
		AndroidToast.ShowToastNotification ("Hello Toast", AndroidToast.LENGTH_LONG);
	}
	
	private void Local() {
		LastNotificationId = AndroidNotificationManager.instance.ScheduleLocalNotification("Hello", "This is local notification", 5);
	}
	
	private void LoadLaunchNotification (){
		AndroidNotificationManager.instance.OnNotificationIdLoaded += OnNotificationIdLoaded;
		AndroidNotificationManager.instance.LocadAppLaunchNotificationId();
	}
	
	private void CanselLocal() {
		AndroidNotificationManager.instance.CancelLocalNotification(LastNotificationId);
	}
	
	private void CancelAll() {
		AndroidNotificationManager.instance.CancelAllLocalNotifications();
	}
	
	
	private void Reg() {
		GoogleCloudMessageService.instance.RgisterDevice();
	}
	
	private void LoadLastMessage() {
		GoogleCloudMessageService.instance.LoadLastMessage();
	}
	
	
	private void LocalNitificationsListExample() {
		//		List<LocalNotificationTemplate> PendingNotofications;
		//	PendingNotofications = AndroidNotificationManager.instance.LoadPendingNotifications();
	}
	

	void HandleActionCMDRegistrationResult (GP_GCM_RegistrationResult res) {
		if(res.isSuccess) {
			AN_PoupsProxy.showMessage ("Regstred", "GCM REG ID: " + GoogleCloudMessageService.instance.registrationId);
		} else {
			AN_PoupsProxy.showMessage ("Reg Failed", "GCM Registration failed :(");
		}
	}

	private void OnNotificationIdLoaded (int notificationid){
		AN_PoupsProxy.showMessage ("Loaded", "App was laucnhed with notification id: " + notificationid);
	}

	private void OnMessageLoaded(string msg) {
		AN_PoupsProxy.showMessage ("Message Loaded", "Last GCM Message: " + GoogleCloudMessageService.instance.lastMessage);
	}
	void Awake()
	{

		//GoogleCloudMessageService.ActionCMDRegistrationResult += HandleActionCMDRegistrationResult;
		//GoogleCloudMessageService.ActionCouldMessageLoaded += OnMessageLoaded;
		//GoogleCloudMessageService.Instance.Init();
//		SmokeEmmiter = Smoke.GetComponent<ParticleAnimator>();
		WheelRadius = new float[Wheels.Length];

	}

	private GameObject AuraModular;
	private GameObject GroundModular2;
	private GameObject SpinningModular;
	private GameObject SpinningModular2;
	private GameObject SkullRotate;
	private GameObject LifeImpact1;
	private GameObject LifeImpact2;
	private GameObject SpinningFire;
	private GameObject SpinningFire1;


	void Start()
	{
		accelerate = false;
		rearWheel.freezeRotation = true;
		frontWheel.freezeRotation = true;
		//forwardsBtn = null;
		//Velocity = 0f;
		isFinish = false;
		/*if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			//GooglePlayConnection.Instance.Disconnect ();
		} else {
			GooglePlayConnection.Instance.Connect ();
		}*/
		//SpeedMotorMobile = SpeedMotorMobile + 10;

		if (this.name == "super_bike(Clone)") {
			AuraModular = GameObject.Find ("AuraModular");
			AuraModular.SetActive (false);
			GroundModular2 = GameObject.Find ("GroundModular2");
			GroundModular2.SetActive (false);
		}
		if (this.name == "party_bike(Clone)") {
			SpinningModular = GameObject.Find ("SpinningModular");
			SpinningModular.SetActive (false);
			SpinningModular2 = GameObject.Find ("SpinningModular (1)");
			SpinningModular2.SetActive (false);
		}
		if (this.name == "nightmare_bike(Clone)") {
			SkullRotate = GameObject.Find ("SkullRotate");
			SkullRotate.SetActive (false);
		}
		if (this.name == "monster_bike(Clone)") {
			LifeImpact1 = GameObject.Find ("LifeImpact1");
			LifeImpact1.SetActive (false);
			LifeImpact2 = GameObject.Find ("LifeImpact2");
			LifeImpact2.SetActive (false);
		}
		if (this.name == "hell_bike(Clone)") {
			SpinningFire = GameObject.Find ("SpinningFire (2)");
			SpinningFire.SetActive (false);
			SpinningFire1 = GameObject.Find ("SpinningFire (1)");
			SpinningFire1.SetActive (false);
		}

		if (SelectedCharacter.super_bike_effect) {
			if(this.name == "super_bike(Clone)"){
				AuraModular.SetActive(true);
				GroundModular2.SetActive (true);
			}
		} 
		if (SelectedCharacter.party_effect) {
			if(this.name == "party_bike(Clone)"){
			SpinningModular.SetActive(true);
			SpinningModular2.SetActive(true);
			}
		}
		if (SelectedCharacter.nightmare_effect) {
			if(this.name == "nightmare_bike(Clone)"){
			SkullRotate.SetActive(true);
			}
		}
		if (SelectedCharacter.monster_effect) {
			if(this.name == "monster_bike(Clone)"){
				LifeImpact1.SetActive(true);
				LifeImpact2.SetActive(true);
			}
		}
		if (SelectedCharacter.neon_effect) {
			if(this.name == "neon_bike(Clone)"){
				GameObject.Find ("Main Camera").GetComponent<GlowEffect.GlowEffect> ().enabled = true;
			}
		} else {
			if(this.name == "neon_bike(Clone)"){
				GameObject.Find ("Main Camera").GetComponent<GlowEffect.GlowEffect> ().enabled = false;
			}
		}
		if (SelectedCharacter.hell_effect) {
			if(this.name == "hell_bike(Clone)"){
				SpinningFire.SetActive(true);
				SpinningFire1.SetActive(true);
			}
		}

		//Motorcycle_Controller2D.checkpoint = false;
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
		if (!testing) {
			if (my_game_uGUI) {
				/*int health = StoreInventory.GetItemBalance ("health");
				
				if (health != 0) {
					healtcount = healtcount + 5 * health;
				}
				int healthx2 = StoreInventory.GetItemBalance ("healthx2");
				int healtcountx2 = 0;
				if (healthx2 != 0) {
					healtcount = healtcount + 10 * healthx2;
				}
				int healthx3 = StoreInventory.GetItemBalance ("healthx3");
				int healtcountx3 = 0;
				if (healthx3 != 0) {
					healtcount = healtcount + 15 * healthx3;
				}
				*/
				//healtcount = healtcount + Convert.ToInt32(my_game_uGUI.lives_count);
				//virtualmoneycount = Convert.ToInt32(my_game_uGUI.virtual_money_count) + virtualmoneycount + StoreInventory.GetItemBalance (StoreInfo.Currencies [0].ItemId);
		

			//	my_game_uGUI.Update_lives (healtcount);

				//my_game_uGUI.Update_virtual_money (virtualmoneycount);
			}

		}
		crashBurned = false;
		crashDrown = false;
		crashDrowned = false;
		time =0;
		ifnitro = false;
		/*if (GameObject.Find ("smoke_effect_purple(Clone)")) {
			effect = GameObject.Find ("smoke_effect_purple(Clone)");
			effectstatic = effect;
		}
		if (GameObject.Find ("blood_effect(Clone)")) {
			effect = GameObject.Find ("blood_effect(Clone)");
			effectstatic = effect;
		}
		if (GameObject.Find ("fire_effect(Clone)")) {
			effect = GameObject.Find ("fire_effect(Clone)");
			effectstatic = effect;
		}
		if (GameObject.Find ("ice_effect(Clone)")) {
			effect = GameObject.Find ("ice_effect(Clone)");
			effectstatic = effect;
		}
		if (GameObject.Find ("electric_effect(Clone)")) {
			effect = GameObject.Find ("electric_effect(Clone)");
			effectstatic = effect;
		}
		if (GameObject.Find ("wave_effect(Clone)")) {
			effect = GameObject.Find ("wave_effect(Clone)");
			effectstatic = effect;
		}
		if (GameObject.Find ("neon_effect(Clone)")) {
			effect = GameObject.Find ("neon_effect(Clone)");
			effectstatic = effect;
		}
		*/
		if (GameObject.Find ("nitro_effect")) {
			effectnitro = GameObject.Find ("nitro_effect");
			effectnitrostatic = effectnitro;
		}
		if (GameObject.Find ("burn_effect")) {
			effectburn = GameObject.Find ("burn_effect");
		}

		effect = GameObject.Find ("fire_effect");
		effectstatic = effect;

		GetComponent<AudioSource>().pitch = StartingPitch;
		GetComponent<AudioSource>().volume = 1.0f;

		BodyCarStatic = Car;
		CarBodyStatic = CarBody;
		PoliStatic = Poli;
		HelmetStatic = helmet;

		rightarmStatic = rightHand;
		leftarmStatic = leftHand;
		legStatic = leg;
		trunkStatic = trunk;
		
		CarBodyTransformStatic = CarBodyTransform;
		frontWheelStatic = frontWheelObject;
		backWheelStatic = backWheelObject;

	
		if(useUpgrade){
		UpgradeInventory ();
		}
		nubes = GameObject.Find ("Nubes");
		edif2 = GameObject.Find ("edif 2");
		humo = GameObject.Find ("humo");
		edif1 = GameObject.Find ("edif 1");
		/*
		CarBody = GameObject.Find("Body2D");
		CenterOfMass = GameObject.Find("CoM2D");
		Smoke = GameObject.Find("Smoke");
		Ensemble = GameObject.Find("Ensemble2D");
		*/
		endTime = Time.time + endTime;
		
		crashSaw = false;
		crashSawHead = false;
		
		crash = false;
		crashed = false;
		isControllable = true;
		//mobileButtons = GameObject.Find ("mobile buttons").transform;
		forwardsBtn = GameObject.Find ("throttle").GetComponent<Collider2D>();
		backwardsBtn = GameObject.Find ("brake").GetComponent<Collider2D>();
		tiltForwardsBtn = GameObject.Find ("right").GetComponent<Collider2D>(); 
		tiltBackwardsBtn = GameObject.Find ("left").GetComponent<Collider2D>();

		/*
		throttleTexture = GameObject.Find ("throttle").GetComponent<Button>();
		brakeTexture = GameObject.Find ("brake").GetComponent<Button>();
		leftTexture = GameObject.Find ("left").GetComponent<Button> ();
		rightTexture = GameObject.Find ("right").GetComponent<Button>();

		*/
		backflipParticle = GameObject.Find ("backflip particle").GetComponent<ParticleSystem>();
		frontflipParticle = GameObject.Find ("frontflip particle").GetComponent<ParticleSystem>();
		/*scoreText = GameObject.Find ("score text").GetComponent<GUIText>();
		scoreText.text = "SCORE : " + score;
		//change score text color
		scoreText.material.color = scoreTextColor; 	
		*/
		Camera.main.GetComponent<CameraFollow2D>().target = CarBody.transform;	
		
		audioSource = Car.GetComponent<AudioSource>();		
		
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

		if (lastcheckpoint) {
			//if ((Input.GetKeyDown (KeyCode.C) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)) && crashed) {
			if (checkpoint) {
				//Checkpoint.Reset ();
				//Destroy (gameObject);
				
				Car.transform.position = lastcheckpoint.position;
				crash = false;
				crashed=false;
			}
		}
		//CalculateVelocity();
	}
	
	void DestroyBike(){

	
		GameObject soul =  CFXM2_Soul; //(GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
		Instantiate(soul, CarBody.transform.position, Quaternion.identity);
		GameObject explotion = CFXM_ExplosionTextNoSmoke;//(GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
		Instantiate(explotion, CarBody.transform.position, Quaternion.identity);
		GameObject smoke = CFXM_GroundSmokeExplosionAlt;//(GameObject)Resources.Load("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
		Instantiate(smoke, CarBody.transform.position, Quaternion.identity);
		
		
		Camera.main.GetComponent<CameraFollow2D>().target = CarBody.transform; //make camera to follow biker's hips	

			unhandlingToDestroy ();


		CarBody.transform.Rotate (Vector3.right * 180);

		
		
		isControllable = false;
		crashed = true;


	}
	
	void FixedUpdate ()
	{      
		
		if (isControllable) {
			if(!isFinish){	
			//if (usingAccelerometer) {
			RotateVehicle ();
			if (!crash && !crashed) {	
			  
				/*if (SpeedMotorMobile > 80) {
					if (fire) {
						Instantiate (fire, CarBody.transform.position, Quaternion.identity);
						fire.transform.position = CarBody.transform.position;
					}
				} else {
					//Destroy(fire);
					//fire.Stop ();
				}*/
				if (ifnitro) {
					effectnitro.SetActive (true);
					effectnitro.transform.position = rearWheel.transform.position;
					//effectnitro.transform.position = Body2D.transform.position;
					effectnitrostatic.transform.position = effectnitro.transform.position;	
				} else {
					effectnitro.SetActive (false);
				}

				if (accelerate) {
					if (ifnitro) {
						//acce / vertical / time / speedmotor
						CurrentVelocity = 20 * Input.GetAxis ("Vertical") * Time.deltaTime * 10;
						//-maxspeed / maxspeed
						Velocity = Mathf.Clamp (CurrentVelocity, -20, 100);


						
						for (var i = 0; i <= (Wheels.Length-1); i++) {
							Wheels [i].GetComponent<Rigidbody2D> ().AddTorque (-1f * (Velocity / WheelRadius [i]) * 10);


						}

					}
					/*else if(offnitro){
						for(var i = 0; i <= (Wheels.Length-1); i++)
						{
							Wheels[i].GetComponent<Rigidbody2D>().AddTorque(1f * (5 / WheelRadius[i]) * 10);
						}
						offnitro = false;
					}*/
					else {

						if (forMobile) {
							SpeedMotorMobile = SpeedMotorMobile;

							CurrentVelocity = Acceleration * InputGetAxis ("Vertical") * Time.deltaTime * SpeedMotorMobile;

							Velocity = Mathf.Clamp (CurrentVelocity, -MaxSpeed, MaxSpeed);

						} else {

							CurrentVelocity = Acceleration * Input.GetAxis ("Vertical") * Time.deltaTime * SpeedMotor;
							//if(Velocity < MaxSpeed){
							Velocity = Mathf.Clamp (CurrentVelocity, -MaxSpeed, MaxSpeed);
							//}
						}
						
						for (var i = 0; i <= (Wheels.Length-1); i++) {
							
							//Wheels[i].GetComponent<Rigidbody2D>().AddTorque(-0.2f * (30 / WheelRadius[i]) * 10);
							Wheels [i].GetComponent<Rigidbody2D> ().AddTorque (-0.1f * (Velocity / WheelRadius [i]) * 10);
						}


					}


					if (onGround) {//if motorcycle is standing on object tagged as "Ground"			
						if (!dirt.isPlaying)
							dirt.Play (); //play dirt particle						
					} 

				} else {
					/*if(nubes){
					nubes.GetComponent<Paralaxcity>().StopScroll();
					edif2.GetComponent<Paralaxcity>().StopScroll();
					humo.GetComponent<Paralaxcity>().StopScroll();
					edif1.GetComponent<Paralaxcity>().StopScroll();
					}*/
					/*
					nubes.GetComponent<Paralaxcity>().enabled = false;
					edif2.GetComponent<Paralaxcity>().enabled = false;
					humo.GetComponent<Paralaxcity>().enabled = false;
					edif1.GetComponent<Paralaxcity>().enabled = false;*/
				}
				if (brake) {
					rearWheel.freezeRotation = true; //disable rotation for rear wheel if player is braking	
					//AudioSource.PlayClipAtPoint(BrakeSound,CarBody.transform.position,10.0f);
				} else {			
					rearWheel.freezeRotation = false; //enable rotation for rear wheel if player isn't braking
					//CarBody.GetComponent<Rigidbody2D>().AddTorque (new Vector2 ((forMobile ? Mathf.Abs(Input.acceleration.x) : 1),0 * groundedWeightFactor * 100 * Time.deltaTime)); 
					//CarBody.GetComponent<Rigidbody2D>().AddTorque (-groundedWeightFactor  * Time.deltaTime,ForceMode2D.Impulse); 
				}
				
				if (left) {
					/*for(var i = 0; i <= (Wheels.length-1); i++)
					{
						Wheels[i].GetComponent.<Rigidbody2D>().AddTorque(-0.2f * (Velocity / WheelRadius[i]) * 10);
					}*/
					CarBody.GetComponent<Rigidbody2D> ().AddTorque (inAirRotationSpeed * 80 * Time.deltaTime, 0);    
					
				}
				if (right) {
					
					CarBody.GetComponent<Rigidbody2D> ().AddTorque (80 * -inAirRotationSpeed * Time.deltaTime, 0);   
					
				}
				
			
				if (Physics.Raycast (rearWheel.transform.position, -CarBody.transform.up, out hit, 0.4f)) { // cast ray to know if motorcycle is in air or grounded
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
		  }else{
			//	brake=true;
			}
		} else {
			dirt.Stop ();
			//brake=true;
			GetUserInput ();		 
		
			//   CalculateVelocity();
		
			GetCurrentspeed ();
		
			/*   if(UserControlled == true)
        {
        	for(var i = 0; i <= (Wheels.length-1); i++)
			{
				Wheels[i].GetComponent.<Rigidbody2D>().AddTorque(-0.2f * (Velocity / WheelRadius[i]) * 10);
			}
        }*/
		}
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
		//accelerate = false;
		rearWheel.freezeRotation = false;
		frontWheel.freezeRotation = false;

		frontWheelStatic = frontWheelObject;
		backWheelStatic = backWheelObject;


		if (Application.loadedLevelName == "W1_Stage_1") {
			float timeLeft = endTime - Time.time;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			if (timeLeft == 0) {
				isControllable = true;
			} else {
				isControllable = false;
			}
		} else {
			float timeLeft = 0 - Time.time;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			if (timeLeft <= 0) {
				isControllable = true;
			} else {
				isControllable = false;
			}
		}
		if (crashed) {
			isControllable = false;
		}
		if (crashBurned) {
			isControllable = false;
		}
		if (crashDrowned) {
			isControllable = false;
		}
		
		if (isControllable) {
			if (!isFinish) {	
				RotateVehicle ();
				if (effect) {
					effect.SetActive (true);
					effect.transform.position = rearWheel.transform.position;
					effectstatic.transform.position = effect.transform.position;			
				}
				if (!crash && !crashed) {
			
					//if(Physics2D.Raycast(frontWheel.position,body.transform.position, out hit, (int)DistToCollided))
					if (Physics.Raycast (frontWheel.position, CarBody.transform.position, out hit, DistToCollided)) {
						if (ObjectToVelocity != null) {
							if (hit.collider.gameObject.name == ObjectToVelocity.name) {
								SpeedMotorMobile = speedSuper;
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
					//mobileButtons = GameObject.Find ("mobile buttons").transform;
				
					var touches = Input.touches;
				
					//accelerate = false;
					//brake = false;
					//left = false;
					//right = false;
					pause = false;
					restart = false;
					leftORright = false;							
				
				
					float angle = 360.0f; // Degree per time unit
					float time = 1.0f; // Time unit in sec
					Vector3 axis = Vector3.left; // Rotation axis, here it the yaw axis
				/*
					leftTexture = mobileButtons.FindChild ("left").GetComponent<GUITexture> ();
					rightTexture = mobileButtons.FindChild ("right").GetComponent<GUITexture> ();
				
					throttleTexture = mobileButtons.FindChild ("throttle").GetComponent<GUITexture> ();
					brakeTexture = mobileButtons.FindChild ("brake").GetComponent<GUITexture> ();
				*/

					/*
					throttleTexture = GameObject.Find ("throttle").GetComponent<GUITexture>();
					brakeTexture = GameObject.Find ("brake").GetComponent<GUITexture>();
					leftTexture = GameObject.Find ("left").GetComponent<GUITexture> ();
					rightTexture = GameObject.Find ("right").GetComponent<GUITexture>();
				
					*/
					
//					leftTexture.enabled = true;
//					rightTexture.enabled = true;
				
//					throttleTexture.enabled = true;
//					brakeTexture.enabled = true;

					//throttleTexture = GameObject.Find ("throttle").GetComponent<Button>();
					if(Input.touches.Length > 0)
					{
						Vector2 touchPos;
						// Look all the touches 
						for(int i = 0; i < Input.touches.Length; i++){
							// Convert the touch position on the screen to the world position.
							Vector2 worldPoint = Input.GetTouch(i).position;
							touchPos = new Vector2(worldPoint.x, worldPoint.y);
							HorizontalDirection(touchPos, i);
							VerticalDirection(touchPos, i);

						}
						
					}

					//clickthrottleTexture()
					foreach (var touch in touches) {	
						string here = "ho";
				
					//	throttleTexture.onClick.AddListener(callthrottleTexture);
					//throttleTexture.onClick.RemoveListener(callthrottleTexture);


					//throttleTexture.onClick.RemoveListener(callthrottleTexture);
						//if (throttleTexture.HitTest (touch.position))//if touch position is inside throttle texture
											
						//	accelerate = true;
					/*
						if (brakeTexture.HitTest (touch.position)) //if touch position is inside brake texture
						//if (clickleftTexture) //if touch position is inside brake texture
						
							brake = true;
					
					
					
						if (leftTexture.HitTest (touch.position))  //left button is touched
						
							left = true;
					
					
						if (rightTexture.HitTest (touch.position)) //right button is touched
						
							right = true;


						if (nitroTexture.HitTest (touch.position)) //if touch position is inside throttle texture
						
						ifnitro = true;
						*/
					
					
					//}
					}
					if (Input.touchCount > 0) {
						string ff="mas o";
					}
					if (Input.touchCount == 0) {
						string ff="ff";
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
					if (!forMobile) {
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
						/*if (Input.GetKeyDown (KeyCode.Q)) {
						ifnitro = true;

					} else {

						ifnitro = false;
					}*/
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
							my_game_uGUI.Update_int_score (setscore);
				
						
						}
						/*if(audioXP){
					audioXP.Play ();
					}*/
						AudioSource.PlayClipAtPoint (audioXP, gameObject.transform.position, 10.0f);

						flip = false;				
						backflipParticle.Emit (1);
					
						if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
						//	makeclick Achievement = new makeclick ();
						SENDACHIEVEMENT (ACHIEVEMENT_ID_First_BackFlip);

						SENDACHIEVEMENTINCREMENT (INCREMENTAL_ACHIEVEMENT_ID_Two_BackFlip, 1);
						}
						//Reciver.SendMessage ("revealAchievement", ACHIEVEMENT_ID_First_BackFlip,SendMessageOptions.DontRequireReceiver);

						//score += 100;
						//scoreText.text = "SCORE : " + score;
					}
				
					if (CarBody.transform.rotation.eulerAngles.z < 30 && flip) { //frontflip is done			
						if (my_game_uGUI) {
							my_game_uGUI.Update_int_score (setscore);
						}
						/*if(audioXP){
					audioXP.Play ();
					}*/
						AudioSource.PlayClipAtPoint (audioXP, gameObject.transform.position, 10.0f);
						flip = false;
						frontflipParticle.Emit (1);
						if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
						//	makeclick Achievement = new makeclick ();
						SENDACHIEVEMENT (ACHIEVEMENT_ID_First_FrontFlip);
						SENDACHIEVEMENTINCREMENT (INCREMENTAL_ACHIEVEMENT_ID_Two_FrontFlip, 1);
						}
						//	Reciver.SendMessage ("revealAchievement", INCREMENTAL_ACHIEVEMENT_ID_Two_FrontFlip,SendMessageOptions.DontRequireReceiver);
						//score += 150;	
						//scoreText.text = "SCORE : " + score;					
					}
				
				
					//changing engine sound pitch depending rear wheel rotational speed
					if (accelerate) {

						if (GetComponent<AudioSource> ().pitch < MaxPitch)
							GetComponent<AudioSource> ().pitch += ((Time.deltaTime) / TimeToIncrease);

						/*pitch = rearWheel.velocity.sqrMagnitude / Velocity;
					pitch *= Time.deltaTime * 2;
					pitch = Mathf.Clamp (pitch + 1, 0.5f, 1.8f);	*/
					} else {
						if (GetComponent<AudioSource> ().pitch > StartingPitch)
							GetComponent<AudioSource> ().pitch -= ((Time.deltaTime) / TimeToDecrease);

						/*pitch = audioSource.pitch;
					pitch = Mathf.Clamp (pitch - Time.deltaTime * 2, 0.5f, 1.8f);	*/															
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
					/*if ((Input.GetKeyDown (KeyCode.X) || (Input.touchCount >= 2 && Input.GetTouch (0).phase == TouchPhase.Began))) {
				
						handling ("");
					}
					if (Input.GetKeyUp (KeyCode.X)) {

						unhandling ("");

						/*hingeJoints = Body2D.GetComponents<HingeJoint2D>();	
					StartCoroutine(Coroutine(4,0.40f));
					StartCoroutine(Coroutine(3,1.10f));
					StartCoroutine(Coroutine(1,1.50f));

					}*/


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
					/*if (Checkpoint.lastPoint) {
					//if ((Input.GetKeyDown (KeyCode.C) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)) && crashed) {
					if (checkpoint) {
					Checkpoint.Reset ();
					Destroy (gameObject);
					}
				}*/
				}
			
				if (crash && !crashed) { //if player just crashed											
					if (ifnitro) {
						effectnitro.SetActive (false);

					}
					if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
					//makeclick Achievement = new makeclick();
					SENDACHIEVEMENT (ACHIEVEMENT_ID_First_Death);
					}
					//AN_PoupsProxy.showMessage ("Achievement unlocked","You Firts Death","Ok");
					//	Reciver.SendMessage ("revealAchievement", ACHIEVEMENT_ID_First_Death,SendMessageOptions.DontRequireReceiver);

					GameObject soul = CFXM2_Soul;//(GameObject)Resources.Load ("prefabs/CFXM2_Soul", typeof(GameObject));
					Instantiate (soul, CarBody.transform.position, Quaternion.identity);
					GameObject explotion = CFXM_ExplosionTextNoSmoke;//(GameObject)Resources.Load ("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
					Instantiate (explotion, CarBody.transform.position, Quaternion.identity);
					GameObject smoke = CFXM_GroundSmokeExplosionAlt;//(GameObject)Resources.Load ("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
					Instantiate (smoke, CarBody.transform.position, Quaternion.identity);

					AudioSource.PlayClipAtPoint (BodyDeadSound, CarBody.transform.position, 10.0f);

					Camera.main.GetComponent<CameraFollow2D> ().target = CarBody.transform; //make camera to follow biker's hips	
				
					unhandlingToDestroy ();

					CarBody.transform.Rotate (Vector3.right * 180);

				
					isControllable = false;
					crashed = true;
					//update lives
					if (my_game_uGUI) {
						my_game_uGUI.Update_lives(-1);
						Invoke ("endgui", 2.0f);
						//my_game_uGUI.Update_lives(live);
					}




				}
				if (crashBurn && !crashed) { //if player just crashed		
					if (ifnitro) {
						effectnitro.SetActive (false);
					}
					time = time + 1;
					effectburn.transform.position = CarBody.transform.position;
					if (time == 1) {
						if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
						//makeclick Achievement = new makeclick();
						SENDACHIEVEMENT (ACHIEVEMENT_ID_First_Burn);
						}
						//	Reciver.SendMessage ("revealAchievement", ACHIEVEMENT_ID_First_Burn,SendMessageOptions.DontRequireReceiver);
						/*
					GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
					Instantiate(soul, CarBody.transform.position, Quaternion.identity);
					GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
					Instantiate(explotion, CarBody.transform.position, Quaternion.identity);
					GameObject smoke = (GameObject)Resources.Load("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
					Instantiate(smoke, CarBody.transform.position, Quaternion.identity);
					*/


						CFX_SpawnSystem.Instantiate (effectburn);
						AudioSource.PlayClipAtPoint (BodyDeadBurnSound, CarBody.transform.position, 10.0f);
					
						Camera.main.GetComponent<CameraFollow2D> ().target = CarBody.transform; //make camera to follow biker's hips	
					
						//unhandlingToDestroy ();
					
						//CarBody.transform.Rotate (Vector3.right * 180);
					
					
						//isControllable = false;
						//crashed = true;
						//update lives
						if (my_game_uGUI) {
							my_game_uGUI.Update_lives(-1);
							Invoke ("endguiburn", 2.0f);

						}
					}
				}
				if (crashDrown && !crashed) { //if player just crashed	
					if (ifnitro) {
						effectnitro.SetActive (false);
					}
					time = time + 1;
					//effectburn.transform.position = CarBody.transform.position;
					if (time == 1) {
						if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
						//makeclick Achievement = new makeclick();
						SENDACHIEVEMENT (ACHIEVEMENT_ID_First_Drown);
						}
						//	Reciver.SendMessage ("revealAchievement", ACHIEVEMENT_ID_First_Burn,SendMessageOptions.DontRequireReceiver);
						/*
					GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
					Instantiate(soul, CarBody.transform.position, Quaternion.identity);
					GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
					Instantiate(explotion, CarBody.transform.position, Quaternion.identity);
					GameObject smoke = (GameObject)Resources.Load("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
					Instantiate(smoke, CarBody.transform.position, Quaternion.identity);
					*/
					
					
						//CFX_SpawnSystem.Instantiate (effectburn);
						AudioSource.PlayClipAtPoint (BodyDeadDrownSound, CarBody.transform.position, 10.0f);
					
						Camera.main.GetComponent<CameraFollow2D> ().target = CarBody.transform; //make camera to follow biker's hips	
					
						//unhandlingToDestroy ();
					
						//CarBody.transform.Rotate (Vector3.right * 180);
					
					
						isControllable = false;
						//crashed = true;
						//update lives
						if (my_game_uGUI) {
							my_game_uGUI.Update_lives(-1);
							Invoke ("endguidrown", 2.0f);
						
						}
					}
				}
				if (crashSaw && !crashed) { //if player just crashed											
					if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
					//makeclick Achievement = new makeclick();
					SENDACHIEVEMENT (ACHIEVEMENT_ID_First_Death);
					}
					//	Reciver.SendMessage ("revealAchievement", ACHIEVEMENT_ID_First_Death,SendMessageOptions.DontRequireReceiver);

					GameObject soul = CFXM2_Soul;//(GameObject)Resources.Load ("prefabs/CFXM2_Soul", typeof(GameObject));
					Instantiate (soul, CarBody.transform.position, Quaternion.identity);
					GameObject explotion = CFXM_ExplosionTextNoSmoke;//(GameObject)Resources.Load ("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
					Instantiate (explotion, CarBody.transform.position, Quaternion.identity);
					GameObject smoke = CFXM_GroundSmokeExplosionAlt;//(GameObject)Resources.Load ("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
					Instantiate (smoke, CarBody.transform.position, Quaternion.identity);
				
					AudioSource.PlayClipAtPoint (BodyDeadSound, CarBody.transform.position, 10.0f);
				
					Camera.main.GetComponent<CameraFollow2D> ().target = CarBody.transform; //make camera to follow biker's hips	

					unhandlingToDestroy ();
				
					CarBody.transform.Rotate (Vector3.right * 180);
				
				
					isControllable = false;
					crashed = true;
					//update lives
					if (my_game_uGUI) {
						my_game_uGUI.Update_lives(-1);
						Invoke ("endgui", 2.0f);
						//my_game_uGUI.Update_lives(live);
					}
				
				}
				if (crashSawHead && !crashed) { //if player just crashed											
					if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
					//makeclick Achievement = new makeclick();
					SENDACHIEVEMENT (ACHIEVEMENT_ID_First_Death);
					//Reciver.SendMessage ("revealAchievement", ACHIEVEMENT_ID_First_Death,SendMessageOptions.DontRequireReceiver);
					}
					GameObject soul = CFXM2_Soul;//(GameObject)Resources.Load ("prefabs/CFXM2_Soul", typeof(GameObject));
					Instantiate (soul, CarBody.transform.position, Quaternion.identity);
					GameObject explotion = CFXM_ExplosionTextNoSmoke;//(GameObject)Resources.Load ("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
					Instantiate (explotion, CarBody.transform.position, Quaternion.identity);
					GameObject smoke = CFXM_GroundSmokeExplosionAlt;//(GameObject)Resources.Load ("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
					Instantiate (smoke, CarBody.transform.position, Quaternion.identity);
				
					AudioSource.PlayClipAtPoint (BodyDeadSound, CarBody.transform.position, 10.0f);
				
					Camera.main.GetComponent<CameraFollow2D> ().target = CarBody.transform; //make camera to follow biker's hips	
				
					unhandlingToDestroySawHead ();
				
					CarBody.transform.Rotate (Vector3.right * 180);
				
				
					isControllable = false;
					crashed = true;
					//update lives
					if (my_game_uGUI) {
						my_game_uGUI.Update_lives(-1);
						Invoke ("endgui", 2.0f);
						//my_game_uGUI.Update_lives(live);
					}
				
				}
			} else {
			//	brake = true;
			}
			
		} else {
			//brake=true;
		}
	

	
		/*
		Vector3 temp = SmokeEmmiter.force;
		temp.y = (SmokeEmmiter.force.y) * 0.5f;
		SmokeEmmiter.force = temp;*/
		//	transform.Translate(Input.acceleration.x, 0, -Input.acceleration.y);
		//SmokeEmmiter.force.y = Velocity * 20f;
	}

	void endgui()
	{
		if(my_game_uGUI){
			crashSaw = false;
			crashSawHead = false;
			crash = false;
			crashed = true;
			my_game_uGUI.Defeat();

		}
	}
	void endguiburn()
	{
		if(my_game_uGUI){
			crashBurn = false;
			crashBurned = true;
			//crashed = true;
			my_game_uGUI.Defeat();
			brake = true;
			//my_game_uGUI.Update_lives(-1);

		}
	}
	void endguidrown()
	{
		if(my_game_uGUI){
			crashDrown = false;
			crashDrowned = true;
			//crashed = true;
			my_game_uGUI.Defeat();
			//brake = true;
			//my_game_uGUI.Update_lives(-1);
			
		}
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
	public void unhandlingToDestroy()
	{

			hingeJoints = Body2D.GetComponents<HingeJoint2D> ();	
			//boots.GetComponent<Rigidbody2D>().AddTorque (-1080,0); 
			hingeJoints [0].enabled = false;
			hingeJoints [1].enabled = false;
			hingeJoints [2].enabled = false;
			hingeJoints [3].enabled = false;
			/*if (hingeJoints [4]) {
				hingeJoints [4].enabled = false;
			}*/
			wheelJoints = Body2D.GetComponents<WheelJoint2D> ();
			wheelJoints [0].enabled = false;
			wheelJoints [1].enabled = false;
			
			leftHandJoints = leftHand.GetComponents<HingeJoint2D> ();	
			rightHandJoints = rightHand.GetComponents<HingeJoint2D> ();	
			bootsJoints = boots.GetComponents<HingeJoint2D> ();	
			kneeJoints = knee.GetComponents<HingeJoint2D> ();	
			legJoints = leg.GetComponents<HingeJoint2D> ();	
			helmetJoints = helmet.GetComponents<HingeJoint2D> ();	
			
			leftHandJoints [0].enabled = false;
			rightHandJoints [0].enabled = false;
			bootsJoints [0].enabled = false;
			kneeJoints [0].enabled = false;
			legJoints [0].enabled = false;
			helmetJoints [0].enabled = false;
	


	}
	public void unhandlingToDestroySawHead()
	{
		
		hingeJoints = Body2D.GetComponents<HingeJoint2D> ();	
		//boots.GetComponent<Rigidbody2D>().AddTorque (-1080,0); 
		/*hingeJoints [0].enabled = false;
		hingeJoints [1].enabled = false;
		hingeJoints [2].enabled = false;
		hingeJoints [3].enabled = false;
		hingeJoints [4].enabled = false;
		*/
		leftHandJoints = leftHand.GetComponents<HingeJoint2D> ();	
		rightHandJoints = rightHand.GetComponents<HingeJoint2D> ();	
		bootsJoints = boots.GetComponents<HingeJoint2D> ();	
		kneeJoints = knee.GetComponents<HingeJoint2D> ();	
		legJoints = leg.GetComponents<HingeJoint2D> ();	
		helmetJoints = helmet.GetComponents<HingeJoint2D> ();	

		helmetJoints [0].enabled = false;

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
		if(Input.GetKey(KeyCode.Space) || CarHandbrake == true || brake == true)
		{
			for(var i = 0; i <= (Wheels.Length-1); i++)
			{
				Wheels[i].GetComponent<Rigidbody2D>().fixedAngle = true;

				rearWheel.GetComponent<Rigidbody2D>().mass= BreakMass;
				rearWheel.GetComponent<Rigidbody2D>().gravityScale= BreakGravity;
			}
			//AudioSource.PlayClipAtPoint(BrakeSound,CarBody.transform.position,5.0f);
		}
		
		
		else
		{
			CarHandbrake = false;
			for(var j = 0; j <= (Wheels.Length-1); j++)
			{
				Wheels[j].GetComponent<Rigidbody2D>().fixedAngle = false;
				rearWheel.GetComponent<Rigidbody2D>().mass= 1;
				rearWheel.GetComponent<Rigidbody2D>().gravityScale= 1.0f;
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
