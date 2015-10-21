using UnityEngine;
using System.Collections;

/// <summary>
/// HUD manager. Name says what it does.
/// This class is an singleton.
/// </summary>
public class HUDManager : MonoBehaviour {


	private static HUDManager _instance;

	/// <summary>
	///  Gets class instance as singleton.
	/// </summary>
	/// <value>The instance.</value>
	public static HUDManager Instance
	{
		get 
		{ 
			if(_instance == null)
			{
				_instance = FindObjectOfType<HUDManager>();
			}
			return _instance;
		}
	}

	public GUISkin guiSkin;				//use same skin as before. 
	private GetCounter coinCounter;		//will help us to control this numbers and what and how to show on screen.
	private GetCounter foodCounter;
	private GetCounter packCounter;
	private string levelCounter;
	


	/* 				BRIEF EXPLANATION
	 * =======================================================
		You can find Sprite placed directly on the screen. 
		Just dragging from inside the folder to the screen. 
		The GameObjects that are this way are within the gameObject 
		called UI that is on the scene ScenePlaying. 
		Here we show in this class using the GUI controls of Unity in OnGui method. 

		That way you can see how to use each form. And also the two working together.

		The Foodpack and Topbar are Sprites that were dragged to the screen. 
		The icons of the coin and the insect are painted in the texture of the object topbar. 
		This difference is to show how to use Sprites and align them in the order they should appear. 
		Ideally, the three icons should be in a single image, since there is not much interaction with them.

	   ========================================================
	*/



	void Awake()
	{
		//lets try get some fake instances.
		//unity always instantiate scene reload. But its not the case. Just check.
		HUDManager[] fake = FindObjectsOfType<HUDManager>();

		//this condition never must be true ;)
		if(fake != null && fake.Length > 1)
		{
			throw new UnityException("Scene has two or more instances of HUDManager");
		}

		LevelManager lvMan = FindObjectOfType<LevelManager>();
		if(lvMan == null)
		{
			throw new UnityException("Scene has no instance of LevelManager. Try start game by 'SceneWorldSelect'.");
		}

	}

	// Use this for initialization
	void Start () {

		//Start level tocgether startscene
		StartLevel();
	}


	void OnGUI()
	{
		//controls of gui and guiSkin only can be used at this method.
		GUI.skin = guiSkin;

		//this is an important step.
		//AWAYS at begining of our OnGui method we call for ScreenAdapt to scale our gui to de screen resolution.
		
		//BeginScale with background is a way to easy to draw a background.
		ScreenAdapt.Instance.BeginScaleGUI();

		//shows level - world || +1's are to fix array started at zero.
		GUI.Label(new Rect(ScreenAdapt.Instance.marginRight - 200, ScreenAdapt.Instance.marginTop + 10, 300, 50), 
		         "Level: " +  levelCounter);

		//shows coins quantity
		GUI.Label(new Rect(ScreenAdapt.Instance.marginLeft + 20, ScreenAdapt.Instance.marginTop + 10, 100, 50), 
		          GetAcquiredCoins.ToString());

		//shows eaten food / how many to pass
		GUI.Label(new Rect(ScreenAdapt.Instance.marginLeft + 240, ScreenAdapt.Instance.marginTop + 10, 100, 50), 
		          GetEatenFood.ToString() + "/" + GetTotalFood.ToString());

		//shows reaminder food in pack to be dropped
		GUI.Label(new Rect(ScreenAdapt.Instance.marginLeft + 480, ScreenAdapt.Instance.marginTop + 10, 100, 50), 
		          GetPackFoodQuantity.ToString());

		//after we finish to draw our gui, just end our scale.
		ScreenAdapt.Instance.EndScaleGUI();
	}



	/// <summary>
	/// Starts the level.
	/// This method help to start a level aways i want to.
	/// I havent to worry about reload this scene, just restart level changin some params.
	/// </summary>
	public void StartLevel()
	{
		foodCounter = new GetCounter();
		packCounter = new GetCounter();
		coinCounter = new GetCounter();

		LevelManager lvMan = FindObjectOfType<LevelManager>();

		//configure actual level to know what i have to do to pass.
		foodCounter.maxValue = lvMan.ActualLevel.foodToPass;
		foodCounter.Value = 0;
		packCounter.Value = lvMan.ActualLevel.qtdFood;

		//levelCounter is an string that i will show at screen.
		//+1 is to adjust index position, started at zero.
		levelCounter =   (lvMan.ActualLevel.WorldNum+1) + "-" +  (lvMan.ActualLevel.NumLevel+1);
	}


	/// <summary>
	/// Enables the pause.
	/// Not aways we can tap pause-game. So tell the pause control to do it olny in correct time.
	/// </summary>
	/// <param name="enables">If set to <c>true</c> enables.</param>
	public void EnablePause(bool enables)
	{
		FindObjectOfType<PauseManager>().enabled = enables;
	}

	//********** These methods and properties below help to short use of it in code at all.			 

	public void ReduceFood()
	{
		packCounter.Remove(1);
	}

	public void EatFood()
	{
		foodCounter.Add(1);
	}

	public void EatCoin ()
	{
		coinCounter.Add(1);
	}


	public int GetTotalFood
	{
		get { return foodCounter.maxValue; }
	}

	public int GetEatenFood
	{
		get {return foodCounter.Value;}
	}

	public int GetRemainderFood
	{
		get { return foodCounter.maxValue - foodCounter.Value; }
	}

	public int GetPackFoodQuantity
	{
		get { return packCounter.Value; }
	}

	public int GetAcquiredCoins
	{
		get { return coinCounter.Value;}
	}

	public int GetTotalCoins
	{
		get { return coinCounter.maxValue; }
	}

	public int GetNewTotalCoins
	{
		get { return coinCounter.maxValue + coinCounter.Value; }
	}


}
