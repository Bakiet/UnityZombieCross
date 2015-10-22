using UnityEngine;
using System.Collections;

public class TumbleweedMotion : MonoBehaviour {
	
	float     wind = 7;
	Rigidbody body;

	void Awake  () {
		body = GetComponent<Rigidbody>();
	}

	void Start  () {
		body.velocity = new Vector3(0,Random.value * 2,0);
	}

	void Update () {
		body.AddForceAtPosition(new Vector3(wind, 2, 0), transform.position);
		if (transform.position.x > 30) Destroy (gameObject);
	}
}
