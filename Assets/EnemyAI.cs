using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

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
	public bool isAutomaticFrontWheel = true;
	public bool isAutomaticBackWheel = true;
	public GameObject ObjectToCollided;
	public GameObject ObjectToCollided2;

	Transform target;
	Transform enemyTransform;
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

	int count = 0;
	//Transform myTransform; //current transform data of this enemy
	void Start () {
		count = 0;
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}

		zombiedead=false;
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		

		
		Flip ();
		
		//this.originalX = this.transform.position.x;
	/*	yRotation += Input.GetAxis("Horizontal");
		//transform.eulerAngles = new Vector2(0, 360);
		transform.eulerAngles = new Vector2(360,0);*/
		/*walkingDirection = 1.0f;
		wallLeft = transform.position.x - wallLeft;
		wallRight = transform.position.x + wallRight;*/
	}
	void Awake(){
		enemyTransform = gameObject.transform;
		//myTransform = transform; 
	}
	
	void FixedUpdate(){
		if (GameObject.FindWithTag ("Player").transform) {
			target = GameObject.FindWithTag ("Player").transform;
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (!zombiedead) {
			if (ObjectToCollided != null || ObjectToCollided2 != null) {
				if (ObjectToCollided.name == collision.gameObject.name || ObjectToCollided2.name == collision.gameObject.name) {
					anim.SetBool ("IsKilled", true);
					anim.SetBool ("IsAggro", false);
					rb2d.velocity = new Vector2 (10f, hitForce);
					rb2d.velocity = new Vector3 (0f, 3f, 0f) * hitForce;
					AudioSource.PlayClipAtPoint (DeadSound, gameObject.transform.position, 10.0f);

					makeclick Achievement = new makeclick();
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Veteran,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Assassin,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Sergeant,1);

					if (my_game_uGUI) {
						my_game_uGUI.Update_int_score (100);			
					}

					if(gameObject.tag =="ZombieFat"){
						gameObject.GetComponent<Rigidbody2D>().mass =0.2f;
					}
					if(gameObject.tag =="Zombie"){
						gameObject.GetComponent<Rigidbody2D>().mass =0.01f;
					}
					if(gameObject.tag =="ZombieMid"){
						gameObject.GetComponent<Rigidbody2D>().mass =1f;
					}

					zombiedead = true;
				}
			}
		}
	}	
	void NotAggro()
	{
		anim.SetBool ("IsAggro", false);
	}

	
	void Update(){
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
		//rotate to look at the player
		var distance = Vector3.Distance(enemyTransform.position, target.position);
	
		if (zombiedead) {
			anim.SetBool ("IsDisturbed", false);
		} else {
			if(distance<=range && distance>stop){
				
				transform.LookAt (target.position, upAxis);
				transform.eulerAngles = new Vector2 (0f, 0f);
				
				//move towards the player
				enemyTransform.position += -transform.right * maxSpeed * Time.deltaTime;
				
				anim.SetBool ("IsDisturbed", true);
				count = count +1;
				if(count == 1){
				AudioSource.PlayClipAtPoint (ZombieSound, gameObject.transform.position, 10.0f);
				}
			}
			
			else  {
				anim.SetBool ("IsDisturbed", false);
				//anim.SetBool ("IsKilled", false);
				
			}

		}

	}
	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}
}
