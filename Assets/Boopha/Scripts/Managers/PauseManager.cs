using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Pause manager.
/// Create a gameObject empty and put this in it.
/// </summary>
public class PauseManager : MonoBehaviour {

	public GUISkin guiskin;
	bool isShow = false; 				//control if this control is shown.

	public Texture panelBackground;		//texture of our background panel. You can use transparent or one like mine.

	public Texture replayButton;		//This textures will be used in our pause buttons
	public Texture listLevelButton;		//You can create all buttons as you want to.
	public Texture soundOnButton;		//Here i use only basics.
	public Texture soundOffButton;
	
	public Texture pauseButton;			//this button represent pause button itself.
	

	float posX;			//Our panel is always there. Just say it to be out of screen.
	float posY;
	float endPosX;		//when we call it, to where panel must to go?
	float endPosY;
	float hidePosX;		//base position to hide panel.

	// Use this for initialization
	void Start () {		

		//out of screen one hundred.
		//our texture are smaller than i wanted. So i have to enlarge it by 30% (*1.3)
		hidePosX = -(panelBackground.width * 1.3f)-100;

		posX = hidePosX;
		posY = ScreenAdapt.Instance.GetMidScreenVertical - (panelBackground.height * 1.3f /2);

		endPosX = ScreenAdapt.Instance.GetMidScreenHorizontal - (panelBackground.width * 1.3f /2);
		endPosY = ScreenAdapt.Instance.GetMidScreenVertical - (panelBackground.height * 1.3f /2);
	}
	
	void OnGUI()
	{
		GUI.depth = -2;
		GUI.skin = guiskin;
	
		//this is an important step.
		//AWAYS at begining of our OnGui method we call for ScreenAdapt to scale our gui to de screen resolution.
		
		//BeginScale with background is a way to easy to draw a background.
		ScreenAdapt.Instance.BeginScaleGUI();
		DrawButton();

		DrawBackground();
		DrawBtnListLevels();
		DrawBtnReplay();
		DrawBtnMute();

		//after we finish to draw our gui, just end our scale.
		ScreenAdapt.Instance.EndScaleGUI();
	}

	public void DrawBackground()
	{
		//Draw background
		GUI.DrawTexture(new Rect(posX,
		                         posY,
		                         panelBackground.width * 1.3f,
		                         panelBackground.height * 1.3f),
		                panelBackground);
	}
	
	void DrawButton()
	{		
		//Draw pauseButton
		if(GUI.Button(new Rect(ScreenAdapt.Instance.marginRight + 50 ,
		                       ScreenAdapt.Instance.marginTop,
		                       pauseButton.width/2,pauseButton.height/2),pauseButton,"trans_button"))
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


	/// <summary>
	/// Draws the button list levels.
	/// Draw a button and control its effect.
	/// </summary>
	public void DrawBtnListLevels()
	{
		//Draw list levels button
		if(GUI.Button(new Rect(posX + 80, posY + 200 , listLevelButton.width , listLevelButton.height),listLevelButton,"trans_button"))
		{
			isShow = false;
			Application.LoadLevel("SceneWorldSelect");
		}
	}

	/// <summary>
	/// Draws the button replay.
	/// Replay button just call our StartLevel in PlayManager. StartLevel knows what have to do.
	/// </summary>
	public void DrawBtnReplay()
	{
		//Draw replay button
		if(GUI.Button(new Rect(posX + 250, posY + 200 , replayButton.width , replayButton.height), replayButton,"trans_button"))
		{
			isShow = false;
			ScenePlayManager.Instance.StartLevel();
		}
	}


	public void DrawBtnMute()
	{
		//check actual state of our sound and show exactly texture.
		//sound is muted? so show button to unmute it.
		Texture soundButton = SoundManager.Instance.IsMuted ? soundOffButton : soundOnButton;

		if(GUI.Button(new Rect(posX + 420, posY + 200 , soundButton.width , soundButton.height), new GUIContent(soundButton),"trans_button"))
		{
			isShow = false;
			
			if(SoundManager.Instance.IsMuted)
				SoundManager.Instance.Continue();
			else
				SoundManager.Instance.Pause();
		}
	}








	// Update is called once per frame
	void Update () 
	{
		if(isShow)
		{
			ShowPanel();
		}
		if(!isShow)
		{
			HidePanel();
		}
	}

	void ShowPanel()
	{
		posX += 60f;
		if(posX > endPosX)
		{
			posX = endPosX;
		}
	}

	void HidePanel()
	{
		posX -= 60f;
		if(posX < hidePosX)
		{
			posX = hidePosX;
			isShow = false;
		}
	}



}
