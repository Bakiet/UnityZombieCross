using UnityEngine;
using System.Collections;
using Soomla.Store;

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
	public bool useUpgrade=false;
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

	public AudioClip BodyDeadSound;
	public AudioClip MotoDeadSound;

	
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

	private float bikespeedmobile1=32f;
	private float bikespeedmotor1=32f;
	private float bikemaxspeed1=42f;
	private float bikebreakmass1=170f;
	private float bikebreakgravity1=3.5f;
	private float bikeacceleration1=16f;

	private float bikespeedmobile2=34;
	private float bikespeedmotor2=34;
	private float bikemaxspeed2=44;
	private float bikebreakmass2=190;
	private float bikebreakgravity2=4;
	private float bikeacceleration2=17;

	private float bikespeedmobile3=36;
	private float bikespeedmotor3=36;
	private float bikemaxspeed3=46;
	private float bikebreakmass3=210;
	private float bikebreakgravity3=4.5f;
	private float bikeacceleration3=18;

	private float superspeedmobile1=37;
	private float superspeedmotor1=37;
	private float supermaxspeed1=47;
	private float superbreakmass1=220;
	private float superbreakgravity1=4.5f;
	private float superacceleration1=19;

	private float superspeedmobile2=39;
	private float superspeedmotor2=39;
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

	void UpgradeInventory(){

		string bikeupgrade = StoreInventory.GetGoodCurrentUpgrade ("bike_upgrade");
		int bikeupgradelevel = 0;
		if (bikeupgrade != "") {
			bikeupgradelevel = StoreInventory.GetGoodUpgradeLevel ("bike_upgrade");
		}
		string superupgrade = StoreInventory.GetGoodCurrentUpgrade ("super_bike_upgrade");
		int superupgradelevel = 0;
		if (superupgrade != "") {
			superupgradelevel = StoreInventory.GetGoodUpgradeLevel ("super_bike_upgrade");
		}
		string partyupgrade = StoreInventory.GetGoodCurrentUpgrade ("party_bike_upgrade");
		int partyupgradelevel = 0;
		if (partyupgrade != "") {
			partyupgradelevel = StoreInventory.GetGoodUpgradeLevel ("party_bike_upgrade");
		}
		string nightmareupgrade = StoreInventory.GetGoodCurrentUpgrade ("nightmare_bike_upgrade");
		int nightmareupgradelevel = 0;
		if (nightmareupgrade != "") {
			nightmareupgradelevel = StoreInventory.GetGoodUpgradeLevel ("nightmare_bike_upgrade");
		}
		string monsterupgrade = StoreInventory.GetGoodCurrentUpgrade ("monster_bike_upgrade");
		int monsterupgradelevel = 0;
		if (monsterupgrade != "") {
			monsterupgradelevel = StoreInventory.GetGoodUpgradeLevel ("monster_bike_upgrade");
		}
		string neonupgrade = StoreInventory.GetGoodCurrentUpgrade ("neon_bike_upgrade");
		int neonupgradelevel = 0;
		if (neonupgrade != "") {
			neonupgradelevel = StoreInventory.GetGoodUpgradeLevel ("neon_bike_upgrade");
		}
		string hellupgrade = StoreInventory.GetGoodCurrentUpgrade ("hell_bike_upgrade");
		int hellupgradelevel = 0;
		if (hellupgrade != "") {
			hellupgradelevel = StoreInventory.GetGoodUpgradeLevel ("hell_bike_upgrade");
		}

		string testupgrade = StoreInventory.GetGoodCurrentUpgrade ("test_bike_upgrade");
		int testupgradelevel = 0;
		if (testupgrade != "") {
			testupgradelevel = StoreInventory.GetGoodUpgradeLevel ("test_bike_upgrade");
		}
		if(this.name == "bike(Clone)"){
			if (bikeupgradelevel != 0) {
				if(bikeupgradelevel ==1){
					SpeedMotorMobile = bikespeedmobile1;
					SpeedMotor = bikespeedmotor1;
					MaxSpeed =bikemaxspeed1;
					BreakMass = bikebreakmass1;
					BreakGravity = bikebreakgravity1;
					Acceleration =bikeacceleration1;}
				if(bikeupgradelevel ==2){
					SpeedMotorMobile = bikespeedmobile2;
					SpeedMotor = bikespeedmotor2;
					MaxSpeed =bikemaxspeed2;
					BreakMass = bikebreakmass2;
					BreakGravity = bikebreakgravity2;
					Acceleration =bikeacceleration2;}
				if(bikeupgradelevel ==3){
					SpeedMotorMobile = bikespeedmobile3;
					SpeedMotor = bikespeedmotor3;
					MaxSpeed =bikemaxspeed3;
					BreakMass = bikebreakmass3;
					BreakGravity = bikebreakgravity3;
					Acceleration =bikeacceleration3;}
			}
		} 
		else if(this.name == "super_bike(Clone)"){
			if (superupgradelevel != 0) {
				if(superupgradelevel ==1){
					SpeedMotorMobile = superspeedmobile1;
					SpeedMotor = superspeedmobile1;
					SpeedMotor = superspeedmotor1;
					MaxSpeed =supermaxspeed1;
					BreakMass = superbreakmass1;
					BreakGravity = superbreakgravity1;
					Acceleration =superacceleration1;}
				if(superupgradelevel ==2){
					SpeedMotorMobile = superspeedmobile2;
					SpeedMotor = superspeedmotor2;
					MaxSpeed =supermaxspeed2;
					BreakMass = superbreakmass2;
					BreakGravity = superbreakgravity2;
					Acceleration =superacceleration2;}
				if(superupgradelevel ==3){
					SpeedMotorMobile = superspeedmobile3;
					SpeedMotor = superspeedmotor3;
					MaxSpeed =supermaxspeed3;
					BreakMass = superbreakmass3;
					BreakGravity = superbreakgravity3;
					Acceleration =superacceleration3;}
			}
		}
		else if (this.name == "party_bike(Clone)") {
			if (partyupgradelevel != 0) {
				if (partyupgradelevel == 1) {
					SpeedMotorMobile = partyspeedmobile1;
					SpeedMotor = partyspeedmotor1;
					MaxSpeed = partymaxspeed1;
					BreakMass = partybreakmass1;
					BreakGravity = partybreakgravity1;
					Acceleration = partyacceleration1;
				}
				if (partyupgradelevel == 2) {
					SpeedMotorMobile = partyspeedmobile2;
					SpeedMotor = partyspeedmotor2;
					MaxSpeed = partymaxspeed2;
					BreakMass = partybreakmass2;
					BreakGravity = partybreakgravity2;
					Acceleration = partyacceleration2;
				}
				if (partyupgradelevel == 3) {
					SpeedMotorMobile = partyspeedmobile3;
					SpeedMotor = partyspeedmotor3;
					MaxSpeed = partymaxspeed3;
					BreakMass = partybreakmass3;
					BreakGravity = partybreakgravity3;
					Acceleration = partyacceleration3;
				}
			} 
		}
		else if (this.name == "nightmare_bike(Clone)") {
			if (nightmareupgradelevel != 0) {
				if (nightmareupgradelevel == 1) {
					SpeedMotorMobile = nightmarespeedmobile1;
					SpeedMotor = nightmarespeedmotor1;
					MaxSpeed = nightmaremaxspeed1;
					BreakMass = nightmarebreakmass1;
					BreakGravity = nightmarebreakgravity1;
					Acceleration = nightmareacceleration1;
				}
				if (nightmareupgradelevel == 2) {
					SpeedMotorMobile = nightmarespeedmobile2;
					SpeedMotor = nightmarespeedmotor2;
					MaxSpeed = nightmaremaxspeed2;
					BreakMass = nightmarebreakmass2;
					BreakGravity = nightmarebreakgravity2;
					Acceleration = nightmareacceleration2;
				}
				if (nightmareupgradelevel == 3) {
					SpeedMotorMobile = nightmarespeedmobile3;
					SpeedMotor = nightmarespeedmobile3;
					SpeedMotor = nightmarespeedmotor3;
					MaxSpeed = nightmaremaxspeed3;
					BreakMass = nightmarebreakmass3;
					BreakGravity = nightmarebreakgravity3;
					Acceleration = nightmareacceleration3;
				}
			}
		}
		else if (this.name == "monster_bike(Clone)") {
			if (monsterupgradelevel != 0) {
				if (monsterupgradelevel == 1) {
					SpeedMotorMobile = monsterspeedmobile1;
					SpeedMotor = monsterspeedmotor1;
					MaxSpeed = monstermaxspeed1;
					BreakMass = monsterbreakmass1;
					BreakGravity = monsterbreakgravity1;
					Acceleration = monsteracceleration1;
				}
				if (monsterupgradelevel == 2) {
					SpeedMotorMobile = monsterspeedmobile2;
					SpeedMotor = monsterspeedmotor2;
					MaxSpeed = monstermaxspeed2;
					BreakMass = monsterbreakmass2;
					BreakGravity = monsterbreakgravity2;
					Acceleration = monsteracceleration2;
				}
				if (monsterupgradelevel == 3) {
					SpeedMotorMobile = monsterspeedmobile3;
					SpeedMotor = monsterspeedmotor3;
					MaxSpeed = monstermaxspeed3;
					BreakMass = monsterbreakmass3;
					BreakGravity = monsterbreakgravity3;
					Acceleration = monsteracceleration3;
				}
			}
		}
		else if (this.name == "neon_bike(Clone)") {
			if (neonupgradelevel != 0) {
				if (neonupgradelevel == 1) {
					SpeedMotorMobile = neonspeedmobile1;
					SpeedMotor = neonspeedmotor1;
					MaxSpeed = neonmaxspeed1;
					BreakMass = neonbreakmass1;
					BreakGravity = neonbreakgravity1;
					Acceleration = neonacceleration1;
				}
				if (neonupgradelevel == 2) {
					SpeedMotorMobile = neonspeedmobile2;
					SpeedMotor = neonspeedmotor2;
					MaxSpeed = neonmaxspeed2;
					BreakMass = neonbreakmass2;
					BreakGravity = neonbreakgravity2;
					Acceleration = neonacceleration2;
				}
				if (neonupgradelevel == 3) {
					SpeedMotorMobile = neonspeedmobile3;
					SpeedMotor = neonspeedmotor3;
					MaxSpeed = neonmaxspeed3;
					BreakMass = neonbreakmass3;
					BreakGravity = neonbreakgravity3;
					Acceleration = neonacceleration3;
				}
			}
		}
		else if (this.name == "hell_bike(Clone)") {
			if (hellupgradelevel != 0) {
				if (hellupgradelevel == 1) {
					SpeedMotorMobile = hellspeedmobile1;
					SpeedMotor = hellspeedmotor1;
					MaxSpeed = hellmaxspeed1;
					BreakMass = hellbreakmass1;
					BreakGravity = hellbreakgravity1;
					Acceleration = hellacceleration1;
				}
				if (hellupgradelevel == 2) {
					SpeedMotorMobile = hellspeedmobile2;
					SpeedMotor = hellspeedmotor2;
					MaxSpeed = hellmaxspeed2;
					BreakMass = hellbreakmass2;
					BreakGravity = hellbreakgravity2;
					Acceleration = hellacceleration2;
				}
				if (hellupgradelevel == 3) {
					SpeedMotorMobile = hellspeedmobile3;
					SpeedMotor = hellspeedmotor3;
					MaxSpeed = hellmaxspeed3;
					BreakMass = hellbreakmass3;
					BreakGravity = hellbreakgravity3;
					Acceleration = hellacceleration3;
				}
			}
		}
		else if (this.name == "test_bike(Clone)") {
			if (testupgradelevel != 0) {
				if (testupgradelevel == 1) {
					SpeedMotorMobile = testspeedmobile1;
					SpeedMotor = testspeedmotor1;
					MaxSpeed = testmaxspeed1;
					BreakMass = testbreakmass1;
					BreakGravity = testbreakgravity1;
					Acceleration = testacceleration1;
				}
				if (testupgradelevel == 2) {
					SpeedMotorMobile = testspeedmobile2;
					SpeedMotor = testspeedmotor2;
					MaxSpeed = testmaxspeed2;
					BreakMass = testbreakmass2;
					BreakGravity = testbreakgravity2;
					Acceleration = testacceleration2;
				}
				if (testupgradelevel == 3) {
					SpeedMotorMobile = testspeedmobile3;
					SpeedMotor = testspeedmotor3;
					MaxSpeed = testmaxspeed3;
					BreakMass = testbreakmass3;
					BreakGravity = testbreakgravity3;
					Acceleration = testacceleration3;
				}
			}
		}

	}
	
	void Awake()
	{

		SmokeEmmiter = Smoke.GetComponent<ParticleAnimator>();
		WheelRadius = new float[Wheels.Length];
	}
	void Start()
	{

		if(useUpgrade){
		UpgradeInventory ();
		}
		nubes = GameObject.Find ("Nubes");
		edif2 = GameObject.Find ("edif 2");
		humo = GameObject.Find ("humo");
		edif1 = GameObject.Find ("edif 1");

		CarBody = GameObject.Find("Body2D");
		CenterOfMass = GameObject.Find("CoM2D");
		Smoke = GameObject.Find("Smoke");
		Ensemble = GameObject.Find("Ensemble2D");

		endTime = Time.time + endTime;
		
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
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

	
		GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
		Instantiate(soul, CarBody.transform.position, Quaternion.identity);
		GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
		Instantiate(explotion, CarBody.transform.position, Quaternion.identity);
		GameObject smoke = (GameObject)Resources.Load("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
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
			//if (usingAccelerometer) {
			RotateVehicle ();
			if (!crash && !crashed) {	
			  
				if (SpeedMotorMobile > 80) {
					if (fire) {
						Instantiate (fire, CarBody.transform.position, Quaternion.identity);
						fire.transform.position = CarBody.transform.position;
					}
				} else {
					//Destroy(fire);
					//fire.Stop ();
				}
				if (accelerate) {
				  if(CurrentSpeedInKmph < MaxSpeed){
					rearWheel.freezeRotation = false; //allow rotation to rear wheel
					//rearWheel.GetComponent.<Rigidbody2D>().AddTorque (0, parseInt(inAirRotationSpeed * 180 * Time.deltaTime));  
					
					if(forMobile){

							if(nubes){
							nubes.GetComponent<Paralaxcity>().InitiateScroll();
							edif2.GetComponent<Paralaxcity>().InitiateScroll();
							humo.GetComponent<Paralaxcity>().InitiateScroll();
							edif1.GetComponent<Paralaxcity>().InitiateScroll();
							}
						
						CurrentVelocity = Acceleration * InputGetAxis("Vertical") * Time.deltaTime * SpeedMotorMobile;
						//CurrentVelocity = Acceleration * InputGetAxis("Vertical") * SpeedMotorMobile;
						//	CurrentVelocity = Acceleration * Input.GetAxisRaw ("Vertical") * Time.deltaTime * 10;
						//Input.acceleration.x
						//rearWheel.AddTorque (new Vector3 (0, 0, -speed * Time.deltaTime), ForceMode.Impulse);
						//if(Velocity < MaxSpeed){
						Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
					//	}

					}
					else{
							if(nubes){
							nubes.GetComponent<Paralaxcity>().InitiateScroll();
							edif2.GetComponent<Paralaxcity>().InitiateScroll();
							humo.GetComponent<Paralaxcity>().InitiateScroll();
							edif1.GetComponent<Paralaxcity>().InitiateScroll();
							}
							/*nubes.GetComponent<Paralaxcity>(). = true;
							edif2.GetComponent<Paralaxcity>().enabled = true;
							humo.GetComponent<Paralaxcity>().enabled = true;
							edif1.GetComponent<Paralaxcity>().enabled = true;
							*/
						CurrentVelocity = Acceleration * Input.GetAxis("Vertical") * Time.deltaTime * SpeedMotor;
						//if(Velocity < MaxSpeed){
						Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
						//}
					}

						for(var i = 0; i <= (Wheels.Length-1); i++)
						{

							//Wheels[i].GetComponent<Rigidbody2D>().AddTorque(-0.2f * (30 / WheelRadius[i]) * 10);
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
				} 
				else{
					if(nubes){
					nubes.GetComponent<Paralaxcity>().StopScroll();
					edif2.GetComponent<Paralaxcity>().StopScroll();
					humo.GetComponent<Paralaxcity>().StopScroll();
					edif1.GetComponent<Paralaxcity>().StopScroll();
					}
					/*
					nubes.GetComponent<Paralaxcity>().enabled = false;
					edif2.GetComponent<Paralaxcity>().enabled = false;
					humo.GetComponent<Paralaxcity>().enabled = false;
					edif1.GetComponent<Paralaxcity>().enabled = false;*/
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
					if(audioXP){
					audioXP.Play ();
					}
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
					if(audioXP){
					audioXP.Play ();
					}
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

					/*	makeclick Achievement = new makeclick();
				Achievement.SENDACHIEVEMENT(ACHIEVEMENT_ID_First_Death);
				*/
				GameObject soul = (GameObject)Resources.Load("prefabs/CFXM2_Soul", typeof(GameObject));
				Instantiate(soul, CarBody.transform.position, Quaternion.identity);
				GameObject explotion = (GameObject)Resources.Load("prefabs/CFXM_Explosion+Text NoSmoke", typeof(GameObject));
				Instantiate(explotion, CarBody.transform.position, Quaternion.identity);
				GameObject smoke = (GameObject)Resources.Load("prefabs/CFXM_GroundSmokeExplosionAlt", typeof(GameObject));
				Instantiate(smoke, CarBody.transform.position, Quaternion.identity);

				AudioSource.PlayClipAtPoint(BodyDeadSound,CarBody.transform.position,10.0f);

				Camera.main.GetComponent<CameraFollow2D>().target = CarBody.transform; //make camera to follow biker's hips	
				
				unhandlingToDestroy ();

				CarBody.transform.Rotate (Vector3.right * 180);

				
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
	public void unhandlingToDestroy()
	{

		hingeJoints = Body2D.GetComponents<HingeJoint2D>();	
		//boots.GetComponent<Rigidbody2D>().AddTorque (-1080,0); 
		hingeJoints[0].enabled = false;
		hingeJoints[1].enabled = false;
		hingeJoints[2].enabled = false;
		hingeJoints[3].enabled = false;
		hingeJoints[4].enabled = false;
		/*hingeJoints [0].limits = 1000;
		hingeJoints [1].limits = 1000;
		hingeJoints [2].limits = 1000;
		hingeJoints [3].limits= 1000;
		hingeJoints [4].limits = 1000;*/

		wheelJoints = Body2D.GetComponents<WheelJoint2D>();
		wheelJoints[0].enabled = false;
		wheelJoints[1].enabled = false;

		leftHandJoints = leftHand.GetComponents<HingeJoint2D>();	
		rightHandJoints = rightHand.GetComponents<HingeJoint2D>();	
		bootsJoints = boots.GetComponents<HingeJoint2D>();	
		kneeJoints = knee.GetComponents<HingeJoint2D>();	
		legJoints = leg.GetComponents<HingeJoint2D>();	
		helmetJoints = helmet.GetComponents<HingeJoint2D>();	

		leftHandJoints[0].enabled = false;
		rightHandJoints[0].enabled = false;
		bootsJoints[0].enabled = false;
		kneeJoints[0].enabled = false;
		legJoints[0].enabled = false;
		helmetJoints[0].enabled = false;

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
