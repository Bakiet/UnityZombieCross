﻿using UnityEngine;
//using UnityEditor;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public GameObject motorcyclePrefab;
	private GameObject motorcyclePrefabClone;
	public string tagToCheck = "Player";
	public Color activatedColor = Color.green;
	public Renderer objectToChangeColor;

	public Transform target;

	private AudioSource audioSource;

	public static Transform lastPoint;
	private static GameObject moto;

	private static int count;
	private static int scoreAtLastPoint = 0;

	private GameObject[] gameObjects;

	void Update(){

		//gameObjects = (GameObject[])FindObjectsOfType(GameObject);
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		/*foreach (GameObject go in allObjects) {

			motorcyclePrefab =go;
		}*/

		for (var i=0; i < allObjects.Length; i++){
			if(allObjects[i].name.Contains("Spawn")){
				motorcyclePrefab = allObjects[i];
			}
		}

		moto = motorcyclePrefab;
		//motorcyclePrefab = GameObject.Find(Children().Where(x=>x.name.Contains("Spawn")));
		//motorcyclePrefabClone = GameObject.Find("Spawn(Clone)");
		/*if (motorcyclePrefab != null) {
			moto = motorcyclePrefab;
		}
		if (motorcyclePrefabClone != null) {
			moto = motorcyclePrefabClone;
		}*/
	}
	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		//motorcyclePrefab = Motorcycle_Controller2D.BodyCarStatic;
		/*motorcyclePrefab = GameObject.Find("Spawn");
		motorcyclePrefabClone = GameObject.Find("Spawn(Clone)");
		if (motorcyclePrefab != null) {
			moto = motorcyclePrefab;
		}
		if (motorcyclePrefabClone != null) {
			moto = motorcyclePrefabClone;
		}*/
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(lastPoint != transform && col.tag == tagToCheck)
		{
			lastPoint = transform;
			objectToChangeColor.material.color = activatedColor;
			audioSource.Play ();
			scoreAtLastPoint = Motorcycle_Controller2D.score;
			//motorcyclePrefab = Motorcycle_Controller2D.BodyCarStatic;
			//moto = motorcyclePrefab;
		}
	}

	public static void Reset()
	{
		//Motorcycle_Controller2D.lastcheckpoint = lastPoint;
		//Application.LoadLevel (Application.loadedLevel);

		Destroy (GameObject.Find(Motorcycle_Controller2D.BodyCarStatic.name));
		//PrefabUtility.ResetToPrefabState (Motorcycle_Controller2D.BodyCarStatic);
		Instantiate (moto, lastPoint.position, Quaternion.identity);
		moto.tag = "SpawnClone";
		//Motorcycle_Controller2D.score = scoreAtLastPoint;

		Motorcycle_Controller2D.checkpoint = true;
		Motorcycle_Controller2D.lastcheckpoint = lastPoint;



		GameObject lastspawn = GameObject.Find("Spawn");
		GameObject[] lastspawnclone = GameObject.FindGameObjectsWithTag("SpawnClone");

		if(lastspawn){
		Destroy (lastspawn);

		}
		foreach (GameObject spawn in lastspawnclone) {
			count++;
			if(count > 1){
				//count = count -2;
				Destroy(spawn);
			}
		}

	
		Motorcycle_Controller2D.score = scoreAtLastPoint;

		//Motorcycle_Controller2D.crash = false;

	}
}
