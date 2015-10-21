using UnityEngine;
using System.Collections;


/// <summary>
/// Input manager.
/// This class center input manager. So all changes will reflect all use.
/// </summary>
public class InputManager : MonoBehaviour
{
	//exist another ways to do this control.
	//some peoples like to use delegates and events.
	//i opt to do this way because its more simple to you understand.
	// be free to adapt your way.

	//if you will build to mobile, check this option.
	//why not create only one control to desktop and mobile?
	//because its more simply to control each one in separate.
	public bool useTouches = true;

	//tell to all if an input is pressed. They can not change this property.
	private bool _IsLeftPressed = false;
	private bool _IsRightPressed = false;

	public bool IsLeftPressed
	{
		get { return _IsLeftPressed; }
	}
	public bool IsRightPressed
	{
		get { return _IsRightPressed; }
	}


	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{	
		//lets go catch the inputs.

		//if you are using touches remember to check this option.
		//this option only apears in GameManager at PlayingScene.
		if(useTouches){
		
			//Checks if has some touch input. Case yes, get first.
			if(Input.touchCount > 0){
				Touch touch = Input.GetTouch(0);
			}
			GetTouches();
		}
		else
			GetKeyboard(); //if you are using keyboard. So get it.


		//This block is very very important.
		//PC and Android KeyCode.Escape are same.
		//We can control it in every screen that maintain this class instance'.
		//When escape is pressed we can go back to another screen. Include exit game.
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			//get current screen name to know what to do after.
			string sceneName = Application.loadedLevelName;

			switch(sceneName)
			{
				case "SceneMain":
				{
					Application.Quit(); 
				}
				break;
				case "SceneWorldSelect":
				{
					Application.LoadLevel("SceneMain");
				}
				break;
				case "ScenePlaying":
				{
					Application.LoadLevel("SceneWorldSelect");
				}
				break;
				default:
				{
					Application.Quit();
				}
				break;
			}
		}
			
	}

	void GetKeyboard()
	{
		if (Input.GetKey (KeyCode.LeftArrow) || 
		    Input.GetKey (KeyCode.A))
		{
			_IsLeftPressed = true;
			_IsRightPressed = false;
		} 
		else if(Input.GetKey (KeyCode.RightArrow) || 
		        Input.GetKey (KeyCode.D))
		{
			_IsLeftPressed = false;
			_IsRightPressed = true;
		}
		//if you want to clean up all inputs when they become meaningless, do it.
		//this game needs input stay pressed. You can change it.
//		else 
//		{
//			_IsLeftPressed = false;
//			_IsRightPressed = false;
//		}
	}

	/// <summary>
	/// Gets the touches.
	/// </summary>
	void GetTouches()
	{
		//Loop through the touches
		foreach (Touch touch in Input.touches) 
		{
			//If a touch has happening
			if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Canceled)
			{

				//Here what is important to us is to know where half-screen touch has happened.
				//left half will press left, and right same way.
				if(touch.position.x < Screen.width/2)
				{
					_IsLeftPressed = true;
					_IsRightPressed = false;
				}
				else if (touch.position.x > Screen.width/2)
				{
					_IsLeftPressed = false;
					_IsRightPressed = true;
				}
			}

			//if you want to clean up all inputs when they become meaningless, do it.
			//this game needs input stays pressed. You can change it.
			//If a touch has ended
//			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
//			{
//				_IsLeftPressed = false;
//				_IsRightPressed = false;
//			}
		}

	}


	public void ClearInput()
	{
		_IsLeftPressed = false;
		_IsRightPressed = false;
	}

}


