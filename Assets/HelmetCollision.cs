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
	void OnCollisionEnter2D(Collision2D obj){
	
		if (obj.gameObject.tag != "Checkpoint" ^ obj.gameObject.tag != "ZoomOutTrigger" ^ obj.gameObject.tag != "ZoomInTrigger" ^ obj.gameObject.tag == "Player" ^ obj.gameObject.tag == "Ragdoll" ^ obj.gameObject.tag == "Coin" ^ obj.gameObject.tag == "nitro"^ obj.gameObject.tag == "Zombie"^ obj.gameObject.tag == "ZombieFat"^ obj.gameObject.tag == "ZombieMid"^ obj.gameObject.tag == "Wood") { //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
				if (!Motorcycle_Controller2D.crash) {
					if (obj.gameObject.tag == "Saw") {					
						Motorcycle_Controller2D.crashSaw = true;
						oohCrowdSC.Play ();
					} else if (obj.gameObject.tag == "SawHead") {
						Motorcycle_Controller2D.crashSawHead = true;
						oohCrowdSC.Play ();
						//Motorcycle_Controller2D.crashBurn = true;
						//oohCrowdSC.Play ();
					}
					else if (obj.gameObject.tag == "Drown") {
						Motorcycle_Controller2D.crashDrown = true;
						//oohCrowdSC.Play ();
					} 
					} else if (obj.gameObject.tag == "DynamicParticle") {
						Motorcycle_Controller2D.crashBurn = true;
						oohCrowdSC.Play ();
					}	else if (obj.gameObject.tag == "Drown") {
						Motorcycle_Controller2D.crashDrown = true;
						//oohCrowdSC.Play ();
					} else {
						oohCrowdSC.Play ();
						Motorcycle_Controller2D.crash = true;
					}
					
					Invoke ("endgui", endTimeLose);
					
					
				}

		if (obj.gameObject.tag == "Ground") {
			
			if (obj.gameObject.tag != "Checkpoint" ^ obj.gameObject.tag != "ZoomOutTrigger" ^ obj.gameObject.tag != "ZoomInTrigger" ^ obj.gameObject.tag == "Player" ^ obj.gameObject.tag == "Ragdoll"^ obj.gameObject.tag == "Coin" ^ obj.gameObject.tag == "nitro"^ obj.gameObject.tag == "Zombie"^ obj.gameObject.tag == "ZombieFat"^ obj.gameObject.tag == "ZombieMid"^ obj.gameObject.tag != "Wood") { //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
				if (!Motorcycle_Controller2D.crash) {
					if (obj.gameObject.tag == "Saw") {					
						Motorcycle_Controller2D.crashSaw = true;
						oohCrowdSC.Play ();
					} else if (obj.gameObject.tag == "SawHead") {
						Motorcycle_Controller2D.crashSawHead = true;
						oohCrowdSC.Play ();
						//Motorcycle_Controller2D.crashBurn = true;
						//oohCrowdSC.Play ();
					} else if (obj.gameObject.tag == "DynamicParticle") {
						Motorcycle_Controller2D.crashBurn = true;
						oohCrowdSC.Play ();
					}	else if (obj.gameObject.tag == "Drown") {
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
	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag != "Checkpoint" ^ obj.gameObject.tag != "ZoomOutTrigger" ^ obj.gameObject.tag != "ZoomInTrigger" ^ obj.gameObject.tag == "Player" ^ obj.gameObject.tag == "Ragdoll" ^ obj.gameObject.tag == "Coin" ^ obj.gameObject.tag == "nitro"^ obj.gameObject.tag == "Zombie"^ obj.gameObject.tag == "ZombieFat"^ obj.gameObject.tag == "ZombieMid"^ obj.gameObject.tag == "Wood") { //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
			if (!Motorcycle_Controller2D.crash) {
				if (obj.gameObject.tag == "Saw") {					
					Motorcycle_Controller2D.crashSaw = true;
					oohCrowdSC.Play ();
				} else if (obj.gameObject.tag == "SawHead") {
					Motorcycle_Controller2D.crashSawHead = true;
					oohCrowdSC.Play ();
					//Motorcycle_Controller2D.crashBurn = true;
					//oohCrowdSC.Play ();
				} else if (obj.gameObject.tag == "DynamicParticle") {
					Motorcycle_Controller2D.crashBurn = true;
					oohCrowdSC.Play ();
				}	else if (obj.gameObject.tag == "Drown") {
					Motorcycle_Controller2D.crashDrown = true;
					//oohCrowdSC.Play ();
				} else {
					oohCrowdSC.Play ();
					Motorcycle_Controller2D.crash = true;
				}
				
				Invoke ("endgui", endTimeLose);

			} 
		}
		if (obj.gameObject.tag == "Ground") {
			
			if (obj.gameObject.tag != "Checkpoint" ^ obj.gameObject.tag != "ZoomOutTrigger" ^ obj.gameObject.tag != "ZoomInTrigger" ^ obj.gameObject.tag == "Player" ^ obj.gameObject.tag == "Ragdoll"^ obj.gameObject.tag == "Coin" ^ obj.gameObject.tag == "nitro"^ obj.gameObject.tag == "Zombie"^ obj.gameObject.tag == "ZombieFat"^ obj.gameObject.tag == "ZombieMid"^ obj.gameObject.tag != "Wood") { //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
				if (!Motorcycle_Controller2D.crash) {
					if (obj.gameObject.tag == "Saw") {					
						Motorcycle_Controller2D.crashSaw = true;
						oohCrowdSC.Play ();
					} else if (obj.gameObject.tag == "SawHead") {
						Motorcycle_Controller2D.crashSawHead = true;
						oohCrowdSC.Play ();
						//Motorcycle_Controller2D.crashBurn = true;
						//oohCrowdSC.Play ();
					} else if (obj.gameObject.tag == "DynamicParticle") {
						Motorcycle_Controller2D.crashBurn = true;
						oohCrowdSC.Play ();
					}	else if (obj.gameObject.tag == "Drown") {
						Motorcycle_Controller2D.crashDrown = true;
						//oohCrowdSC.Play ();
					} else if (obj.gameObject.tag == "Ground") {
						Motorcycle_Controller2D.crashDown = true;
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
