using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Profile;
using Soomla.Store;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class makeclick : MonoBehaviour {

	int best_int_score_in_this_stage_0_00;
	int best_int_score_in_this_stage_0_01;
	int best_int_score_in_this_stage_0_02;
	int best_int_score_in_this_stage_0_03;
	int best_int_score_in_this_stage_0_04;
	int best_int_score_in_this_stage_0_05;
	int best_int_score_in_this_stage_0_06;
	int best_int_score_in_this_stage_0_07;
	int best_int_score_in_this_stage_0_08;
	int best_int_score_in_this_stage_0_09;
	int best_int_score_in_this_stage_0_010;
	int best_int_score_in_this_stage_0_011;
	int best_int_score_in_this_stage_0_012;
	int best_int_score_in_this_stage_0_013;
	int best_int_score_in_this_stage_0_014;
	int best_int_score_in_this_stage_0_10;
	int best_int_score_in_this_stage_0_11;
	int best_int_score_in_this_stage_0_12;
	int best_int_score_in_this_stage_0_13;
	int best_int_score_in_this_stage_0_14;
	int best_int_score_in_this_stage_0_15;
	int best_int_score_in_this_stage_0_16;
	int best_int_score_in_this_stage_0_17;
	int best_int_score_in_this_stage_0_18;
	int best_int_score_in_this_stage_0_19;
	int best_int_score_in_this_stage_0_110;
	int best_int_score_in_this_stage_0_111;
	int best_int_score_in_this_stage_0_112;
	int best_int_score_in_this_stage_0_113;
	int best_int_score_in_this_stage_0_114;
	int best_int_score_in_this_stage_0_20;
	int best_int_score_in_this_stage_0_21;
	int best_int_score_in_this_stage_0_22;
	int best_int_score_in_this_stage_0_23;
	int best_int_score_in_this_stage_0_24;
	int best_int_score_in_this_stage_0_25;
	int best_int_score_in_this_stage_0_26;
	int best_int_score_in_this_stage_0_27;
	int best_int_score_in_this_stage_0_28;
	int best_int_score_in_this_stage_0_29;
	int best_int_score_in_this_stage_0_210;
	int best_int_score_in_this_stage_0_211;
	int best_int_score_in_this_stage_0_212;
	int best_int_score_in_this_stage_0_213;
	int best_int_score_in_this_stage_0_214;

	//Facebook
	private static bool IsUserInfoLoaded = false;
	private static bool IsFrindsInfoLoaded = false;
	private static bool IsAuntificated = false;

	private string rateText = "If you enjoy playing Zombie Cross, please take a moment to rate it. Thanks for your support!";
	//example link to your app on android market
	private string rateUrl = "https://play.google.com/store/apps/details?id=unity.zombiecross";

	private string title="Zombie Cross";
	private string message="Like this game? Please Rate us";
	private string yes ="YES";
	private string later="LATER";
	private string no="NO";
	private string url="https://play.google.com/store/apps/details?id=unity.zombiecross";
	//public event Action<AndroidDialogResult> ActionComplete = delegate{};

	//private string LEADERBOARD_ID;
	private const string LEADERBOARD_ID = "CgkIipfs2qcGEAIQAA";

	private const string ACHIEVEMENT_ID_First_Freeze = "CgkIq6GznYALEAIQDg";
	private const string ACHIEVEMENT_ID_First_Buy = "CgkIq6GznYALEAIQDQ";
	private const string ACHIEVEMENT_ID_First_Burn = "CgkIq6GznYALEAIQDA";
	private const string ACHIEVEMENT_ID_Veteran = "CgkIq6GznYALEAIQCw";
	private const string ACHIEVEMENT_ID_Assassin = "CgkIq6GznYALEAIQCg";
	private const string ACHIEVEMENT_ID_Sergeant = "CgkIq6GznYALEAIQCQ";
	private const string ACHIEVEMENT_ID_First_Drown = "CgkIq6GznYALEAIQCA";
	private const string ACHIEVEMENT_ID_First_Death = "CgkIq6GznYALEAIQBw";
	private const string ACHIEVEMENT_ID_First_Explotion = "CgkIq6GznYALEAIQBg";
	private const string ACHIEVEMENT_ID_First_FrontFlip = "CgkIq6GznYALEAIQBA";
	private const string ACHIEVEMENT_ID_First_BackFlip = "CgkIq6GznYALEAIQAg";

	private const string INCREMENTAL_ACHIEVEMENT_ID_Two_FrontFlip = "CgkIq6GznYALEAIQBQ";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Two_BackFlip = "CgkIq6GznYALEAIQAw";

	private const string MY_BANNERS_AD_UNIT_ID		 = "ca-app-pub-7288875708989992/5953651462"; 
	private const string MY_INTERSTISIALS_AD_UNIT_ID =  "ca-app-pub-7288875708989992/3000185061"; 

	public bool callfunction=false;
	public string functioncalled="";
	public string Scene;
	//public bool isClick=false;
	private GoogleMobileAdBanner banner2;

	game_master my_game_master;
	manage_linear_map my_manage_linear_map;

	public enum this_world_is_unlocked_after
	{
		start,
		previous_world_is_finished,
		reach_this_star_score,
		bui_it
		
	}
	int starts;
	int money;
	//int money = my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(0);
	int lives;
	int stages;
	int best_score;
	int stage_progress;
	int world_progress;

	manage_menu_uGUI my_manage_menu_uGUI;
	public store_item_manager my_store_item_manager;
	public int[][] incremental_item_current_level;//[profile][item_array_slot]
	public int[][] consumable_item_current_quantity;//[profile][item_array_slot]
	public this_world_is_unlocked_after[] this_world_is_unlocked_after_selected;
	
	public int[] total_stages_in_world_n;
	
	
	public bool[][] world_playable;//[profile][world]
	public bool[][] world_purchased;//[profile][world]
	public bool[][,] stage_playable; //[profile][world,stage]
	public bool[][,] stage_solved; //[profile][world,stage]
	
	//star score
	public int[][,] stage_stars_score; //[profile][world,stage]
	public int[][] star_score_in_this_world;//[profile][world]
	public int[] stars_total_score;//[profile] this can be helpful if you want to unlock worlds when player get enough stars 
	//int score
	public int[][,] best_int_score_in_this_stage; //[profile][world,stage]
	public int[] best_int_score_for_current_player; //[profile]
	public int best_int_score_on_this_device;//the best score among all profiles
	public static bool[] all_stages_solved;//[profile]
	
	public bool[][,] dot_tail_turn_on;//[profile][w,s];
	
	public my_Soomla_billing my_Soomla_billing_script;

	//google plus

	private List<AN_PlusButton> Abuttons =  new List<AN_PlusButton>();
	
	private AN_PlusButton PlusButton = null;
	//private string PlusUrl = "https://profile.google.com/u/0/104631396711140710378";
	//private string PlusUrl = "https://unionassets.com/";
	private string PlusUrl = "https://play.google.com/store/apps/details?id=unity.zombiecross";

	
	public void CreatePlusButtons() {
		
		if(Abuttons.Count != 0) {
			return;
		} 
		
		AN_PlusButton b =  new AN_PlusButton(PlusUrl, AN_PlusBtnSize.SIZE_TALL, AN_PlusBtnAnnotation.ANNOTATION_BUBBLE);
		b.SetGravity(TextAnchor.UpperLeft);
		
		Abuttons.Add(b);
		
		
		b =  new AN_PlusButton(PlusUrl, AN_PlusBtnSize.SIZE_SMALL, AN_PlusBtnAnnotation.ANNOTATION_INLINE);
		b.SetGravity(TextAnchor.UpperRight);
		Abuttons.Add(b);
		
		b =  new AN_PlusButton(PlusUrl, AN_PlusBtnSize.SIZE_MEDIUM, AN_PlusBtnAnnotation.ANNOTATION_INLINE);
		b.SetGravity(TextAnchor.UpperCenter);
		Abuttons.Add(b);
		
		b =  new AN_PlusButton(PlusUrl, AN_PlusBtnSize.SIZE_STANDARD, AN_PlusBtnAnnotation.ANNOTATION_INLINE);
		b.SetGravity(TextAnchor.MiddleLeft);
		
		Abuttons.Add(b);
		
		foreach(AN_PlusButton bb in Abuttons) {
			bb.ButtonClicked += ButtonClicked;
		}
		
	}


	
	
	public void HideButtons() {
		foreach(AN_PlusButton b in Abuttons) {
			b.Hide();
		}
	}
	
	public void ShoweButtons() {
		foreach(AN_PlusButton b in Abuttons) {
			b.Show();
		}
	}


	public void CreateRandomPostButton() {
		if(PlusButton == null) {
			PlusButton =  new AN_PlusButton(PlusUrl, AN_PlusBtnSize.SIZE_STANDARD, AN_PlusBtnAnnotation.ANNOTATION_BUBBLE);
			PlusButton.SetPosition(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
			PlusButton.ButtonClicked += ButtonClicked;
		}
		
	}
	
	
	public void ChangePosPostButton()  {
		if(PlusButton != null) {
			PlusButton.SetPosition(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
		}
		
	}
	
	void ButtonClicked () {
		AndroidMessage.Create("Click Detected", "Plus Button Click Detected");
	}
	
	void OnDestroy() {
		HideButtons();
		if(PlusButton != null) {
			PlusButton.Hide();
		}
	}

	public void CreateNewSnapshot() {
		StartCoroutine(MakeScreenshotAndSaveGameData());
	}
	
	public void ShowSavedGamesUI() {
		int maxNumberOfSavedGamesToShow = 1;
		GooglePlaySavedGamesManager.Instance.ShowSavedGamesUI("See My Saves", maxNumberOfSavedGamesToShow);
	}
	
	
	public void LoadSavedGames() {
		GooglePlaySavedGamesManager.ActionAvailableGameSavesLoaded += ActionAvailableGameSavesLoaded;
		GooglePlaySavedGamesManager.Instance.LoadAvailableSavedGames();
		
		//SA_StatusBar.text = "Loading saved games.. ";
	}
	
	private void ActionAvailableGameSavesLoaded (GooglePlayResult res) {
		
		GooglePlaySavedGamesManager.ActionAvailableGameSavesLoaded -= ActionAvailableGameSavesLoaded;
		if(res.IsSucceeded) {
			foreach(GP_SnapshotMeta meta in GooglePlaySavedGamesManager.Instance.AvailableGameSaves) {
				Debug.Log("Meta.Title: " 					+ meta.Title);
				Debug.Log("Meta.Description: " 				+ meta.Description);
				Debug.Log("Meta.CoverImageUrl): " 			+ meta.CoverImageUrl);
				Debug.Log("Meta.LastModifiedTimestamp: " 	+ meta.LastModifiedTimestamp);
				Debug.Log("Meta.TotalPlayedTime" 			+ meta.TotalPlayedTime);
			}
			
			if(GooglePlaySavedGamesManager.Instance.AvailableGameSaves.Count > 0) {
				GP_SnapshotMeta s =  GooglePlaySavedGamesManager.Instance.AvailableGameSaves[0];
				AndroidDialog dialog = AndroidDialog.Create("Load Snapshot?", "Would you like to load " + s.Title);
				dialog.ActionComplete += OnSpanshotLoadDialogComplete;
			}
			
		} else {
			AndroidMessage.Create("Fail", "Available Game Saves Load failed");
		}
	}
	
	public void OnSpanshotLoadDialogComplete (AndroidDialogResult res) {
		if(res == AndroidDialogResult.YES) {
			GP_SnapshotMeta s =  GooglePlaySavedGamesManager.Instance.AvailableGameSaves[0];
			GooglePlaySavedGamesManager.Instance.LoadSpanshotByName(s.Title);
		}
	}


	//--------------------------------------
	// EVENTS
	//--------------------------------------
	
	private void ActionNewGameSaveRequest () {
		//SA_StatusBar.text = "New  Game Save Requested, Creating new save..";
		//Debug.Log("New  Game Save Requested, Creating new save..");
		StartCoroutine(MakeScreenshotAndSaveGameData());

		//AndroidMessage.Create("Result", "New Game Save Request");
	}
	private IEnumerator MakeScreenshotAndSaveGameData() {
		
		save ();

		int world_playable_0_0 = System.Convert.ToInt32(world_playable[0][0]);
		int world_purchased_0_0 = System.Convert.ToInt32(world_purchased[0][0]);
		int star_score_in_this_world_0_0 = System.Convert.ToInt32(star_score_in_this_world[0][0]);
		int world_playable_0_1 = System.Convert.ToInt32(world_playable[0][1]);
		int world_purchased_0_1 = System.Convert.ToInt32(world_purchased[0][1]);
		int star_score_in_this_world_0_1 = System.Convert.ToInt32(star_score_in_this_world[0][1]);
		int world_playable_0_2=System.Convert.ToInt32(world_playable[0][2]);
		int world_purchased_0_2 = System.Convert.ToInt32(world_purchased[0][2]);
		int star_score_in_this_world_0_2=star_score_in_this_world[0][2];
		int stage_playable_0_00=System.Convert.ToInt32(stage_playable[0][0,0]);
		int stage_solved_0_00=System.Convert.ToInt32(stage_solved[0][0,0]);
		int dot_tail_turn_on_0_00=System.Convert.ToInt32(dot_tail_turn_on[0][0,0]);
		int stage_stars_score_0_00=stage_stars_score[0][0,0];
		best_int_score_in_this_stage_0_00=best_int_score_in_this_stage[0][0,0];
		int stage_playable_0_01 =System.Convert.ToInt32(stage_playable[0][0,1]);
		int stage_solved_0_01 = System.Convert.ToInt32 (stage_solved [0] [0, 1]);
		int dot_tail_turn_on_0_01 = System.Convert.ToInt32 (dot_tail_turn_on [0] [0, 1]);
		int stage_stars_score_0_01 = stage_stars_score [0] [0, 1];
		best_int_score_in_this_stage_0_01 = best_int_score_in_this_stage [0] [0, 1];
		int stage_playable_0_02 = System.Convert.ToInt32 (stage_playable [0] [0, 2]);
		int stage_solved_0_02 = System.Convert.ToInt32(stage_solved[0][0,2]);
		int dot_tail_turn_on_0_02=System.Convert.ToInt32(dot_tail_turn_on[0][0,2]);
		int stage_stars_score_0_02= stage_stars_score[0][0,2];
		best_int_score_in_this_stage_0_02=best_int_score_in_this_stage[0][0,2];
		int stage_playable_0_03 =System.Convert.ToInt32(stage_playable[0][0,3]);
		int stage_solved_0_03=System.Convert.ToInt32(stage_solved[0][0,3]);
		int dot_tail_turn_on_0_03=System.Convert.ToInt32(dot_tail_turn_on[0][0,3]);
		int stage_stars_score_0_03=stage_stars_score[0][0,3];
		best_int_score_in_this_stage_0_03=best_int_score_in_this_stage[0][0,3];
		int stage_playable_0_04=System.Convert.ToInt32(stage_playable[0][0,4]);
		int stage_solved__04 =System.Convert.ToInt32(stage_solved[0][0,4]);
		int dot_tail_turn_on_0_04=System.Convert.ToInt32(dot_tail_turn_on[0][0,4]);
		int stage_stars_score_0_04=stage_stars_score[0][0,4];
		best_int_score_in_this_stage_0_04=best_int_score_in_this_stage[0][0,4];
		int stage_playable_0_05=System.Convert.ToInt32(stage_playable[0][0,5]);
		int stage_solved_0_05=System.Convert.ToInt32(stage_solved[0][0,5]);
		int dot_tail_turn_on_0_05=System.Convert.ToInt32(dot_tail_turn_on[0][0,5]);
		int stage_stars_score_0_05=stage_stars_score[0][0,5];
		best_int_score_in_this_stage_0_05=best_int_score_in_this_stage[0][0,5];
		int stage_playable_0_06=System.Convert.ToInt32(stage_playable[0][0,6]);
		int stage_solved_0_06=System.Convert.ToInt32(stage_solved[0][0,6]);
		int dot_tail_turn_on_0_06=System.Convert.ToInt32(dot_tail_turn_on[0][0,6]);
		int stage_stars_score_0_06 = stage_stars_score[0][0,6];
		best_int_score_in_this_stage_0_06=best_int_score_in_this_stage[0][0,6];
		int stage_playable_0_07=System.Convert.ToInt32(stage_playable[0][0,7]);
		int stage_solved_0_07=System.Convert.ToInt32(stage_solved[0][0,7]);
		int dot_tail_turn_on_0_07=System.Convert.ToInt32(dot_tail_turn_on[0][0,7]);
		int stage_stars_score_0_07=stage_stars_score[0][0,7];
		best_int_score_in_this_stage_0_07=best_int_score_in_this_stage[0][0,7];
		int stage_playable_0_08=System.Convert.ToInt32(stage_playable[0][0,8]);
		int stage_solved_0_08=System.Convert.ToInt32(stage_solved[0][0,8]);
		int dot_tail_turn_on_0_08=System.Convert.ToInt32(dot_tail_turn_on[0][0,8]);
		int stage_stars_score_0_08=stage_stars_score[0][0,8];
		best_int_score_in_this_stage_0_08=best_int_score_in_this_stage[0][0,8];
		int stage_playable_0_09=System.Convert.ToInt32(stage_playable[0][0,9]);
		int stage_solved_0_09=System.Convert.ToInt32(stage_solved[0][0,9]);
		int dot_tail_turn_on_0_09=System.Convert.ToInt32(dot_tail_turn_on[0][0,9]);
		int stage_stars_score_0_09=stage_stars_score[0][0,9];
		best_int_score_in_this_stage_0_09=best_int_score_in_this_stage[0][0,9];
		int stage_playable_0_010=System.Convert.ToInt32(stage_playable[0][0,10]);
		int stage_solved_0_010=System.Convert.ToInt32(stage_solved[0][0,10]);
		int dot_tail_turn_on_0_010=System.Convert.ToInt32(dot_tail_turn_on[0][0,10]);
		int stage_stars_score_0_010=stage_stars_score[0][0,10];
		best_int_score_in_this_stage_0_010=best_int_score_in_this_stage[0][0,10];
		int stage_playable_0_011=System.Convert.ToInt32(stage_playable[0][0,11]);
		int stage_solved_0_011=System.Convert.ToInt32(stage_solved[0][0,11]);
		int dot_tail_turn_on_0_011=System.Convert.ToInt32(dot_tail_turn_on[0][0,11]);
		int stage_stars_score_0_011=stage_stars_score[0][0,11];
		best_int_score_in_this_stage_0_011=best_int_score_in_this_stage[0][0,11];
		int stage_playable_0_012=System.Convert.ToInt32(stage_playable[0][0,12]);
		int stage_solved_0_012=System.Convert.ToInt32(stage_solved[0][0,12]);
		int dot_tail_turn_on_0_012=System.Convert.ToInt32(dot_tail_turn_on[0][0,12]);
		int stage_stars_score_0_012=stage_stars_score[0][0,12];
		best_int_score_in_this_stage_0_012=best_int_score_in_this_stage[0][0,12];
		int stage_playable_0_013=System.Convert.ToInt32(stage_playable[0][0,13]);
		int stage_solved_0_013=System.Convert.ToInt32(stage_solved[0][0,13]);
		int dot_tail_turn_on_0_013=System.Convert.ToInt32(dot_tail_turn_on[0][0,13]);
		int stage_stars_score_0_013=stage_stars_score[0][0,13];
		best_int_score_in_this_stage_0_013=best_int_score_in_this_stage[0][0,13];
		int stage_playable_0_014=System.Convert.ToInt32(stage_playable[0][0,14]);
		int stage_solved_0_014=System.Convert.ToInt32(stage_solved[0][0,14]);
		int dot_tail_turn_on_0_014=System.Convert.ToInt32(dot_tail_turn_on[0][0,14]);
		int stage_stars_score_0_014=stage_stars_score[0][0,14];
		best_int_score_in_this_stage_0_014=best_int_score_in_this_stage[0][0,14];
		int stage_playable_0_10=System.Convert.ToInt32(stage_playable[0][1,0]);
		int stage_solved_0_10=System.Convert.ToInt32(stage_solved[0][1,0]);
		int dot_tail_turn_on_0_10=System.Convert.ToInt32(dot_tail_turn_on[0][1,0]);
		int stage_stars_score_0_10=stage_stars_score[0][1,0];
		best_int_score_in_this_stage_0_10=best_int_score_in_this_stage[0][1,0];
		int stage_playable_0_11=System.Convert.ToInt32(stage_playable[0][1,1]);
		int stage_solved_0_11=System.Convert.ToInt32(stage_solved[0][1,1]);
		int dot_tail_turn_on_0_11=System.Convert.ToInt32(dot_tail_turn_on[0][1,1]);
		int stage_stars_score_0_11=stage_stars_score[0][1,1];
		best_int_score_in_this_stage_0_11=best_int_score_in_this_stage[0][1,1];
		int stage_playable_0_12=System.Convert.ToInt32(stage_playable[0][1,2]);
		int stage_solved_0_12=System.Convert.ToInt32(stage_solved[0][1,2]);
		int dot_tail_turn_on_0_12=System.Convert.ToInt32(dot_tail_turn_on[0][1,2]);
		int stage_stars_score_0_12=stage_stars_score[0][1,2];
		best_int_score_in_this_stage_0_12=best_int_score_in_this_stage[0][1,2];
		int stage_playable_0_13=System.Convert.ToInt32(stage_playable[0][1,3]);
		int stage_solved_0_13=System.Convert.ToInt32(stage_solved[0][1,3]);
		int dot_tail_turn_on_0_13=System.Convert.ToInt32(dot_tail_turn_on[0][1,3]);
		int stage_stars_score_0_13=stage_stars_score[0][1,3];
		best_int_score_in_this_stage_0_13=best_int_score_in_this_stage[0][1,3];
		int stage_playable_0_14=System.Convert.ToInt32(stage_playable[0][1,4]);
		int stage_solved_0_14=System.Convert.ToInt32(stage_solved[0][1,4]);
		int dot_tail_turn_on_0_14=System.Convert.ToInt32(dot_tail_turn_on[0][1,4]);
		int stage_stars_score_0_14=stage_stars_score[0][1,4];
		best_int_score_in_this_stage_0_14=best_int_score_in_this_stage[0][1,4];
		int stage_playable_0_15=System.Convert.ToInt32(stage_playable[0][1,5]);
		int stage_solved_0_15=System.Convert.ToInt32(stage_solved[0][1,5]);
		int dot_tail_turn_on_0_15=System.Convert.ToInt32(dot_tail_turn_on[0][1,5]);
		int stage_stars_score_0_15=stage_stars_score[0][1,5];
		best_int_score_in_this_stage_0_15=best_int_score_in_this_stage[0][1,5];
		int stage_playable_0_16=System.Convert.ToInt32(stage_playable[0][1,6]);
		int stage_solved_0_16=System.Convert.ToInt32(stage_solved[0][1,6]);
		int dot_tail_turn_on_0_16=System.Convert.ToInt32(dot_tail_turn_on[0][1,6]);
		int stage_stars_score_0_16=stage_stars_score[0][1,6];
		best_int_score_in_this_stage_0_16=best_int_score_in_this_stage[0][1,6];
		int stage_playable_0_17=System.Convert.ToInt32(stage_playable[0][1,7]);
		int stage_solved_0_17=System.Convert.ToInt32(stage_solved[0][1,7]);
		int dot_tail_turn_on_0_17=System.Convert.ToInt32(dot_tail_turn_on[0][1,7]);
		int stage_stars_score_0_17=stage_stars_score[0][1,7];
		best_int_score_in_this_stage_0_17=best_int_score_in_this_stage[0][1,7];
		int stage_playable_0_18=System.Convert.ToInt32(stage_playable[0][1,8]);
		int stage_solved_0_18=System.Convert.ToInt32(stage_solved[0][1,8]);
		int dot_tail_turn_on_0_18=System.Convert.ToInt32(dot_tail_turn_on[0][1,8]);
		int stage_stars_score_0_18=stage_stars_score[0][1,8];
		best_int_score_in_this_stage_0_18=best_int_score_in_this_stage[0][1,8];
		int stage_playable_0_19=System.Convert.ToInt32(stage_playable[0][1,9]);
		int stage_solved_0_19=System.Convert.ToInt32(stage_solved[0][1,9]);
		int dot_tail_turn_on_0_19=System.Convert.ToInt32(dot_tail_turn_on[0][1,9]);
		int stage_stars_score_0_19=stage_stars_score[0][1,9];
		best_int_score_in_this_stage_0_19=best_int_score_in_this_stage[0][1,9];
		int stage_playable_0_110=System.Convert.ToInt32(stage_playable[0][1,10]);
		int stage_solved_0_110=System.Convert.ToInt32(stage_solved[0][1,10]);
		int dot_tail_turn_on_0_110=System.Convert.ToInt32(dot_tail_turn_on[0][1,10]);
		int stage_stars_score_0_110=stage_stars_score[0][1,10];
		best_int_score_in_this_stage_0_110=best_int_score_in_this_stage[0][1,10];
		int stage_playable_0_111=System.Convert.ToInt32(stage_playable[0][1,11]);
		int stage_solved_0_111=System.Convert.ToInt32(stage_solved[0][1,11]);
		int dot_tail_turn_on_0_111=System.Convert.ToInt32(dot_tail_turn_on[0][1,11]);
		int stage_stars_score_0_111=stage_stars_score[0][1,11];
		best_int_score_in_this_stage_0_111=best_int_score_in_this_stage[0][1,11];
		int stage_playable_0_112=System.Convert.ToInt32(stage_playable[0][1,12]);
		int stage_solved_0_112=System.Convert.ToInt32(stage_solved[0][1,12]);
		int dot_tail_turn_on_0_112=System.Convert.ToInt32(dot_tail_turn_on[0][1,12]);
		int stage_stars_score_0_112=stage_stars_score[0][1,12];
		best_int_score_in_this_stage_0_112=best_int_score_in_this_stage[0][1,12];
		int stage_playable_0_113=System.Convert.ToInt32(stage_playable[0][1,13]);
		int stage_solved_0_113=System.Convert.ToInt32(stage_solved[0][1,13]);
		int dot_tail_turn_on_0_113=System.Convert.ToInt32(dot_tail_turn_on[0][1,13]);
		int stage_stars_score_0_113=stage_stars_score[0][1,13];
		best_int_score_in_this_stage_0_113=best_int_score_in_this_stage[0][1,13];
		int stage_playable_0_114=System.Convert.ToInt32(stage_playable[0][1,14]);
		int stage_solved_0_114=System.Convert.ToInt32(stage_solved[0][1,14]);
		int dot_tail_turn_on_0_114=System.Convert.ToInt32(dot_tail_turn_on[0][1,14]);
		int stage_stars_score_0_114=stage_stars_score[0][1,14];
		best_int_score_in_this_stage_0_114=best_int_score_in_this_stage[0][1,14];
		int stage_playable_0_20=System.Convert.ToInt32(stage_playable[0][2,0]);
		int stage_solved_0_20=System.Convert.ToInt32(stage_solved[0][2,0]);
		int dot_tail_turn_on_0_20=System.Convert.ToInt32(dot_tail_turn_on[0][2,0]);
		int stage_stars_score_0_20=stage_stars_score[0][2,0];
		best_int_score_in_this_stage_0_20=best_int_score_in_this_stage[0][2,0];
		int stage_playable_0_21=System.Convert.ToInt32(stage_playable[0][2,1]);
		int stage_solved_0_21=System.Convert.ToInt32(stage_solved[0][2,1]);
		int dot_tail_turn_on_0_21=System.Convert.ToInt32(dot_tail_turn_on[0][2,1]);
		int stage_stars_score_0_21=stage_stars_score[0][2,1];
		best_int_score_in_this_stage_0_21=best_int_score_in_this_stage[0][2,1];
		int stage_playable_0_22=System.Convert.ToInt32(stage_playable[0][2,2]);
		int stage_solved_0_22=System.Convert.ToInt32(stage_solved[0][2,2]);
		int dot_tail_turn_on_0_22=System.Convert.ToInt32(dot_tail_turn_on[0][2,2]);
		int stage_stars_score_0_22=stage_stars_score[0][2,2];
		best_int_score_in_this_stage_0_22=best_int_score_in_this_stage[0][2,2];
		int stage_playable_0_23=System.Convert.ToInt32(stage_playable[0][2,3]);
		int stage_solved_0_23=System.Convert.ToInt32(stage_solved[0][2,3]);
		int dot_tail_turn_on_0_23=System.Convert.ToInt32(dot_tail_turn_on[0][2,3]);
		int stage_stars_score_0_23=stage_stars_score[0][2,3];
		best_int_score_in_this_stage_0_23=best_int_score_in_this_stage[0][2,3];
		int stage_playable_0_24=System.Convert.ToInt32(stage_playable[0][2,4]);
		int stage_solved_0_24=System.Convert.ToInt32(stage_solved[0][2,4]);
		int dot_tail_turn_on_0_24=System.Convert.ToInt32(dot_tail_turn_on[0][2,4]);
		int stage_stars_score_0_24=stage_stars_score[0][2,4];
		best_int_score_in_this_stage_0_24=best_int_score_in_this_stage[0][2,4];
		int stage_playable_0_25=System.Convert.ToInt32(stage_playable[0][2,5]);
		int stage_solved_0_25=System.Convert.ToInt32(stage_solved[0][2,5]);
		int dot_tail_turn_on_0_25=System.Convert.ToInt32(dot_tail_turn_on[0][2,5]);
		int stage_stars_score_0_25=stage_stars_score[0][2,5];
		best_int_score_in_this_stage_0_25=best_int_score_in_this_stage[0][2,5];
		int stage_playable_0_26=System.Convert.ToInt32(stage_playable[0][2,6]);
		int stage_solved_0_26=System.Convert.ToInt32(stage_solved[0][2,6]);
		int dot_tail_turn_on_0_26=System.Convert.ToInt32(dot_tail_turn_on[0][2,6]);
		int stage_stars_score_0_26=stage_stars_score[0][2,6];
		best_int_score_in_this_stage_0_26=best_int_score_in_this_stage[0][2,6];
		int stage_playable_0_27=System.Convert.ToInt32(stage_playable[0][2,7]);
		int stage_solved_0_27=System.Convert.ToInt32(stage_solved[0][2,7]);
		int dot_tail_turn_on_0_27=System.Convert.ToInt32(dot_tail_turn_on[0][2,7]);
		int stage_stars_score_0_27=stage_stars_score[0][2,7];
		best_int_score_in_this_stage_0_27=best_int_score_in_this_stage[0][2,7];
		int stage_playable_0_28=System.Convert.ToInt32(stage_playable[0][2,8]);
		int stage_solved_0_28=System.Convert.ToInt32(stage_solved[0][2,8]);
		int dot_tail_turn_on_0_28=System.Convert.ToInt32(dot_tail_turn_on[0][2,8]);
		int stage_stars_score_0_28=stage_stars_score[0][2,8];
		best_int_score_in_this_stage_0_28=best_int_score_in_this_stage[0][2,8];
		int stage_playable_0_29=System.Convert.ToInt32(stage_playable[0][2,9]);
		int stage_solved_0_29=System.Convert.ToInt32(stage_solved[0][2,9]);
		int dot_tail_turn_on_0_29=System.Convert.ToInt32(dot_tail_turn_on[0][2,9]);
		int stage_stars_score_0_29=stage_stars_score[0][2,9];
		best_int_score_in_this_stage_0_29=best_int_score_in_this_stage[0][2,9];
		int stage_playable_0_210=System.Convert.ToInt32(stage_playable[0][2,10]);
		int stage_solved_0_210=System.Convert.ToInt32(stage_solved[0][2,10]);
		int	dot_tail_turn_on_0_210=System.Convert.ToInt32(dot_tail_turn_on[0][2,10]);
		int stage_stars_score_0_210=stage_stars_score[0][2,10];
		best_int_score_in_this_stage_0_210=best_int_score_in_this_stage[0][2,10];
		int stage_playable_0_211=System.Convert.ToInt32(stage_playable[0][2,11]);
		int stage_solved_0_211=System.Convert.ToInt32(stage_solved[0][2,11]);
		int dot_tail_turn_on_0_211=System.Convert.ToInt32(dot_tail_turn_on[0][2,11]);
		int stage_stars_score_0_211=stage_stars_score[0][2,11];
		best_int_score_in_this_stage_0_211=best_int_score_in_this_stage[0][2,11];
		int stage_playable_0_212=System.Convert.ToInt32(stage_playable[0][2,12]);
		int stage_solved_0_212=System.Convert.ToInt32(stage_solved[0][2,12]);
		int dot_tail_turn_on_0_212=System.Convert.ToInt32(dot_tail_turn_on[0][2,12]);
		int stage_stars_score_0_212=stage_stars_score[0][2,12];
		best_int_score_in_this_stage_0_212=best_int_score_in_this_stage[0][2,12];
		int stage_playable_0_213=System.Convert.ToInt32(stage_playable[0][2,13]);
		int stage_solved_0_213=System.Convert.ToInt32(stage_solved[0][2,13]);
		int dot_tail_turn_on_0_213=System.Convert.ToInt32(dot_tail_turn_on[0][2,13]);
		int stage_stars_score_0_213=stage_stars_score[0][2,13];
		best_int_score_in_this_stage_0_213=best_int_score_in_this_stage[0][2,13];
		int stage_playable_0_214=System.Convert.ToInt32(stage_playable[0][2,14]);
		int stage_solved_0_214=System.Convert.ToInt32(stage_solved[0][2,14]);
		int dot_tail_turn_on_0_214=System.Convert.ToInt32(dot_tail_turn_on[0][2,14]);
		int stage_stars_score_0_214=stage_stars_score[0][2,14];
		best_int_score_in_this_stage_0_214=best_int_score_in_this_stage[0][2,14];
		int incremental_item_current_level_0_0 = incremental_item_current_level[0][0];
		int incremental_item_current_level_0_1 = incremental_item_current_level[0][1];
		int incremental_item_current_level_0_2 = incremental_item_current_level[0][2];
		int incremental_item_current_level_0_3 = incremental_item_current_level[0][3];
		int incremental_item_current_level_0_4 = incremental_item_current_level[0][4];
		int incremental_item_current_level_0_5 = incremental_item_current_level[0][5];
		int incremental_item_current_level_0_6 = incremental_item_current_level[0][6];
		int consumable_item_current_quantity_0_0 = consumable_item_current_quantity[0][0];
		int consumable_item_current_quantity_0_1 = consumable_item_current_quantity[0][1];
		int consumable_item_current_quantity_0_2 = consumable_item_current_quantity[0][2];
		int consumable_item_current_quantity_0_3 = consumable_item_current_quantity[0][3];
		int consumable_item_current_quantity_0_4 = consumable_item_current_quantity[0][4];
		int consumable_item_current_quantity_0_5 = consumable_item_current_quantity[0][5];
		int consumable_item_current_quantity_0_6 = consumable_item_current_quantity[0][6];
		int consumable_item_current_quantity_0_7 = consumable_item_current_quantity[0][7];
		int consumable_item_current_quantity_0_8 = consumable_item_current_quantity[0][8];
		int consumable_item_current_quantity_0_9 = consumable_item_current_quantity[0][9];
		int consumable_item_current_quantity_0_10 = consumable_item_current_quantity[0][10];
		int consumable_item_current_quantity_0_11 = consumable_item_current_quantity[0][11];
		int consumable_item_current_quantity_0_12 = consumable_item_current_quantity[0][12];
		int consumable_item_current_quantity_0_13 = consumable_item_current_quantity[0][13];
		int consumable_item_current_quantity_0_14 = consumable_item_current_quantity[0][14];
		int consumable_item_current_quantity_0_15 = consumable_item_current_quantity[0][15];
		int consumable_item_current_quantity_0_16 = consumable_item_current_quantity[0][16];
		starts= PlayerPrefs.GetInt("profile_0_total_stars");
		money = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(0);
		lives = PlayerPrefs.GetInt("profile_0_current_lives");
		stages = PlayerPrefs.GetInt("profile_0_total_number_of_stages_in_the_game_solved");
		best_score = PlayerPrefs.GetInt("profile_0_best_int_score_for_this_profile");
		stage_progress = PlayerPrefs.GetInt("profile_0_play_this_stage_to_progress");
		world_progress = PlayerPrefs.GetInt("profile_0_play_this_world_to_progress");
		
		
		
		
		string saveData = System.String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};"+
		                                       "{9};{10};{11};{12};{13};"+
		                                       "{14};{15};{16};{17};{18};"+
		                                       "{19};{20};{21};{22};{23};"+
		                                       "{24};{25};{26};{27};{28};"+
		                                       "{29};{30};{31};{32};{33};"+
		                                       "{34};{35};{36};{37};{38};"+
		                                       "{39};{40};{41};{42};{43};"+
		                                       "{44};{45};{46};{47};{48};"+
		                                       "{49};{50};{51};{52};{53};"+
		                                       "{54};{55};{56};{57};{58};"+
		                                       "{59};{60};{61};{62};{63};"+
		                                       "{64};{65};{66};{67};{68};"+
		                                       "{69};{70};{71};{72};{73};"+
		                                       "{74};{75};{76};{77};{78};"+
		                                       "{79};{80};{81};{82};{83};"+
		                                       "{84};{85};{86};{87};{88};"+
		                                       "{89};{90};{91};{92};{93};"+
		                                       "{94};{95};{96};{97};{98};"+
		                                       "{99};{100};{101};{102};{103};"+
		                                       "{104};{105};{106};{107};{108};"+
		                                       "{109};{110};{111};{112};{113};"+
		                                       "{114};{115};{116};{117};{118};"+
		                                       "{119};{120};{121};{122};{123};"+
		                                       "{124};{125};{126};{127};{128};"+
		                                       "{129};{130};{131};{132};{133};"+
		                                       "{134};{135};{136};{137};{138};"+
		                                       "{139};{140};{141};{142};{143};"+
		                                       "{144};{145};{146};{147};{148};"+
		                                       "{149};{150};{151};{152};{153};"+
		                                       "{154};{155};{156};{157};{158};"+
		                                       "{159};{160};{161};{162};{163};"+
		                                       "{164};{165};{166};{167};{168};"+
		                                       "{169};{170};{171};{172};{173};"+
		                                       "{174};{175};{176};{177};{178};"+
		                                       "{179};{180};{181};{182};{183};"+
		                                       "{184};{185};{186};{187};{188};"+
		                                       "{189};{190};{191};{192};{193};"+
		                                       "{194};{195};{196};{197};{198};"+
		                                       "{199};{200};{201};{202};{203};"+
		                                       "{204};{205};{206};{207};{208};"+
		                                       "{209};{210};{211};{212};{213};"+
		                                       "{214};{215};{216};{217};{218};"+
		                                       "{219};{220};{221};{222};{223};"+
		                                       "{224};{225};{226};{227};{228};"+
		                                       "{229};{230};{231};{232};{233};"+
		                                       "{234};{235};{236};"+
		                                       "{237};{238};{239};{240};"+
		                                       "{241};{242};{243};{241};{245};"+
		                                       "{246};{247};{248};{249};{250};"+
		                                       "{251};{252};{253};{254};{255};"+
		                                       "{256};{257};"+
		                                       "{258};"+
		                                       "{259};"+
		                                       "{260};"+
		                                       "{261};"+
		                                       "{262};"+
		                                       "{263};"+
		                                       "{264};"
		                                       ,world_playable_0_0,world_purchased_0_0,star_score_in_this_world_0_0,world_playable_0_1,world_purchased_0_1,star_score_in_this_world_0_1,world_playable_0_2,world_purchased_0_2,star_score_in_this_world_0_2,
		                                       stage_playable_0_00,stage_solved_0_00,dot_tail_turn_on_0_00,stage_stars_score_0_00,best_int_score_in_this_stage_0_00,
		                                       stage_playable_0_01,stage_solved_0_01,dot_tail_turn_on_0_01,stage_stars_score_0_01,best_int_score_in_this_stage_0_01,
		                                       stage_playable_0_02,stage_solved_0_02,dot_tail_turn_on_0_02,stage_stars_score_0_02,best_int_score_in_this_stage_0_02,
		                                       stage_playable_0_03,stage_solved_0_03,dot_tail_turn_on_0_03,stage_stars_score_0_03,best_int_score_in_this_stage_0_03,
		                                       stage_playable_0_04,stage_solved__04,dot_tail_turn_on_0_04,stage_stars_score_0_04,best_int_score_in_this_stage_0_04,
		                                       stage_playable_0_05,stage_solved_0_05,dot_tail_turn_on_0_05,stage_stars_score_0_05,best_int_score_in_this_stage_0_05,
		                                       stage_playable_0_06,stage_solved_0_06,dot_tail_turn_on_0_06,stage_stars_score_0_06,best_int_score_in_this_stage_0_06,
		                                       stage_playable_0_07,stage_solved_0_07,dot_tail_turn_on_0_07,stage_stars_score_0_07,best_int_score_in_this_stage_0_07,
		                                       stage_playable_0_08,stage_solved_0_08,dot_tail_turn_on_0_08,stage_stars_score_0_08,best_int_score_in_this_stage_0_08,
		                                       stage_playable_0_09,stage_solved_0_09,dot_tail_turn_on_0_09,stage_stars_score_0_09,best_int_score_in_this_stage_0_09,
		                                       stage_playable_0_010,stage_solved_0_010,dot_tail_turn_on_0_010,stage_stars_score_0_010,best_int_score_in_this_stage_0_010,
		                                       stage_playable_0_011,stage_solved_0_011,dot_tail_turn_on_0_011,stage_stars_score_0_011,best_int_score_in_this_stage_0_011,
		                                       stage_playable_0_012,stage_solved_0_012,dot_tail_turn_on_0_012,stage_stars_score_0_012,best_int_score_in_this_stage_0_012,
		                                       stage_playable_0_013,stage_solved_0_013,dot_tail_turn_on_0_013,stage_stars_score_0_013,best_int_score_in_this_stage_0_013,
		                                       stage_playable_0_014,stage_solved_0_014,dot_tail_turn_on_0_014,stage_stars_score_0_014,best_int_score_in_this_stage_0_014,	
		                                       stage_playable_0_10,stage_solved_0_10,dot_tail_turn_on_0_10,stage_stars_score_0_10,best_int_score_in_this_stage_0_10,
		                                       stage_playable_0_11,stage_solved_0_11,dot_tail_turn_on_0_11,stage_stars_score_0_11,best_int_score_in_this_stage_0_11,
		                                       stage_playable_0_12,stage_solved_0_12,dot_tail_turn_on_0_12,stage_stars_score_0_12,best_int_score_in_this_stage_0_12,
		                                       stage_playable_0_13,stage_solved_0_13,dot_tail_turn_on_0_13,stage_stars_score_0_13,best_int_score_in_this_stage_0_13,
		                                       stage_playable_0_14,stage_solved_0_14,dot_tail_turn_on_0_14,stage_stars_score_0_14,best_int_score_in_this_stage_0_14,
		                                       stage_playable_0_15,stage_solved_0_15,dot_tail_turn_on_0_15,stage_stars_score_0_15,best_int_score_in_this_stage_0_15,
		                                       stage_playable_0_16,stage_solved_0_16,dot_tail_turn_on_0_16,stage_stars_score_0_16,best_int_score_in_this_stage_0_16,
		                                       stage_playable_0_17,stage_solved_0_17,dot_tail_turn_on_0_17,stage_stars_score_0_17,best_int_score_in_this_stage_0_17,
		                                       stage_playable_0_18,stage_solved_0_18,dot_tail_turn_on_0_18,stage_stars_score_0_18,best_int_score_in_this_stage_0_18,
		                                       stage_playable_0_19,stage_solved_0_19,dot_tail_turn_on_0_19,stage_stars_score_0_19,best_int_score_in_this_stage_0_19,
		                                       stage_playable_0_110,stage_solved_0_110,dot_tail_turn_on_0_110,stage_stars_score_0_110,best_int_score_in_this_stage_0_110,
		                                       stage_playable_0_111,stage_solved_0_111,dot_tail_turn_on_0_111,stage_stars_score_0_111,best_int_score_in_this_stage_0_111,
		                                       stage_playable_0_112,stage_solved_0_112,dot_tail_turn_on_0_112,stage_stars_score_0_112,best_int_score_in_this_stage_0_112,
		                                       stage_playable_0_113,stage_solved_0_113,dot_tail_turn_on_0_113,stage_stars_score_0_113,best_int_score_in_this_stage_0_113,
		                                       stage_playable_0_114,stage_solved_0_114,dot_tail_turn_on_0_114,stage_stars_score_0_114,best_int_score_in_this_stage_0_114,
		                                       stage_playable_0_20,stage_solved_0_20,dot_tail_turn_on_0_20,stage_stars_score_0_20,best_int_score_in_this_stage_0_20,
		                                       stage_playable_0_21,stage_solved_0_21,dot_tail_turn_on_0_21,stage_stars_score_0_21,best_int_score_in_this_stage_0_21,
		                                       stage_playable_0_22,stage_solved_0_22,dot_tail_turn_on_0_22,stage_stars_score_0_22,best_int_score_in_this_stage_0_22,
		                                       stage_playable_0_23,stage_solved_0_23,dot_tail_turn_on_0_23,stage_stars_score_0_23,best_int_score_in_this_stage_0_23,
		                                       stage_playable_0_24,stage_solved_0_24,dot_tail_turn_on_0_24,stage_stars_score_0_24,best_int_score_in_this_stage_0_24,
		                                       stage_playable_0_25,stage_solved_0_25,dot_tail_turn_on_0_25,stage_stars_score_0_25,best_int_score_in_this_stage_0_25,
		                                       stage_playable_0_26,stage_solved_0_26,dot_tail_turn_on_0_26,stage_stars_score_0_26,best_int_score_in_this_stage_0_26,
		                                       stage_playable_0_27,stage_solved_0_27,dot_tail_turn_on_0_27,stage_stars_score_0_27,best_int_score_in_this_stage_0_27,
		                                       stage_playable_0_28,stage_solved_0_28,dot_tail_turn_on_0_28,stage_stars_score_0_28,best_int_score_in_this_stage_0_28,
		                                       stage_playable_0_29,stage_solved_0_29,dot_tail_turn_on_0_29,stage_stars_score_0_29,best_int_score_in_this_stage_0_29,
		                                       stage_playable_0_210,stage_solved_0_210,dot_tail_turn_on_0_210,stage_stars_score_0_210,best_int_score_in_this_stage_0_210,
		                                       stage_playable_0_211,stage_solved_0_211,dot_tail_turn_on_0_211,stage_stars_score_0_211,best_int_score_in_this_stage_0_211,
		                                       stage_playable_0_212,stage_solved_0_212,dot_tail_turn_on_0_212,stage_stars_score_0_212,best_int_score_in_this_stage_0_212,
		                                       stage_playable_0_213,stage_solved_0_213,dot_tail_turn_on_0_213,stage_stars_score_0_213,best_int_score_in_this_stage_0_213,
		                                       stage_playable_0_214,stage_solved_0_214,dot_tail_turn_on_0_214,stage_stars_score_0_214,best_int_score_in_this_stage_0_214,
		                                       incremental_item_current_level_0_0,incremental_item_current_level_0_1,incremental_item_current_level_0_2,
		                                       incremental_item_current_level_0_3,incremental_item_current_level_0_4,incremental_item_current_level_0_5,incremental_item_current_level_0_6,
		                                       consumable_item_current_quantity_0_0,consumable_item_current_quantity_0_1,consumable_item_current_quantity_0_2,consumable_item_current_quantity_0_3,consumable_item_current_quantity_0_4,
		                                       consumable_item_current_quantity_0_5,consumable_item_current_quantity_0_6,consumable_item_current_quantity_0_7,consumable_item_current_quantity_0_8,consumable_item_current_quantity_0_9,
		                                       consumable_item_current_quantity_0_10,consumable_item_current_quantity_0_11,consumable_item_current_quantity_0_12,consumable_item_current_quantity_0_13,consumable_item_current_quantity_0_14,
		                                       consumable_item_current_quantity_0_15,consumable_item_current_quantity_0_16,
		                                       starts,
		                                       money,
		                                       lives,
		                                       stages,
		                                       best_score,
		                                       stage_progress,
		                                       world_progress);
		
		//string saveData = System.String.Format("{0};{1};{2}",starts,money,lives);
		//byte[] saveBytes = Encoding.UTF8.GetBytes(saveState);
		//AndroidMessage.Create("Snapshot Created", "Data: Starts: " + starts + " Coins: " + money + " Lives: " + lives);
		
		
		yield return new WaitForEndOfFrame();
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		Texture2D Screenshot = new Texture2D( width, height, TextureFormat.RGB24, false );
		// Read screen contents into the texture
		Screenshot.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		Screenshot.Apply();
		
		
		long TotalPlayedTime = 20000;
		//string currentSaveName =  "snapshotTemp-" + UnityEngine.Random.Range(1, 281).ToString();
		string currentSaveName =  "snapshotTemp-" + UnityEngine.Random.Range(1, 281).ToString();
		//string currentSaveName =  "Saved Game";
		string description  = "Starts: " + starts + " Coins: " + money + " Lives: " + lives+ " Level: "+ stage_progress +" and also purchases.";
		
		
		GooglePlaySavedGamesManager.ActionGameSaveResult += ActionGameSaveResult;
		GooglePlaySavedGamesManager.instance.CreateNewSnapshot(currentSaveName, description, Screenshot, saveData, TotalPlayedTime);
		
		Invoke("SendScore",1f);
		
		Destroy(Screenshot);
	}
	public void SendScore() {
		
		long score = 0;
		int v= best_int_score_in_this_stage_0_00+
			best_int_score_in_this_stage_0_01+
				best_int_score_in_this_stage_0_02+
				best_int_score_in_this_stage_0_03+
				best_int_score_in_this_stage_0_04+
				best_int_score_in_this_stage_0_05+
				best_int_score_in_this_stage_0_06+
				best_int_score_in_this_stage_0_07+
				best_int_score_in_this_stage_0_08+
				best_int_score_in_this_stage_0_09+
				best_int_score_in_this_stage_0_010+
				best_int_score_in_this_stage_0_011+
				best_int_score_in_this_stage_0_012+
				best_int_score_in_this_stage_0_013+
				best_int_score_in_this_stage_0_014+
				best_int_score_in_this_stage_0_10+
				best_int_score_in_this_stage_0_11+
				best_int_score_in_this_stage_0_12+
				best_int_score_in_this_stage_0_13+
				best_int_score_in_this_stage_0_14+
				best_int_score_in_this_stage_0_15+
				best_int_score_in_this_stage_0_16+
				best_int_score_in_this_stage_0_17+
				best_int_score_in_this_stage_0_18+
				best_int_score_in_this_stage_0_19+
				best_int_score_in_this_stage_0_110+
				best_int_score_in_this_stage_0_111+
				best_int_score_in_this_stage_0_112+
				best_int_score_in_this_stage_0_113+
				best_int_score_in_this_stage_0_114+
				best_int_score_in_this_stage_0_20+
				best_int_score_in_this_stage_0_21+
				best_int_score_in_this_stage_0_22+
				best_int_score_in_this_stage_0_23+
				best_int_score_in_this_stage_0_24+
				best_int_score_in_this_stage_0_25+
				best_int_score_in_this_stage_0_26+
				best_int_score_in_this_stage_0_27+
				best_int_score_in_this_stage_0_28+
				best_int_score_in_this_stage_0_29+
				best_int_score_in_this_stage_0_210+
				best_int_score_in_this_stage_0_211+
				best_int_score_in_this_stage_0_212+
				best_int_score_in_this_stage_0_213+
				best_int_score_in_this_stage_0_214;
		//score = Convert.ToInt64(long.Parse(win_screen_int_score_count.text));
		score = System.Convert.ToInt64(v);
		//if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
		//GooglePlayConnection.Instance.Disconnect ();
		//} else {
		GooglePlayConnection.Instance.Connect ();
		//}
		//if (GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
		GooglePlayManager.instance.SubmitScoreById (LEADERBOARD_ID, score);
		AndroidToast.ShowToastNotification ("Saved Score: " + score, 1);
		//}
	}
	private void ActionGameSaveLoaded (GP_SpanshotLoadResult result) {
	
	
			Debug.Log ("ActionGameSaveLoaded: " + result.Message);
			if (result.IsSucceeded) {


				Debug.Log ("Snapshot.Title: " + result.Snapshot.meta.Title);
				Debug.Log ("Snapshot.Description: " + result.Snapshot.meta.Description);
				Debug.Log ("Snapshot.CoverImageUrl): " + result.Snapshot.meta.CoverImageUrl);
				Debug.Log ("Snapshot.LastModifiedTimestamp: " + result.Snapshot.meta.LastModifiedTimestamp);
			
				Debug.Log ("Snapshot.stringData: " + result.Snapshot.stringData);
				Debug.Log ("Snapshot.bytes.Length: " + result.Snapshot.bytes.Length);



				string[] values = result.Snapshot.stringData.Split (';');
				for (int i = 0; i < values.Length; i++) {
					values [i] = values [i].Trim ();
				}

			
			int world_playable_0_0 = System.Convert.ToInt32(values[0]);
			int world_purchased_0_0 = System.Convert.ToInt32(values[1]);
			int star_score_in_this_world_0_0 = System.Convert.ToInt32(values[2]);
			int world_playable_0_1 = System.Convert.ToInt32(values[3]);
			int world_purchased_0_1 = System.Convert.ToInt32(values[4]);
			int star_score_in_this_world_0_1 = System.Convert.ToInt32(values[5]);
			int world_playable_0_2=System.Convert.ToInt32(values[6]);
			int world_purchased_0_2 = System.Convert.ToInt32(values[7]);
			int star_score_in_this_world_0_2=System.Convert.ToInt32(values[8]);
			int stage_playable_0_00=System.Convert.ToInt32(values[9]);
			int stage_solved_0_00=System.Convert.ToInt32(values[10]);
			int dot_tail_turn_on_0_00=System.Convert.ToInt32(values[11]);
			int stage_stars_score_0_00=System.Convert.ToInt32(values[12]);
			int best_int_score_in_this_stage_0_00=System.Convert.ToInt32(values[13]);
			int stage_playable_0_01 =System.Convert.ToInt32(values[14]);
			int stage_solved_0_01 = System.Convert.ToInt32(values[15]);
			int dot_tail_turn_on_0_01 = System.Convert.ToInt32(values[16]);
			int stage_stars_score_0_01 = System.Convert.ToInt32(values[17]);
			int best_int_score_in_this_stage_0_01 = System.Convert.ToInt32(values[18]);
			int stage_playable_0_02 = System.Convert.ToInt32(values[19]);
			int stage_solved_0_02 = System.Convert.ToInt32(values[20]);
			int dot_tail_turn_on_0_02=System.Convert.ToInt32(values[21]);
			int stage_stars_score_0_02= System.Convert.ToInt32(values[22]);
			int best_int_score_in_this_stage_0_02=System.Convert.ToInt32(values[23]);
			int stage_playable_0_03 =System.Convert.ToInt32(values[24]);
			int stage_solved_0_03=System.Convert.ToInt32(values[25]);
			int dot_tail_turn_on_0_03=System.Convert.ToInt32(values[26]);
			int stage_stars_score_0_03=System.Convert.ToInt32(values[27]);
			int best_int_score_in_this_stage_0_03=System.Convert.ToInt32(values[28]);
			int stage_playable_0_04=System.Convert.ToInt32(values[29]);
			int stage_solved__04 =System.Convert.ToInt32(values[30]);
			int dot_tail_turn_on_0_04=System.Convert.ToInt32(values[31]);
			int stage_stars_score_0_04=System.Convert.ToInt32(values[32]);
			int best_int_score_in_this_stage_0_04=System.Convert.ToInt32(values[33]);
			int stage_playable_0_05=System.Convert.ToInt32(values[34]);
			int stage_solved_0_05=System.Convert.ToInt32(values[35]);
			int dot_tail_turn_on_0_05=System.Convert.ToInt32(values[36]);
			int stage_stars_score_0_05=System.Convert.ToInt32(values[37]);
			int best_int_score_in_this_stage_0_05=System.Convert.ToInt32(values[38]);
			int stage_playable_0_06=System.Convert.ToInt32(values[39]);
			int stage_solved_0_06=System.Convert.ToInt32(values[40]);
			int dot_tail_turn_on_0_06=System.Convert.ToInt32(values[41]);
			int stage_stars_score_0_06 = System.Convert.ToInt32(values[42]);
			int best_int_score_in_this_stage_0_06=System.Convert.ToInt32(values[43]);
			int stage_playable_0_07=System.Convert.ToInt32(values[44]);
			int stage_solved_0_07=System.Convert.ToInt32(values[45]);
			int dot_tail_turn_on_0_07=System.Convert.ToInt32(values[46]);
			int stage_stars_score_0_07=System.Convert.ToInt32(values[47]);
			int best_int_score_in_this_stage_0_07=System.Convert.ToInt32(values[48]);
			int stage_playable_0_08=System.Convert.ToInt32(values[49]);
			int stage_solved_0_08=System.Convert.ToInt32(values[50]);
			int dot_tail_turn_on_0_08=System.Convert.ToInt32(values[51]);
			int stage_stars_score_0_08=System.Convert.ToInt32(values[52]);
			int best_int_score_in_this_stage_0_08=System.Convert.ToInt32(values[53]);
			int stage_playable_0_09=System.Convert.ToInt32(values[54]);
			int stage_solved_0_09=System.Convert.ToInt32(values[55]);
			int dot_tail_turn_on_0_09=System.Convert.ToInt32(values[56]);
			int stage_stars_score_0_09=System.Convert.ToInt32(values[57]);
			int best_int_score_in_this_stage_0_09=System.Convert.ToInt32(values[58]);
			int stage_playable_0_010=System.Convert.ToInt32(values[59]);
			int stage_solved_0_010=System.Convert.ToInt32(values[60]);
			int dot_tail_turn_on_0_010=System.Convert.ToInt32(values[61]);
			int stage_stars_score_0_010=System.Convert.ToInt32(values[62]);
			int best_int_score_in_this_stage_0_010=System.Convert.ToInt32(values[63]);
			int stage_playable_0_011=System.Convert.ToInt32(values[64]);
			int stage_solved_0_011=System.Convert.ToInt32(values[65]);
			int dot_tail_turn_on_0_011=System.Convert.ToInt32(values[66]);
			int stage_stars_score_0_011=System.Convert.ToInt32(values[67]);
			int best_int_score_in_this_stage_0_011=System.Convert.ToInt32(values[68]);
			int stage_playable_0_012=System.Convert.ToInt32(values[69]);
			int stage_solved_0_012=System.Convert.ToInt32(values[70]);
			int dot_tail_turn_on_0_012=System.Convert.ToInt32(values[71]);
			int stage_stars_score_0_012=System.Convert.ToInt32(values[72]);
			int best_int_score_in_this_stage_0_012=System.Convert.ToInt32(values[73]);
			int stage_playable_0_013=System.Convert.ToInt32(values[74]);
			int stage_solved_0_013=System.Convert.ToInt32(values[75]);
			int dot_tail_turn_on_0_013=System.Convert.ToInt32(values[76]);
			int stage_stars_score_0_013=System.Convert.ToInt32(values[77]);
			int best_int_score_in_this_stage_0_013=System.Convert.ToInt32(values[78]);
			int stage_playable_0_014=System.Convert.ToInt32(values[79]);
			int stage_solved_0_014=System.Convert.ToInt32(values[80]);
			int dot_tail_turn_on_0_014=System.Convert.ToInt32(values[81]);
			int stage_stars_score_0_014=System.Convert.ToInt32(values[82]);
			int best_int_score_in_this_stage_0_014=System.Convert.ToInt32(values[83]);
			int stage_playable_0_10=System.Convert.ToInt32(values[84]);
			int stage_solved_0_10=System.Convert.ToInt32(values[85]);
			int dot_tail_turn_on_0_10=System.Convert.ToInt32(values[86]);
		    int stage_stars_score_0_10=System.Convert.ToInt32(values[87]);
			int best_int_score_in_this_stage_0_10=System.Convert.ToInt32(values[88]);
			int stage_playable_0_11=System.Convert.ToInt32(values[89]);
			int stage_solved_0_11=System.Convert.ToInt32(values[90]);
			int dot_tail_turn_on_0_11=System.Convert.ToInt32(values[91]);
			int stage_stars_score_0_11=System.Convert.ToInt32(values[92]);
			int best_int_score_in_this_stage_0_11=System.Convert.ToInt32(values[93]);
			int stage_playable_0_12=System.Convert.ToInt32(values[94]);
			int stage_solved_0_12=System.Convert.ToInt32(values[95]);
			int dot_tail_turn_on_0_12=System.Convert.ToInt32(values[96]);
			int stage_stars_score_0_12=System.Convert.ToInt32(values[97]);
			int best_int_score_in_this_stage_0_12=System.Convert.ToInt32(values[98]);
			int stage_playable_0_13=System.Convert.ToInt32(values[99]);
			int stage_solved_0_13=System.Convert.ToInt32(values[100]);
			int dot_tail_turn_on_0_13=System.Convert.ToInt32(values[101]);
			int stage_stars_score_0_13=System.Convert.ToInt32(values[102]);
			int best_int_score_in_this_stage_0_13=System.Convert.ToInt32(values[103]);
			int stage_playable_0_14=System.Convert.ToInt32(values[104]);
			int stage_solved_0_14=System.Convert.ToInt32(values[105]);
			int dot_tail_turn_on_0_14=System.Convert.ToInt32(values[106]);
			int stage_stars_score_0_14=System.Convert.ToInt32(values[107]);
			int best_int_score_in_this_stage_0_14=System.Convert.ToInt32(values[108]);
			int stage_playable_0_15=System.Convert.ToInt32(values[109]);
			int stage_solved_0_15=System.Convert.ToInt32(values[110]);
			int dot_tail_turn_on_0_15=System.Convert.ToInt32(values[111]);
			int stage_stars_score_0_15=System.Convert.ToInt32(values[112]);
			int best_int_score_in_this_stage_0_15=System.Convert.ToInt32(values[113]);
			int stage_playable_0_16=System.Convert.ToInt32(values[114]);
			int stage_solved_0_16=System.Convert.ToInt32(values[115]);
			int dot_tail_turn_on_0_16=System.Convert.ToInt32(values[116]);
			int stage_stars_score_0_16=System.Convert.ToInt32(values[117]);
			int best_int_score_in_this_stage_0_16=System.Convert.ToInt32(values[118]);
			int stage_playable_0_17=System.Convert.ToInt32(values[119]);
			int stage_solved_0_17=System.Convert.ToInt32(values[120]);
			int dot_tail_turn_on_0_17=System.Convert.ToInt32(values[121]);
			int stage_stars_score_0_17=System.Convert.ToInt32(values[122]);
			int best_int_score_in_this_stage_0_17=System.Convert.ToInt32(values[123]);
			int stage_playable_0_18=System.Convert.ToInt32(values[124]);
			int stage_solved_0_18=System.Convert.ToInt32(values[125]);
			int dot_tail_turn_on_0_18=System.Convert.ToInt32(values[126]);
			int stage_stars_score_0_18=System.Convert.ToInt32(values[127]);
			int best_int_score_in_this_stage_0_18=System.Convert.ToInt32(values[128]);
			int stage_playable_0_19=System.Convert.ToInt32(values[129]);
			int stage_solved_0_19=System.Convert.ToInt32(values[130]);
			int dot_tail_turn_on_0_19=System.Convert.ToInt32(values[131]);
			int stage_stars_score_0_19=System.Convert.ToInt32(values[132]);
			int best_int_score_in_this_stage_0_19=System.Convert.ToInt32(values[133]);
			int stage_playable_0_110=System.Convert.ToInt32(values[134]);
			int stage_solved_0_110=System.Convert.ToInt32(values[135]);
			int dot_tail_turn_on_0_110=System.Convert.ToInt32(values[136]);
			int stage_stars_score_0_110=System.Convert.ToInt32(values[137]);
			int best_int_score_in_this_stage_0_110=System.Convert.ToInt32(values[138]);
			int stage_playable_0_111=System.Convert.ToInt32(values[139]);
			int stage_solved_0_111=System.Convert.ToInt32(values[140]);
			int dot_tail_turn_on_0_111=System.Convert.ToInt32(values[141]);
			int stage_stars_score_0_111=System.Convert.ToInt32(values[142]);
			int best_int_score_in_this_stage_0_111=System.Convert.ToInt32(values[143]);
			int stage_playable_0_112=System.Convert.ToInt32(values[144]);
			int stage_solved_0_112=System.Convert.ToInt32(values[145]);
			int dot_tail_turn_on_0_112=System.Convert.ToInt32(values[146]);
			int stage_stars_score_0_112=System.Convert.ToInt32(values[147]);
			int best_int_score_in_this_stage_0_112=System.Convert.ToInt32(values[148]);
			int stage_playable_0_113=System.Convert.ToInt32(values[149]);
			int stage_solved_0_113=System.Convert.ToInt32(values[150]);
			int dot_tail_turn_on_0_113=System.Convert.ToInt32(values[151]);
			int stage_stars_score_0_113=System.Convert.ToInt32(values[152]);
			int best_int_score_in_this_stage_0_113=System.Convert.ToInt32(values[153]);
			int stage_playable_0_114=System.Convert.ToInt32(values[154]);
			int stage_solved_0_114=System.Convert.ToInt32(values[155]);
			int dot_tail_turn_on_0_114=System.Convert.ToInt32(values[156]);
			int stage_stars_score_0_114=System.Convert.ToInt32(values[157]);
			int best_int_score_in_this_stage_0_114=System.Convert.ToInt32(values[158]);
			int stage_playable_0_20=System.Convert.ToInt32(values[159]);
			int stage_solved_0_20=System.Convert.ToInt32(values[160]);
			int dot_tail_turn_on_0_20=System.Convert.ToInt32(values[161]);
			int stage_stars_score_0_20=System.Convert.ToInt32(values[162]);
			int best_int_score_in_this_stage_0_20=System.Convert.ToInt32(values[163]);
			int stage_playable_0_21=System.Convert.ToInt32(values[164]);
			int stage_solved_0_21=System.Convert.ToInt32(values[165]);
			int dot_tail_turn_on_0_21=System.Convert.ToInt32(values[166]);
			int stage_stars_score_0_21=System.Convert.ToInt32(values[167]);
			int best_int_score_in_this_stage_0_21=System.Convert.ToInt32(values[168]);
			int stage_playable_0_22=System.Convert.ToInt32(values[169]);
			int stage_solved_0_22=System.Convert.ToInt32(values[170]);
			int dot_tail_turn_on_0_22=System.Convert.ToInt32(values[171]);
			int stage_stars_score_0_22=System.Convert.ToInt32(values[172]);
			int best_int_score_in_this_stage_0_22=System.Convert.ToInt32(values[173]);
			int stage_playable_0_23=System.Convert.ToInt32(values[174]);
			int stage_solved_0_23=System.Convert.ToInt32(values[175]);
			int dot_tail_turn_on_0_23=System.Convert.ToInt32(values[176]);
			int stage_stars_score_0_23=System.Convert.ToInt32(values[177]);
			int best_int_score_in_this_stage_0_23=System.Convert.ToInt32(values[178]);
			int stage_playable_0_24=System.Convert.ToInt32(values[179]);
			int stage_solved_0_24=System.Convert.ToInt32(values[180]);
			int dot_tail_turn_on_0_24=System.Convert.ToInt32(values[181]);
			int stage_stars_score_0_24=System.Convert.ToInt32(values[182]);
			int best_int_score_in_this_stage_0_24=System.Convert.ToInt32(values[183]);
			int stage_playable_0_25=System.Convert.ToInt32(values[184]);
			int stage_solved_0_25=System.Convert.ToInt32(values[185]);
			int dot_tail_turn_on_0_25=System.Convert.ToInt32(values[186]);
			int stage_stars_score_0_25=System.Convert.ToInt32(values[187]);
			int best_int_score_in_this_stage_0_25=System.Convert.ToInt32(values[188]);
			int stage_playable_0_26=System.Convert.ToInt32(values[189]);
			int stage_solved_0_26=System.Convert.ToInt32(values[190]);
			int dot_tail_turn_on_0_26=System.Convert.ToInt32(values[191]);
			int stage_stars_score_0_26=System.Convert.ToInt32(values[192]);
			int best_int_score_in_this_stage_0_26=System.Convert.ToInt32(values[193]);
			int stage_playable_0_27=System.Convert.ToInt32(values[194]);
			int stage_solved_0_27=System.Convert.ToInt32(values[195]);
			int dot_tail_turn_on_0_27=System.Convert.ToInt32(values[196]);
			int stage_stars_score_0_27=System.Convert.ToInt32(values[197]);
			int best_int_score_in_this_stage_0_27=System.Convert.ToInt32(values[198]);
			int stage_playable_0_28=System.Convert.ToInt32(values[199]);
			int stage_solved_0_28=System.Convert.ToInt32(values[200]);
			int dot_tail_turn_on_0_28=System.Convert.ToInt32(values[201]);
			int stage_stars_score_0_28=System.Convert.ToInt32(values[202]);
			int best_int_score_in_this_stage_0_28=System.Convert.ToInt32(values[203]);
			int stage_playable_0_29=System.Convert.ToInt32(values[204]);
			int stage_solved_0_29=System.Convert.ToInt32(values[205]);
			int dot_tail_turn_on_0_29=System.Convert.ToInt32(values[206]);
			int stage_stars_score_0_29=System.Convert.ToInt32(values[207]);
			int best_int_score_in_this_stage_0_29=System.Convert.ToInt32(values[208]);
			int stage_playable_0_210=System.Convert.ToInt32(values[209]);
			int stage_solved_0_210=System.Convert.ToInt32(values[210]);
			int dot_tail_turn_on_0_210=System.Convert.ToInt32(values[211]);
			int stage_stars_score_0_210=System.Convert.ToInt32(values[212]);
			int best_int_score_in_this_stage_0_210=System.Convert.ToInt32(values[213]);
			int stage_playable_0_211=System.Convert.ToInt32(values[214]);
			int stage_solved_0_211=System.Convert.ToInt32(values[215]);
			int dot_tail_turn_on_0_211=System.Convert.ToInt32(values[216]);
			int stage_stars_score_0_211=System.Convert.ToInt32(values[217]);
			int best_int_score_in_this_stage_0_211=System.Convert.ToInt32(values[218]);
			int stage_playable_0_212=System.Convert.ToInt32(values[219]);
			int stage_solved_0_212=System.Convert.ToInt32(values[220]);
			int dot_tail_turn_on_0_212=System.Convert.ToInt32(values[221]);
			int stage_stars_score_0_212=System.Convert.ToInt32(values[222]);
			int best_int_score_in_this_stage_0_212=System.Convert.ToInt32(values[223]);
			int stage_playable_0_213=System.Convert.ToInt32(values[224]);
			int stage_solved_0_213=System.Convert.ToInt32(values[225]);
			int dot_tail_turn_on_0_213=System.Convert.ToInt32(values[226]);
			int stage_stars_score_0_213=System.Convert.ToInt32(values[227]);
			int best_int_score_in_this_stage_0_213=System.Convert.ToInt32(values[228]);
			int stage_playable_0_214=System.Convert.ToInt32(values[229]);
			int stage_solved_0_214=System.Convert.ToInt32(values[230]);
			int dot_tail_turn_on_0_214=System.Convert.ToInt32(values[231]);
			int stage_stars_score_0_214=System.Convert.ToInt32(values[232]);
			int best_int_score_in_this_stage_0_214=System.Convert.ToInt32(values[233]);
			int incremental_item_current_level_0_0 = System.Convert.ToInt32(values[234]);
			int incremental_item_current_level_0_1 = System.Convert.ToInt32(values[235]);
			int incremental_item_current_level_0_2 = System.Convert.ToInt32(values[236]);
			int incremental_item_current_level_0_3 = System.Convert.ToInt32(values[237]);
			int incremental_item_current_level_0_4 = System.Convert.ToInt32(values[238]);
			int incremental_item_current_level_0_5 = System.Convert.ToInt32(values[239]);
			int incremental_item_current_level_0_6 = System.Convert.ToInt32(values[240]);
			int consumable_item_current_quantity_0_0 = System.Convert.ToInt32(values[241]);
			int consumable_item_current_quantity_0_1 = System.Convert.ToInt32(values[242]);
			int consumable_item_current_quantity_0_2 = System.Convert.ToInt32(values[243]);
			int consumable_item_current_quantity_0_3 = System.Convert.ToInt32(values[244]);
			int consumable_item_current_quantity_0_4 = System.Convert.ToInt32(values[245]);
			int consumable_item_current_quantity_0_5 = System.Convert.ToInt32(values[246]);
			int consumable_item_current_quantity_0_6 = System.Convert.ToInt32(values[247]);
			int consumable_item_current_quantity_0_7 = System.Convert.ToInt32(values[248]);
			int consumable_item_current_quantity_0_8 = System.Convert.ToInt32(values[249]);
			int consumable_item_current_quantity_0_9 = System.Convert.ToInt32(values[250]);
			int consumable_item_current_quantity_0_10 = System.Convert.ToInt32(values[251]);
			int consumable_item_current_quantity_0_11 = System.Convert.ToInt32(values[252]);
			int consumable_item_current_quantity_0_12 = System.Convert.ToInt32(values[253]);
			int consumable_item_current_quantity_0_13 = System.Convert.ToInt32(values[254]);
			int consumable_item_current_quantity_0_14 = System.Convert.ToInt32(values[255]);
			int consumable_item_current_quantity_0_15 = System.Convert.ToInt32(values[256]);
			int consumable_item_current_quantity_0_16 = System.Convert.ToInt32(values[257]);
			starts= System.Convert.ToInt32(values[258]);
			money = System.Convert.ToInt32(values[259]);
			lives = System.Convert.ToInt32(values[260]);
			stages= System.Convert.ToInt32(values[261]);
			best_score = System.Convert.ToInt32(values[262]);
			stage_progress= System.Convert.ToInt32(values[263]);
			world_progress= System.Convert.ToInt32(values[264]);

			//AndroidMessage.Create ("Snapshot Loaded", "Data: Starts: " + result.Snapshot.stringData);
			AndroidMessage.Create ("Loaded", "Data: money: " + values[259]+" lives: " +values[260] + " Purchased and Levels to.");
				//	string saveData = String.Format("{0};{1};{2};{3};{4};{5};{6}", stage, world, stages,starts,continues,money,lives);

				PlayerPrefs.SetInt ("profile_0_array_W0_world_unlocked", world_playable_0_0);
				PlayerPrefs.SetInt ("profile_0_array_W0_world_purchased", world_purchased_0_0);
				PlayerPrefs.SetInt ("profile_0_star_score_in_this_world", star_score_in_this_world_0_0);
				PlayerPrefs.SetInt ("profile_0_array_W1_world_unlocked", world_playable_0_1);
				PlayerPrefs.SetInt ("profile_0_array_W1_world_purchased", world_purchased_0_1);
				PlayerPrefs.SetInt ("profile_0_star_score_in_this_world", star_score_in_this_world_0_1);
				PlayerPrefs.SetInt ("profile_0_array_W2_world_unlocked", world_playable_0_2);
				PlayerPrefs.SetInt ("profile_0_array_W2_world_purchased", world_purchased_0_2);
				PlayerPrefs.SetInt ("profile_0_star_score_in_this_world", star_score_in_this_world_0_2);
				PlayerPrefs.SetInt ("profile_0_array_W0S0_stages_unlocked", stage_playable_0_00);
				PlayerPrefs.SetInt ("profile_0_array_W0S0_stage_solved", stage_solved_0_00);
				PlayerPrefs.SetInt ("profile_0_array_W0S0_dots", dot_tail_turn_on_0_00);
				PlayerPrefs.SetInt ("profile_0_array_W0S0_stage_stars_score", stage_stars_score_0_00);
				PlayerPrefs.SetInt ("profile_0_array_W0S0_stage_int_score", best_int_score_in_this_stage_0_00);
				PlayerPrefs.SetInt ("profile_0_array_W0S1_stages_unlocked", stage_playable_0_01);
				PlayerPrefs.SetInt ("profile_0_array_W0S1_stage_solved", stage_solved_0_01);
				PlayerPrefs.SetInt ("profile_0_array_W0S1_dots", dot_tail_turn_on_0_01);
				PlayerPrefs.SetInt ("profile_0_array_W0S1_stage_stars_score", stage_stars_score_0_01);
				PlayerPrefs.SetInt ("profile_0_array_W0S1_stage_int_score", best_int_score_in_this_stage_0_01);
				PlayerPrefs.SetInt ("profile_0_array_W0S2_stages_unlocked", stage_playable_0_02);
				PlayerPrefs.SetInt ("profile_0_array_W0S2_stage_solved", stage_solved_0_02);
				PlayerPrefs.SetInt ("profile_0_array_W0S2_dots", dot_tail_turn_on_0_02);
				PlayerPrefs.SetInt ("profile_0_array_W0S2_stage_stars_score", stage_stars_score_0_02);
				PlayerPrefs.SetInt ("profile_0_array_W0S2_stage_int_score", best_int_score_in_this_stage_0_02);
				PlayerPrefs.SetInt ("profile_0_array_W0S2_stages_unlocked", stage_playable_0_03);
				PlayerPrefs.SetInt ("profile_0_array_W0S3_stage_solved", stage_solved_0_03);
				PlayerPrefs.SetInt ("profile_0_array_W0S3_dots", dot_tail_turn_on_0_03);
				PlayerPrefs.SetInt ("profile_0_array_W0S3_stage_stars_score", stage_stars_score_0_03);
				PlayerPrefs.SetInt ("profile_0_array_W0S3_stage_int_score", best_int_score_in_this_stage_0_03);
				PlayerPrefs.SetInt ("profile_0_array_W0S4_stages_unlocked", stage_playable_0_04);
				PlayerPrefs.SetInt ("profile_0_array_W0S4_stage_solved", stage_solved__04);
				PlayerPrefs.SetInt ("profile_0_array_W0S4_dots", dot_tail_turn_on_0_04);
				PlayerPrefs.SetInt ("profile_0_array_W0S4_stage_stars_score", stage_stars_score_0_04);
				PlayerPrefs.SetInt ("profile_0_array_W0S4_stage_int_score", best_int_score_in_this_stage_0_04);
				PlayerPrefs.SetInt ("profile_0_array_W0S5_stages_unlocked", stage_playable_0_05);
				PlayerPrefs.SetInt ("profile_0_array_W0S5_stage_solved", stage_solved_0_05);
				PlayerPrefs.SetInt ("profile_0_array_W0S5_dots", dot_tail_turn_on_0_05);
				PlayerPrefs.SetInt ("profile_0_array_W0S5_stage_stars_score", stage_stars_score_0_05);
				PlayerPrefs.SetInt ("profile_0_array_W0S5_stage_int_score", best_int_score_in_this_stage_0_05);
				PlayerPrefs.SetInt ("profile_0_array_W0S6_stages_unlocked", stage_playable_0_06);
				PlayerPrefs.SetInt ("profile_0_array_W0S6_stage_solved", stage_solved_0_06);
				PlayerPrefs.SetInt ("profile_0_array_W0S6_dots", dot_tail_turn_on_0_06);
				PlayerPrefs.SetInt ("profile_0_array_W0S6_stage_stars_score", stage_stars_score_0_06);
				PlayerPrefs.SetInt ("profile_0_array_W0S6_stage_int_score", best_int_score_in_this_stage_0_06);
				PlayerPrefs.SetInt ("profile_0_array_W0S7_stages_unlocked", stage_playable_0_07);
				PlayerPrefs.SetInt ("profile_0_array_W0S7_stage_solved", stage_solved_0_07);
				PlayerPrefs.SetInt ("profile_0_array_W0S7_dots", dot_tail_turn_on_0_07);
				PlayerPrefs.SetInt ("profile_0_array_W0S7_stage_stars_score", stage_stars_score_0_07);
				PlayerPrefs.SetInt ("profile_0_array_W0S7_stage_int_score", best_int_score_in_this_stage_0_07);
				PlayerPrefs.SetInt ("profile_0_array_W0S8_stages_unlocked", stage_playable_0_08);
				PlayerPrefs.SetInt ("profile_0_array_W0S8_stage_solved", stage_solved_0_08);
				PlayerPrefs.SetInt ("profile_0_array_W0S8_dots", dot_tail_turn_on_0_08);
				PlayerPrefs.SetInt ("profile_0_array_W0S8_stage_stars_score", stage_stars_score_0_08);
				PlayerPrefs.SetInt ("profile_0_array_W0S8_stage_int_score", best_int_score_in_this_stage_0_08);
				PlayerPrefs.SetInt ("profile_0_array_W0S9_stages_unlocked", stage_playable_0_09);
				PlayerPrefs.SetInt ("profile_0_array_W0S9_stage_solved", stage_solved_0_09);
				PlayerPrefs.SetInt ("profile_0_array_W0S9_dots", dot_tail_turn_on_0_09);
				PlayerPrefs.SetInt ("profile_0_array_W0S9_stage_stars_score", stage_stars_score_0_09);
				PlayerPrefs.SetInt ("profile_0_array_W0S9_stage_int_score", best_int_score_in_this_stage_0_09);
				PlayerPrefs.SetInt ("profile_0_array_W0S10_stages_unlocked", stage_playable_0_010);
				PlayerPrefs.SetInt ("profile_0_array_W0S10_stage_solved", stage_solved_0_010);
				PlayerPrefs.SetInt ("profile_0_array_W0S10_dots", dot_tail_turn_on_0_010);
				PlayerPrefs.SetInt ("profile_0_array_W0S10_stage_stars_score", stage_stars_score_0_010);
				PlayerPrefs.SetInt ("profile_0_array_W0S10_stage_int_score", best_int_score_in_this_stage_0_010);
				PlayerPrefs.SetInt ("profile_0_array_W0S11_stages_unlocked", stage_playable_0_011);
				PlayerPrefs.SetInt ("profile_0_array_W0S11_stage_solved", stage_solved_0_011);
				PlayerPrefs.SetInt ("profile_0_array_W0S11_dots", dot_tail_turn_on_0_011);
				PlayerPrefs.SetInt ("profile_0_array_W0S11_stage_stars_score", stage_stars_score_0_011);
				PlayerPrefs.SetInt ("profile_0_array_W0S11_stage_int_score", best_int_score_in_this_stage_0_011);
				PlayerPrefs.SetInt ("profile_0_array_W0S12_stages_unlocked", stage_playable_0_012);
				PlayerPrefs.SetInt ("profile_0_array_W0S12_stage_solved", stage_solved_0_012);
				PlayerPrefs.SetInt ("profile_0_array_W0S12_dots", dot_tail_turn_on_0_012);
				PlayerPrefs.SetInt ("profile_0_array_W0S12_stage_stars_score", stage_stars_score_0_012);
				PlayerPrefs.SetInt ("profile_0_array_W0S12_stage_int_score", best_int_score_in_this_stage_0_012);
				PlayerPrefs.SetInt ("profile_0_array_W0S13_stages_unlocked", stage_playable_0_013);
				PlayerPrefs.SetInt ("profile_0_array_W0S13_stage_solved", stage_solved_0_013);
				PlayerPrefs.SetInt ("profile_0_array_W0S13_dots", dot_tail_turn_on_0_013);
				PlayerPrefs.SetInt ("profile_0_array_W0S13_stage_stars_score", stage_stars_score_0_013);
				PlayerPrefs.SetInt ("profile_0_array_W0S13_stage_int_score", best_int_score_in_this_stage_0_013);
				PlayerPrefs.SetInt ("profile_0_array_W0S14_stages_unlocked", stage_playable_0_014);
				PlayerPrefs.SetInt ("profile_0_array_W0S14_stage_solved", stage_solved_0_014);
				PlayerPrefs.SetInt ("profile_0_array_W0S14_dots", dot_tail_turn_on_0_014);
				PlayerPrefs.SetInt ("profile_0_array_W0S14_stage_stars_score", stage_stars_score_0_014);
				PlayerPrefs.SetInt ("profile_0_array_W0S14_stage_int_score", best_int_score_in_this_stage_0_014);
				PlayerPrefs.SetInt ("profile_0_array_W1S0_stages_unlocked", stage_playable_0_10);
				PlayerPrefs.SetInt ("profile_0_array_W1S0_stage_solved", stage_solved_0_10);
				PlayerPrefs.SetInt ("profile_0_array_W1S0_dots", dot_tail_turn_on_0_10);
				PlayerPrefs.SetInt ("profile_0_array_W1S0_stage_stars_score", stage_stars_score_0_10);
				PlayerPrefs.SetInt ("profile_0_array_W1S0_stage_int_score", best_int_score_in_this_stage_0_10);
				PlayerPrefs.SetInt ("profile_0_array_W1S1_stages_unlocked", stage_playable_0_11);
				PlayerPrefs.SetInt ("profile_0_array_W1S1_stage_solved", stage_solved_0_11);
				PlayerPrefs.SetInt ("profile_0_array_W1S1_dots", dot_tail_turn_on_0_11);
				PlayerPrefs.SetInt ("profile_0_array_W1S1_stage_stars_score", stage_stars_score_0_11);
				PlayerPrefs.SetInt ("profile_0_array_W1S1_stage_int_score", best_int_score_in_this_stage_0_11);
				PlayerPrefs.SetInt ("profile_0_array_W1S2_stages_unlocked", stage_playable_0_12);
				PlayerPrefs.SetInt ("profile_0_array_W1S2_stage_solved", stage_solved_0_12);
				PlayerPrefs.SetInt ("profile_0_array_W1S2_dots", dot_tail_turn_on_0_12);
				PlayerPrefs.SetInt ("profile_0_array_W1S2_stage_stars_score", stage_stars_score_0_12);
				PlayerPrefs.SetInt ("profile_0_array_W1S2_stage_int_score", best_int_score_in_this_stage_0_12);
				PlayerPrefs.SetInt ("profile_0_array_W1S3_stages_unlocked", stage_playable_0_13);
				PlayerPrefs.SetInt ("profile_0_array_W1S3_stage_solved", stage_solved_0_13);
				PlayerPrefs.SetInt ("profile_0_array_W1S3_dots", dot_tail_turn_on_0_13);
				PlayerPrefs.SetInt ("profile_0_array_W1S3_stage_stars_score", stage_stars_score_0_13);
				PlayerPrefs.SetInt ("profile_0_array_W1S3_stage_int_score", best_int_score_in_this_stage_0_13);
				PlayerPrefs.SetInt ("profile_0_array_W1S4_stages_unlocked", stage_playable_0_14);
				PlayerPrefs.SetInt ("profile_0_array_W1S4_stage_solved", stage_solved_0_14);
				PlayerPrefs.SetInt ("profile_0_array_W1S4_dots", dot_tail_turn_on_0_14);
				PlayerPrefs.SetInt ("profile_0_array_W1S4_stage_stars_score", stage_stars_score_0_14);
				PlayerPrefs.SetInt ("profile_0_array_W1S4_stage_int_score", best_int_score_in_this_stage_0_14);
				PlayerPrefs.SetInt ("profile_0_array_W1S5_stages_unlocked", stage_playable_0_15);
				PlayerPrefs.SetInt ("profile_0_array_W1S5_stage_solved", stage_solved_0_15);
				PlayerPrefs.SetInt ("profile_0_array_W1S5_dots", dot_tail_turn_on_0_15);
				PlayerPrefs.SetInt ("profile_0_array_W1S5_stage_stars_score", stage_stars_score_0_15);
				PlayerPrefs.SetInt ("profile_0_array_W1S5_stage_int_score", best_int_score_in_this_stage_0_15);
				PlayerPrefs.SetInt ("profile_0_array_W1S6_stages_unlocked", stage_playable_0_16);
				PlayerPrefs.SetInt ("profile_0_array_W1S6_stage_solved", stage_solved_0_16);
				PlayerPrefs.SetInt ("profile_0_array_W1S6_dots", dot_tail_turn_on_0_16);
				PlayerPrefs.SetInt ("profile_0_array_W1S6_stage_stars_score", stage_stars_score_0_16);
				PlayerPrefs.SetInt ("profile_0_array_W1S6_stage_int_score", best_int_score_in_this_stage_0_16);
				PlayerPrefs.SetInt ("profile_0_array_W1S7_stages_unlocked", stage_playable_0_17);
				PlayerPrefs.SetInt ("profile_0_array_W1S7_stage_solved", stage_solved_0_17);
				PlayerPrefs.SetInt ("profile_0_array_W1S7_dots", dot_tail_turn_on_0_17);
				PlayerPrefs.SetInt ("profile_0_array_W1S7_stage_stars_score", stage_stars_score_0_17);
				PlayerPrefs.SetInt ("profile_0_array_W1S7_stage_int_score", best_int_score_in_this_stage_0_17);
				PlayerPrefs.SetInt ("profile_0_array_W1S8_stages_unlocked", stage_playable_0_18);
				PlayerPrefs.SetInt ("profile_0_array_W1S8_stage_solved", stage_solved_0_18);
				PlayerPrefs.SetInt ("profile_0_array_W1S8_dots", dot_tail_turn_on_0_18);
				PlayerPrefs.SetInt ("profile_0_array_W1S8_stage_stars_score", stage_stars_score_0_18);
				PlayerPrefs.SetInt ("profile_0_array_W1S8_stage_int_score", best_int_score_in_this_stage_0_18);
				PlayerPrefs.SetInt ("profile_0_array_W1S9_stages_unlocked", stage_playable_0_19);
				PlayerPrefs.SetInt ("profile_0_array_W1S9_stage_solved", stage_solved_0_19);
				PlayerPrefs.SetInt ("profile_0_array_W1S9_dots", dot_tail_turn_on_0_19);
				PlayerPrefs.SetInt ("profile_0_array_W1S9_stage_stars_score", stage_stars_score_0_19);
				PlayerPrefs.SetInt ("profile_0_array_W1S9_stage_int_score", best_int_score_in_this_stage_0_19);
				PlayerPrefs.SetInt ("profile_0_array_W1S10_stages_unlocked", stage_playable_0_110);
				PlayerPrefs.SetInt ("profile_0_array_W1S10_stage_solved", stage_solved_0_110);
				PlayerPrefs.SetInt ("profile_0_array_W1S10_dots", dot_tail_turn_on_0_110);
				PlayerPrefs.SetInt ("profile_0_array_W1S10_stage_stars_score", stage_stars_score_0_110);
				PlayerPrefs.SetInt ("profile_0_array_W1S10_stage_int_score", best_int_score_in_this_stage_0_110);
				PlayerPrefs.SetInt ("profile_0_array_W1S11_stages_unlocked", stage_playable_0_111);
				PlayerPrefs.SetInt ("profile_0_array_W1S11_stage_solved", stage_solved_0_111);
				PlayerPrefs.SetInt ("profile_0_array_W1S11_dots", dot_tail_turn_on_0_111);
				PlayerPrefs.SetInt ("profile_0_array_W1S11_stage_stars_score", stage_stars_score_0_111);
				PlayerPrefs.SetInt ("profile_0_array_W1S11_stage_int_score", best_int_score_in_this_stage_0_111);
				PlayerPrefs.SetInt ("profile_0_array_W1S12_stages_unlocked", stage_playable_0_112);
				PlayerPrefs.SetInt ("profile_0_array_W1S12_stage_solved", stage_solved_0_112);
				PlayerPrefs.SetInt ("profile_0_array_W1S12_dots", dot_tail_turn_on_0_112);
				PlayerPrefs.SetInt ("profile_0_array_W1S12_stage_stars_score", stage_stars_score_0_112);
				PlayerPrefs.SetInt ("profile_0_array_W1S12_stage_int_score", best_int_score_in_this_stage_0_112);
				PlayerPrefs.SetInt ("profile_0_array_W1S13_stages_unlocked", stage_playable_0_113);
				PlayerPrefs.SetInt ("profile_0_array_W1S13_stage_solved", stage_solved_0_113);
				PlayerPrefs.SetInt ("profile_0_array_W1S13_dots", dot_tail_turn_on_0_113);
				PlayerPrefs.SetInt ("profile_0_array_W1S13_stage_stars_score", stage_stars_score_0_113);
				PlayerPrefs.SetInt ("profile_0_array_W1S13_stage_int_score", best_int_score_in_this_stage_0_113);
				PlayerPrefs.SetInt ("profile_0_array_W1S14_stages_unlocked", stage_playable_0_114);
				PlayerPrefs.SetInt ("profile_0_array_W1S14_stage_solved", stage_solved_0_114);
				PlayerPrefs.SetInt ("profile_0_array_W1S14_dots", dot_tail_turn_on_0_114);
				PlayerPrefs.SetInt ("profile_0_array_W1S14_stage_stars_score", stage_stars_score_0_114);
				PlayerPrefs.SetInt ("profile_0_array_W1S14_stage_int_score", best_int_score_in_this_stage_0_114);
				PlayerPrefs.SetInt ("profile_0_array_W2S0_stages_unlocked", stage_playable_0_20);
				PlayerPrefs.SetInt ("profile_0_array_W2S0_stage_solved", stage_solved_0_20);
				PlayerPrefs.SetInt ("profile_0_array_W2S0_dots", dot_tail_turn_on_0_20);
				PlayerPrefs.SetInt ("profile_0_array_W2S0_stage_stars_score", stage_stars_score_0_20);
				PlayerPrefs.SetInt ("profile_0_array_W2S0_stage_int_score", best_int_score_in_this_stage_0_20);
				PlayerPrefs.SetInt ("profile_0_array_W2S1_stages_unlocked", stage_playable_0_21);
				PlayerPrefs.SetInt ("profile_0_array_W2S1_stage_solved", stage_solved_0_21);
				PlayerPrefs.SetInt ("profile_0_array_W2S1_dots", dot_tail_turn_on_0_21);
				PlayerPrefs.SetInt ("profile_0_array_W2S1_stage_stars_score", stage_stars_score_0_21);
				PlayerPrefs.SetInt ("profile_0_array_W2S1_stage_int_score", best_int_score_in_this_stage_0_21);
				PlayerPrefs.SetInt ("profile_0_array_W2S2_stages_unlocked", stage_playable_0_22);
				PlayerPrefs.SetInt ("profile_0_array_W2S2_stage_solved", stage_solved_0_22);
				PlayerPrefs.SetInt ("profile_0_array_W2S2_dots", dot_tail_turn_on_0_22);
				PlayerPrefs.SetInt ("profile_0_array_W2S2_stage_stars_score", stage_stars_score_0_22);
				PlayerPrefs.SetInt ("profile_0_array_W2S2_stage_int_score", best_int_score_in_this_stage_0_22);
				PlayerPrefs.SetInt ("profile_0_array_W2S3_stages_unlocked", stage_playable_0_23);
				PlayerPrefs.SetInt ("profile_0_array_W2S3_stage_solved", stage_solved_0_23);
				PlayerPrefs.SetInt ("profile_0_array_W2S3_dots", dot_tail_turn_on_0_23);
				PlayerPrefs.SetInt ("profile_0_array_W2S3_stage_stars_score", stage_stars_score_0_23);
				PlayerPrefs.SetInt ("profile_0_array_W2S3_stage_int_score", best_int_score_in_this_stage_0_23);
				PlayerPrefs.SetInt ("profile_0_array_W2S4_stages_unlocked", stage_playable_0_24);
				PlayerPrefs.SetInt ("profile_0_array_W2S4_stage_solved", stage_solved_0_24);
				PlayerPrefs.SetInt ("profile_0_array_W2S4_dots", dot_tail_turn_on_0_24);
				PlayerPrefs.SetInt ("profile_0_array_W2S4_stage_stars_score", stage_stars_score_0_24);
				PlayerPrefs.SetInt ("profile_0_array_W2S4_stage_int_score", best_int_score_in_this_stage_0_24);
				PlayerPrefs.SetInt ("profile_0_array_W2S5_stages_unlocked", stage_playable_0_25);
				PlayerPrefs.SetInt ("profile_0_array_W2S5_stage_solved", stage_solved_0_25);
				PlayerPrefs.SetInt ("profile_0_array_W2S5_dots", dot_tail_turn_on_0_25);
				PlayerPrefs.SetInt ("profile_0_array_W2S5_stage_stars_score", stage_stars_score_0_25);
				PlayerPrefs.SetInt ("profile_0_array_W2S5_stage_int_score", best_int_score_in_this_stage_0_25);
				PlayerPrefs.SetInt ("profile_0_array_W2S6_stages_unlocked", stage_playable_0_26);
				PlayerPrefs.SetInt ("profile_0_array_W2S6_stage_solved", stage_solved_0_26);
				PlayerPrefs.SetInt ("profile_0_array_W2S6_dots", dot_tail_turn_on_0_26);
				PlayerPrefs.SetInt ("profile_0_array_W2S6_stage_stars_score", stage_stars_score_0_26);
				PlayerPrefs.SetInt ("profile_0_array_W2S6_stage_int_score", best_int_score_in_this_stage_0_26);
				PlayerPrefs.SetInt ("profile_0_array_W2S7_stages_unlocked", stage_playable_0_27);
				PlayerPrefs.SetInt ("profile_0_array_W2S7_stage_solved", stage_solved_0_27);
				PlayerPrefs.SetInt ("profile_0_array_W2S7_dots", dot_tail_turn_on_0_27);
				PlayerPrefs.SetInt ("profile_0_array_W2S7_stage_stars_score", stage_stars_score_0_27);
				PlayerPrefs.SetInt ("profile_0_array_W2S7_stage_int_score", best_int_score_in_this_stage_0_27);
				PlayerPrefs.SetInt ("profile_0_array_W2S8_stages_unlocked", stage_playable_0_28);
				PlayerPrefs.SetInt ("profile_0_array_W2S8_stage_solved", stage_solved_0_28);
				PlayerPrefs.SetInt ("profile_0_array_W2S8_dots", dot_tail_turn_on_0_28);
				PlayerPrefs.SetInt ("profile_0_array_W2S8_stage_stars_score", stage_stars_score_0_28);
				PlayerPrefs.SetInt ("profile_0_array_W2S8_stage_int_score", best_int_score_in_this_stage_0_28);
				PlayerPrefs.SetInt ("profile_0_array_W2S9_stages_unlocked", stage_playable_0_29);
				PlayerPrefs.SetInt ("profile_0_array_W2S9_stage_solved", stage_solved_0_29);
				PlayerPrefs.SetInt ("profile_0_array_W2S9_dots", dot_tail_turn_on_0_29);
				PlayerPrefs.SetInt ("profile_0_array_W2S9_stage_stars_score", stage_stars_score_0_29);
				PlayerPrefs.SetInt ("profile_0_array_W2S9_stage_int_score", best_int_score_in_this_stage_0_29);
				PlayerPrefs.SetInt ("profile_0_array_W2S10_stages_unlocked", stage_playable_0_210);
				PlayerPrefs.SetInt ("profile_0_array_W2S10_stage_solved", stage_solved_0_210);
				PlayerPrefs.SetInt ("profile_0_array_W2S10_dots", dot_tail_turn_on_0_210);
				PlayerPrefs.SetInt ("profile_0_array_W2S10_stage_stars_score", stage_stars_score_0_210);
				PlayerPrefs.SetInt ("profile_0_array_W2S10_stage_int_score", best_int_score_in_this_stage_0_210);
				PlayerPrefs.SetInt ("profile_0_array_W2S11_stages_unlocked", stage_playable_0_211);
				PlayerPrefs.SetInt ("profile_0_array_W2S11_stage_solved", stage_solved_0_211);
				PlayerPrefs.SetInt ("profile_0_array_W2S11_dots", dot_tail_turn_on_0_211);
				PlayerPrefs.SetInt ("profile_0_array_W2S11_stage_stars_score", stage_stars_score_0_211);
				PlayerPrefs.SetInt ("profile_0_array_W2S11_stage_int_score", best_int_score_in_this_stage_0_211);
				PlayerPrefs.SetInt ("profile_0_array_W2S12_stages_unlocked", stage_playable_0_212);
				PlayerPrefs.SetInt ("profile_0_array_W2S12_stage_solved", stage_solved_0_212);
				PlayerPrefs.SetInt ("profile_0_array_W2S12_dots", dot_tail_turn_on_0_212);
				PlayerPrefs.SetInt ("profile_0_array_W2S12_stage_stars_score", stage_stars_score_0_212);
				PlayerPrefs.SetInt ("profile_0_array_W2S12_stage_int_score", best_int_score_in_this_stage_0_212);
				PlayerPrefs.SetInt ("profile_0_array_W2S13_stages_unlocked", stage_playable_0_213);
				PlayerPrefs.SetInt ("profile_0_array_W2S13_stage_solved", stage_solved_0_213);
				PlayerPrefs.SetInt ("profile_0_array_W2S13_dots", dot_tail_turn_on_0_213);
				PlayerPrefs.SetInt ("profile_0_array_W2S13_stage_stars_score", stage_stars_score_0_213);
				PlayerPrefs.SetInt ("profile_0_array_W2S13_stage_int_score", best_int_score_in_this_stage_0_213);
				PlayerPrefs.SetInt ("profile_0_array_W2S14_stages_unlocked", stage_playable_0_214);
				PlayerPrefs.SetInt ("profile_0_array_W2S14_stage_solved", stage_solved_0_214);
				PlayerPrefs.SetInt ("profile_0_array_W2S14_dots", dot_tail_turn_on_0_214);
				PlayerPrefs.SetInt ("profile_0_array_W2S14_stage_stars_score", stage_stars_score_0_214);
				PlayerPrefs.SetInt ("profile_0_array_W2S14_stage_int_score", best_int_score_in_this_stage_0_214);
				PlayerPrefs.SetInt ("profile_0_incremental_item_0_current_level", incremental_item_current_level_0_0);
				PlayerPrefs.SetInt ("profile_0_incremental_item_1_current_level", incremental_item_current_level_0_1);
				PlayerPrefs.SetInt ("profile_0_incremental_item_2_current_level", incremental_item_current_level_0_2);
				PlayerPrefs.SetInt ("profile_0_incremental_item_3_current_level", incremental_item_current_level_0_3);
				PlayerPrefs.SetInt ("profile_0_incremental_item_4_current_level", incremental_item_current_level_0_4);
				PlayerPrefs.SetInt ("profile_0_incremental_item_5_current_level", incremental_item_current_level_0_5);
				PlayerPrefs.SetInt ("profile_0_incremental_item_6_current_level", incremental_item_current_level_0_6);
				PlayerPrefs.SetInt ("profile_0_consumable_item_0_current_quantity", consumable_item_current_quantity_0_0);
				PlayerPrefs.SetInt ("profile_0_consumable_item_1_current_quantity", consumable_item_current_quantity_0_1);
				PlayerPrefs.SetInt ("profile_0_consumable_item_2_current_quantity", consumable_item_current_quantity_0_2);
				PlayerPrefs.SetInt ("profile_0_consumable_item_3_current_quantity", consumable_item_current_quantity_0_3);
				PlayerPrefs.SetInt ("profile_0_consumable_item_4_current_quantity", consumable_item_current_quantity_0_4);
				PlayerPrefs.SetInt ("profile_0_consumable_item_5_current_quantity", consumable_item_current_quantity_0_5);
				PlayerPrefs.SetInt ("profile_0_consumable_item_6_current_quantity", consumable_item_current_quantity_0_6);
				PlayerPrefs.SetInt ("profile_0_consumable_item_7_current_quantity", consumable_item_current_quantity_0_7);
				PlayerPrefs.SetInt ("profile_0_consumable_item_8_current_quantity", consumable_item_current_quantity_0_8);
				PlayerPrefs.SetInt ("profile_0_consumable_item_9_current_quantity", consumable_item_current_quantity_0_9);
				PlayerPrefs.SetInt ("profile_0_consumable_item_10_current_quantity", consumable_item_current_quantity_0_10);
				PlayerPrefs.SetInt ("profile_0_consumable_item_11_current_quantity", consumable_item_current_quantity_0_11);
				PlayerPrefs.SetInt ("profile_0_consumable_item_12_current_quantity", consumable_item_current_quantity_0_12);
				PlayerPrefs.SetInt ("profile_0_consumable_item_13_current_quantity", consumable_item_current_quantity_0_13);
				PlayerPrefs.SetInt ("profile_0_consumable_item_14_current_quantity", consumable_item_current_quantity_0_14);
				PlayerPrefs.SetInt ("profile_0_consumable_item_15_current_quantity", consumable_item_current_quantity_0_15);
				PlayerPrefs.SetInt ("profile_0_consumable_item_16_current_quantity", consumable_item_current_quantity_0_16);
				PlayerPrefs.SetInt ("profile_0_total_stars", starts);
				PlayerPrefs.SetInt ("profile_0_virtual_money", money);
				PlayerPrefs.SetInt ("profile_0_current_lives", lives);
				PlayerPrefs.SetInt ("profile_0_total_number_of_stages_in_the_game_solved", stages);
				PlayerPrefs.SetInt ("profile_0_best_int_score_for_this_profile", best_score);
				PlayerPrefs.SetInt ("profile_0_play_this_stage_to_progress", stage_progress);
				PlayerPrefs.SetInt ("profile_0_play_this_world_to_progress", world_progress);



		
			} 
		my_game_master.SimulateAwake ();
		my_manage_menu_uGUI.Back ();
	
		//mp.My_start ();

		
	}



	
	private void ActionGameSaveResult (GP_SpanshotLoadResult result) {
		GooglePlaySavedGamesManager.ActionGameSaveResult -= ActionGameSaveResult;
		Debug.Log("ActionGameSaveResult: " + result.Message);
		
		if(result.IsSucceeded) {
			AndroidToast.ShowToastNotification ("Saved game", 1); //SA_StatusBar.text = "Games Saved: " + result.Snapshot.meta.Title;
		} else {
			AndroidToast.ShowToastNotification ("Cant'n Saved game", 3);
			//SA_StatusBar.text = "Games Save Failed";
		}
		

	}	
	
	private void ActionConflict (GP_SnapshotConflict result) {
		
		Debug.Log("Conflict Detected: ");
		
		GP_Snapshot snapshot = result.Snapshot;
		GP_Snapshot conflictSnapshot = result.ConflictingSnapshot;
		
		// Resolve between conflicts by selecting the newest of the conflicting snapshots.
		GP_Snapshot mResolvedSnapshot = snapshot;
		
		if (snapshot.meta.LastModifiedTimestamp < conflictSnapshot.meta.LastModifiedTimestamp) {
			mResolvedSnapshot = conflictSnapshot;
		}
		
		result.Resolve(mResolvedSnapshot);
	}

	private void save(){
		
		int starts= PlayerPrefs.GetInt("profile_0_total_stars");
		//int money = PlayerPrefs.GetInt("profile_0_virtual_money");
		int money = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(0);
		int lives = PlayerPrefs.GetInt("profile_0_current_lives");
		int stages = PlayerPrefs.GetInt("profile_0_total_number_of_stages_in_the_game_solved");
		int best_score = PlayerPrefs.GetInt("profile_0_best_int_score_for_this_profile");
		int stage_progress = PlayerPrefs.GetInt("profile_0_play_this_stage_to_progress");
		int world_progress = PlayerPrefs.GetInt("profile_0_play_this_world_to_progress");
		
		for(int world = 0; world < my_game_master.total_stages_in_world_n.Length; world++)
		{
			
			world_purchased[0][world] = System.Convert.ToBoolean(PlayerPrefs.GetInt("profile_0_array_W"+world.ToString()+"_"+"world_purchased"));
			star_score_in_this_world[0][world] = PlayerPrefs.GetInt("profile_0_star_score_in_this_world");
			
			for(int stage = 0; stage < my_game_master.total_stages_in_world_n[world]; stage++)
			{
				//array bool
				stage_playable[0][world,stage] = System.Convert.ToBoolean(PlayerPrefs.GetInt("profile_0_array_W"+world.ToString()+"S"+stage.ToString()+"_"+"stages_unlocked")) ;
				stage_solved[0][world,stage] = System.Convert.ToBoolean(PlayerPrefs.GetInt("profile_0_array_W"+world.ToString()+"S"+stage.ToString()+"_"+"stage_solved")) ;
				dot_tail_turn_on[0][world,stage] = System.Convert.ToBoolean(PlayerPrefs.GetInt("profile_0_array_W"+world.ToString()+"S"+stage.ToString()+"_"+"dots")) ;
				
				//array int
				stage_stars_score[0][world,stage] = PlayerPrefs.GetInt("profile_0_array_W"+world.ToString()+"S"+stage.ToString()+"_"+"stage_stars_score") ;
				best_int_score_in_this_stage[0][world,stage] = PlayerPrefs.GetInt("profile_0_array_W"+world.ToString()+"S"+stage.ToString()+"_"+"stage_int_score") ;
			}
			
			if (PlayerPrefs.HasKey("profile_0_array_W"+world.ToString()+"_"+"world_unlocked"))
				world_playable[0][world] = System.Convert.ToBoolean(PlayerPrefs.GetInt("profile_0_array_W"+world.ToString()+"_"+"world_unlocked"));
			else
			{
				if (this_world_is_unlocked_after_selected[world] == this_world_is_unlocked_after.start)
				{
					world_playable[0][world] = true;
					stage_playable[0][world,0] = true;
				}
			}
		}
		for (int i = 0; i < my_game_master.my_store_item_manager.incremental_item_list.Length; i++)
		{
			incremental_item_current_level[0][i] = PlayerPrefs.GetInt("profile_0_incremental_item_"+i.ToString()+"_current_level");
		}
		for (int i = 0; i < my_game_master.my_store_item_manager.consumable_item_list.Length; i++)
		{
			consumable_item_current_quantity[0][i] = PlayerPrefs.GetInt("profile_0_consumable_item_"+i.ToString()+"_current_quantity");
		}
	}


	void Start () {
		int max_stages_in_a_world = 15;
		//save game
		GooglePlaySavedGamesManager.ActionNewGameSaveRequest += ActionNewGameSaveRequest;
		GooglePlaySavedGamesManager.ActionGameSaveLoaded += ActionGameSaveLoaded;
		GooglePlaySavedGamesManager.ActionConflict += ActionConflict;

		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			//GooglePlayConnection.Instance.Disconnect ();
			
		} else {
			GooglePlayConnection.Instance.Connect ();
		}


		if (functioncalled != "ShareFB" || functioncalled != "LikePage" || functioncalled != "RateDialogPopUp"  || functioncalled !="showAchievementsUI") {
			if (callfunction) {
				Invoke (functioncalled, 0);
			}
		}
		my_game_master = (game_master)game_master.game_master_obj.GetComponent("game_master");
		my_manage_menu_uGUI = GameObject.Find("Home_Canvas").GetComponent<manage_menu_uGUI>();



		world_playable = new bool[1][];
		world_purchased = new bool[1][];
		stage_playable = new bool[1][,];
		stage_solved = new bool[1][,];
		all_stages_solved = new bool[1];
		dot_tail_turn_on = new bool[1][,];
		stage_stars_score = new int[1][,];
		star_score_in_this_world = new int[1][];
		stars_total_score = new int[1];
		best_int_score_in_this_stage = new int[1][,];
		best_int_score_for_current_player = new int[1];
		
		incremental_item_current_level= new int[1][];
		
		consumable_item_current_quantity = new int[1][];
		
		for (int i = 0; i < 1; i++)
		{
			incremental_item_current_level[i] = new int[my_game_master.my_store_item_manager.incremental_item_list.Length];
			
			consumable_item_current_quantity[i] = new int[my_game_master.my_store_item_manager.consumable_item_list.Length];
			
			world_playable[i] = new bool[my_game_master.total_stages_in_world_n.Length];
			world_purchased[i] = new bool[my_game_master.total_stages_in_world_n.Length];
			stage_playable[i] = new bool[my_game_master.total_stages_in_world_n.Length,max_stages_in_a_world];
			stage_solved[i] = new bool[my_game_master.total_stages_in_world_n.Length,max_stages_in_a_world];
			stage_stars_score[i] = new int[my_game_master.total_stages_in_world_n.Length,max_stages_in_a_world];
			star_score_in_this_world[i] = new int[my_game_master.total_stages_in_world_n.Length];
			best_int_score_in_this_stage[i] = new int[my_game_master.total_stages_in_world_n.Length,max_stages_in_a_world]; 
			dot_tail_turn_on[i] = new bool[my_game_master.total_stages_in_world_n.Length,max_stages_in_a_world];
			
			//this_profile_have_a_save_state_in_it[i] = Convert.ToBoolean(PlayerPrefs.GetInt("profile_"+i.ToString()+"_have_a_save_state_in_it")) ;
			/*if (my_store_item_manager)
			{
				incremental_item_current_level[i] = new int[my_store_item_manager.incremental_item_list.Length]; 
				consumable_item_current_quantity[i] = new int[my_store_item_manager.consumable_item_list.Length];
			}*/
		}
	//	SPFacebook.Instance.OnInitCompleteAction += OnInit;
	//	SPFacebook.Instance.OnFocusChangedAction += OnFocusChanged;
		
		
	//	SPFacebook.Instance.OnAuthCompleteAction += OnAuth;
		
		
		
	//	SPFacebook.Instance.OnPostingCompleteAction += OnPost;

		
	//	SPFacebook.Instance.Init();


	
	}
	/*public void Connect() {
		if(!IsAuntificated) {
			SPFacebook.Instance.Login("email,publish_actions");

		} else {
			LogOut();

		}
	}
	*/
	/*private void OnInit() {
		if(SPFacebook.Instance.IsLoggedIn) {
			IsAuntificated = true;
		} else {

		}
	}*/



	private void OnFocusChanged(bool focus) {
		
	
		
		if (!focus)  {                                                                                        
			                                       
			Time.timeScale = 0;                                                                  
		} else  {                                                                                        
			                           
			Time.timeScale = 1;                                                                  
		}   
	}
	
/*	private void OnAuth(FBResult result) {
		if(SPFacebook.Instance.IsLoggedIn) {
			IsAuntificated = true;

		} else {

		}
		
	}

	private void OnPost(FBPostResult res) {
		
		if(res.IsSucceeded) {

		} else {

		}
	}
	*/


	/*
	private void LogOut() {
		IsUserInfoLoaded = false;
		
		IsAuntificated = false;
		
		SPFacebook.Instance.Logout();
	}
	*/
	public void PostNativeScreenshot() {
		StartCoroutine(PostFBScreenshot());
	}

	private IEnumerator PostFBScreenshot() {
		
		
		yield return new WaitForEndOfFrame();
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D( width, height, TextureFormat.RGB24, false );
		// Read screen contents into the texture
		tex.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		tex.Apply();
		

		AndroidSocialGate.StartShareIntent("Zombie Cross", "download zombie cross, and becomes the best survivor of the zombie apocalypse, https://play.google.com/store/apps/details?id=unity.zombiecross", tex,  "facebook.katana");
		
		Destroy(tex);
		
	}
	/*public void rate(){
		AN_PoupsProxy.showRateDialog(title, message, yes, later, no);
		Create (title, message,url);
	}*/
	public void RateDialogPopUp() {
		AndroidRateUsPopUp rate = AndroidRateUsPopUp.Create("Rate Us", rateText, rateUrl);
		rate.ActionComplete += OnRatePopUpClose;
	}
	private void OnRatePopUpClose(AndroidDialogResult result) {
		
		switch(result) {
		case AndroidDialogResult.RATED:
			AN_PoupsProxy.showMessage("Thanks", "for rate Zombie Cross");
			break;
		case AndroidDialogResult.REMIND:
			AN_PoupsProxy.showMessage("Thanks", "soon know about us");
			break;
		case AndroidDialogResult.DECLINED:
			AN_PoupsProxy.showMessage("Thanks", "remember, your opinion is important to us");
			break;
			
		}
		//AN_PoupsProxy.showMessage("Result", result.ToString() + " button pressed");
	}
	public void PageBKT() {
		Application.OpenURL("https://www.facebook.com/BKT-Games-762018407240812/");
	}
	public void LikePage() {
		Application.OpenURL("https://www.facebook.com/zombiecrossgame/");
	}
	public static AndroidRateUsPopUp Create(string title, string message, string url) {
		return Create(title, message, url, "Rate app", "Later", "No, thanks");
	}
	
	public static AndroidRateUsPopUp Create(string title, string message, string url, string yes, string later, string no) {
		AndroidRateUsPopUp rate = new GameObject("AndroidRateUsPopUp").AddComponent<AndroidRateUsPopUp>();
		rate.title = title;
		rate.message = message;
		rate.url = url;
		
		rate.yes = yes;
		rate.later = later;
		rate.no = no;
		
		rate.init();
		
		return rate;
	}

	public void LoadScene(string Scene){
		Application.LoadLevel (Scene);
	}
	//end facebook
	public void SENDACHIEVEMENT(string id) {
		
		GooglePlayManager.Instance.UnlockAchievement (id);
	}
	
	public void SENDACHIEVEMENTINCREMENT(string id,int increment) {
		
		GooglePlayManager.Instance.IncrementAchievementById (id, increment);
	}
	//google play
	public void showLeaderBoardsUI() {
		GooglePlayManager.Instance.ShowLeaderBoardsUI ();

	}

	public void showLeaderBoard() {
		GooglePlayManager.Instance.ShowLeaderBoardById (LEADERBOARD_ID);

	}

	public void showAchievementsUI() {
		GooglePlayManager.Instance.ShowAchievementsUI ();
	}

	public void ConncetButtonPress() {

		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			GooglePlayConnection.Instance.Disconnect ();
		} else {
			GooglePlayConnection.Instance.Connect ();
		}
	  
	}
	// Update is called once per frame

	public void SmartBottom() {
		banner2 = AndroidAdMobController.Instance.CreateAdBanner(TextAnchor.LowerCenter, GADBannerSize.SMART_BANNER);
		//banner2.Show();
	}
	
	
	public void B2Hide() {
		banner2.Hide();
	}
	
	
	public void B2Show() {
		banner2.Show();
	}

}
