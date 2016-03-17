using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MakePoints : MonoBehaviour {


	public GameObject CFX;
	private Rigidbody2D rb2d;
	private Animator anim;
	public float maxSpeed = 5f;
	public float hitForce = 10f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public bool lookingRight = true;
	private bool isGrounded = false;
	
	public AudioClip DeadSound;
	public AudioClip ZombieSound;

	
	public GameObject legToCollided;
	public GameObject trunkToCollided;
	public GameObject leftarmToCollided;
	public GameObject rightarmToCollided;
	
	public GameObject HelmetToCollided;
	public GameObject PoliToCollided;
	public GameObject BodyToCollided;
	public GameObject ObjectToCollided;
	public GameObject ObjectToCollided2;
	
	private Transform target;
	Transform enemyTransform;
	
	Vector2 walkAmount;
	public float speed = 3f;
	public float rotationSpeed=10f;
	Vector3 upAxis = new Vector3 (0f, 0f, -1f);
	
	public float range =10f;
	public float range2 =10f;
	public float stop =0;
	private bool zombiedead=false;
	
	game_uGUI my_game_uGUI;
	
	private const string INCREMENTAL_ACHIEVEMENT_ID_Veteran = "CgkIq6GznYALEAIQCw";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Assassin = "CgkIq6GznYALEAIQCg";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Sergeant = "CgkIq6GznYALEAIQCQ";
	
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
	
	private  string INCREMENTAL_ACHIEVEMENT_ID_Lieutenant = "CgkIq6GznYALEAIQEg";
	private  string INCREMENTAL_ACHIEVEMENT_ID_Captain = "CgkIq6GznYALEAIQEw";
	
	int count = 0;
	int count2 = 0;
	int zombie_count = 0;
	
	public float yRotation = 5.0F;
	public float walkingDirectionnew = -1.0f;
	float distance = 0;
	public float endTime = 3.0F;
	// Use this for initialization
	void Start () {
		endTime = Time.time + endTime;
		count = 0;
		count2 = 0;
		distance = 0;
		
		//	gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
		
		zombiedead=false;
		anim = GetComponent<Animator>();
	}
	void Awake(){
		enemyTransform = gameObject.transform;
		//myTransform = transform; 
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (!zombiedead) {
			if (ObjectToCollided != null || ObjectToCollided2 != null || BodyToCollided != null || PoliToCollided != null) {
				if (ObjectToCollided.name == collision.gameObject.name || ObjectToCollided2.name == collision.gameObject.name || BodyToCollided.name == collision.gameObject.name || PoliToCollided.name == collision.gameObject.name) {
					
					//	gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
					gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
					
					gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
					//AudioSource.PlayClipAtPoint (DeadSound, gameObject.transform.position, 10.0f);
					
					makeclick Achievement = new makeclick();
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Veteran,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Assassin,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Sergeant,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Lieutenant,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Captain,1);
					
					if (my_game_uGUI) {
						my_game_uGUI.Update_int_score (100);
					}
					zombiedead = true;
					
				}
			}
		}
	}
	void FixedUpdate(){
		
		legToCollided = Motorcycle_Controller2D.legStatic;			
		trunkToCollided = Motorcycle_Controller2D.trunkStatic;
		leftarmToCollided = Motorcycle_Controller2D.leftarmStatic;		
		rightarmToCollided = Motorcycle_Controller2D.rightarmStatic;	
		HelmetToCollided = Motorcycle_Controller2D.HelmetStatic;	
		PoliToCollided = Motorcycle_Controller2D.PoliStatic;	
		BodyToCollided = Motorcycle_Controller2D.CarBodyStatic;	
		ObjectToCollided = Motorcycle_Controller2D.frontWheelStatic;
		ObjectToCollided2 = Motorcycle_Controller2D.backWheelStatic;


	}
	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectWithTag ("Ragdoll") != null) {
			target = GameObject.FindGameObjectWithTag ("Ragdoll").transform;
		}
		
		//rotate to look at the player
		if (target == null) {
			target = enemyTransform.transform;
		}
		distance = Vector3.Distance (enemyTransform.position, target.position);
		//}
		if(target.name == "Spawn")
		{
			//Debug.LogError("here: " + target.name);
		}

	}
}
