using UnityEngine;
using System.Collections;

public class BodyTrigger2D : MonoBehaviour {

	public bool ifbody=false;
	public static bool finish = false;
	public float endTimeLose = 2.0f;
	public float endTimeWin = 2.0f;
	//used to play sounds
	public AudioClip CoinSound;
	public AudioClip NitroSound;
	public AudioClip bonesCrackSound;
	public AudioClip hitSound;
	public AudioClip oohCrowdSound;
	
	private AudioSource bonesCrackSC;
	private	AudioSource hitSC;
	private AudioSource oohCrowdSC;	
	
	//used to show text when entered in finish
	public GUIText winText;
	public GUIText crashText;		
	public Color winTextColor;
	public Color crashTextColor;
	
	//used to know if next level exists.
	private bool nextLevel = false;

	public GameObject EffectFinish;
	public GameObject EffectFinishleft1;
	public GameObject EffectFinishleft2;
	public GameObject EffectFinishleft3;
	public GameObject EffectFinishright1;
	public GameObject EffectFinishright2;
	public GameObject EffectFinishright3;

	public GameObject EffectCoin;
	
	private int count;

	game_uGUI my_game_uGUI;
	
	void Start()
	{
		count = 0;
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
		//my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
		
		finish = false;
		
		winText = GameObject.Find ("win text").GetComponent<GUIText>();
		crashText = GameObject.Find ("crash text").GetComponent<GUIText>();
		
		winText.enabled = false;
		crashText.enabled = false;
		
		//change text colors
		winText.material.color = winTextColor;
		crashText.material.color = crashTextColor;
		
		//ignoring collision between biker's bodytrigger and motorcycle body
		//Physics.IgnoreCollision (this.GetComponent<Collider>(), transform.parent.GetComponent<Collider>());
		
		//add new audio sources and add audio clips to them, used to play sounds
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
		//--------------------------------------------------
	}
	

	
	void OnTriggerEnter2D(Collider2D obj)
	{	

		if (obj.tag == "Coin") {
			
			if (my_game_uGUI) {
				//my_game_uGUI.Update_int_score (100);
				my_game_uGUI.Update_virtual_money(1);				
			}
			EffectCoin.SetActive (true);
			GameObject position = obj.gameObject;
			if (position != null) {
				EffectCoin.transform.position = position.transform.position;
				CFX_SpawnSystem.Instantiate (EffectCoin);
				AudioSource.PlayClipAtPoint (CoinSound, EffectCoin.transform.position, 10.0f);
			}
			if(my_game_uGUI){
			my_game_uGUI.Update_virtual_money (1);
			}
			Destroy (obj.gameObject);
		}

		if (obj.tag == "nitro") {
			Motorcycle_Controller2D.ifnitro = true;
			Motorcycle_Controller2D.offnitro = false;


			//Motorcycle_Controller2D.effectstatic.transform.position = Motorcycle_Controller2D.backWheelStatic.transform.position;
			//Motorcycle_Controller2D.effectstatic.transform.position = position.transform.position;
			//CFX_SpawnSystem.Instantiate (Motorcycle_Controller2D.effectnitrostatic);
			AudioSource.PlayClipAtPoint (NitroSound, Motorcycle_Controller2D.backWheelStatic.transform.position, 10.0f);
			Destroy (obj.gameObject);
			Invoke ("NitroOff", 8);

		}
		if (obj.gameObject.tag == "Finish" && !Motorcycle_Controller2D.crash) {//if entered in finish trigger
			finish = true;
			
			Motorcycle_Controller2D.isControllable = false; //disable motorcycle controlling
			
			//disable rear wheel rotation
			Motorcycle_Controller2D.isControllable = false;
			//var m = transform.root.GetComponent<Motorcycle_Controller2D>();
			//m.rearWheel.freezeRotation = true;
			//rearWheel.freezeRotation = true;
			//m.acceleration = 0;
			//	m.Acceleration = 0;
			GameObject meta = GameObject.Find ("meta");
			
			if (EffectFinish != null) {
				EffectFinish.SetActive (true);
				EffectFinishleft1.SetActive (true);
				EffectFinishleft2.SetActive (true);
				EffectFinishleft3.SetActive (true);
				EffectFinishright1.SetActive (true);
				EffectFinishright2.SetActive (true);
				EffectFinishright3.SetActive (true);

				GameObject position = meta;
				if (position != null) {
					EffectFinish.transform.position = position.transform.position;

					Vector3 temp = EffectFinish.transform.position;
					temp.y = (EffectFinish.transform.position.y + 2.0f);
					temp.z = (EffectFinish.transform.position.z + 0.08f);
					EffectFinish.transform.position = temp;
					CFX_SpawnSystem.Instantiate (EffectFinish);

					EffectFinishleft1.transform.position = position.transform.position;
					
					Vector3 temp2 = EffectFinishleft1.transform.position;
					temp2.y = (EffectFinishleft1.transform.position.y + 1.5f);
					temp2.x = (EffectFinishleft1.transform.position.x - 0.7f);
					temp2.z = (EffectFinishleft1.transform.position.z + 0.08f);

					EffectFinishleft1.transform.position = temp2;					
					CFX_SpawnSystem.Instantiate (EffectFinishleft1);

					EffectFinishleft2.transform.position = position.transform.position;
					
					Vector3 temp3 = EffectFinishleft2.transform.position;
					temp3.y = (EffectFinishleft2.transform.position.y + 0.8f);
					temp3.x = (EffectFinishleft2.transform.position.x - 0.7f);
					temp3.z = (EffectFinishleft2.transform.position.z + 0.08f);
					
					EffectFinishleft2.transform.position = temp3;					
					CFX_SpawnSystem.Instantiate (EffectFinishleft2);

					EffectFinishleft3.transform.position = position.transform.position;
					
					Vector3 temp4 = EffectFinishleft3.transform.position;
					temp4.y = (EffectFinishleft3.transform.position.y + 0.06f);
					temp4.x = (EffectFinishleft3.transform.position.x - 0.7f);
					temp4.z = (EffectFinishleft3.transform.position.z + 0.08f);
					
					EffectFinishleft3.transform.position = temp4;					
					CFX_SpawnSystem.Instantiate (EffectFinishleft3);

					EffectFinishright1.transform.position = position.transform.position;
					
					Vector3 tempright2 = EffectFinishright1.transform.position;
					tempright2.y = (EffectFinishright1.transform.position.y + 1.5f);
					tempright2.x = (EffectFinishright1.transform.position.x + 0.7f);
					tempright2.z = (EffectFinishright1.transform.position.z + 0.08f);
					
					EffectFinishright1.transform.position = tempright2;					
					CFX_SpawnSystem.Instantiate (EffectFinishright1);
					
					EffectFinishright2.transform.position = position.transform.position;
					
					Vector3 tempright3 = EffectFinishright2.transform.position;
					tempright3.y = (EffectFinishright2.transform.position.y + 0.8f);
					tempright3.x = (EffectFinishright2.transform.position.x + 0.7f);
					tempright3.z = (EffectFinishright2.transform.position.z + 0.08f);
					
					EffectFinishright2.transform.position = tempright3;					
					CFX_SpawnSystem.Instantiate (EffectFinishright2);
					
					EffectFinishright3.transform.position = position.transform.position;
					
					Vector3 tempright4 = EffectFinishright3.transform.position;
					tempright4.y = (EffectFinishright3.transform.position.y + 0.06f);
					tempright4.x = (EffectFinishright3.transform.position.x + 0.7f);
					tempright4.z = (EffectFinishright3.transform.position.z + 0.08f);
					
					EffectFinishright3.transform.position = tempright4;					
					CFX_SpawnSystem.Instantiate (EffectFinishright3);
					//AudioSource.PlayClipAtPoint(SoundLoseGravity,EffectLoseGravity.transform.position);


					//EffectFinishleft3.transform.position.x + 0.7f);
				}

			}

			winText.enabled = true; //show win text				
			
			if (Application.loadedLevel < Application.levelCount - 1) { //if won level isn't last level (levels are set in File -> Build Settings)
				nextLevel = true;
				
//				if(m.forMobile)
				//	winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n TAP ON SCREEN FOR NEXT LEVEL";

				Invoke ("wingui", endTimeWin);


				//	winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n PRESS SPACE FOR NEXT LEVEL";		

			} else { //won level is last one
				Invoke ("wingui", endTimeWin);
				//if(m.forMobile)
				//winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n TAP ON SCREEN TO PLAY FIRST LEVEL";				
				//else
				//	winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n PRESS SPACE TO PLAY FIRST LEVEL";				
				
				nextLevel = false;
			}
			
		} else if (obj.tag != "Checkpoint" ^ obj.tag != "ZoomOutTrigger" ^ obj.tag != "ZoomInTrigger" ^ obj.tag == "Player" ^ obj.tag == "Coin" ^ obj.tag == "Ground" ^ obj.tag == "nitro"^ obj.tag == "Zombie"^ obj.tag == "ZombieFat"^ obj.tag == "ZombieMid"^ obj.tag == "Wood") 
			{ //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
			if (!Motorcycle_Controller2D.crash) {
				if (obj.tag == "Saw") {		
					count = count +1;
					if(count == 1){
					Motorcycle_Controller2D.crashSaw = true;
					oohCrowdSC.Play ();
					}
				} else if (obj.tag == "SawHead") {
					count = count +1;
					if(count == 1){
					Motorcycle_Controller2D.crashSawHead = true;
					oohCrowdSC.Play ();
					}
				} else if (obj.tag == "DynamicParticle") {
					count = count +1;
					if(count == 1){
					Motorcycle_Controller2D.crashBurn = true;
					oohCrowdSC.Play ();
					}
				}	else if (obj.tag == "Drown") {
					count = count +1;
					if(count == 1){
					Motorcycle_Controller2D.crashDrown = true;
					}
					//oohCrowdSC.Play ();
				} else {
					oohCrowdSC.Play ();
					Motorcycle_Controller2D.crash = true;
				}
				//play sounds
				//bonesCrackSC.Play ();
				//hitSC.Play ();
				//oohCrowdSC.Play ();

				Invoke ("endgui", endTimeLose);

				
				/*if(!finish) //if we haven't entered in finish make crash text visible
				{
					crashText.enabled = true;
					
					var m = transform.root.GetComponent<Motorcycle_Controller2D>();
					if(m != null){
						if(m.forMobile)
						{
							if(Checkpoint.lastPoint)
								crashText.text = "TAP ON SCREEN TO GO TO LAST CHECKPOINT \n TAP ON SCREEN WITH 2 FINGERS TO RESTART";
							else
								crashText.text = "TAP ON SCREEN WITH 2 FINGERS TO RESTART";
						}
						else
						{
							if(Checkpoint.lastPoint)
								crashText.text = "PRESS 'C' TO GO TO LAST CHECKPOINT \n PRESS 'R' TO RESTART";
							else
								crashText.text = "PRESS 'R' TO RESTART";
						}
					}
					
				}*/
			} 
		}
	}


	void endgui()
	{
		if(my_game_uGUI){
			my_game_uGUI.Defeat();
		}
	}
	void wingui()
	{
		if(my_game_uGUI){
			my_game_uGUI.Victory();
		}
	}

	void NitroOff()
	{
		Motorcycle_Controller2D.ifnitro = false;
		Motorcycle_Controller2D.offnitro = true;
	}
	
	void Update()
	{
		if (Motorcycle_Controller2D.crash) {

			//AudioClip.Destroy(NitroSound);
		}
		/*if(finish && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began))) //if motorcycle entered in finish and space is pressed
		{
			if(nextLevel)
				Application.LoadLevel(Application.loadedLevel + 1);	//load next level
			else
				Application.LoadLevel(0); //load first level

			Motorcycle_Controller.score = 0;
		}*/
	}
}
