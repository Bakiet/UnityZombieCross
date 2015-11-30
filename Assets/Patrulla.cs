using UnityEngine;
using System.Collections;

public class Patrulla : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Animator anim;
	public float maxSpeed = 5f;
	public float hitForce = 10f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public bool lookingRight = true;
	private bool isGrounded = false;
	
	public AudioClip DeadSound;
	public bool isAutomaticFrontWheel = true;
	public bool isAutomaticBackWheel = true;
	public GameObject ObjectToCollided;
	public GameObject ObjectToCollided2;

	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 5.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	float walkingDirection = 1.0f;
	Vector2 walkAmount;
	float originalX; // Original float value

	public void Start () {

		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		
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



		//this.originalX = this.transform.position.x;
		yRotation += Input.GetAxis("Horizontal");
		//transform.eulerAngles = new Vector2(0, 360);
		transform.eulerAngles = new Vector2(360,0);
		walkingDirection = 1.0f;
		wallLeft = transform.position.x - wallLeft;
		wallRight = transform.position.x + wallRight;

	}

	public float yRotation = 5.0F;
	public float xRotation = 5.0F;
	void Update()
	{  
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

		//if (transform.position.x >= wallRight) {
			//walkingDirection = -1.0f;
			yRotation += Input.GetAxis("Horizontal");
			transform.eulerAngles = new Vector2(360,0);
			walkingDirection = 1.0f;
			
		//} else if (walkingDirection < 0.0f && transform.position.x <= wallLeft) {
		/*
			yRotation += Input.GetAxis("Horizontal");
			transform.eulerAngles = new Vector2(0,180);
			walkingDirection = -1.0f;*/
			
	//	}
		transform.Translate(walkAmount);
		anim.SetBool ("IsDisturbed", true);

	
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (ObjectToCollided != null || ObjectToCollided2 != null) {
			if (ObjectToCollided.name == collision.gameObject.name) {
				anim.SetBool ("IsKilled", true);
				anim.SetBool ("IsAggro", false);
				rb2d.velocity = new Vector2 (10f, hitForce);
				rb2d.velocity = new Vector3 (0f, 3f, 0f) * hitForce;
				AudioSource.PlayClipAtPoint (DeadSound, gameObject.transform.position, 10.0f);
				
			}
		}
		
	}	
	void NotAggro()
	{
		anim.SetBool ("IsAggro", false);
	}
	
	
	void FixedUpdate () 
	{

	}

}
