using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Animator anim;
	public float maxSpeed = 5f;
	public float hitForce = 10f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public bool lookingRight = true;
	private bool isGrounded = false;


	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		if (Input.GetButtonDown("Vertical"))
		{
			anim.SetBool ("IsDisturbed", true);
		
		}

		if (Input.GetButtonDown("Jump"))
		{
			anim.SetBool ("IsDisturbed", false);
			anim.SetBool ("IsKilled", false);
			
		}

		if (Input.GetButtonDown("Fire1"))
		
		{
			anim.SetBool ("IsKilled", true);
			anim.SetBool ("IsAggro", false);
			rb2d.velocity = new Vector2 (10f, hitForce);
			rb2d.velocity = new Vector3(0f, 3f, 0f) * hitForce;
		}


		if (Input.GetButtonDown ("Fire2")) {
			anim.SetBool ("IsDamaged", true);
		} 
		else 
		{
			anim.SetBool ("IsDamaged", false);
		}

		if (Input.GetButtonDown ("Attack")){
			anim.SetBool ("IsAggro", true);
			Invoke("NotAggro",0.7f);
		} 



	}


	void NotAggro()
	{
		anim.SetBool ("IsAggro", false);
	}


	void FixedUpdate () 
	{
		
		float hor = Input.GetAxis ("Horizontal");
		
		anim.SetFloat ("Speed", Mathf.Abs (hor));
		
		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
		
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);
		
		anim.SetBool ("IsGrounded", isGrounded);
		
		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();


	}


	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}
	
}
