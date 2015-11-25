using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class tsg_PropulsionPhysics2D : MonoBehaviour {
	public Transform target;
	public float reachTime = 1.5f;
	public AudioClip propelSound;
	public Color trajectoryColor = Color.magenta;
	public bool showTrajectory = true;
	public float verticalOnlyMin = 0.5f;
	
	void Start() {
		// Added an empty start so the script could be enabled/disabled
		//DrawArrow(target.,(gameObject.position-target.position));
	}
	void OnCollisionEnter2D(Collision2D other){
		if(PropulsionPadActive()) {
			
			Vector2 hitPoint = other.transform.position;
			PropelObject(other.gameObject, CalculateVelocity(hitPoint));
			
			//////////////////////////////////////////////////////////////////
			// To prevent the collider from missing the target, get the
			// closest point the collider hit on the trigger and calculate the
			// velocity based on that starting point.
			
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(PropulsionPadActive()) {
			//////////////////////////////////////////////////////////////////
			// To prevent the collider from missing the target, get the
			// closest point the collider hit on the trigger and calculate the
			// velocity based on that starting point.
			Vector2 hitPoint = other.bounds.ClosestPoint(transform.position);
			PropelObject(other.gameObject, CalculateVelocity(hitPoint));
			
		}
	}
	
	void OnDrawGizmos() {
		if(showTrajectory && PropulsionPadActive()) {
			DrawTrajectory();
		}
	}
	
	public void SetTarget(Transform newTarget, float newReachTime) {
		if(newTarget != null && newReachTime > 0) {
			target = newTarget;
			reachTime = newReachTime;
		}
	}
	
	private
		
	bool PropulsionPadActive() {
		return enabled && target != null && reachTime > 0;
	}
	
	////////////////////////////////////////////////////////////////////////////////
	// When an object hits me, check to see if it implements the tsg_IPropelBehavior
	// interface and if it does call its implemented method.
	void PropelObject(GameObject propelObject, Vector2 velocity) {
		tsg_IPropelBehavior objectInterface = propelObject.GetComponent(typeof(tsg_IPropelBehavior)) as tsg_IPropelBehavior;
		
		if(objectInterface != null) {
			objectInterface.React(velocity);
			PlayPropulsionSound();
		}
	}
	
	void PlayPropulsionSound() {
		if(propelSound) {
			AudioSource.PlayClipAtPoint(propelSound, transform.position);
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////
	// This is the heart of the Propulsion Physics script. If the target is far enough away
	// the normal trajectory is calculated based on the editor's set gravity. A non-
	// parabolic trajectory is calculated if the target is almost straight overhead.
	// The verticalOnlyMin can be adjusted to when the velocity calculation should
	// switch to vertical populsion only.
	Vector2 CalculateVelocity(Vector2 startPoint) {
		Vector2 direction = new Vector2(target.position.x,target.position.y) - startPoint;
		float gravity = Physics2D.gravity.magnitude;
		float yVelocity = (direction.y / reachTime) + (0.5f * gravity * reachTime);

		if(TargetTooClose()) {
			return new Vector2(0, yVelocity);
		} else {
			return new Vector2(direction.x / reachTime, yVelocity);
		}
	}
	
	bool TargetTooClose(){
		Vector2 targetPosition = target.position;
		Vector2 leveledTarget = new Vector2(targetPosition.x, transform.position.y);
		return Vector2.Distance(leveledTarget, transform.position) <= verticalOnlyMin;
	}
	
	void DrawTrajectory() {
		Vector2 initialVelocity = CalculateVelocity(transform.position);
		float deltaTime = reachTime / initialVelocity.magnitude;
		int drawSteps = (int)(initialVelocity.magnitude - 0.5f);
		Vector2 currentPosition = transform.position;
		Vector2 previousPosition = currentPosition;
		Gizmos.color = trajectoryColor;
		
		if(IsParabolicVelocity(initialVelocity)) {
			for(int i = 0; i < drawSteps; i++) {
				currentPosition += (initialVelocity * deltaTime) + (0.5f * Physics2D.gravity * deltaTime * deltaTime);
				initialVelocity += Physics2D.gravity * deltaTime;
				Gizmos.DrawLine(previousPosition, currentPosition);
				//////////////////////////////////////////////////////////////////////////////////
				// If the next loop is the last iteration, then don't update the previous position
				// vector so it can be used to draw the gizmos arrow.
				if((i+1) < drawSteps) {
					previousPosition = currentPosition;
				}
			}
			DrawArrow(previousPosition, (currentPosition - previousPosition));
		} else {
			Vector2 newUpDirection = new Vector2(currentPosition.x, target.position.y);
			Gizmos.DrawLine(currentPosition, newUpDirection);
			DrawArrow(newUpDirection, new Vector2(0f, 0.01f));
		}
	}
	
	void DrawArrow(Vector2 position, Vector2 direction) {
		int[] arrowAngles = new int[] { 225, 135 };
		foreach(int angle in arrowAngles) {
			//Vector2 endPoint = Quaternion.LookRotation(direction) * Quaternion.Euler(0, angle, 0) * direction.x;
			Vector2 endPoint = direction;
			Gizmos.DrawRay(position + direction, endPoint * 0.5f);
		}
	}
	
	bool IsParabolicVelocity(Vector2 velocity) {
		return !(velocity.x == 0);
	}
}