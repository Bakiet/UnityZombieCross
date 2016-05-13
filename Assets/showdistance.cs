using UnityEngine;
using System.Collections;

public class showdistance : MonoBehaviour {
	float distance = 0;
	public float range =12f;
	public float stop =0;
	private Transform target;
	Transform enemyTransform;
	// Use this for initialization
	void Start () {
		distance = 0;
	}
	void Awake(){
		enemyTransform = gameObject.transform;
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
	}
	void FixedUpdate () {
		
		if (distance != 0) {
			if (distance <= range && distance > stop) {
				gameObject.SetActive(true);
			}
		}
	}
}
