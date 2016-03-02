using UnityEngine;
using System.Collections;

public class CameraFollow2DMulti : MonoBehaviour {

	public Transform target;
	public bool IfCity;
	public bool IfVolcan;
	
	private Transform cam;
	
	void Start()
	{
		cam = transform;
		//target = Motorcycle_Controller2D.CarBodyTransformStatic;
	}
	
	// Update is called once per frame
	void Update () {
		if (IfCity) {
			if(target){
				cam.position = new Vector3 (target.position.x, target.position.y + 5, cam.position.z);
			}
		} 
		else if (IfVolcan) {
			if(target != null)
				cam.position = new Vector3 (target.position.x, target.position.y + 4, cam.position.z);
		}
		else {
			if(target != null)
				cam.position = new Vector3 (target.position.x, target.position.y, cam.position.z);
		}
	}
}
