using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	//public Transform target;
	public Transform[] backgrounds;			// Array (list) of all the back- and foregrounds to be parallaxed
	private float[] parallaxScales;			// The proportion of the camera's movement to move the backgrounds by

	public bool Element0Constant = false;
	public float Element0 = 0f;	
	public bool Element1Constant = false;
	public float Element1 = 0f;	
	public bool Element2Constant = false;
	public float Element2 = 0f;	
	public bool Element3Constant = false;
	public float Element3 = 0f;	
	public bool Element4Constant = false;
	public float Element4 = 0f;	
	public bool Element5Constant = false;
	public float Element5 = 0f;	
	public bool Element6Constant = false;
	public float Element6 = 0f;	
	public bool Element7Constant = false;
	public float Element7 = 0f;	
	public bool Element8Constant = false;
	public float Element8 = 0f;	
	public bool Element9Constant = false;
	public float Element9 = 0f;	
	public bool Element10Constant = false;
	public float Element10 = 0f;	
	public bool Element11Constant = false;
	public float Element11 = 0f;	
	public bool Element12Constant = false;
	public float Element12 = 0f;	
	public bool Element13Constant = false;
	public float Element13 = 0f;	
	public bool Element14Constant = false;
	public float Element14 = 0f;	
	public bool Element15Constant = false;
	public float Element15 = 0f;	
	public bool Element16Constant = false;
	public float Element16 = 0f;	
	public bool Element17Constant = false;
	public float Element17 = 0f;	
	public bool Element18Constant = false;
	public float Element18 = 0f;	
	public bool Element19Constant = false;
	public float Element19 = 0f;	
	public bool Element20Constant = false;
	public float Element20 = 0f;	
	public bool Element21Constant = false;
	public float Element21 = 0f;	
	public bool Element22Constant = false;
	public float Element22 = 0f;	
	public bool Element23Constant = false;
	public float Element23 = 0f;	
	public bool Element24Constant = false;
	public float Element24 = 0f;	
	public bool Element25Constant = false;
	public float Element25 = 0f;	
	public bool Element26Constant = false;
	public float Element26 = 0f;	
	public bool Element27Constant = false;
	public float Element27 = 0f;	



	private Transform cam;					// reference to the main cameras transform
	private Vector3 previousCamPos;			// the position of the camera in the previous frame

	// Is called before Start(). Great for references.
	void Awake () {
		// set up camera the reference
		cam = Camera.main.transform;


	}

	// Use this for initialization
	void Start () {
		/*if (IfCity) {
			cam.position = new Vector3 (cam.position.y + 5, cam.position.z);
		} 
		else if (IfVolcan) {
			cam.position = new Vector3 (cam.position.x, cam.position.y + 4, cam.position.z);
		}
		else {
			
			cam.position = new Vector3 (cam.position.x, cam.position.y, cam.position.z);
		}*/
		// The previous frame had the current frame's camera position
		previousCamPos = cam.position;



		// asigning coresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;

			if(i == 0 && Element0Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element0, 0.0f);
			}
			if(i == 1 && Element1Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element1, 0.0f);
			}
			if(i == 2 && Element2Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element2, 0.0f);
			}
			if(i == 3 && Element3Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element3, 0.0f);
			}
			if(i == 4 && Element4Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element4, 0.0f);
			}
			if(i == 5 && Element5Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element5, 0.0f);
			}
			if(i == 6 && Element6Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element6, 0.0f);
			}
			if(i == 7 && Element7Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element7, 0.0f);
			}
			if(i == 8 && Element8Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element8, 0.0f);
			}
			if(i == 9 && Element9Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element9, 0.0f);
			}
			if(i == 10 && Element10Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element10, 0.0f);
			}
			if(i == 11 && Element11Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element11, 0.0f);
			}
			if(i == 12 && Element12Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element12, 0.0f);
			}
			if(i == 13 && Element13Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element13, 0.0f);
			}
			if(i == 14 && Element14Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element14, 0.0f);
			}
			if(i == 15 && Element15Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element15, 0.0f);
			}
			if(i == 16 && Element16Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element16, 0.0f);
			}
			if(i == 17 && Element17Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element17, 0.0f);
			}
			if(i == 18 && Element18Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element18, 0.0f);
			}
			if(i == 19 && Element19Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element19, 0.0f);
			}
			if(i == 20 && Element20Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element20, 0.0f);
			}
			if(i == 21 && Element21Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element21, 0.0f);
			}
			if(i == 22 && Element22Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element22, 0.0f);
			}
			if(i == 23 && Element23Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element23, 0.0f);
			}
			if(i == 24 && Element24Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element24, 0.0f);
			}
			if(i == 25  && Element25Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element25, 0.0f);
			}
			if(i == 26 && Element26Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element26, 0.0f);
			}
			if(i == 27 && Element27Constant){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Element27, 0.0f);
			}

		}


	}
	
	// Update is called once per frame
	void Update () {

		// for each background
		for (int i = 0; i < backgrounds.Length; i++) {
			// the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (cam.position.x - previousCamPos.x) * parallaxScales[i];

			// set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create a target position which is the background's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and the target position using lerp

			if(i == 0 && !Element0Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element0 * Time.deltaTime);
			}
			if(i == 1 && !Element1Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element1 * Time.deltaTime);
			}
			if(i == 2 && !Element2Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element2 * Time.deltaTime);
			}
			if(i == 3 && !Element3Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element3 * Time.deltaTime);
			}
			if(i == 4 && !Element4Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element4 * Time.deltaTime);
			}
			if(i == 5 && !Element5Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element5 * Time.deltaTime);
			}
			if(i == 6 && !Element6Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element6 * Time.deltaTime);
			}
			if(i == 7 && !Element7Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element7 * Time.deltaTime);
			}
			if(i == 8 && !Element8Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element8 * Time.deltaTime);
			}
			if(i == 9 && !Element9Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element9 * Time.deltaTime);
			}
			if(i == 10 && !Element10Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element10 * Time.deltaTime);
			}
			if(i == 11 && !Element11Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element11 * Time.deltaTime);
			}
			if(i == 12 && !Element12Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element12 * Time.deltaTime);
			}
			if(i == 13 && !Element13Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element13 * Time.deltaTime);
			}
			if(i == 14 && !Element14Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element14 * Time.deltaTime);
			}
			if(i == 15 && !Element15Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element15 * Time.deltaTime);
			}
			if(i == 16 && !Element16Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element16 * Time.deltaTime);
			}
			if(i == 17 && !Element17Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element17 * Time.deltaTime);
			}
			if(i == 18 && !Element18Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element18 * Time.deltaTime);
			}
			if(i == 19 && !Element19Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element19 * Time.deltaTime);
			}
			if(i == 20 && !Element20Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element20 * Time.deltaTime);
			}
			if(i == 21 && !Element21Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element21 * Time.deltaTime);
			}
			if(i == 22 && !Element22Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element22 * Time.deltaTime);
			}
			if(i == 23 && !Element23Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element23 * Time.deltaTime);
			}
			if(i == 24 && !Element24Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element24 * Time.deltaTime);
			}
			if(i == 25  && !Element25Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element25 * Time.deltaTime);
			}
			if(i == 26 && !Element26Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element26 * Time.deltaTime);
			}
			if(i == 27 && !Element27Constant){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, Element27 * Time.deltaTime);
			}



		}

		// set the previousCamPos to the camera's position at the end of the frame
		previousCamPos = cam.position;
	}
}
