using UnityEngine;
using System.Collections;

public class ScenePlayManager : MonoBehaviour {

	private static ScenePlayManager _instance;

	public static ScenePlayManager Instance
	{
		get 
		{ 
			if(_instance == null)
			{
				_instance = FindObjectOfType<ScenePlayManager>();
			}
			return _instance;
		}
	}

	public bool endLevel = false;			//indicates if actual level has been ended.
	public bool showingEndPanel = false;	//indicates if end level panel is showed

	public Sprite[] backgroundSprites;		//must have same size of world. Select background sprites to use here.

	public GameObject player;		//our player, of course.
	public GameObject npc;			//our NPC, of course.
	
	private LevelManager lvlManeger; //this component is attached to Session object, it will be recovered.



	void Awake()
	{
		ScenePlayManager[] fake = FindObjectsOfType<ScenePlayManager>();

		if(fake != null && fake.Length > 1)
		{
			throw new UnityException("Scene has two or more instances of ScenePlayManager");
		}

		lvlManeger = FindObjectOfType<LevelManager>();

		if(lvlManeger == null)
		{
			throw new UnityException("Scene has no instance of LevelManager. Try start game by 'SceneWorldSelect'.");
		}

		if(backgroundSprites == null || backgroundSprites.Length < 1)
		{
			throw new UnityException("This world has none background sprite at ScenePlayManager.backgroundSprites check GameManager object and assign it.");
		}

		SoundManager.Instance.PlaySoundFx(EnumSounds.MusicLevel);
	}


	// Use this for initialization
	void Start () 
	{
		StartLevel();
	}
	
	// Update is called once per frame
	void Update () {

		//check if level has ended;
		if(endLevel == false && HUDManager.Instance.GetPackFoodQuantity == 0) //npc.GetComponent<NpcController>().foodQuantity == 0)
		{
			//Whenever we use the information that is in the hud because they are 
			//reliable and saves us from creating and maintaining another variable.

			//if win
			//Win condition: player has eaten the same or more food than necessary at the end.
			if(HUDManager.Instance.GetEatenFood >= lvlManeger.ActualLevel.foodToPass)
			{
				lvlManeger.ActualLevel.isWin = true; //we tell to level manager that actual level has been won.

				//tell to our player that he must change your anim.
				player.GetComponent<PlayerController>().ToWinPosition();

				//tell to levelManager how many stars were acquired.
				lvlManeger.ActualLevel.starsAcquired = 1;
				if(HUDManager.Instance.GetEatenFood >= lvlManeger.ActualLevel.foods3Star)	{ lvlManeger.ActualLevel.starsAcquired =3;	}
				else if (HUDManager.Instance.GetEatenFood >= lvlManeger.ActualLevel.foods2Star) { lvlManeger.ActualLevel.starsAcquired = 2; }

				//Once we pass level, unlock next level.
				UnlockNextLevel();
			}
			//else lose
			else
			{
				//Do nothing. Just inform to player go to lose anim.
				player.GetComponent<PlayerController>().ToLosePosition();
			}

			//At both cases, stop update all characters.
			player.GetComponent<PlayerController>().StopEndLevel(); //playable = false;
			npc.GetComponent<NpcController>().StopEndLevel(); //playable = false;

			PlayEndLevelMusic();
			endLevel = true;
		}

	}

	void OnGUI()
	{
		if(endLevel)
		{
			Rect rect = new Rect();
			rect.width = 100;
			rect.height = 40;
			rect.x = Screen.width - rect.width;
			rect.y = Screen.height - rect.height;

			if(!showingEndPanel) 
			{
				FindObjectOfType<PauseManager>().enabled = false;

				//Show result panel with win options.
				if(lvlManeger.ActualLevel.isWin)
				{
					ResultManager.Instance.ShowResultBox(true, lvlManeger.ActualLevel.starsAcquired,
					                                     new CallbackFunction[]{DoChooseLevels,DoReplay,DoNextLevel});
				}
				//Show result panel with lose options.
				else
				{
					ResultManager.Instance.ShowResultBox(false,0,new CallbackFunction[]{DoChooseLevels,DoReplay});
				}

				//do not call this show panels again.
				showingEndPanel = true;
			}

			rect.x -= rect.width;

			rect.width = 200;
			rect.x -= Screen.width/2-rect.width/2;
			rect.y =0;		

		}

	}

	/// <summary>
	/// Starts the level.
	/// </summary>
	public void StartLevel()
	{
		SoundManager.Instance.PlaySoundFx(EnumSounds.MusicLevel);

		showingEndPanel = false; 	// hide result panel.
		endLevel = false;		 	//reset level status on this panel.
		HUDManager.Instance.EnablePause(true);	//enable pause options.
		HUDManager.Instance.StartLevel();		//clean our hud.

		//set characteres playable again
		player.GetComponent<PlayerController>().playable = true; 
		npc.GetComponent<NpcController>().playable = true;

		//Change background texture each level charged.
		//Its very important the sprites loaded in backgroundSprites use same order as worlds.
		SpriteRenderer r = (SpriteRenderer)GameObject.Find("Background").GetComponent<SpriteRenderer>();
		r.sprite = backgroundSprites[lvlManeger.ActualLevel.WorldNum];

	}

	/// <summary>
	/// Stops the game.
	/// But i dont use this. You can erase it.
	/// </summary>
	public void StopGame()
	{
		Time.timeScale = 0;
	}

	/// <summary>
	/// Plays the end level music loop.
	/// </summary>
	public void PlayEndLevelMusic()
	{
		if(lvlManeger.ActualLevel.isWin) 
		{
			SoundManager.Instance.PlaySoundFx(EnumSounds.MusicWin);
		}
		else
		{
			SoundManager.Instance.PlaySoundFx(EnumSounds.MusicLose);
		}
	}

	/// <summary>
	/// Unlocks the next level.
	/// </summary>
	public void UnlockNextLevel()
	{
		lvlManeger.UnlockNextLevel();
	}


	#region Buttons End Level Panel

	void DoChooseLevels()
	{
		//Goes to select world-levels scene.
		Application.LoadLevel("SceneWorldSelect");
	}
	void DoReplay()
	{
		StartLevel(); //Restart current level.
	}
	void DoNextLevel()
	{
		lvlManeger.selectedLevel++; //advance current level to next.

		//check if level is last one. Caso not, starts new level.
		if(lvlManeger.selectedLevel < lvlManeger.levels.Length)
		{
			StartLevel();
		}
		else
		{
			//case finished all levels.
			//TODO: Load Win Screen
		}
	}

	#endregion



}
