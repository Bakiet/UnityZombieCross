using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

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
	// Use this for initialization
	void Start () {
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
	// Update is called once per frame
	void Update () {
		//if (Input.GetButtonDown ("Vertical")){
			//anim.SetBool ("IsAggro", true);
		  //  anim.SetBool ("IsDisturbed", true);
			//Invoke("NotAggro",0.7f);
		//} 
	}

	void NotAggro()
	{
		anim.SetBool ("IsAggro", false);
	}
	
	
	void FixedUpdate () 
	{
		
		float hor = Input.GetAxis ("Vertical");
		
		anim.SetFloat ("Speed", Mathf.Abs (hor));
		
		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
		
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);
		
		anim.SetBool ("IsGrounded", isGrounded);
		
		if ((hor > 0 && lookingRight) || (hor < 0 && !lookingRight)) {
			Flip ();
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
