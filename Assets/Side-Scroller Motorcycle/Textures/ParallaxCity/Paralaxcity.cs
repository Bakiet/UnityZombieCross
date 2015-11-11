using UnityEngine;
using System.Collections;

public class Paralaxcity : MonoBehaviour {

	public float velocidad = 0f;
	public bool Movement= false;
	public float timestart=0f;
	// Use this for initialization
	void Start () {

	}

	public void InitiateScroll(){
		Movement = true;
		//timestart = Time.time;
	}
	public void StopScroll(){
		Movement = false;

	}
	
	// Update is called once per frame
	void Update () {
		timestart = Time.time;
		if (Movement) {
			gameObject.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 ((timestart) * velocidad, 0);
		}
	}
} 
