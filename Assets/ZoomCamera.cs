using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {

	public float moveForce;
	public float camSize;
	public float camSizeLimit;
	public float increment;
	public float timeLerp;
	public float timeLerpValue;
	public bool shouldZoomIn;
	public bool shouldZoomOut;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (shouldZoomIn) {
			ZoomIn ();
		} else if (shouldZoomOut) {
			ZoomOut();
		}
		camSize = Camera.main.orthographicSize;
		timeLerpValue = timeLerp * Time.deltaTime;
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "ZoomInTrigger")
		{		
			shouldZoomIn = true;
		} else if (collider.gameObject.tag == "ZoomOutTrigger")
		{
			shouldZoomOut = true;
		}
	}

	void ZoomOut()
	{
		if (Camera.main.orthographicSize < camSizeLimit) {
			Camera.main.orthographicSize = Mathf.Lerp(
				Camera.main.orthographicSize,
				Camera.main.orthographicSize * increment,
				timeLerp * Time.deltaTime);

		}
		else if (Camera.main.orthographicSize > camSizeLimit) {
			shouldZoomOut = false;
		}
	}
	void ZoomIn()
	{
		if (Camera.main.orthographicSize > 7.419368f) {
			Camera.main.orthographicSize = Mathf.Lerp(
				Camera.main.orthographicSize,
				Camera.main.orthographicSize * -increment,
				timeLerp * Time.deltaTime);

		}
		else if (Camera.main.orthographicSize < 7.419368f) {
			shouldZoomIn = false;
		}
	}
}
