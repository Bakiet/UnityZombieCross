using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	//public Transform target;
	public Transform[] backgrounds;			// Array (list) of all the back- and foregrounds to be parallaxed
	private float[] parallaxScales;			// The proportion of the camera's movement to move the backgrounds by
	public float smoothingcielo = 1f;	
	public float smoothingnubes = 1f;
	public float smoothingedif = 1f;
	public float smoothingediftiny = 1f;
	public float smoothinghumo = 1f;


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
			if(i == 6){
			backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 7){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 8){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 9){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 10){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 23){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 24){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i ==25){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 26){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
			if(i == 27){
				backgrounds[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {

		// for each background
		for (int i = 0; i < backgrounds.Length; i++) {
			// the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create a target position which is the background's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and the target position using lerp
			if(i == 0){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingcielo * Time.deltaTime);
			}
			if(i == 1){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingcielo * Time.deltaTime);
			}
			if(i == 2){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingcielo * Time.deltaTime);
			}
			if(i == 3){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingcielo * Time.deltaTime);
			}
			if(i == 4){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingcielo* Time.deltaTime);
			}
			if(i == 5){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingcielo* Time.deltaTime);
			}
			/*if(i == 6){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingnubes * Time.deltaTime);
			}
			if(i == 7){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingnubes * Time.deltaTime);
			}
			if(i == 8){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingnubes * Time.deltaTime);
			}
			if(i == 9){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingnubes * Time.deltaTime);
			}
			if(i == 10){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingnubes * Time.deltaTime);
			}*/
			if(i == 11){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingedif * Time.deltaTime);
			}
			if(i == 12){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingedif * Time.deltaTime);
			}
			if(i == 13){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingedif * Time.deltaTime);
			}
			if(i == 14){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingedif * Time.deltaTime);
			}
			if(i == 15){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingedif * Time.deltaTime);
			}
			if(i == 16){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingedif * Time.deltaTime);
			}
			if(i == 17){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingediftiny * Time.deltaTime);
			}
			if(i == 18){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingediftiny * Time.deltaTime);
			}
			if(i == 19){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingediftiny * Time.deltaTime);
			}
			if(i == 20){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingediftiny * Time.deltaTime);
			}
			if(i == 21){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingediftiny * Time.deltaTime);
			}
			if(i == 22){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothingediftiny * Time.deltaTime);
			}
			/*if(i == 23){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothinghumo * Time.deltaTime);
			}
			if(i == 24){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothinghumo * Time.deltaTime);
			}
			if(i == 25){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothinghumo * Time.deltaTime);
			}
			if(i == 26){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothinghumo * Time.deltaTime);
			}
			if(i == 27){
				backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothinghumo * Time.deltaTime);
			}*/

		}

		// set the previousCamPos to the camera's position at the end of the frame
		previousCamPos = cam.position;
	}
}
