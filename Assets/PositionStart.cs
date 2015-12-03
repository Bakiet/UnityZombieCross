using UnityEngine;
using System.Collections;

public class PositionStart : MonoBehaviour {
	private Vector3 positionstart;
	private GameObject stone;
	public float period = 5.0f;
	// Use this for initialization
	void Start () {
		positionstart = transform.position;
		stone = gameObject;
		StartCoroutine(ActivationRoutine());
	
	}
	private IEnumerator ActivationRoutine()
	{        
		yield return new WaitForSeconds(period);

		Instantiate (stone, positionstart, Quaternion.identity);
		Destroy(gameObject);//gameObject.transform.position = positionstart;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
