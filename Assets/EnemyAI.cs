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
	public bool isAutomaticBody = true;
	public bool isAutomaticFrontWheel = true;
	public bool isAutomaticBackWheel = true;
	public bool isAutomaticPoli = true;
	public bool isAutomaticHelmet = true;
	public bool isAutomaticleg = true;
	public bool isAutomatictrunk = true;
	public bool isAutomaticleftarm = true;
	public bool isAutomaticrightarm = true;

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

	int count = 0;
	int zombie_count = 0;

	public float yRotation = 5.0F;
	public float walkingDirectionnew = -1.0f;
	float distance = 0;

	//Transform myTransform; //current transform data of this enemy
	void Start () {
		count = 0;
		distance = 0;

		gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}

		zombiedead=false;
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		

		
		Flip ();
		if(gameObject.tag =="ZombieFat"){
			gameObject.GetComponent<Rigidbody2D>().mass =0.2f;

			
		}
		if(gameObject.tag =="Zombie"){
			gameObject.GetComponent<Rigidbody2D>().mass =0.01f;

		}
		if(gameObject.tag =="ZombieMid"){
			gameObject.GetComponent<Rigidbody2D>().mass =1f;

		}
		
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

		/*if (GameObject.FindWithTag ("Player").transform) {
			target = GameObject.FindWithTag ("Player").transform;
		}*/
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (!zombiedead) {
			if (ObjectToCollided != null || ObjectToCollided2 != null || BodyToCollided != null || PoliToCollided != null) {
				if (ObjectToCollided.name == collision.gameObject.name || ObjectToCollided2.name == collision.gameObject.name || BodyToCollided.name == collision.gameObject.name || PoliToCollided.name == collision.gameObject.name) {
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
						//zombie_count = zombie_count + 1;
						//my_game_uGUI.Add_zombies (1);
						//my_game_uGUI.star_number = 1;
						//my_game_uGUI.Add_stars (1);

					}

					if(gameObject.tag =="ZombieFat"){
						gameObject.GetComponent<Rigidbody2D>().mass =0.2f;
						Physics2D.IgnoreCollision(HelmetToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(PoliToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(BodyToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(ObjectToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(ObjectToCollided2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

						Physics2D.IgnoreCollision(legToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(trunkToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(leftarmToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(rightarmToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());

					}
					if(gameObject.tag =="Zombie"){
						gameObject.GetComponent<Rigidbody2D>().mass =0.01f;
						Physics2D.IgnoreCollision(HelmetToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(PoliToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(BodyToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(ObjectToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(ObjectToCollided2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

						Physics2D.IgnoreCollision(legToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(trunkToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(leftarmToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(rightarmToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
					}
					if(gameObject.tag =="ZombieMid"){
						gameObject.GetComponent<Rigidbody2D>().mass =1f;
						Physics2D.IgnoreCollision(HelmetToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(PoliToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(BodyToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(ObjectToCollided.GetComponent<Collider2D>(), GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(ObjectToCollided2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

						Physics2D.IgnoreCollision(legToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(trunkToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(leftarmToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
						Physics2D.IgnoreCollision(rightarmToCollided.GetComponent<Collider2D>(),GetComponent<Collider2D>());
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
		if (GameObject.FindGameObjectWithTag ("Ragdoll").transform) {
			target = GameObject.FindGameObjectWithTag ("Ragdoll").transform;
		}

		//rotate to look at the player
		//if (target == null) {
		distance = Vector3.Distance (enemyTransform.position, target.position);
		//}
		if(target.name == "Spawn")
		{
			//Debug.LogError("here: " + target.name);
		}
		if (zombiedead) {
			anim.SetBool ("IsDisturbed", false);
			gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		} else {
			if(distance != 0){
				if(distance<=range && distance>stop){

					transform.LookAt (target.position, upAxis);
					transform.eulerAngles = new Vector3 (0f, 0f);
					
					//move towards the player
					//enemyTransform.position += -transform.position * maxSpeed * Time.deltaTime;
					//enemyTransform.position += transform.right * maxSpeed * Time.deltaTime;

					//enemyTransform.position = Vector3.MoveTowards(transform.position , target.position ,Time.deltaTime * maxSpeed);
					//test

					gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

					walkAmount.x = walkingDirectionnew * maxSpeed * Time.deltaTime;
					yRotation += Input.GetAxis("Horizontal");
					transform.eulerAngles = new Vector2(360,0);
					//walkingDirection = -4.0f;
					transform.Translate(walkAmount);

					anim.SetBool ("IsDisturbed", true);
					count = count +1;
					if(count == 1){
					AudioSource.PlayClipAtPoint (ZombieSound, gameObject.transform.position, 10.0f);
					}
				}
				
				else  {

					gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

					anim.SetBool ("IsDisturbed", false);
					//anim.SetBool ("IsKilled", false);
					
				}
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
