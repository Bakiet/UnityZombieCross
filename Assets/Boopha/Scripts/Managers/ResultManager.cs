using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Callback function.
/// This will help us to each button effect' (method that will call when pressed)
/// </summary>
public delegate void CallbackFunction();    

/// <summary>
/// Result manager.
/// Its like Pause Panel, but we will use some different features here.
/// </summary>
public class ResultManager : MonoBehaviour 
{
	private static ResultManager _instance;

	///<Summary>
	///This property will be get from outside of this class like this ResultManager.Instance
	///<Summary>
	public static ResultManager Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = FindObjectOfType<ResultManager>();
			}
			return _instance;
		}
	}


	public GUISkin guiSkin;
	public Texture panelBackground;
	public Texture boxFailedBackground;
	public Texture listLevelButton;
	public Texture replayButton;
	public Texture nextTexture;
	public Texture starTexture;	

	//here we will use this to call functions associated with buttons.
	public List<CallbackFunction> callbackFunctions = new List<CallbackFunction>();
	
	public static float width = 1;
	public static float height = 1;

	//what panel we will show? One of it must be true.
	private bool win = false;
	private bool lose = false;
	
	private int numberOfStar = 0;		//how many stars should we show?
	private int currentShowStar = 0;
	private float holdCount;
	private Vector2 startPos;
	private float scale = 0f;			//our star is bigger than i want. So lets scale this texture to fit.

	private float posX; 	//will be used to reference a position
	private float posY;		//Start method shows you where is positioned.

	void Awake()
	{
	}	

	void Start()
	{
		posX = ScreenAdapt.Instance.GetMidScreenHorizontal - (panelBackground.width * 1.3f /2);
		posY = ScreenAdapt.Instance.GetMidScreenVertical - (panelBackground.height * 1.3f /2);
	}


	///<Summary>
	///This function will be called from outside of this class
	/// isWin: state of game, win or lose.
	// star: number of star player get
	/// functions: List of callback functions for each action when click on buttons in this control
	///functions[0]: perform action for Choose Levels button
	///functions[1]: perform action for Replay button
	///functions[2]: perform action for Next Level button
	///</Summary>
	public void ShowResultBox(bool isWin, int star, CallbackFunction[] functions)
	{
		win = isWin	;
		lose = !isWin;
		currentShowStar  = 0;
		scale =0;
		numberOfStar = star;
		callbackFunctions.Clear();
		callbackFunctions.AddRange(functions);
	}
	void OnGUI()
	{		
		GUI.skin = guiSkin;

		//this is an important step.
		//AWAYS at begining of our OnGui method we call for ScreenAdapt to scale our gui to de screen resolution.
		
		//BeginScale with background is a way to easy to draw a background.
		ScreenAdapt.Instance.BeginScaleGUI();

		// if the game result  is lose
		if(lose)
		{
			DrawBackground();

			DrawListLevelsButton();
			
			DrawReplayButton();
		}		
		// if the game result is win
		if(win)
		{
			DrawBackground();

			ShowWin();

			DrawListLevelsButton();
			
			DrawReplayButton();

			DrawNextButton();
		}

		//after we finish to draw our gui, just end our scale.
		ScreenAdapt.Instance.EndScaleGUI ();
	}	

	/// <summary>
	/// Draws the panel background.
	/// This background is not like scene background. It is a panel.
	/// Because of it we dont start scale passing this as paremeter.
	/// </summary>
	public void DrawBackground()
	{
		//Draw background
		GUI.DrawTexture(new Rect(posX,
		                         posY,
		                         panelBackground.width * 1.3f,
		                         panelBackground.height * 1.3f),
		                panelBackground);
	}
	
	public void ShowWin()
	{
		//calculate star rect
		Rect starRect = new Rect();	

		//NOTE: this literal values are refered to my star texture.

		//make an pivot by center of star texture. 
		Vector2 starCenter = new Vector2(ScreenAdapt.Instance.GetMidScreenHorizontal -125, 270);

		#region "DRAW STARS"
		//only draw the start before current poping up star
		for(int i=0;i<=currentShowStar;i++)
		{	
			//if current star is coming,  show the resize up action by scale the star				
			if(i==currentShowStar)
			{
				//calculate the current star at this time
				starRect.width = 50 * scale;
				starRect.height = 50 * scale;
			}
			//if current star has ended to animate, it has full scaled width, height
			else if(i<currentShowStar)
			{
				starRect.width = 100;
				starRect.height = 100;
			}
			//calculate left, top of star rect
			starRect.x = starCenter.x - starRect.width/2f;
			starRect.y = starCenter.y - starRect.height/2f;

			//draw star
			GUI.DrawTexture(starRect,starTexture);

			//shift right 125 pixels to next star
			starCenter.x += 125;
		}
		#endregion
	
	}

	/// <summary>
	/// Shows the lose.
	/// Shows what lose panel contains.
	/// </summary>
	public void ShowLose()
	{
		DrawListLevelsButton();

		DrawReplayButton();
	}


	//****** ALL Buttons can be adapted like pause buttons. Just copy that class if you think this becomes complicated.


	public void DrawListLevelsButton()
	{
		//draw choose levels button
		if(GUI.Button(new Rect(posX + 80, posY + 200 , listLevelButton.width , listLevelButton.height), listLevelButton,"trans_button"))
		{
			//Call the choose level callback functions
			callbackFunctions[0]();
			//hide the box
			lose = false;
			win = false;
			return;
		}
	}

	public void DrawReplayButton()
	{
		//draw replay button
		if(GUI.Button(new Rect(posX + 250, posY + 200 , replayButton.width , replayButton.height), replayButton,"trans_button"))
		{
			callbackFunctions[1]();
			//hide the box
			lose = false;
			win = false;
			return;
		}
	}

	public void DrawNextButton()
	{
		//draw Next Level button
		if(GUI.Button(new Rect(posX + 420, posY + 200 , nextTexture.width , nextTexture.height), nextTexture, "trans_button"))
		{			
			callbackFunctions[2]();
			//hide the box
			lose = false;
			win = false;
			return;
		}
	}	



	public void Update()
	{		
		//show stars as counted. Animating it by scale.
		if(win)
		{
			scale += Time.deltaTime * 3f;
			if(scale > 2f)
			{
				if(currentShowStar < numberOfStar-1)
				{
					currentShowStar++;
					scale = 0f;
				}
				else if(currentShowStar == numberOfStar-1)
				{
					scale = 2f;
				}
			}
		}
	}






}
