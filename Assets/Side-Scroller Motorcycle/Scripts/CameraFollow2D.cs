using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {
	
	public Transform target;
	public bool IfCity;
	public bool IfVolcan;
	public static bool CameraifFollow;
	private Transform cam;
	
	void Start()
	{
		CameraifFollow = true;
		cam = transform;
		target = Motorcycle_Controller2D.CarBodyTransformStatic;
	}

	// Update is called once per frame
	void Update () {
		if (IfCity) {
			if(target){
				if(CameraifFollow){
					cam.position = new Vector3 (target.position.x, target.position.y + 4, cam.position.z);
				}
			}
		} 
		else if (IfVolcan) {
			if(target != null){
				if(CameraifFollow){
				cam.position = new Vector3 (target.position.x, target.position.y + 3, cam.position.z);
				}
			}
		}
		else {
			if(target != null){
				if(CameraifFollow){
					cam.position = new Vector3 (target.position.x, target.position.y, cam.position.z);
				}
			}
		}
	}
}
