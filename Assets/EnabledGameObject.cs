using UnityEngine;
using System.Collections;

public class EnabledGameObject : MonoBehaviour {

	//private float nextActionTime = 0.0f;
	public float period = 5.0f;

	// Use this for initialization

	public float[] particles;

	
	// Update is called once per frame
	void Update () {
		/*if (Time.time > nextActionTime ) {
			//nextActionTime = Time.time + period; 
			nextActionTime += period;
			gameObject.GetComponent<ParticleGenerator>().enabled = true;
		}
		else if(Time.time <= nextActionTime){
			gameObject.GetComponent<ParticleGenerator>().enabled = false;
		}*/

	}


	//public GameObject objectToActivate;
	
	private void Start()
	{
		StartCoroutine(ActivationRoutine());
	}
	
	private IEnumerator ActivationRoutine()
	{        
		foreach(float par in particles){
			GetComponent<AudioSource>().Play();
		//Wait for 14 secs.
			yield return new WaitForSeconds(period);
			GetComponent<AudioSource>().Stop();
			//Turn My game object that is set to false(off) to True(on).
			gameObject.GetComponent<ParticleGenerator>().enabled = false;
			
			//Turn the Game Oject back off after 1 sec.
			yield return new WaitForSeconds(period);

			GetComponent<AudioSource>().Play();
			//Game object will turn off
			gameObject.GetComponent<ParticleGenerator>().enabled = true;
		}
	}
}
