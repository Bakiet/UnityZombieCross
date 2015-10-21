using UnityEngine;
using System.Collections;

public class CollisonCallPrefab : MonoBehaviour {
	public GameObject ObjectCollide;
	public GameObject Effect;
	public GameObject ObjectDestroy;
	
	private const string ACHIEVEMENT_ID_First_Burn = "CgkIq6GznYALEAIQDA";	
	private const string ACHIEVEMENT_ID_First_Drown = "CgkIq6GznYALEAIQCA";
	private const string ACHIEVEMENT_ID_First_Death = "CgkIq6GznYALEAIQBw";
	private const string ACHIEVEMENT_ID_First_Explotion = "CgkIq6GznYALEAIQBg";

	


	public float explosionTime = 0.2f;
	public float radius = 100f;
	public float power = 100000f;
	public int probeCount = 150;
	public float explodeDuration = 0.5f;
	// Use this for initialization
	void Start () {
		Effect.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.name == ObjectCollide.name) {

			makeclick Achievement = new makeclick();
			Achievement.SENDACHIEVEMENT(ACHIEVEMENT_ID_First_Explotion);

			Effect.SetActive (true);
			Effect.transform.position = ObjectDestroy.gameObject.transform.position;
			Effect.AddComponent<Exploder>();

			Effect.AddComponent<Exploder>().explosionTime = explosionTime;
			Effect.AddComponent<Exploder>().power = power;
			Effect.AddComponent<Exploder>().radius = radius;
			Effect.AddComponent<Exploder>().explodeDuration = explodeDuration;
			Instantiate (Effect);		
			Destroy (ObjectDestroy);	

		}

	}
}
