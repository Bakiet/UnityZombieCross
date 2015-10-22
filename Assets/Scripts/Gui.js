#pragma strict

//var KphDisplay : GUIText;
public var GuiEnabled : boolean = true;
public static var TouchButtonsEnabledGlobal : boolean;
public var TouchButtonsEnabledLocal : boolean;

var TransparentStyle : GUIStyle;

var LeftBtnTexture : Texture;
var RightBtnTexture : Texture;
var HandbrakeBtnTexture : Texture;
var FlipBtnTexture : Texture;
var ResetBtnTexture : Texture;

function Update()
{
	//Make static variable visible to other script
	TouchButtonsEnabledGlobal = TouchButtonsEnabledLocal;
}

function OnGUI()
{
	if(GuiEnabled == true)
	{
		GUI.Box (Rect (40,40,160,60), "Statistics");
		GUI.Label(Rect(50,60,Screen.width,Screen.height), "Current speed: "+Move.CurrentSpeed+" Km/h");
		GUI.Box (Rect (40,Screen.height - 130,250,120), "Steering");
		GUI.Label(Rect(50,Screen.height - 100,Screen.width,Screen.height), "'A' or 'Left arrow' - Move back/brake");
		GUI.Label(Rect(50,Screen.height - 85,Screen.width,Screen.height), "'D' or 'Right arrow' - Move forward/gas");
		GUI.Label(Rect(50,Screen.height - 70,Screen.width,Screen.height), "'Space' - Handbrake");
		GUI.Label(Rect(50,Screen.height - 55,Screen.width,Screen.height), "'R' - Reload level");
		GUI.Label(Rect(50,Screen.height - 40,Screen.width,Screen.height), "'Z' - Flip the car");
	}
	
	//Draw touch steering buttons
	if(TouchButtonsEnabledLocal == true)
	{
		if (!LeftBtnTexture || !RightBtnTexture || !HandbrakeBtnTexture || !FlipBtnTexture || !ResetBtnTexture) 
		{
			Debug.LogError("Please assign all button textures in the inspector!");
			return;
		}
		
		if(GUI.RepeatButton(Rect(Screen.width - 230,Screen.height - 150,80,80),LeftBtnTexture, TransparentStyle))
		{
			Move.axisH = -1;
			Move.CarMoveLeft = true;
			Move.CarMoveRight = false;
						
			//Draw also right button
			GUI.RepeatButton(Rect(Screen.width - 120,Screen.height - 150,80,80),RightBtnTexture, TransparentStyle);
		}
		
		else if(GUI.RepeatButton(Rect(Screen.width - 120,Screen.height - 150,80,80),RightBtnTexture, TransparentStyle))
		{
			Move.axisH = 1;
			Move.CarMoveRight = true;
			Move.CarMoveLeft = false;
			
			//Draw also left button
			GUI.RepeatButton(Rect(Screen.width - 230,Screen.height - 150,80,80),LeftBtnTexture, TransparentStyle);
		}
		
		else 
		{
			Move.axisH = 0;
			Move.CarMoveLeft = false;
			Move.CarMoveRight = false;
		}
		
		if(GUI.RepeatButton(Rect(Screen.width - 120,Screen.height - 250,80,80),HandbrakeBtnTexture, TransparentStyle))
		{
			Move.CarHandbrake = true;
		}
		
		else Move.CarHandbrake = false;
		
		if(GUI.RepeatButton(Rect(Screen.width - 120,Screen.height - 350,80,80),FlipBtnTexture, TransparentStyle))
		{
			Move.CarFlip = true;
		}
		
		else Move.CarFlip = false;
		
		if(GUI.RepeatButton(Rect(Screen.width - 230,Screen.height - 350,80,80),ResetBtnTexture, TransparentStyle))
		{
			Application.LoadLevel(Application.loadedLevel);
		}

	}
	
	//Draw 'Enable/disable touch steering buttons' buttons
	if(GUI.Button(Rect(Screen.width - 230,Screen.height - 60,90,30),"Touch btn on"))
	{
		TouchButtonsEnabledLocal = true;
	}
	
	if(GUI.Button(Rect(Screen.width - 130,Screen.height - 60,90,30),"Touch btn off"))
	{
		TouchButtonsEnabledLocal = false;
	}
    
	
}

