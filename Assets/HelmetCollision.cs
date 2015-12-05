using UnityEngine;
using System.Collections;

public class HelmetCollision : MonoBehaviour {

	public float endTimeLose = 2.0f;
	public AudioClip bonesCrackSound;
	public AudioClip hitSound;
	public AudioClip oohCrowdSound;
	private AudioSource bonesCrackSC;
	private	AudioSource hitSC;
	private AudioSource oohCrowdSC;	
	game_uGUI my_game_uGUI;
	// Use this for initialization
	void Start () {
	
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}

		bonesCrackSC = gameObject.AddComponent<AudioSource>();
		hitSC = gameObject.AddComponent<AudioSource>();
		oohCrowdSC = gameObject.AddComponent<AudioSource>();
		
		bonesCrackSC.playOnAwake = false;
		hitSC.playOnAwake = false;
		oohCrowdSC.playOnAwake = false;
		
		bonesCrackSC.rolloffMode = AudioRolloffMode.Linear;
		hitSC.rolloffMode = AudioRolloffMode.Linear;
		oohCrowdSC.rolloffMode = AudioRolloffMode.Linear;
		
		bonesCrackSC.clip = bonesCrackSound;
		hitSC.clip = hitSound;
		oohCrowdSC.clip = oohCrowdSound;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.tag == "Ground") {
			
			if (obj.tag != "Checkpoint" ^ obj.tag != "ZoomOutTrigger" ^ obj.tag != "ZoomInTrigger" ^ obj.tag == "Player" ^ obj.tag == "Coin" ^ obj.tag == "nitro"^ obj.tag == "Zombie"^ obj.tag == "ZombieFat"^ obj.tag == "ZombieMid"^ obj.tag == "Wood") { //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
				if (!Motorcycle_Controller2D.crash) {
					if (obj.tag == "Saw") {					
						Motorcycle_Controller2D.crashSaw = true;
						oohCrowdSC.Play ();
					} else if (obj.tag == "SawHead") {
						Motorcycle_Controller2D.crashSawHead = true;
						oohCrowdSC.Play ();
						Motorcycle_Controller2D.crashBurn = true;
						oohCrowdSC.Play ();
					}	else if (obj.tag == "Drown") {
						Motorcycle_Controller2D.crashDrown = true;
						//oohCrowdSC.Play ();
					} else {
						oohCrowdSC.Play ();
						Motorcycle_Controller2D.crash = true;
					}
					
					Invoke ("endgui", endTimeLose);
					
					
				} 
			}
		}
	}
	void endgui()
	{
		if(my_game_uGUI){
			my_game_uGUI.Defeat();
		}
	}
}
