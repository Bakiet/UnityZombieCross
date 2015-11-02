using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {
	
	public Transform target;
	public bool IfCity;
	public bool IfVolcan;

	private Transform cam;
	
	void Start()
	{
		cam = transform;
	}

	// Update is called once per frame
	void Update () {
		if (IfCity) {
			cam.position = new Vector3 (target.position.x, target.position.y + 5, cam.position.z);
		} 
		else if (IfVolcan) {
			cam.position = new Vector3 (target.position.x, target.position.y + 4, cam.position.z);
		}
		else {
			cam.position = new Vector3 (target.position.x, target.position.y, cam.position.z);
		}
	}
}
