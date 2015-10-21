using UnityEngine;
using System.Collections;


/// <summary>
/// Screen adapt.
/// NEVER AGAIN you will worry about screen sizes using this class.
/// </summary>
public class ScreenAdapt
{
	private static ScreenAdapt _instance;
	public static ScreenAdapt Instance
	{
		get{
			if(_instance == null)
			{
				_instance = new ScreenAdapt();
			}
			return _instance;
		}
	}

	private static bool isScaled;
	private static float originalWidth = 1280.0f;  					// define here the original resolution
	private static float originalHeight = 800f;	//768.0f; WP8 		// you used to create the GUI contents 
	private Vector3 scale;
	Matrix4x4 normalMat = GUI.matrix; //our screen is an presentation matrix. Then calculate it.

	//Here i put some variable to use in a lot of places during my code.
	//You can create and calculate yours.

	private static float btnRoundWidth = 150f;//80f;	//my round button texture width
	private static float btnRoundHeight = 200f; //107;	//my round button texture height
	private static float midHeight = originalHeight/2;	//where is midScreen height.

	//used for buttons everywere.

	public float marginRight = originalWidth - btnRoundWidth - 30f;
	public float marginLeft = 50f;
	public float marginTop = 5f;
	public float marginBottom = originalHeight - btnRoundHeight - 30f;

	//used in world selection screen.

	public float worldFrameRight = (originalWidth / 10) * 2;
	public float worldFrameTop = (originalHeight / 10) *2;
	public float worldFrameWidth = 800f;
	public float worldFrameHeight = 558f;
	


	public float GetMidScreenHorizontal
	{
		get {
			return originalWidth/2;
		}
	}

	public float GetMidScreenVertical
	{
		get {
			return originalHeight/2;
		}
	}


	public Rect GetRoundBtnMidLeft
	{
		get { 
			return new Rect(marginLeft, 
			                midHeight - (btnRoundHeight/2),
			                btnRoundWidth,
			                btnRoundHeight);
        }
	}

	public Rect GetRoundBtnMidRight
	{
		get { 
			return new Rect(marginRight, 
			                midHeight - (btnRoundHeight/2),
			                btnRoundWidth,
			                btnRoundHeight);
		}
	}

	public Rect GetRoundBtnBottomRight
	{
		get { 
			return new Rect(marginLeft, 
			                originalHeight - (btnRoundHeight/2) - 30,
			                btnRoundWidth/1.6f,
			                btnRoundHeight/1.6f);
		}
	}

	
	/// <summary>
	/// Begins the scale GUI.
	/// YES: You need to use these methods in each OnGUI event
	/// because life-cycle of scenes and components inside unity.
	/// </summary>
	/// <param name="background">Background.</param>
	public void BeginScaleGUI(Texture background)
	{
		//do not scale twice or more.
		if(!isScaled)
		{
			//Just to help to draw an background in right size.
			DrawBG(background);

			scale.x = Screen.width/originalWidth; // calculate horizontal scale
			scale.y = Screen.height/originalHeight; // calculate vertical scale
			scale.z = 1;
			
			normalMat = GUI.matrix; // store current matrix
			
			// substitute matrix - only scale is altered from standard
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		}
	}

	/// <summary>
	/// Begins the scale GUI.
	/// Dont want to draw any background? Use this method to scale.
	/// YES: You need to use these methods in each OnGUI event
	/// because life-cycle of scenes and components inside unity.
	/// </summary>
	public void BeginScaleGUI()
	{
		if(!isScaled)
		{
			scale.x = Screen.width/originalWidth; // calculate horizontal scale
			scale.y = Screen.height/originalHeight; // calculate vertical scale
			scale.z = 1;
			
			normalMat = GUI.matrix; // store current matrix
			
			// substitute matrix - only scale is altered from standard
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		}
	}

	/// <summary>
	/// Ends the scale GUI.
	/// Restore main resolution by ending scale.
	/// YES: You need to use these methods in each OnGUI event
	/// because life-cycle of scenes and components inside unity.
	/// </summary>
	public void EndScaleGUI()
	{
		if(isScaled == true)
		{
			// restore matrix before returning
			GUI.matrix = normalMat; // restore matrix
			isScaled = false;
		}
	}

	public int ResizeHorizontal(int value)
	{
		float newValue = (value / originalWidth) * Screen.width ;
		
		return (int)newValue;
	}

	public int ResizeVertical(int value)
	{
		float newValue = (value / originalHeight) * Screen.height ;
		
		return (int)newValue;
	}
	
	private void DrawBG(Texture background)
	{
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), background);
	}

}
