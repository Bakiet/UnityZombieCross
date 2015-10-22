#pragma strict

 var skinGui:GUISkin;
 
 //the GUI scale ratio
 private var guiRatioX:float;
 private var guiRatioY:float;
 //the screen width
 private var sWidth:float;
 private var sHeight:float;
 //A vector3 that will be created using the scale ratio
 private var GUIsF:Vector3;
 var sizegui:int;
 
 
 
 
 
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
var PauseBtnTexture : Texture;
var ResumeBtnTexture : Texture;

var isShow : boolean = false;

function Awake()
 {
     //get the screen's width
     sWidth = Screen.width;
     sHeight = Screen.height;
     //calculate the rescale ratio
     guiRatioX = sWidth/1920.0 * sizegui;
     guiRatioY = sHeight/1080.0* sizegui;
     //create a rescale Vector3 with the above ratio
     GUIsF = new Vector3(guiRatioX,guiRatioY,0);
 }
 
 
function Update()
{
	//Make static variable visible to other script
	TouchButtonsEnabledGlobal = TouchButtonsEnabledLocal;

}


 function DrawButton()
	{		
		//Draw pauseButton
		if(GUI.Button(new Rect(50,4,40,40),PauseBtnTexture,"trans_button"))
		{
			isShow = !isShow;
		}

		//*** Pause happens here. This code below is exactly what pauses the game.
		//Pause game if panel is shown.
		if(isShow)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
function OnGUI()
{
	GUI.skin = skinGui;
	 
	// GUI.matrix = Matrix4x4.TRS(new Vector3(GUIsF.x,GUIsF.y,0),Quaternion.identity,GUIsF);
	 
	

	if(GuiEnabled == true)
	{
		GUI.Box (Rect (40,40,160,60), "Statistics");
		GUI.Label(Rect(50,60,Screen.width,Screen.height), "Current speed: "+Move2D.CurrentSpeed+" Km/h");
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
		
	/*	if(GUI.RepeatButton(Rect(Screen.width - 230,Screen.height - 150,80,80),LeftBtnTexture, TransparentStyle))
		{
			Move2D.axisH = -1;
			Move2D.CarMoveLeft = true;
			Move2D.CarMoveRight = false;
						
			//Draw also right button
			GUI.RepeatButton(Rect(Screen.width - 120,Screen.height - 150,80,80),RightBtnTexture, TransparentStyle);
		}*/

		
		else if(GUI.RepeatButton(Rect(Screen.width - 90,160,80,80),RightBtnTexture, TransparentStyle))
		{
			Move2D.axisH = 1;
			Move2D.CarMoveRight = true;
			Move2D.CarMoveLeft = false;
			
			//Draw also left button
		//	GUI.RepeatButton(Rect(Screen.width - 230,Screen.height - 150,80,80),LeftBtnTexture, TransparentStyle);
		}
		
		else 
		{
			Move2D.axisH = 0;
			Move2D.CarMoveLeft = false;
			Move2D.CarMoveRight = false;
		}
		
		if(GUI.RepeatButton(Rect(4,160,80,80),HandbrakeBtnTexture, TransparentStyle))
		{
			Move2D.CarHandbrake = true;
		}
		
		else Move2D.CarHandbrake = false;
		
		/*if(GUI.RepeatButton(Rect(Screen.width - 120,Screen.height - 350,80,80),FlipBtnTexture, TransparentStyle))
		{
			Move2D.CarFlip = true;
		}*/
		
		//else Move2D.CarFlip = false;
		
		//if(GUI.RepeatButton(Rect(Screen.width - 640,Screen.height - 400,80,80),ResetBtnTexture, TransparentStyle))
		if(GUI.RepeatButton(Rect(1,4,40,40),ResetBtnTexture, TransparentStyle))
		
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		
		DrawButton();
		
		//GUI.RepeatButton(Rect(Screen.width - 230,Screen.height - 370,80,80),ResumeBtnTexture, TransparentStyle);
		
		

	}
	
	
	
	
	//Draw 'Enable/disable touch steering buttons' buttons
	/*if(GUI.Button(Rect(Screen.width - 230,Screen.height - 60,90,30),"Touch btn on"))
	{
		TouchButtonsEnabledLocal = true;
	}
	
	if(GUI.Button(Rect(Screen.width - 130,Screen.height - 60,90,30),"Touch btn off"))
	{
		TouchButtonsEnabledLocal = false;
	}
    */
	
}

