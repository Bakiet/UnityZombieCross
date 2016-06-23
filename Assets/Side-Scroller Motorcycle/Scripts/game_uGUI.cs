using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Soomla.Profile;
using Soomla.Store;
using System.Collections.Generic;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class game_uGUI : MonoBehaviour {
	/*
	private string rateText = "If you enjoy playing Zombie Cross, please take a moment to rate it. Thanks for your support!";
	//example link to your app on android market
	private string rateUrl = "https://play.google.com/store/apps/details?id=unity.zombiecross";
	*/
	
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
	private static int temptutorial = 0;
	private int next_tutorial = 0;
	private int healtcount = 0;
	private const string LEADERBOARD_ID = "CgkIq6GznYALEAIQAA";
	private const string LEADERBOARD_MULTIPLAYER_ID = "CgkIq6GznYALEAIQAQ";
	[SerializeField]private EventSystem my_eventSystem = null;

	public int n_world;//the current world. It is need to save and load in the corret slot
	public int n_stage;//the number of this stage. It is need to save and load in the corret slot
	public AudioClip stage_music;
	
	public bool ignore_game_master_preferences;
	
	//ads
	public gift_manager my_gift_manager;
	public feedback_window my_feedback_window;
	[HideInInspector]public GameObject double_score;
	bool score_doubled;
	
	[HideInInspector]public Transform play_screen;
	[HideInInspector]public Transform pause_screen;
	[HideInInspector]public Transform loading_screen;
	public Transform options_screen;
	public Transform tutorial_screen;
	options_menu my_options;

	[HideInInspector]public Transform win_screen;
	[HideInInspector]public Transform lose_screen;
	[HideInInspector]public GameObject retry_button;
	public GameObject return_to_home;
	[HideInInspector]public GameObject stage_button;
	[HideInInspector]public continue_window my_continue_window;
	
	//what button select with the pad when open this screen
	public GameObject tutorial_screen_target_button;
	public GameObject options_screen_target_button;
	[HideInInspector]public GameObject pause_screen_target_button;
	[HideInInspector]public GameObject win_screen_target_button;
	[HideInInspector]public GameObject lose_screen_target_button;
	[HideInInspector]public GameObject continue_window_target_button;
	
	[HideInInspector]public GameObject lives_ico;
	[HideInInspector]public Text lives_count;
	
	public bool show_virtual_money;
	public bool keep_money_taken_in_this_stage_only_if_you_win;
	int temp_money_count;
	[HideInInspector]public GameObject virtual_money_ico;
	[HideInInspector]public Text virtual_money_count;
	
	[HideInInspector]public GameObject int_score_ico;
	[HideInInspector]public Text int_score_count;
	[HideInInspector]public GameObject int_score_record_ico;
	[HideInInspector]public Text int_score_record;
	[HideInInspector]public Text win_screen_int_score_title;
	[HideInInspector]public GameObject int_score_record_anim;
	string temp_score_name;
	[HideInInspector]public Text win_screen_int_score_count;
	[HideInInspector]public Text win_screen_int_score_record;
	bool new_record;
	
	public bool show_star_score;
	public bool show_star_count;
	public bool show_progress_bar;
	public progress_bar my_progress_bar;
	public bool progress_bar_use_score;
	
	public bool show_int_score;
	public bool show_stage_record;
	public GameObject stars_ico;
	[HideInInspector]public Text stars_count;
	
	[HideInInspector]public GameObject lose_screen_lives_ico;
	[HideInInspector]public Text lose_screen_lives_count;
	
	[HideInInspector]public GameObject next_stage_ico;
	
	//win screen
	public float delay_start_star_score_animation = 1;
	public float delay_star_creation = 0.10f; // recommend value = 1
	[HideInInspector]public GameObject star_container;
	public GameObject images_tutorial_container;
	public GameObject[] tutorial_on;

	public GameObject[] stars_on;
	int invoke_count = 0;
	[HideInInspector]public int star_number;
	[HideInInspector]public int int_score;
	public Sprite perfect_emoticon;
	[HideInInspector]public Image perfect_target;
	Sprite normal_emoticon;
	
	public static bool allow_game_input;//this is false when a menu is open
	public static bool in_pause;
	public static bool stage_end;
	
	game_master my_game_master;
	
	public bool restart_without_reload_the_stage;
	[HideInInspector]public bool restarting;
	
	public bool show_debug_messages;
	public bool show_debug_warnings;

	public static bool isfinish=false;
	public int funds=0;
	// Use this for initialization
	/*
	public void RateDialogPopUp() {
		AndroidRateUsPopUp rate = AndroidRateUsPopUp.Create("Rate Us", rateText, rateUrl);
		rate.ActionComplete += OnRatePopUpClose;
	}
	private void ShowPreloader() {
		Invoke("HidePreloader", 2f);
		AndroidNativeUtility.ShowPreloader("Loading", "Wait 2 seconds please");
	}
	
	private void HidePreloader() {
		AndroidNativeUtility.HidePreloader();
	}
	
	private void OpenRatingPage() {
		AndroidNativeUtility.OpenAppRatingPage(rateUrl);
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

	
	
	
	private void OnDialogClose(AndroidDialogResult result) {
		
		//parsing result
		switch(result) {
		case AndroidDialogResult.YES:
			Debug.Log ("Yes button pressed");
			break;
		case AndroidDialogResult.NO:
			Debug.Log ("No button pressed");
			break;
			
		}
		
		AN_PoupsProxy.showMessage("Result", result.ToString() + " button pressed");
	}
	
	*/
	
	private void OnMessageClose(AndroidDialogResult result) {
		AN_PoupsProxy.showMessage("Result", "Message Closed");
	}
	public void PageBKT() {
		Application.OpenURL("https://www.facebook.com/BKT-Games-762018407240812/");
	}
	public void LikePage() {
		Application.OpenURL("https://www.facebook.com/zombiecrossgame/");
	}
	public void PlayStorePage() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=unity.zombiecross");
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

	private void ActionNewGameSaveRequest () {
		//SA_StatusBar.text = "New  Game Save Requested, Creating new save..";
		//Debug.Log("New  Game Save Requested, Creating new save..");
		StartCoroutine(MakeScreenshotAndSaveGameData());
		
		AndroidMessage.Create("Result", "New Game Save Request");
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

	private void ActionGameSaveResult (GP_SpanshotLoadResult result) {
		GooglePlaySavedGamesManager.ActionGameSaveResult -= ActionGameSaveResult;
		Debug.Log("ActionGameSaveResult: " + result.Message);
		
		if(result.IsSucceeded) {
			AndroidToast.ShowToastNotification ("Saved game", 1); //SA_StatusBar.text = "Games Saved: " + result.Snapshot.meta.Title;
		} else {
			AndroidToast.ShowToastNotification ("Cant'n Saved game", 1);
			//SA_StatusBar.text = "Games Save Failed";
		}
		
		//AndroidMessage.Create("Zombie Cross", "Saved game");
	}	
	public void CreateNewSnapshot() {
		StartCoroutine(MakeScreenshotAndSaveGameData());
	}
	private void save(){
		/*
		starts= PlayerPrefs.GetInt("profile_0_total_stars");
		//int money = PlayerPrefs.GetInt("profile_0_virtual_money");
		money = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(0);
		lives = PlayerPrefs.GetInt("profile_0_current_lives");
		stages = PlayerPrefs.GetInt("profile_0_total_number_of_stages_in_the_game_solved");
		best_score = PlayerPrefs.GetInt("profile_0_best_int_score_for_this_profile");
		stage_progress = PlayerPrefs.GetInt("profile_0_play_this_stage_to_progress");
		world_progress = PlayerPrefs.GetInt("profile_0_play_this_world_to_progress");
		*/
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
		money = PlayerPrefs.GetInt("profile_0_virtual_money");
		//my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(0);
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
		//AndroidMessage.Create("Snapshot Created", "Data: Starts: " + starts + " Coins: " + money + " Lives: " + lives + " stages: " + stages + " best_score: " + best_score + " stage_progress: " + stage_progress+ " world_progress: " + world_progress+ " world_purchased: " + world_purchased+ " star_score_in_this_world: " + star_score_in_this_world+ " stage_playable: " + stage_playable+ " stage_solved: " + stage_solved+ " dot_tail_turn_on: " + dot_tail_turn_on+ " stage_stars_score: " + stage_stars_score+ " best_int_score_in_this_stage: " + best_int_score_in_this_stage+ " world_playable: " + world_playable);



		yield return new WaitForEndOfFrame();
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		Texture2D Screenshot = new Texture2D( width, height, TextureFormat.RGB24, false );
		// Read screen contents into the texture
		Screenshot.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		Screenshot.Apply();
		
		
		long TotalPlayedTime = 20000;
		string currentSaveName =  "snapshotTemp-" + UnityEngine.Random.Range(1, 281).ToString();
		//string currentSaveName =  "snapshotTemp";
		//string currentSaveName =  "Saved Game";
		//string description  = "Modified data at: " + System.DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");
		string description  = "Starts:" + starts + " Coins:" + money + " Lives:" + lives+ " Level:"+ stage_progress +" and purchases.";
		
		
		GooglePlaySavedGamesManager.ActionGameSaveResult += ActionGameSaveResult;
		GooglePlaySavedGamesManager.instance.CreateNewSnapshot(currentSaveName, description, Screenshot, saveData, TotalPlayedTime);
		

		
		Destroy(Screenshot);
	}


	void Start () {
		int max_stages_in_a_world = 15;


		GetComponent<AudioSource>().volume = 0.4f;
		n_world = Convert.ToInt32(Application.loadedLevelName.Substring(1,1));
		if(Application.loadedLevelName.Length > 10){
		n_stage = Convert.ToInt32(Application.loadedLevelName.Substring(9,2));
		}else{
			n_stage = Convert.ToInt32(Application.loadedLevelName.Substring(9,1));
		}

		isfinish=false;
		in_pause = false;
		GooglePlayConnection.ActionPlayerConnected +=  OnPlayerConnected;
		GooglePlayConnection.ActionPlayerDisconnected += OnPlayerDisconnected;		
		GooglePlayConnection.ActionConnectionResultReceived += OnConnectionResult;
		GooglePlayManager.ActionScoreSubmited += OnScoreSbumitted;

		GooglePlaySavedGamesManager.ActionNewGameSaveRequest += ActionNewGameSaveRequest;
	//	GooglePlaySavedGamesManager.ActionGameSaveLoaded += ActionGameSaveLoaded;
		GooglePlaySavedGamesManager.ActionConflict += ActionConflict;

		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			//GooglePlayConnection.Instance.Disconnect ();
			
		} else {
			GooglePlayConnection.Instance.Connect ();
		}
		/*
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			//GooglePlayConnection.Instance.Disconnect ();
		} else {
			GooglePlayConnection.Instance.Connect ();
		}*/

		my_options = options_screen.GetComponent<options_menu>();

		//normal_emoticon = perfect_target.sprite;


		if (game_master.game_master_obj)
		{
			my_store_item_manager = game_master.game_master_obj.GetComponent<store_item_manager>();
			my_game_master = (game_master)game_master.game_master_obj.GetComponent("game_master");
			my_game_master.my_ads_master.my_game_uGUI = this;
		}
		funds = StoreInventory.GetItemBalance("Coins");

		my_game_master = (game_master)game_master.game_master_obj.GetComponent("game_master");

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
		Update_virtual_money (funds);

		if (my_game_master)
		{
			//set ads gui
			my_game_master.music_source.Stop();
			my_game_master.my_ads_master.Initiate_ads();
			my_game_master.my_ads_master.my_feedback_window = my_feedback_window;
			my_game_master.my_ads_master.my_gift_manager = my_gift_manager;
			my_gift_manager.my_game_master = my_game_master;
			if(Application.loadedLevelName != "Home"){
			//my_game_master.Start_music(my_game_master.music_menu,false);
				my_game_master.music_source.enabled  = false;
			}
			else{
				my_game_master.music_source.enabled  = true;
				my_game_master.Start_music(my_game_master.music_menu,false);
			}
			//my_game_master.Start_music(my_game_master.music_menu,false);
			//my_game_master.music_menu =null;
			//star score
			if (!ignore_game_master_preferences)
			{
				show_star_score = my_game_master.show_star_score;
				show_progress_bar = my_game_master.show_progres_bar;
				//int score
				show_int_score = my_game_master.show_int_score;
			}
			show_stage_record = my_game_master.show_int_score_stage_record_in_game_stage;
			
			
			if (my_game_master.score_name != "")
				int_score_ico.GetComponent<Text>().text = my_game_master.score_name;
			
			if (!ignore_game_master_preferences)
			{
				show_debug_messages = my_game_master.show_debug_messages;
				show_debug_warnings = my_game_master.show_debug_warnings;
			}
			
			my_game_master.latest_stage_played_world[my_game_master.current_profile_selected] = n_world;
			my_game_master.latest_stage_played_stage[my_game_master.current_profile_selected] = n_stage;
			
			
			my_game_master.current_world[my_game_master.current_profile_selected] = n_world-1;
		}
		else
		{
			temp_score_name = win_screen_int_score_title.text;
			if (show_debug_warnings)
				Debug.LogWarning("In order to allow saves and play music and menu sfx, you must star from Home scene and open this stage using the in game menu");
		}


		//star score
		if (show_star_score)
			star_container.SetActive(true);
		else
		{
			show_star_count = false;
			star_container.SetActive(false);
		}
		if (show_progress_bar)
		{
			my_progress_bar.Start_me(this);
			my_progress_bar.gameObject.SetActive (true);
		}
		else
			my_progress_bar.gameObject.SetActive (false);
		
		//int score
		if (show_int_score)
		{
			int_score_ico.SetActive(true);
		}
		else
			int_score_ico.SetActive(false);
		
		Reset_me();
		if (Application.loadedLevelName == "W1_Stage_1") {
			temptutorial = temptutorial + 1;
			if(temptutorial <= 1){
			Open_tutorial(true);
			}
		}
	}
	private void OnPlayerDisconnected() {
		
	}
	
	private void OnPlayerConnected() {
		
	}
	
	private void OnConnectionResult(GooglePlayConnectionResult result) {
		
	}
	public void LoadScore() {
		
		
	}
	
	void OnScoreSbumitted (GP_LeaderboardResult result) {
		//SA_StatusBar.text = "Score Submit Resul:  " + result.message;
		LoadScore();
	}
	public void Reset_me()
	{
		if (show_debug_messages)
			Debug.Log("reset stage game gui");
		
		Time.timeScale = 1;
		
		if (my_game_master)
		{
			//music

			//my_game_master.Start_music(stage_music,true);
			
			//lives
			if (my_game_master.infinite_lives)
				lives_ico.SetActive(false);
			else
				Update_lives(0);
			
			my_game_master.star_score_difference = 0;
			
			if (!keep_money_taken_in_this_stage_only_if_you_win){
				virtual_money_count.text = my_game_master.current_virtual_money[my_game_master.current_profile_selected].ToString();
				//virtual_money_count.text = "150";
			}
			
		}
		
		
		//reset int score
		double_score.SetActive(false);
		score_doubled = false;
		int_score = 0;
		int_score_count.text = (0).ToString("N0");
		win_screen_int_score_title.gameObject.SetActive(false);
		int_score_record_anim.SetActive (false);
		if (my_game_master)
			win_screen_int_score_title.text = my_game_master.score_name;
		else
			win_screen_int_score_title.text = temp_score_name;
		win_screen_int_score_count.text = (0).ToString("N0");
		new_record = false;
		win_screen_int_score_record.gameObject.SetActive(new_record);
		win_screen_int_score_record.text = "";
		if (show_stage_record && my_game_master && !ignore_game_master_preferences)
		{
			int_score_record.text = (my_game_master.best_int_score_in_this_stage [my_game_master.current_profile_selected] [n_world - 1, n_stage - 1]).ToString ("N0");
			int_score_record_ico.SetActive (true);
		}
		else
			int_score_record_ico.SetActive (false);
		
		//virtual money
		temp_money_count = 0;
		if (keep_money_taken_in_this_stage_only_if_you_win || !my_game_master)
			virtual_money_count.text = temp_money_count.ToString();
		
		//reset star score
		star_number = 0;
		if (show_star_count)
		{
			stars_count.text = (0).ToString();
			stars_ico.gameObject.SetActive(true);
		}
		else
			stars_ico.gameObject.SetActive(false);
		
		//reset win screen
		win_screen.gameObject.SetActive(false);
		tutorial_screen.gameObject.SetActive(false);
		//perfect_target.sprite = normal_emoticon;
		for (int i = 0; i < 3; i++)
		{
			stars_on[i].transform.localScale = Vector3.zero;
			stars_on[i].SetActive(false);
		}
		
		//reset lose screen
		lose_screen.gameObject.SetActive(false);
		
		
		loading_screen.gameObject.SetActive(false);
		pause_screen.gameObject.SetActive(false);
		
		//start
		allow_game_input = true;
		in_pause = false;
		stage_end = false;
		play_screen.gameObject.SetActive(true);
		
		if(my_game_master)
			my_game_master.my_ads_master.Call_ad(my_game_master.my_ads_master.ads_when_stage_start);
		
	}
	
	
	
	void Update()
	{
		
		
		if (my_game_master)
		{
			if ( Input.GetKeyDown(my_game_master.pad_pause_button) && !my_continue_window.gameObject.activeSelf
			    && (play_screen.gameObject.activeSelf || pause_screen.gameObject.activeSelf) )
				Pause();
			
			Manage_ESC();
			Manage_pad_back();
		}
		
	}
	
	void Manage_pad_back()
	{
		if ((Input.GetKeyDown(my_game_master.pad_back_button) && my_game_master.use_pad))
		{
			if (!play_screen.gameObject.activeSelf)
			{
				if (play_screen.gameObject.activeSelf || pause_screen.gameObject.activeSelf)
				{
					Pause();
				}
				else 
				{
					if (options_screen.gameObject.activeSelf)
						Close_options_menu(true);
					else
						Go_to_stage_screen();
				}
			}
		}
	}
	
	void Manage_ESC()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && my_game_master.allow_ESC)
		{
			if (!my_continue_window.gameObject.activeSelf)
			{
				if ((play_screen.gameObject.activeSelf || pause_screen.gameObject.activeSelf))
					Pause();
				else if (options_screen.gameObject.activeSelf)
					Close_options_menu(true);
				else
					Go_to_stage_screen();
			}
		}
	}
	public void Open_tutorial(bool from_pause_screen)
	{
		if (my_game_master)
		{
			if (from_pause_screen){
				pause_screen.gameObject.SetActive(false);
				in_pause = true;
				allow_game_input = false;

			}
			else
			{
				in_pause = false;
				allow_game_input = false;
				play_screen.gameObject.SetActive(false);
				Time.timeScale = 0;
			}
			
			tutorial_screen.gameObject.SetActive(true);

			Mark_this_button(tutorial_screen_target_button);
		}
		else
		{
			if (show_debug_warnings)
				Debug.LogWarning("In order to allow saves and play music and menu sfx, you must star from Home scene and open this stage using the in game menu");
		}
	}
	public void Close_Tutorial(bool back_to_pause_screen)
	{
		tutorial_screen.gameObject.SetActive(false);
		if (back_to_pause_screen)
		{
			pause_screen.gameObject.SetActive(true);
			Mark_this_button(pause_screen_target_button);

			in_pause = false;
			allow_game_input = true;
			play_screen.gameObject.SetActive(true);


		}
		else
		{
			in_pause = false;
			allow_game_input = true;
			play_screen.gameObject.SetActive(true);
			Time.timeScale = 1;
		}
	}

	public void Open_options_menu(bool from_pause_screen)
	{
		if (my_game_master)
		{
			if (from_pause_screen)
				pause_screen.gameObject.SetActive(false);
			else
			{
				in_pause = true;
				allow_game_input = false;
				play_screen.gameObject.SetActive(false);
				Time.timeScale = 0;
			}
			
			options_screen.gameObject.SetActive(true);
			my_options.Start_me();
			Mark_this_button(options_screen_target_button);
		}
		else
		{
			if (show_debug_warnings)
				Debug.LogWarning("In order to allow saves and play music and menu sfx, you must star from Home scene and open this stage using the in game menu");
		}
	}
	
	public void Close_options_menu(bool back_to_pause_screen)
	{
		options_screen.gameObject.SetActive(false);
		if (back_to_pause_screen)
		{
			pause_screen.gameObject.SetActive(true);
			Mark_this_button(pause_screen_target_button);
		}
		else
		{
			in_pause = false;
			allow_game_input = true;
			play_screen.gameObject.SetActive(true);
			Time.timeScale = 1;
		}
	}
	
	public void Pause()
	{
		if (my_game_master)
			my_game_master.Gui_sfx(my_game_master.tap_sfx);
		
		if (in_pause)
		{
			in_pause = false;
			allow_game_input = true;
			play_screen.gameObject.SetActive(true);
			Time.timeScale = 1;
			pause_screen.gameObject.SetActive(false);
			Mark_this_button(null);
		}
		else
		{
			in_pause = true;
			allow_game_input = false;
			play_screen.gameObject.SetActive(false);
			pause_screen.gameObject.SetActive(true);
			Time.timeScale = 0;
			
			Mark_this_button(pause_screen_target_button);
		}
		
	}
	
	public void Mark_this_button(GameObject target_button)
	{
		if (show_debug_messages)
		{
			if (target_button)
				Debug.Log("Mark_this_button: " + target_button.name);
			else
				if (show_debug_messages)
					Debug.Log("NULL");
		}
		
		if(my_game_master && my_game_master.use_pad)
		{
			my_eventSystem.SetSelectedGameObject(target_button);
		}
	}
	
	public void Mark_continue()
	{
		if (show_debug_messages)
			Debug.Log("Mark_continue()");
		Mark_this_button(continue_window_target_button);
	}
	
	
	
	public void Retry()
	{
		if (my_game_master)
		{
			my_game_master.Gui_sfx(my_game_master.tap_sfx);
			//my_game_master.Unlink_me_to_camera();
			if (my_game_master.show_loading_screen)
				loading_screen.gameObject.SetActive(true);
		}
		//reload this stage
		if (restart_without_reload_the_stage) {
			restarting = true;
			Reset_me();
		} else {
			if(Checkpoint.lastPoint != null){
			Checkpoint.Reset ();
			lose_screen.gameObject.SetActive (false);
			options_screen.gameObject.SetActive(false);
			tutorial_screen.gameObject.SetActive(false);
			play_screen.gameObject.SetActive(true);
			loading_screen.gameObject.SetActive(false);
			pause_screen.gameObject.SetActive(false);
				Pause();
			in_pause = false;

			}else{
				Application.LoadLevel (Application.loadedLevel);
				//in_pause = false;
			}
		}
	}


	
	public void Next()
	{
		if (my_game_master)
		{
            if (my_game_master.press_start_and_go_to_selected != game_master.press_start_and_go_to.map) { 
                my_game_master.Gui_sfx(my_game_master.tap_sfx);
			//my_game_master.Unlink_me_to_camera();
			
			    if(n_stage < my_game_master.total_stages_in_world_n[n_world-1])//there are more stages in this world to play
			    {
				    int next_stage = n_stage+1;
				    int next_world = n_world;
				    if (show_debug_messages)
					    Debug.Log("there are more stage in this world, so go to " + "W"+next_world.ToString()+"_Stage_" + next_stage.ToString());
				    if (my_game_master.show_loading_screen)
					    loading_screen.gameObject.SetActive(true);
				    Application.LoadLevel ("W"+next_world.ToString()+"_Stage_" + next_stage.ToString()); 
			    }
			    else //go to next word if exist
			    {
				    if (n_world < my_game_master.total_stages_in_world_n.Length)
				    {
					    if (my_game_master.world_playable[my_game_master.current_profile_selected][n_world] && my_game_master.stage_playable[my_game_master.current_profile_selected][n_world,0])
					    {
						    int next_world = n_world+1;
						    if (show_debug_messages)
							    Debug.Log("go to next world " + ("W"+next_world.ToString()+"_Stage_1"));
						    if (my_game_master.show_loading_screen)
							    loading_screen.gameObject.SetActive(true);
						    Application.LoadLevel ("W"+next_world.ToString()+"_Stage_1"); 
					    }
					    else 
						    Go_to_stage_screen();
				    }
				    else //this was the last stage, so...
					    my_game_master.All_stages_solved();
			    }
            }
            else
            {
                Go_to_stage_screen();
            }
        }
		else
		{
			if (show_debug_warnings)
				Debug.LogWarning("You must start the game from Home scene in order to use this button");
		}
	}

	public void Go_to_Checkpoint()
	{
		/*Checkpoint.Reset ();
		lose_screen.gameObject.SetActive (false);
		play_screen.gameObject.SetActive(true);*/

	}
	
	public void Go_to_stage_screen()
	{
		if (my_game_master)
		{
			my_game_master.Gui_sfx(my_game_master.tap_sfx);
			//my_game_master.Unlink_me_to_camera();
			my_game_master.go_to_this_screen = game_master.this_screen.stage_screen;
			Time.timeScale = 1;
			if (my_game_master.show_loading_screen)
				loading_screen.gameObject.SetActive(true);
			Application.LoadLevel (my_game_master.home_scene_name); 
		}
		else
		{
			if (show_debug_warnings)
				Debug.LogWarning("You must start the game from Home scene in order to use this button");
		}
	}
	
	public void Go_to_Home_screen()
	{
		if (my_game_master)
		{
			my_game_master.refresh_stage_and_world_screens = true;
			my_game_master.Gui_sfx(my_game_master.tap_sfx);
			//my_game_master.Unlink_me_to_camera();
			my_game_master.go_to_this_screen = game_master.this_screen.home_screen;
			Time.timeScale = 1;
			if (my_game_master.show_loading_screen)
				loading_screen.gameObject.SetActive(true);
			Application.LoadLevel (my_game_master.home_scene_name); 
		}
		else
		{
			if (show_debug_warnings)
				Debug.LogWarning("You must start the game from Home scene in order to use this button");
		}
	}
	
	public void Update_virtual_money(int money)
	{
		//Debug.Log("money: " + money);
		//Debug.Log(my_game_master.current_virtual_money[my_game_master.current_profile_selected]);
		//Debug.Log((my_game_master.current_virtual_money[my_game_master.current_profile_selected] + money));
		if (keep_money_taken_in_this_stage_only_if_you_win)
		{
			temp_money_count += money;
			virtual_money_count.text = temp_money_count.ToString();
		}
		else
		{
			if (my_game_master)
			{
				if ((my_game_master.current_virtual_money[my_game_master.current_profile_selected] + money) <= my_game_master.virtual_money_cap  )
				{
					if (my_game_master.buy_virtual_money_with_real_money_with_soomla)
					{
						// DELETE THIS LINE FOR SOOMLA
						my_game_master.my_Soomla_billing_script.Give_virtual_money_for_free(my_game_master.current_profile_selected,money);
					//	my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(my_game_master.current_profile_selected);
						my_game_master.current_virtual_money[my_game_master.current_profile_selected] = PlayerPrefs.GetInt("profile_0_virtual_money");
						 //DELETE THIS LINE FOR SOOMLA
					}
					else
						my_game_master.current_virtual_money[my_game_master.current_profile_selected] += money;
					
					if (show_debug_messages)
						Debug.Log("add money: " + money);
				}
				else
				{
					if (my_game_master.buy_virtual_money_with_real_money_with_soomla)
					{
						// DELETE THIS LINE FOR SOOMLA
						my_game_master.my_Soomla_billing_script.Give_virtual_money_for_free(my_game_master.current_profile_selected,(my_game_master.virtual_money_cap-my_game_master.current_virtual_money[my_game_master.current_profile_selected]));
						//my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(my_game_master.current_profile_selected);
						my_game_master.current_virtual_money[my_game_master.current_profile_selected] = PlayerPrefs.GetInt("profile_0_virtual_money");
						 //DELETE THIS LINE FOR SOOMLA
					}
					else
						my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.virtual_money_cap;
					
					if (show_debug_messages)
						Debug.Log("virtual money cap");
				}
				
				PlayerPrefs.SetInt("profile_"+my_game_master.current_profile_selected.ToString()+"_virtual_money",	my_game_master.current_virtual_money[my_game_master.current_profile_selected]);
				virtual_money_count.text = my_game_master.current_virtual_money[my_game_master.current_profile_selected].ToString();
				
				
			}
			else
			{
				if (show_debug_warnings)
					Debug.LogWarning("You must start the game from Home scene in order to save virtual money in a game profile");
			}
		}
	}
	
	public void Update_lives(int live_variation)
	{
		bool dead = false;
		if (my_game_master)
		{
			if (!my_game_master.infinite_lives)
			{
				/*int health = StoreInventory.GetItemBalance ("health");
				
				if (health != 0) {
					healtcount = healtcount + 5 * health;
				}
				int healthx2 = StoreInventory.GetItemBalance ("healthx2");
				int healtcountx2 = 0;
				if (healthx2 != 0) {
					healtcount = healtcount + 10 * healthx2;
				}
				int healthx3 = StoreInventory.GetItemBalance ("healthx3");
				int healtcountx3 = 0;
				if (healthx3 != 0) {
					healtcount = healtcount + 15 * healthx3;
				}
				*/
				//healtcount = healtcount + Convert.ToIntlive_variation32(my_game_uGUI.lives_count);
				//healtcount = healtcount -live_variation;
				my_game_master.current_lives[my_game_master.current_profile_selected] += live_variation;
				healtcount = 0;
				if (show_debug_messages)
					Debug.Log("lives = " + my_game_master.current_lives[my_game_master.current_profile_selected]);
				
				
				if (my_game_master.current_lives[my_game_master.current_profile_selected] > my_game_master.live_cap)
					my_game_master.current_lives[my_game_master.current_profile_selected] = my_game_master.live_cap;
				else if (my_game_master.current_lives[my_game_master.current_profile_selected] <= 0)
				{
					my_game_master.current_lives[my_game_master.current_profile_selected] = 0;
					dead = true;
				}
				else
					dead = false;
				my_game_master.Save(my_game_master.current_profile_selected);
				
				if (dead)
				{
					if (my_game_master.lose_lives_selected == game_master.lose_lives.in_game)
					{
						if (my_game_master.continue_rule_selected != game_master.continue_rule.never_continue)
						{//ask if you want continue
							if (my_game_master.my_ads_master.ads_when_continue_screen_appear.this_ad_is_enabled)
								my_continue_window.Start_me_with_ad(my_game_master.my_ads_master.ads_when_continue_screen_appear);
							else
								my_continue_window.Start_me();
						}
						else
						{//ultimate lose
							Defeat();
						}
					}
					else if (my_game_master.lose_lives_selected == game_master.lose_lives.when_show_lose_screen)
					{
						if (my_game_master.continue_rule_selected != game_master.continue_rule.never_continue)
						{//ask if you want continue
							if (my_game_master.my_ads_master.ads_when_continue_screen_appear.this_ad_is_enabled)
								my_continue_window.Start_me_with_ad(my_game_master.my_ads_master.ads_when_continue_screen_appear);
							else
								my_continue_window.Start_me();
						}
					}
				}
				else 
				{
					//player continue to play from check point in this state or after new live animation, etcetera...
					//these behavior are managed from yours scripts and not from this generic gui system
				}
				
				lives_count.text = my_game_master.current_lives[my_game_master.current_profile_selected].ToString();
				lose_screen_lives_count.text = my_game_master.current_lives[my_game_master.current_profile_selected].ToString();
			}
		}
		else
		{
			if (show_debug_warnings)
				Debug.LogWarning("You must start the game from Home scene in order to keep track of lives");
		}
	}
	
	public void Update_int_score(int points)
	{
		int_score += points;
		int_score_count.text = int_score.ToString("N0");
		if (show_progress_bar && progress_bar_use_score)
			my_progress_bar.Update_fill (int_score);
	}
	
	public void Update_int_score()
	{
		int_score_count.text = int_score.ToString("N0");
		if (show_progress_bar && progress_bar_use_score)
			my_progress_bar.Update_fill (int_score);
	}
	public void Next_tutorial(){

		next_tutorial = next_tutorial+1;
		if (next_tutorial >= 3) {
			next_tutorial = 0;

			tutorial_on[0].SetActive(false);
			tutorial_on[1].SetActive(false);
			tutorial_on[2].SetActive(false);

		}
		//foreach (GameObject t in tutorial_on) {
			tutorial_on[next_tutorial].SetActive(true);
		//}

		//Invoke("Star_sfx",delay_star_creation*n_star);
	}

	public void Add_stars(int quantity)
	{
		star_number += quantity;//add star
		stars_count.text = star_number.ToString();//update gui
	}
	
	public void New_star_score(int star_total)
	{
		star_number = star_total;//add star
		stars_count.text = star_number.ToString();//update gui
	}
	
	void Update_int_score_record()
	{
		if (int_score > 0)
		{
			new_record = true;
			
			if (show_debug_messages)
				Debug.Log("new stage int record!");
			
			if (my_game_master.what_say_if_new_stage_record != "")
				win_screen_int_score_record.text = my_game_master.what_say_if_new_stage_record;
			
			my_game_master.best_int_score_in_this_stage[my_game_master.current_profile_selected][n_world-1,n_stage-1] = int_score;
			PlayerPrefs.SetInt("profile_"+my_game_master.current_profile_selected.ToString()+"_array_W"+(n_world-1).ToString()+"S"+(n_stage-1).ToString()+"_"+"stage_int_score",my_game_master.best_int_score_in_this_stage[my_game_master.current_profile_selected][n_world-1,n_stage-1]);
			
			
			if (int_score > my_game_master.best_int_score_for_current_player[my_game_master.current_profile_selected])
			{
				if (show_debug_messages)
					Debug.Log("new personal record!");
				
				if (my_game_master.what_say_if_new_personal_record != "")
					win_screen_int_score_record.text = my_game_master.what_say_if_new_personal_record;
				
				my_game_master.best_int_score_for_current_player[my_game_master.current_profile_selected] = int_score;
				PlayerPrefs.SetInt("profile_"+my_game_master.current_profile_selected.ToString()+"_best_int_score_for_this_profile",my_game_master.best_int_score_for_current_player[my_game_master.current_profile_selected]);
				
				
				
				if (my_game_master.number_of_save_profile_slot_avaibles > 1)
				{
					if (int_score > my_game_master.best_int_score_on_this_device)
					{
						if (show_debug_messages)
							Debug.Log("new device record!");
						
						if (my_game_master.what_say_if_new_device_record != "")
							win_screen_int_score_record.text = my_game_master.what_say_if_new_device_record;
						
						my_game_master.best_int_score_on_this_device = int_score;
						PlayerPrefs.SetInt("best_int_score_on_this_device", my_game_master.best_int_score_on_this_device);
						my_game_master.best_int_score_for_current_player[my_game_master.current_profile_selected] = int_score;
						PlayerPrefs.SetInt("profile_"+my_game_master.current_profile_selected.ToString()+"_best_int_score_for_this_profile",my_game_master.best_int_score_for_current_player[my_game_master.current_profile_selected]);
						
					}
				}
			}
		}
	}
	
	public void Victory()
	{

		if (!stage_end)
		{	
			//stage_end = true;
			//makeclick saved = new makeclick();
			if(n_world == 1 && n_stage == 1){
				CreateNewSnapshot();
			}
			if(n_world == 1 && n_stage == 5){
				CreateNewSnapshot();
			}
			if(n_world == 1 && n_stage == 10){
				CreateNewSnapshot();
			}
			if(n_world == 1 && n_stage == 15){
				CreateNewSnapshot();
			}
			if(n_world == 2 && n_stage == 5){
				CreateNewSnapshot();
			}
			if(n_world == 2 && n_stage == 10){
				CreateNewSnapshot();
			}
			if(n_world == 2 && n_stage == 15){
				CreateNewSnapshot();
			}
			if(n_world == 3 && n_stage == 5){
				CreateNewSnapshot();
			}
			if(n_world == 3 && n_stage == 10){
				CreateNewSnapshot();
			}
			if(n_world == 3 && n_stage == 15){
				CreateNewSnapshot();
			}

			if (show_debug_messages)
				Debug.Log("you win " + "W"+(n_world)+"_Stage_"+(n_stage));
			allow_game_input = false;
			in_pause = true;
			
			//go to win screen
			play_screen.gameObject.SetActive(false);
			win_screen.gameObject.SetActive(true);



			AudioSource music = gameObject.GetComponent<AudioSource>();
			music.Stop();
			if (show_star_score)
				StartCoroutine(	Show_star_score(star_number));
			
			if (my_game_master)
			{
				my_game_master.my_ads_master.Call_ad(my_game_master.my_ads_master.ads_when_player_open_a_gift_packet);
				//music

				if (my_game_master.when_win_play_selected == game_master.when_win_play.music)
					my_game_master.Start_music(my_game_master.music_stage_win,my_game_master.play_win_music_in_loop);
				else if (my_game_master.when_win_play_selected == game_master.when_win_play.sfx)
					my_game_master.Gui_sfx(my_game_master.music_stage_win);

				if (my_game_master.press_start_and_go_to_selected == game_master.press_start_and_go_to.map)
					//next_stage_ico.SetActive(false);
				   next_stage_ico.SetActive(true);
				else
					next_stage_ico.SetActive(true);
				
				//virtual money
				if (keep_money_taken_in_this_stage_only_if_you_win)
				{
					if (my_game_master.virtual_money_cap < (my_game_master.current_virtual_money[my_game_master.current_profile_selected] + temp_money_count))
					{
						if (my_game_master.buy_virtual_money_with_real_money_with_soomla)
						{
							 //DELETE THIS LINE FOR SOOMLA
							my_game_master.my_Soomla_billing_script.Give_virtual_money_for_free(my_game_master.current_profile_selected,temp_money_count);
							//my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(my_game_master.current_profile_selected);
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] = PlayerPrefs.GetInt("profile_0_virtual_money");
							 //DELETE THIS LINE FOR SOOMLA
						}
						else{
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] += temp_money_count;
						}
					}
					else
					{
						if (my_game_master.buy_virtual_money_with_real_money_with_soomla)
						{
							 //DELETE THIS LINE FOR SOOMLA
							my_game_master.my_Soomla_billing_script.Give_virtual_money_for_free(my_game_master.current_profile_selected,temp_money_count);
							//my_game_master.my_Soomla_billing_script.Give_virtual_money_for_free(my_game_master.current_profile_selected,(my_game_master.virtual_money_cap-my_game_master.current_virtual_money[my_game_master.current_profile_selected]));
							//my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(my_game_master.current_profile_selected);
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] = PlayerPrefs.GetInt("profile_0_virtual_money");
							 //DELETE THIS LINE FOR SOOMLA
						}
						else
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.virtual_money_cap;
						
						if (show_debug_messages)
							Debug.Log("virtual money cap");
					}
				}
				
				//if you have solved this stage for the first time
				if (!my_game_master.stage_solved[my_game_master.current_profile_selected][n_world-1,n_stage-1])
				{
					if (show_debug_messages)
						Debug.Log("first time win");
					//update stage count
					my_game_master.total_number_of_stages_in_the_game_solved[my_game_master.current_profile_selected]++;
					my_game_master.stage_solved[my_game_master.current_profile_selected][n_world-1,n_stage-1] = true;
					//update star score
					my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1] = star_number;
					my_game_master.star_score_in_this_world[my_game_master.current_profile_selected][n_world-1] += star_number;
					my_game_master.stars_total_score[my_game_master.current_profile_selected] += star_number;
					my_game_master.star_score_difference = star_number;
					//update int score
					Update_int_score_record();
					
				}
				else //you have solved this level more than once
				{
					if (show_debug_messages)
						Debug.Log("rewin same stage: " + star_number + " - " + my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1] + " = " + (star_number - my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1])
						          + " *** int score = " + int_score);
					
					//if your star score is better than the previous
					if (star_number > my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1])
					{
						//update star score
						my_game_master.star_score_difference = (star_number - my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1]);
						
						my_game_master.stars_total_score[my_game_master.current_profile_selected] += (star_number-my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1]);
						my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1] = star_number;
						my_game_master.star_score_in_this_world[my_game_master.current_profile_selected][n_world-1] += my_game_master.star_score_difference;
						if (show_debug_messages)
							Debug.Log("...with better score = " + my_game_master.star_score_difference);
					}
					else
					{
						if (show_debug_messages)
							Debug.Log("...but without better star score");
						my_game_master.star_score_difference = 0;
					}
					
					//if your int score is better than the previous
					if (int_score > my_game_master.best_int_score_in_this_stage[my_game_master.current_profile_selected][n_world-1,n_stage-1])
					{
						//update int score
						Update_int_score_record();
					}
					else
					{
						if (show_debug_messages)
							Debug.Log("no new int_score record");
					}
					
				}
				
				//unlock the next stage if it exist
				if (n_stage < my_game_master.total_stages_in_world_n[n_world-1])
				{
					if (!my_game_master.stage_playable[my_game_master.current_profile_selected][n_world-1,n_stage])
					{
						my_game_master.stage_playable[my_game_master.current_profile_selected][n_world-1,n_stage] = true;
						my_game_master.play_this_stage_to_progress_in_the_game_world[my_game_master.current_profile_selected] = n_world-1;
						my_game_master.play_this_stage_to_progress_in_the_game_stage[my_game_master.current_profile_selected] = n_stage;
					}
				}
				//unlock next world if it exist
				else if (n_world < my_game_master.total_stages_in_world_n.Length)
				{
					my_game_master.play_this_stage_to_progress_in_the_game_world[my_game_master.current_profile_selected] = n_world;
					my_game_master.play_this_stage_to_progress_in_the_game_stage[my_game_master.current_profile_selected] = 0;
					
					if (my_game_master.this_world_is_unlocked_after_selected[n_world] == game_master.this_world_is_unlocked_after.previous_world_is_finished)
					{
						my_game_master.world_playable[my_game_master.current_profile_selected][n_world] = true;
						my_game_master.stage_playable[my_game_master.current_profile_selected][n_world,0] = true;
					}
					else if (my_game_master.this_world_is_unlocked_after_selected[n_world] == game_master.this_world_is_unlocked_after.reach_this_star_score)
					{
						if (my_game_master.stars_total_score[my_game_master.current_profile_selected] >= my_game_master.star_score_required_to_unlock_this_world[n_world])
						{
							my_game_master.world_playable[my_game_master.current_profile_selected][n_world] = true;
							my_game_master.stage_playable[my_game_master.current_profile_selected][n_world,0] = true;
						}
					}
					
					
				}
				my_game_master.Save(my_game_master.current_profile_selected);
				if (show_debug_messages)
					Debug.Log("stage score: " + star_number + " *** total score: " + my_game_master.stars_total_score[my_game_master.current_profile_selected]);
			}


			if (show_int_score && !show_star_score)
				StartCoroutine(Int_score_animation(0.5f,0));

			Invoke("SendScore",1f);
			Invoke("Mark_win",0.1f);

			//Invoke("",0.1f);
		}
	}
	public void VictoryMultiPlayer(string gameOvertext)
	{
		if (!stage_end)
		{	
			//stage_end = true;
			
			
			if (show_debug_messages)
				Debug.Log("you win " + "W"+(n_world)+"_Stage_"+(n_stage));
			allow_game_input = false;
			in_pause = true;
			
			//go to win screen
			play_screen.gameObject.SetActive(false);
			win_screen.gameObject.SetActive(true);
			
			if (show_star_score)
				StartCoroutine(	Show_star_score(star_number));
			
			if (my_game_master)
			{
				//music
				if (my_game_master.when_win_play_selected == game_master.when_win_play.music)
					my_game_master.Start_music(my_game_master.music_stage_win,my_game_master.play_win_music_in_loop);
				else if (my_game_master.when_win_play_selected == game_master.when_win_play.sfx)
					my_game_master.Gui_sfx(my_game_master.music_stage_win);
				
				if (my_game_master.press_start_and_go_to_selected == game_master.press_start_and_go_to.map)
					next_stage_ico.SetActive(true);
				else
					next_stage_ico.SetActive(true);
				
				//virtual money
				if (keep_money_taken_in_this_stage_only_if_you_win)
				{
					if (my_game_master.virtual_money_cap < (my_game_master.current_virtual_money[my_game_master.current_profile_selected] + temp_money_count))
					{
						if (my_game_master.buy_virtual_money_with_real_money_with_soomla)
						{
							 //DELETE THIS LINE FOR SOOMLA
							my_game_master.my_Soomla_billing_script.Give_virtual_money_for_free(my_game_master.current_profile_selected,temp_money_count);
							//my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(my_game_master.current_profile_selected);
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] = PlayerPrefs.GetInt("profile_0_virtual_money");
							 //DELETE THIS LINE FOR SOOMLA
						}
						else{
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] += temp_money_count;
						}
					}
					else
					{
						if (my_game_master.buy_virtual_money_with_real_money_with_soomla)
						{
							 //DELETE THIS LINE FOR SOOMLA
							my_game_master.my_Soomla_billing_script.Give_virtual_money_for_free(my_game_master.current_profile_selected,(my_game_master.virtual_money_cap-my_game_master.current_virtual_money[my_game_master.current_profile_selected]));
							//my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.my_Soomla_billing_script.Show_how_many_virtual_money_there_is_in_this_profile(my_game_master.current_profile_selected);
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] = PlayerPrefs.GetInt("profile_0_virtual_money");
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] = money;
							 //DELETE THIS LINE FOR SOOMLA
						}
						else
							my_game_master.current_virtual_money[my_game_master.current_profile_selected] = my_game_master.virtual_money_cap;
						
						if (show_debug_messages)
							Debug.Log("virtual money cap");
					}
				}
				
				//if you have solved this stage for the first time
				if (!my_game_master.stage_solved[my_game_master.current_profile_selected][n_world-1,n_stage-1])
				{
					if (show_debug_messages)
						Debug.Log("first time win");
					//update stage count
					my_game_master.total_number_of_stages_in_the_game_solved[my_game_master.current_profile_selected]++;
					my_game_master.stage_solved[my_game_master.current_profile_selected][n_world-1,n_stage-1] = true;
					//update star score
					my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1] = star_number;
					my_game_master.star_score_in_this_world[my_game_master.current_profile_selected][n_world-1] += star_number;
					my_game_master.stars_total_score[my_game_master.current_profile_selected] += star_number;
					my_game_master.star_score_difference = star_number;
					//update int score
					Update_int_score_record();
					
				}
				else //you have solved this level more than once
				{
					if (show_debug_messages)
						Debug.Log("rewin same stage: " + star_number + " - " + my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1] + " = " + (star_number - my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1])
						          + " *** int score = " + int_score);
					
					//if your star score is better than the previous
					if (star_number > my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1])
					{
						//update star score
						my_game_master.star_score_difference = (star_number - my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1]);
						
						my_game_master.stars_total_score[my_game_master.current_profile_selected] += (star_number-my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1]);
						my_game_master.stage_stars_score[my_game_master.current_profile_selected][n_world-1,n_stage-1] = star_number;
						my_game_master.star_score_in_this_world[my_game_master.current_profile_selected][n_world-1] += my_game_master.star_score_difference;
						if (show_debug_messages)
							Debug.Log("...with better score = " + my_game_master.star_score_difference);
					}
					else
					{
						if (show_debug_messages)
							Debug.Log("...but without better star score");
						my_game_master.star_score_difference = 0;
					}
					
					//if your int score is better than the previous
					if (int_score > my_game_master.best_int_score_in_this_stage[my_game_master.current_profile_selected][n_world-1,n_stage-1])
					{
						//update int score
						Update_int_score_record();
					}
					else
					{
						if (show_debug_messages)
							Debug.Log("no new int_score record");
					}
					
				}
				
				//unlock the next stage if it exist
				if (n_stage < my_game_master.total_stages_in_world_n[n_world-1])
				{
					if (!my_game_master.stage_playable[my_game_master.current_profile_selected][n_world-1,n_stage])
					{
						my_game_master.stage_playable[my_game_master.current_profile_selected][n_world-1,n_stage] = true;
						my_game_master.play_this_stage_to_progress_in_the_game_world[my_game_master.current_profile_selected] = n_world-1;
						my_game_master.play_this_stage_to_progress_in_the_game_stage[my_game_master.current_profile_selected] = n_stage;
					}
				}
				//unlock next world if it exist
				else if (n_world < my_game_master.total_stages_in_world_n.Length)
				{
					my_game_master.play_this_stage_to_progress_in_the_game_world[my_game_master.current_profile_selected] = n_world;
					my_game_master.play_this_stage_to_progress_in_the_game_stage[my_game_master.current_profile_selected] = 0;
					
					if (my_game_master.this_world_is_unlocked_after_selected[n_world] == game_master.this_world_is_unlocked_after.previous_world_is_finished)
					{
						my_game_master.world_playable[my_game_master.current_profile_selected][n_world] = true;
						my_game_master.stage_playable[my_game_master.current_profile_selected][n_world,0] = true;
					}
					else if (my_game_master.this_world_is_unlocked_after_selected[n_world] == game_master.this_world_is_unlocked_after.reach_this_star_score)
					{
						if (my_game_master.stars_total_score[my_game_master.current_profile_selected] >= my_game_master.star_score_required_to_unlock_this_world[n_world])
						{
							my_game_master.world_playable[my_game_master.current_profile_selected][n_world] = true;
							my_game_master.stage_playable[my_game_master.current_profile_selected][n_world,0] = true;
						}
					}
					
					
				}
				my_game_master.Save(my_game_master.current_profile_selected);
				if (show_debug_messages)
					Debug.Log("stage score: " + star_number + " *** total score: " + my_game_master.stars_total_score[my_game_master.current_profile_selected]);
			}
			/*
			long score = Convert.ToInt64(long.Parse(my_game_master.stars_total_score[my_game_master.current_profile_selected].ToString()));
			*/
			//GooglePlayManager.instance.SubmitScoreById(LEADERBOARD_MULTIPLAYER_ID,score);

			/*long score = 0;
			score = Convert.ToInt64(long.Parse(win_screen_int_score_count.text));

			GooglePlayManager.Instance.SubmitScoreById(LEADERBOARD_ID,score);*/
			if (show_int_score && !show_star_score)
				StartCoroutine(Int_score_animation(0.5f,0)); 
			
			Invoke("Mark_win",0.1f);
			Application.LoadLevel ("Home");
		}
	}
	
	IEnumerator Int_score_animation(float wait, int start_from)
	{
		yield return new WaitForSeconds(wait);
		
		win_screen_int_score_title.gameObject.SetActive(true);
		
		//animation
		if (int_score > 0)
		{
			int temp_score = start_from;
			int add_this = int_score/100;
			float seconds = int_score/(100000*int_score);
			
			if (add_this < 1)
				add_this = 1;
			
			if (seconds == 0)
				seconds = 0.0001f;

			while (temp_score < int_score)
			{
				if ((temp_score+add_this) < int_score)
					temp_score += add_this;
				else
					temp_score = int_score;
				
				win_screen_int_score_count.text = (temp_score).ToString("N0");
				//yield return new WaitForSeconds(seconds);
			}
		}
		
		//end animation
		win_screen_int_score_count.text = (int_score).ToString("N0");
		//Invoke("ConncetButtonPress",0.1f);
		win_screen_int_score_record.gameObject.SetActive(new_record);
		if (new_record)
			int_score_record_anim.SetActive(true);
		//ads
		if (my_game_master)
		{
			if (my_game_master.my_ads_master.ask_if_double_int_score.this_ad_is_enabled && !score_doubled && int_score > 0 && my_game_master.my_ads_master.Advertisement_isInitialized())
			{
				if (my_game_master.my_ads_master.ask_if_double_int_score_when_selected == ads_master.ask_if_double_int_score_when.random)
				{
					
					if (UnityEngine.Random.Range(1,100) <= my_game_master.my_ads_master.ask_if_double_int_score.chance_to_open_an_ad_here)
						double_score.SetActive(true);
				}
			}
		}
		
		if (win_screen.gameObject.activeSelf)
			Invoke ("Mark_win", 0.1f);
		else if (lose_screen.gameObject.activeSelf)
		
			Invoke ("Mark_lose", 0.1f);

		
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
		score = Convert.ToInt64(v);
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
	public void Double_score_button()
	{
		my_game_master.Gui_sfx(my_game_master.tap_sfx);
		double_score.SetActive(false);
		my_game_master.my_ads_master.current_ad = my_game_master.my_ads_master.ask_if_double_int_score;
		//star ad
		my_game_master.my_ads_master.Show_ad(true);//true = rewarded
		
	}
	
	public void Score_doubled()
	{
		double_score.SetActive(false);
		score_doubled = true;
		new_record = false;
		int old_score = int_score;
		int_score = int_score*2;
		
		//check if new record
		if (int_score > my_game_master.best_int_score_in_this_stage[my_game_master.current_profile_selected][n_world-1,n_stage-1])
		{
			Update_int_score_record();
			my_game_master.Save(my_game_master.current_profile_selected);
		}
		
		StartCoroutine(Int_score_animation(0.25f,old_score));
	}
	
	
	void Mark_win()
	{

		if (show_debug_messages)
			Debug.Log("Mark_win()");
		Mark_this_button(win_screen_target_button);
		
	}
	
	public void Defeat()
	{		

		if (!isfinish) {
			if (!stage_end) {	
				//stage_end = true;
				if (show_debug_messages)
					Debug.Log ("you lose");
			
				allow_game_input = false;
				in_pause = true;
			
				if (my_game_master) {
					if (my_game_master.infinite_lives) {	
						lose_screen_lives_ico.SetActive (false);
						retry_button.SetActive (true);
						stage_button.SetActive (true);
					} else {
						lose_screen_lives_ico.SetActive (true);
						if (my_game_master.lose_lives_selected == game_master.lose_lives.when_show_lose_screen)
							Update_lives (-1);
					
						if (my_game_master.current_lives [my_game_master.current_profile_selected] > 0) {
							retry_button.SetActive (true);
							stage_button.SetActive (true);
						} else {


							return_to_home.SetActive(false);
							retry_button.SetActive (false);
							stage_button.SetActive (true);
							if (my_game_master.continue_rule_selected == game_master.continue_rule.never_continue) {
								my_continue_window.my_game_master = my_game_master;
								my_continue_window.Continue_no (false);
							}
						}
					}
				
				}
				Motorcycle_Controller2D.isControllable = false;
				//go to lose screen
				play_screen.gameObject.SetActive (false);
				lose_screen.gameObject.SetActive (true);

				if (my_game_master) {
					if (my_game_master.when_lose_play_selected == game_master.when_lose_play.music)
						my_game_master.Start_music (my_game_master.music_stage_lose, my_game_master.play_lose_music_in_loop);
					else if (my_game_master.when_lose_play_selected == game_master.when_lose_play.sfx)
						my_game_master.Gui_sfx (my_game_master.music_stage_lose);
				
					if (my_game_master.show_score_in_lose_screen_too && show_int_score) {
						StartCoroutine (Int_score_animation (0.5f, 0));
					
						//if your int score is better than the previous
						if (int_score > my_game_master.best_int_score_in_this_stage [my_game_master.current_profile_selected] [n_world - 1, n_stage - 1]) {
							//update int score
							Update_int_score_record ();
						}
					}
				}

				Invoke ("Mark_lose", 0.1f);

			}
		}
	}
	

	
	void Mark_lose()
	{
		//if (!isfinish) {
			Mark_this_button (lose_screen_target_button);
		//}
	}
	
	void Show_defeat_ad()
	{
		my_game_master.my_ads_master.Call_ad(my_game_master.my_ads_master.ask_if_double_int_score);
	}
	
	IEnumerator Show_star_score(int stars_number)
	{
		if (stars_number == 3)
			perfect_target.sprite = perfect_emoticon;
		
		yield return new WaitForSeconds(delay_start_star_score_animation);
		
		invoke_count = 0;
		
		if (stars_number == 1)
		{
			Show_star(0);
		}
		else if (stars_number == 2)
		{
			Show_star(0);
			Show_star(1);
		}
		else if (stars_number == 3)
		{
			Show_star(0);
			Show_star(1);
			Show_star(2);
		}
		
		if (show_int_score)
			StartCoroutine(Int_score_animation(delay_star_creation*stars_number,0));
		
	}
	
	void Show_star(int n_star)
	{
		stars_on[n_star].SetActive(true);
		//Invoke("Star_sfx",delay_star_creation*n_star);
		Invoke("Star_sfx",n_star/3f);
	}
	
	void Star_sfx()
	{
		if (invoke_count < 3)
		{
			stars_on[invoke_count].GetComponent<Animation>().Play("star");
			if (my_game_master)
			{
				my_game_master.Gui_sfx(my_game_master.show_big_star_sfx[invoke_count]);
			}
			
			invoke_count++;
		}
	}
	
	
	
	
}
