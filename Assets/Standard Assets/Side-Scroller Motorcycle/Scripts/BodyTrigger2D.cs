using UnityEngine;
using System.Collections;

public class BodyTrigger2D : MonoBehaviour {

	public static bool finish = false;
	
	//used to play sounds
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
	
	
	game_uGUI my_game_uGUI;
	
	void Start()
	{
		my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
		
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
	
	void OnTriggerEnter(Collider obj)
	{

	}
	
	void OnTriggerEnter2D(Collider2D obj)
	{	
		
		
		if(obj.gameObject.tag == "Finish" && !Motorcycle_Controller2D.crash)//if entered in finish trigger
		{
			finish = true;
			
			Motorcycle_Controller2D.isControllable = false; //disable motorcycle controlling
			
			//disable rear wheel rotation
			var m = transform.root.GetComponent<Motorcycle_Controller2D>();
			m.rearWheel.freezeRotation = true;
			m.acceleration = 0;
			
			
			winText.enabled = true; //show win text				
			
			if(Application.loadedLevel < Application.levelCount - 1) //if won level isn't last level (levels are set in File -> Build Settings)
			{
				nextLevel = true;
				
				if(m.forMobile)
					winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n TAP ON SCREEN FOR NEXT LEVEL";
				if(my_game_uGUI){
					my_game_uGUI.Victory();
				}
				else
					winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n PRESS SPACE FOR NEXT LEVEL";		
				if(my_game_uGUI){
					my_game_uGUI.Victory();
				}
			}
			else //won level is last one
			{
				if(m.forMobile)
					winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n TAP ON SCREEN TO PLAY FIRST LEVEL";				
				else
					winText.text = "CONGRATULATIONS, YOU WON! \n YOUR SCORE IS: " + Motorcycle_Controller2D.score + "\n\n PRESS SPACE TO PLAY FIRST LEVEL";				
				
				nextLevel = false;
			}
			
		}
		else if(obj.tag != "Checkpoint" ^ obj.tag != "ZoomOutTrigger" ^ obj.tag != "ZoomInTrigger") //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
		{
			if(!Motorcycle_Controller2D.crash)
			{
				Motorcycle_Controller2D.crash = true;
				if(my_game_uGUI){
					my_game_uGUI.Defeat();
				}
				//play sounds
				bonesCrackSC.Play ();
				hitSC.Play ();
				oohCrowdSC.Play ();
				
				if(!finish) //if we haven't entered in finish make crash text visible
				{
					crashText.enabled = true;
					
					var m = transform.root.GetComponent<Motorcycle_Controller2D>();
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
			} 
		}
	}
	
	void Update()
	{
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
