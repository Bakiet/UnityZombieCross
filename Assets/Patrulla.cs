using UnityEngine;
using System.Collections;

public class Patrulla : MonoBehaviour {

	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 5.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	float walkingDirection = 1.0f;
	Vector2 walkAmount;
	float originalX; // Original float value

	public void Start () {
		//this.originalX = this.transform.position.x;
		yRotation += Input.GetAxis("Horizontal");
		transform.eulerAngles = new Vector2(0, 360);
		walkingDirection = -1.0f;
		wallLeft = transform.position.x - wallLeft;
		wallRight = transform.position.x + wallRight;

	}

	public float yRotation = 5.0F;
	public float xRotation = 5.0F;
	void Update()
	{  
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

		if (transform.position.x >= wallRight) {
			//walkingDirection = -1.0f;
			yRotation += Input.GetAxis("Horizontal");
			transform.eulerAngles = new Vector2(360,0);
			walkingDirection = -1.0f;
			/*xRotation += Input.GetAxis("Vertical");
			transform.eulerAngles = new Vector2(360,0);*/
		} else if (walkingDirection < 0.0f && transform.position.x <= wallLeft) {
		
			yRotation += Input.GetAxis("Horizontal");
			transform.eulerAngles = new Vector2(0,180);
			walkingDirection = -1.0f;
			/*xRotation += Input.GetAxis("Vertical");
			transform.eulerAngles = new Vector2(0,360);*/
		}
		transform.Translate(walkAmount);


	
	}
}
