using UnityEngine;
using System.Collections;

public class Paralaxcity : MonoBehaviour {

	public float velocidad = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Time.time * velocidad, 0);
	
	}
} 
