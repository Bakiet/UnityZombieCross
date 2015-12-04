using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public GameObject motorcyclePrefab;
	public string tagToCheck = "Player";
	public Color activatedColor = Color.green;
	public Renderer objectToChangeColor;

	public Transform target;

	private AudioSource audioSource;

	public static Transform lastPoint;
	private static GameObject moto;


	private static int scoreAtLastPoint = 0;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		motorcyclePrefab = Motorcycle_Controller2D.BodyCarStatic;
		moto = motorcyclePrefab;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(lastPoint != transform && col.tag == tagToCheck)
		{
			lastPoint = transform;
			objectToChangeColor.material.color = activatedColor;
			audioSource.Play ();
			scoreAtLastPoint = Motorcycle_Controller2D.score;
			motorcyclePrefab = Motorcycle_Controller2D.BodyCarStatic;
			moto = motorcyclePrefab;
		}
	}

	public static void Reset()
	{
		Motorcycle_Controller2D.lastcheckpoint = lastPoint;
		Application.LoadLevel (Application.loadedLevel);
		Motorcycle_Controller2D.checkpoint = true;
		//Motorcycle_Controller2D.lastcheckpoint = lastPoint;
		//Instantiate (moto, lastPoint.position, Quaternion.identity);
		//Motorcycle_Controller2D.score = scoreAtLastPoint;
		//Motorcycle_Controller2D.crash = false;

	}
}
