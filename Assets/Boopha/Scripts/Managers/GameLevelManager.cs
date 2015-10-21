using UnityEngine;
using System.Collections;

public class GameLevelManager : MonoBehaviour 
{
	#region Public Properties

	public GUISkin guiskin;				// an skin to our hud.
	public Texture background;			//texture to use as background.

	public int currentWorld =0;			//control visual selected world.

	public string[] worldName;			//what are our world names.
	public Texture[] texWorldBackgroundFrame;	//an background frame for each world. If you want 3 worlds, put 3 backgrounds frames.
					//dont forget to configure GameManager object at ScenePlaying with backgrounds associateds.

	public Texture texBlockedWorld;		//what texture we should to use to indicate that world is blocked yet.
	public Texture texButtonBack;		//button gui to select previous world.
	public Texture texButtonNext;		//button gui to select next world.
	public Texture texPrevious;			//button gui to get screen back.

	public Texture[] IconByState = new Texture[5]; //Set icon to open, to blocked, to 1 star, to 2 stars and 3 stars.

	public LevelManager lvlManager; 	//our class that control levels open or blocked and current.

	#endregion

	//we have two different moments at this scene.
	//Showing world selection and showing level selection.
	//this variable will tell us what moment is it.
	private bool isShownWorldPanel = true;

	//base dist from de edges. Dont worry, this margins will be tranformed to screen scale in time.
	private int distX = 50; 
	private int distY = 50;	


	void Awake()
	{
		//this scene must have one object with it.
		lvlManager = FindObjectOfType<LevelManager>();
	}


	// Use this for initialization
	void Start () {
		//Play menu music loop.
		SoundManager.Instance.PlaySoundFx(EnumSounds.MusicMain);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnGUI()
	{
		//this is an important step.
		//AWAYS at begining of our OnGui method we call for ScreenAdapt to scale our gui to de screen resolution.

		//BeginScale with background is a way to easy to draw a background.
		ScreenAdapt.Instance.BeginScaleGUI(background);

		GUI.skin = guiskin;

		//What panel we should show? World or Level selection?
		if(isShownWorldPanel == true)
		{
			DrawWorldFrame(); 	//the name says what this do.
			DrawButtons();		//draw next and previous button to world selection
			DrawBackToMainScreen();	//draw button to get back to main screen.
		}
		else 
		{
			DrawLevels();		//the name says what this do.
			DrawBackToWorldSelection();	//draw button to get back to show world selection panel.
		}

		DrawWorldName();	//draws at top selected world name.

		//after we finish to draw our gui, just end our scale.
		ScreenAdapt.Instance.EndScaleGUI();

	}
	

	#region World Selection

	public void DrawWorldFrame()
	{
		//if this world was not blocked show background and permit click action
		if(currentWorld <= lvlManager.maxWorldUnlocked) //isWorldBlocked[currentWorld] == false)
		{
			//show gui level.
			//if(GUI.Button(new Rect(200, 80, 400, 300), lvlManager.textureWorldBackground[currentWorld], "world_button"))
			if(GUI.Button(new Rect(ScreenAdapt.Instance.worldFrameRight,
			                       ScreenAdapt.Instance.worldFrameTop,
			                       ScreenAdapt.Instance.worldFrameWidth,
			                       ScreenAdapt.Instance.worldFrameHeight),
			              texWorldBackgroundFrame[currentWorld], "world_button"))
			{
				SoundManager.Instance.PlaySoundFx (EnumSounds.Click);
				isShownWorldPanel = false;
			}
		}
		//if this world WAS blocked show Blocked background and DONT permit click action.
		else
		{
			//show gui level.			//			if(GUI.Button(new Rect(150, 60, 400, 300), texBlockedWorld, "block_world_button"))
			//if(GUI.Button(new Rect(200, 80, 400, 300), texBlockedWorld, "block_world_button"))
			if(GUI.Button(new Rect(ScreenAdapt.Instance.worldFrameRight,
			                       ScreenAdapt.Instance.worldFrameTop,
			                       ScreenAdapt.Instance.worldFrameWidth,
			                       ScreenAdapt.Instance.worldFrameHeight),
			              texBlockedWorld, "world_button"))
			{
				//SoundManager.Instance.PlaySoundFx (EnumSounds.Burp);
			}
		}
		
	}

	/// <summary>
	/// Draws the buttons to control selected world.
	/// </summary>
	public void DrawButtons()
	{
		// change to previous world.
		if(GUI.Button(ScreenAdapt.Instance.GetRoundBtnMidLeft, texButtonBack, "back_icon_button"))
		{
			//plays selection sound effect.
			SoundManager.Instance.PlaySoundFx (EnumSounds.Click);
			--currentWorld;
			if(currentWorld < 0)
			{ 
				currentWorld = texWorldBackgroundFrame.Length -1; //if less than first, then go to last frame.
			}
		}

		//change selected to next world.
		if(GUI.Button(ScreenAdapt.Instance.GetRoundBtnMidRight,texButtonNext, "back_icon_button"))
		{
			//plays selection sound effect.
			SoundManager.Instance.PlaySoundFx (EnumSounds.Click);
			++currentWorld;

			//we use lvlManager.textureWorldBackground.Length because
			//this variable knows exatly how many worlds we have to show.
			if(currentWorld > texWorldBackgroundFrame.Length-1)
			{ 
				currentWorld = 0; //if more than last, then go to first frame.
			}
		}
	}

	/// <summary>
	/// Draws the back to main screen.
	/// </summary>
	public void DrawBackToMainScreen()
	{
		if(GUI.Button(ScreenAdapt.Instance.GetRoundBtnBottomRight, texPrevious, "previous_button"))
		{
			SoundManager.Instance.PlaySoundFx (EnumSounds.Click);
			Application.LoadLevel("SceneMain");
		}
	}

	/// <summary>
	/// Draws the name of the world.
	/// </summary>
	public void DrawWorldName()
	{
		//current selected world will be user here too.
		//to identify our world array index.
		GUI.Label(new Rect(Screen.width/2,
		                   30,
		                   300,
		                   55), 
		          worldName[currentWorld]);
	}

	#endregion


	#region Level Selection


	/// <summary>
	/// Draws each square of the levels. Blocked and Unblocked.
	/// </summary>
	private void DrawLevels()
	{
		//REMEMBER: Here we just started Scale screen. So, we dont need worry about it each line.

		//for each level listed in manager
		for(int i =0; i < lvlManager.levels.Length; i++)
		{
			//checks if this level belongs to current selected world.
			if(lvlManager.levels[i].WorldNum == currentWorld)
			{
				//show gui level as button. CurrentIcon is used to know what icon will be shown.
				if(GUI.Button(new Rect(distX, distY, 145, 197), CurrentIcon(lvlManager.levels[i]), "level_icon_button"))
				{
					if(lvlManager.levels[i].isBlocked == false) 
					{
						SoundManager.Instance.PlaySoundFx (EnumSounds.Click);
						lvlManager.selectedLevel = i;
						DontDestroyOnLoad(lvlManager); //levelmanager will be used at playing scene.
						Application.LoadLevel("ScenePlaying");
					}
				}
				
				distX += CurrentIcon(lvlManager.levels[i]).width + 30; //30 is distance between one and another.

				//checks quantity limit of levels each row by screen size and level size.
				if(ScreenAdapt.Instance.ResizeHorizontal(distX) >= Screen.width - ScreenAdapt.Instance.ResizeHorizontal(50))
				{
					distY += CurrentIcon(lvlManager.levels[i]).height + 30; //30 is distance between one and another.
					distX = 50;
				}
				
			}// end filter levels by world
		}//end for
		
		distX = 50;
		distY = 50;
		
	}

	/// <summary>
	/// Draws the back to world selection.
	/// This button change what panel will be shown, getting back to world selection.
	/// </summary>
	private void DrawBackToWorldSelection()
	{
		//this label "previous_button" just as another ones. Means nothing. You can put an empty string.
		if(GUI.Button(ScreenAdapt.Instance.GetRoundBtnBottomRight, texPrevious, "previous_button"))
		{
			SoundManager.Instance.PlaySoundFx (EnumSounds.Click);

			isShownWorldPanel = true;
		}
	}
	

	#endregion
	
	/// <summary>
	/// Gets Currents the icon.
	/// This method helps me a lot!
	/// You can change what each number (i say position of icons in array) means.
	/// </summary>
	/// <returns>The icon.</returns>
	/// <param name="lvl">Lvl.</param>
	public Texture CurrentIcon(Level lvl)
	{
		if(lvl.isWin) 
		{
			if(lvl.starsAcquired == 3) { return IconByState[4]; }
			else if(lvl.starsAcquired == 2) { return IconByState[3]; }
			else { return IconByState[2]; }
		}
		else if(lvl.isBlocked) { return IconByState[1]; }
		else { return IconByState[0]; }
	}

}
