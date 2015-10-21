using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Level manager.
/// This class manages all about levels. 
/// </summary>
public class LevelManager : MonoBehaviour 
{

	public int maxWorldUnlocked =0; 			//indicate what is top world unblocked
	//public Texture[] textureWorldBackground;	//an background for each world. If you want 3 worlds, put 3 backgrounds.
	public Level[] levels;						//array contains all levels. We will generate automatically.

	//REMEMBER: if you put a lot of levels in one world
	//this all levels may not fit on the screen
	public int totalGameLevels = 9;				//how many levels our game will have
	public int levelsForEachWorld =3;			//each world will have 3 levels in this case.

	public int selectedLevel;					//indicates selected level. This info will be used in PlayingScene.
												//to gameManager know what level will charging

	//simplifies to know what is current level
	public Level ActualLevel
	{
		get { return levels[selectedLevel]; }
	}

	private bool isLevelsCreated; 		//used to not create all levels again

	/// <summary>
	/// Initializes a new instance of the <see cref="LevelManager"/> class.
	/// When instatiate, automaticaly create levels. This step happens before awake.
	/// </summary>
	public LevelManager()
	{
		CreateLevels();
	}

	void Awake()
	{
		//Check if exist another instance. If yes, take it.
		LevelManager[] fake = FindObjectsOfType<LevelManager>();
		
		if(fake != null && fake.Length > 1)
		{
			this.levels = fake[0].levels;
			//this.textureWorldBackground = fake[0].textureWorldBackground;
			this.maxWorldUnlocked = fake[0].maxWorldUnlocked;
			this.selectedLevel = fake[0].selectedLevel;

			//DestroyImmediate(fake);
		}

		//Only one instance of this can exist. Get all infos and destroy it Mwahaha!
		GameObject[] sessions = GameObject.FindGameObjectsWithTag("SessionLevels");

		for(int i =0; i< sessions.Length; i++)
		{
			if(sessions[i] != this.gameObject)
			{
				DestroyImmediate(sessions[i]);
			}
		}

		DontDestroyOnLoad(this);
	}
	




	/// <summary>
	/// Unlocks the next level.
	/// </summary>
	public void UnlockNextLevel()
	{
		//check if this current level is not the last one.
		if(selectedLevel+1 < levels.Length){
			levels[selectedLevel+1].isBlocked = false;
		}

		UpdateMaxLevels();
	}

	
	public void UpdateMaxLevels()
	{
		int unlockedWorld =0; //temp var

		//seeks at all levels which is the world's largest unlocked
		for(int i =0; i< levels.Length; i++)
		{
			if(levels[i].isBlocked == false && levels[i].WorldNum > unlockedWorld)
			{
				unlockedWorld = levels[i].WorldNum;
			}
		}

		//now we know what is bigger world unlocked.
		maxWorldUnlocked = unlockedWorld;
	}


	/// <summary>
	/// Creates the levels automaticaly. Great!
	/// This procedure can create infinite levels.
	/// You may change the mathematical formula and thus changing the curve course of the game.
	/// </summary>
	private void CreateLevels()
	{
		//We dont want to recreate all levels. So check it.
		if(isLevelsCreated == false)
		{
			int worldNum =0;
			int lvCount =0;
			List<Level> lst = new List<Level>();

			for(int i =0; i < totalGameLevels; i++) // 9 total game levels
			{
				if(i >1 && i % levelsForEachWorld == 0) // 3 levels for each world 
				{
					worldNum++;
					lvCount = 0;
				}

				Level lvl = new Level();
				lvl.WorldNum = worldNum;
				lvl.NumLevel = lvCount;
				lvl.isWin = false;

				//this is an ternary expression. We check an boolean and return his result.
				//Eg.  (boolean expression) ? case true return this value  :  case false return this value.
				//Here we always unlock first level of first world.
				lvl.isBlocked = (lvCount == 0 && worldNum == 0 ? false : true);

				//use an mathematical formula for custom results.
				lvl.qtdFood = 5;
				lvl.foodToPass =2; //automaticaly reach quantity to pass grants 1 star.
				lvl.foods2Star =3;
				lvl.foods3Star =4;

				lvCount++;
				lst.Add(lvl);
			}

			//we use array and not generic List because arrays are faster than lists to process.
			levels = lst.ToArray();
			isLevelsCreated = true;
		}
	}


}