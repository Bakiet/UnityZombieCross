using UnityEngine;
using System.Collections;

public class AppearObject : MonoBehaviour {

	private Transform target;
	Transform enemyTransform;
	public float range =12f;
	public float stop =0;
	float distance = 0;
	// Use this for initialization
	void Start () {
	
	}
	void Awake(){
		enemyTransform = gameObject.transform;

	}
	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectWithTag ("Ragdoll") != null) {
			target = GameObject.FindGameObjectWithTag ("Ragdoll").transform;
		}
		enemyTransform = gameObject.transform;
		if(enemyTransform && target){
			distance = Vector3.Distance (enemyTransform.position, target.position);
		}


	
	}
	void FixedUpdate(){
		if(distance != 0){
			if(distance<=range && distance>stop){
				
				//TextureObject.SetActive(true);
				gameObject.GetComponent<SpriteRenderer>().enabled = true;

				
			}else{
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
	}
}
