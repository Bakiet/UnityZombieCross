using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector3 nMovement;

	void Start () {
		nMovement = new Vector3(3,3,3);
	}
	
	void Update () {
		this.transform.Translate(nMovement * Time.deltaTime);
	}
	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
		this.transform.Translate(nMovement * Time.deltaTime);
	}
}
