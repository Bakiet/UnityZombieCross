using UnityEngine;
using System.Collections;

public class Wood3 : MonoBehaviour {

	public GameObject Explotion2;
	public Rigidbody body;
	public static bool Collider = false;
	public static bool Collision = false;
	public int time = 3;
	GameObject wood3;
	GameObject wood4;
	GameObject wood5;
	GameObject wood6;
	GameObject wood7;
	GameObject wood8;
	GameObject wood9;


	void OnCollisionEnter (Collision collision)
	{
		
		Invoke("MyWaitingFunction",time);	

	}	

	void MyWaitingFunction()
	{

		//if (GetComponent<Rigidbody> ().name != "Cube 1") {
			//if (GetComponent<Rigidbody> ().name == "front wheel") {
					
				wood3 = GameObject.Find ("Cube 1"); 
				
				Explotion2.SetActive (true);
				Explotion2.transform.position = body.position;

				wood4 = GameObject.Find ("Cube 2");
				wood5 = GameObject.Find ("Cube 3");
				wood6 = GameObject.Find ("Cube 4");
				wood7 = GameObject.Find ("Cube 5");
				wood8 = GameObject.Find ("Cube 6");
				wood9 = GameObject.Find ("Cube 7");

				wood3.GetComponent<Rigidbody> ().isKinematic = false; 
				wood3.GetComponent<Rigidbody> ().useGravity = true;

				wood4.GetComponent<Rigidbody> ().isKinematic = false; 
				wood4.GetComponent<Rigidbody> ().useGravity = true;

				wood5.GetComponent<Rigidbody> ().isKinematic = false; 
				wood5.GetComponent<Rigidbody> ().useGravity = true;

				wood6.GetComponent<Rigidbody> ().isKinematic = false; 
				wood6.GetComponent<Rigidbody> ().useGravity = true;

				wood7.GetComponent<Rigidbody> ().isKinematic = false; 
				wood7.GetComponent<Rigidbody> ().useGravity = true;

				wood8.GetComponent<Rigidbody> ().isKinematic = false; 
				wood8.GetComponent<Rigidbody> ().useGravity = true;

				wood9.GetComponent<Rigidbody> ().isKinematic = false; 
				wood9.GetComponent<Rigidbody> ().useGravity = true;
			}
		





	// Use this for initialization
	void Start () {
		Explotion2.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
