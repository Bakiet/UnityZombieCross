using UnityEngine;
using System.Collections;

public class BreakJoint : MonoBehaviour {
	public GameObject EffectDead;

	public bool body = false;
	public float velocityForBrake = 3000;
	public float angularVelocityForBrake = 2500;
	public GameObject blood;
	
	private HingeJoint2D joint;
	private Rigidbody2D rb;

	float distance = 0;
	public float range =10f;
	public float stop =0;
	private Transform target;
	Transform enemyTransform;

	public GameObject legToCollided;
	public GameObject trunkToCollided;
	public GameObject leftarmToCollided;
	public GameObject rightarmToCollided;
	
	public GameObject HelmetToCollided;
	public GameObject PoliToCollided;
	public GameObject BodyToCollided;
	public GameObject ObjectToCollided;
	public GameObject ObjectToCollided2;

	private int counter;
	private int counterblood;

	// Use this for initialization
	void Start () {
		counter = 0;
		counterblood =0;
		BoxCollider2D[] myColliders = gameObject.GetComponents<BoxCollider2D>();
		foreach (BoxCollider2D bc in myColliders) {
			counter = counter + 1;
			if(counter > 1){
			Destroy(bc);
			}
		}
		distance = 0;
		//get hingejoint2D and rigidbody2D components from object on which this script is assigned
		joint = GetComponent<HingeJoint2D>();
		rb = GetComponent<Rigidbody2D>();
	}
	void Awake(){


		enemyTransform = gameObject.transform;
	}
	// Update is called once per frame
	void FixedUpdate () {

		legToCollided = Motorcycle_Controller2D.legStatic;			
		trunkToCollided = Motorcycle_Controller2D.trunkStatic;
		leftarmToCollided = Motorcycle_Controller2D.leftarmStatic;		
		rightarmToCollided = Motorcycle_Controller2D.rightarmStatic;	
		HelmetToCollided = Motorcycle_Controller2D.HelmetStatic;	
		PoliToCollided = Motorcycle_Controller2D.PoliStatic;	
		BodyToCollided = Motorcycle_Controller2D.CarBodyStatic;	
		ObjectToCollided = Motorcycle_Controller2D.frontWheelStatic;
		ObjectToCollided2 = Motorcycle_Controller2D.backWheelStatic;

		if (GameObject.FindGameObjectWithTag ("Ragdoll") != null) {
			target = GameObject.FindGameObjectWithTag ("Ragdoll").transform;
		}
		
		//rotate to look at the player
		if (target == null) {
			target = enemyTransform.transform;
		}

		distance = Vector3.Distance (enemyTransform.position, target.position);
		if (distance != 0) {
			if (distance <= range && distance > stop) {
				
				gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
				gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
				gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

				if (rb.velocity.sqrMagnitude > velocityForBrake || rb.angularVelocity > angularVelocityForBrake) {
					
					if (!body) {
						//disable joint
						joint.enabled = false;
						
						gameObject.GetComponent<Rigidbody2D>().isKinematic =false;
						//instantiate blood
						counterblood = counterblood + 1;
						if(counterblood <= 30){
							var bloodObject = Instantiate (blood, transform.TransformPoint (GetComponent<HingeJoint2D> ().anchor), Quaternion.identity) as GameObject;
							Destroy (bloodObject, 1);
						}

						Invoke ("IgnoreCollision", 0.1f);
						//play hurt sound
						if (GetComponent<HurtSound> ()) {
							GetComponent<HurtSound> ().PlaySound ();
						}
						Invoke ("disappear", 2f);
					} else {
						gameObject.GetComponent<Rigidbody2D>().isKinematic =false;
						Invoke ("IgnoreCollision", 0.1f);
						Invoke ("disappear", 2f);
					}
				}
			}
		}

	}
	private void disappear()
	{
		if(EffectDead){
		EffectDead.transform.position = transform.position;
		Instantiate (EffectDead);
		}
		Destroy(gameObject.GetComponent<SpriteRenderer>());
		Destroy(gameObject);
	}
	private void IgnoreCollision()
	{
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), legToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), trunkToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), leftarmToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), rightarmToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), HelmetToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), PoliToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), BodyToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), ObjectToCollided.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D>(), ObjectToCollided2.GetComponent<Collider2D>());


	}
}
