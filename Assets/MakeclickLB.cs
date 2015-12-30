using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MakeclickLB : MonoBehaviour {

	private static bool IsUserInfoLoaded = false;
	private static bool IsFrindsInfoLoaded = false;
	private static bool IsAuntificated = false;
	
	private string title="Zombie Cross";
	private string message="Like this game? Please Rate us";
	private string yes ="YES";
	private string later="LATER";
	private string no="NO";
	private string url="https://play.google.com/store/apps/details?id=unity.zombiecross";
	//public event Action<AndroidDialogResult> ActionComplete = delegate{};

	
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
	
	//public bool callfunction=false;
	//public string functioncalled="";
	//public string Scene;
	//public bool isClick=false;
	private GoogleMobileAdBanner banner2;
	
	//example
	private const string LEADERBOARD_ID = "CgkIq6GznYALEAIQAA";

	public GameObject avatar;
	private Texture defaulttexture;

	public DefaultPreviewButton connectButton;
	public SA_Label playerLabel;
	public DefaultPreviewButton GlobalButton;
	public DefaultPreviewButton LocalButton;
	public DefaultPreviewButton AllTimeButton;
	public DefaultPreviewButton WeekButton;
	public DefaultPreviewButton TodayButton;
	public DefaultPreviewButton SubmitScoreButton;
	public DefaultPreviewButton[] ConnectionDependedntButtons;
	public CustomLeaderboardFiledsHolder[] lines;	
	private GPLeaderBoard loadedLeaderBoard = null;
	private GPCollectionType displayCollection = GPCollectionType.FRIENDS;
	private GPBoardTimeSpan displayTime = GPBoardTimeSpan.ALL_TIME;

	score_rank_item[] rank_items;
	int[] sort_scores;
	string[] sort_names;
	bool[] name_assigned;
	int child_count;
	game_master my_game_master;

	long longscore=0;
	
	void Update(){
		//Invoke ("LoadScore", 0);
	}
	void Start () {

		playerLabel.text = "Player Disconnected";
		defaulttexture = avatar.GetComponent<Renderer>().material.mainTexture;
		SA_StatusBar.text = "Custom Leader-board example scene loaded";
		
		foreach(CustomLeaderboardFiledsHolder line in lines) {
			line.Disable();
		}
		
		
		//listen for GooglePlayConnection events
		
		
		GooglePlayConnection.ActionPlayerConnected +=  OnPlayerConnected;
		GooglePlayConnection.ActionPlayerDisconnected += OnPlayerDisconnected;
		
		GooglePlayConnection.ActionConnectionResultReceived += OnConnectionResult;
		
		
		
		
		GooglePlayManager.ActionScoreSubmited += OnScoreSbumitted;
		
		
		//Same events, one with C# actions, one with FLE
		GooglePlayManager.ActionScoresListLoaded += ActionScoreRequestReceived;
		
		
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			//checking if player already connected
			OnPlayerConnected ();
		} 
		defaulttexture = avatar.GetComponent<Renderer>().material.mainTexture;
		/*
		if (functioncalled != "ShareFB" || functioncalled != "LikePage" || functioncalled != "RateDialogPopUp"  || functioncalled !="showAchievementsUI") {
			if (callfunction) {
				Invoke (functioncalled, 0);
			}
		}*/
		//	SPFacebook.instance.OnInitCompleteAction += OnInit;
		//	SPFacebook.instance.OnFocusChangedAction += OnFocusChanged;
		//	SPFacebook.instance.OnAuthCompleteAction += OnAuth;
		//	SPFacebook.instance.OnPostingCompleteAction += OnPost;
		//	SPFacebook.instance.Init();

		if (game_master.game_master_obj)
			my_game_master = (game_master)game_master.game_master_obj.GetComponent("game_master");
		
		//create and arrays
		child_count = this.transform.childCount;
		rank_items = new score_rank_item[child_count];
		sort_scores = new int[child_count];
		sort_names = new string[child_count];
		name_assigned = new bool[child_count];
	
		//load data
		for (int i = 0; i < my_game_master.number_of_save_profile_slot_avaibles; i++)
		{
			my_game_master.best_int_score_for_current_player[i] = PlayerPrefs.GetInt("profile_"+i.ToString()+"_best_int_score_for_this_profile");
			my_game_master.profile_name[i] = PlayerPrefs.GetString("profile_"+i.ToString()+"_name");
			//rank_items [i] = (score_rank_item)this.transform.GetChild (i).GetComponent<score_rank_item> ();
			//longscore = Convert.ToInt64(long.Parse(this.transform.GetChild (i).GetComponent<score_rank_item> ().score_text.text));
			//longscore = Convert.ToInt64(long.Parse(sort_scores[i].ToString()));
			//Debug.Log("["+i+"] originale: " + my_game_master.best_int_score_for_current_player[i] + " " + my_game_master.profile_name[i] + " ... " + my_game_master.this_profile_have_a_save_state_in_it[i]);
			//Debug.Log("["+i+"] copia: " + sort_scores[i]);
			longscore = Convert.ToInt64(long.Parse(my_game_master.best_int_score_for_current_player.GetValue(i).ToString()));
		}
	
		//Update_local();
		LoadScore ();
		ShowGlobal ();

	}

	
	void Back(){
		Application.LoadLevel ("Home");
	}
	
	private void OnFocusChanged(bool focus) {
		
		
		
		if (!focus)  {                                                                                        
			
			Time.timeScale = 0;                                                                  
		} else  {                                                                                        
			
			Time.timeScale = 1;                                                                  
		}   
	}

	public void LoadScore() {
		SubmitScore ();
		GooglePlayManager.instance.LoadPlayerCenteredScores(LEADERBOARD_ID, displayTime, displayCollection, 10);
	}
	
	public void OpenUI() {
		GooglePlayManager.instance.ShowLeaderBoardById(LEADERBOARD_ID);
	}
	
	
	
	public void ShowGlobal() {
		displayCollection = GPCollectionType.GLOBAL;
		UpdateScoresDisaplay();
	}
	
	public void ShowLocal() {
		displayCollection = GPCollectionType.FRIENDS;
		UpdateScoresDisaplay();
	}
	
	
	public void ShowAllTime() {
		displayTime = GPBoardTimeSpan.ALL_TIME;
		UpdateScoresDisaplay();
	}
	
	public void ShowWeek() {
		displayTime = GPBoardTimeSpan.WEEK;
		UpdateScoresDisaplay();
	}
	
	public void ShowDay() {
		displayTime = GPBoardTimeSpan.TODAY;
		UpdateScoresDisaplay();
	}
	
	
	private void ConncetButtonPress() {
		Debug.Log("GooglePlayManager State  -> " + GooglePlayConnection.State.ToString());
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			SA_StatusBar.text = "Disconnecting from Play Service...";
			GooglePlayConnection.Instance.Disconnect ();
		} else {
			SA_StatusBar.text = "Connecting to Play Service...";
			GooglePlayConnection.Instance.Connect ();
		}
	}
	
	
	//--------------------------------------
	// UNITY
	//--------------------------------------
	
	void UpdateScoresDisaplay() {
		
		
		
		if(loadedLeaderBoard != null) {
			
			
			//Getting current player score
			int displayRank;
			
			GPScore currentPlayerScore = loadedLeaderBoard.GetCurrentPlayerScore(displayTime, displayCollection);
			if(currentPlayerScore == null) {
				//Player does not have rank at this collection / time
				//so let's show the top score
				//since we used loadPlayerCenteredScores function. we should have top scores loaded if player have no scores at this collection / time
				//https://developer.android.com/reference/com/google/android/gms/games/leaderboard/Leaderboards.html#loadPlayerCenteredScores(com.google.android.gms.common.api.GoogleApiClient, java.lang.String, int, int, int)
				//Asynchronously load the player-centered page of scores for a given leaderboard. If the player does not have a score on this leaderboard, this call will return the top page instead.
				displayRank = 1;
			} else {
				//Let's show 5 results before curent player Rank
				displayRank = Mathf.Clamp(currentPlayerScore.Rank - 5, 1, currentPlayerScore.Rank);
				
				//let's check if displayRank we what to display before player score is exists
				while(loadedLeaderBoard.GetScore(displayRank, displayTime, displayCollection) == null) {
					displayRank++;
				}
			}
			
			
			Debug.Log("Start Display at rank: " + displayRank);
			
			
			int i = displayRank;
			foreach(CustomLeaderboardFiledsHolder line in lines) {
				
				line.Disable();
				
				GPScore score = loadedLeaderBoard.GetScore(i, displayTime, displayCollection);
				if(score != null) {
					line.rank.text 			= i.ToString();
					line.score.text 		= score.LongScore.ToString();
					line.playerId.text 		= score.PlayerId;
					
					GooglePlayerTemplate player = GooglePlayManager.instance.GetPlayerById(score.PlayerId);
					if(player != null) {
						line.playerName.text =  player.name;
						if(player.hasIconImage) {
							line.avatar.GetComponent<Renderer>().material.mainTexture = player.icon;
						} else {
							line.avatar.GetComponent<Renderer>().material.mainTexture = defaulttexture;
						}
						
					} else {
						line.playerName.text = "--";
						line.avatar.GetComponent<Renderer>().material.mainTexture = defaulttexture;
					}
					line.avatar.GetComponent<Renderer>().enabled = true;
					
				} else {
					line.Disable();
				}
				
				i++;
			}
			
			
		//	SubmitScore();
			
			
			
			
		} else {
			foreach(CustomLeaderboardFiledsHolder line in lines) {
				line.Disable();
			}
		}
		
		
		
		
		
		
	}
	
	
	
	void FixedUpdate() {
		
		
		//SubmitScoreButton.text = "Submit Score: " + score;
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			if(GooglePlayManager.instance.player.icon != null) {
				avatar.GetComponent<Renderer>().material.mainTexture = GooglePlayManager.instance.player.icon;
			}
		}  else {
			avatar.GetComponent<Renderer>().material.mainTexture = defaulttexture;
		}

		
		string title = "Connect";
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			title = "Disconnect";
			
			foreach(DefaultPreviewButton btn in ConnectionDependedntButtons) {
				btn.EnabledButton();
			}
			
			
			AllTimeButton.Unselect();
			WeekButton.Unselect();
			TodayButton.Unselect();
			
			
			switch(displayTime) {
			case GPBoardTimeSpan.ALL_TIME:
				AllTimeButton.Select();
				break;
			case GPBoardTimeSpan.WEEK:
				WeekButton.Select();
				break;
			case GPBoardTimeSpan.TODAY:
				TodayButton.Select();
				break;
			}

			GlobalButton.Unselect();
			LocalButton.Unselect();
			switch(displayCollection) {
			case GPCollectionType.GLOBAL:
				GlobalButton.Select();
				break;
			case GPCollectionType.FRIENDS:
				LocalButton.Select();
				break;
			}
			
			
		} else {
			foreach(DefaultPreviewButton btn in ConnectionDependedntButtons) {
				btn.DisabledButton();
				
			}
			if(GooglePlayConnection.State == GPConnectionState.STATE_DISCONNECTED || GooglePlayConnection.State == GPConnectionState.STATE_UNCONFIGURED) {
				
				title = "Connect";
			} else {
				title = "Connecting..";
			}
		}
		
		connectButton.text = title;
	}
	
	
	//--------------------------------------
	// EVENTS
	//--------------------------------------
	
	
	
	
	private void SubmitScore() {
		GooglePlayManager.instance.SubmitScoreById(LEADERBOARD_ID, longscore);
		//SA_StatusBar.text = "Submitiong score: " + (score +1).ToString();
		//score ++;
	}
	
	
	private void OnPlayerDisconnected() {
		SA_StatusBar.text = "Player Disconnected";
		playerLabel.text = "Player Disconnected";
		
	}
	
	private void OnPlayerConnected() {
		SA_StatusBar.text = "Player Connected";
		playerLabel.text = GooglePlayManager.instance.player.name;
		
	}
	
	private void OnConnectionResult(GooglePlayConnectionResult result) {
		
		SA_StatusBar.text = "Connection Resul:  " + result.code.ToString();
		Debug.Log(result.code.ToString());
	}
	
	
	
	private void ActionScoreRequestReceived (GooglePlayResult obj) {
		
		SA_StatusBar.text = "Scores Load Finished";
		
		loadedLeaderBoard = GooglePlayManager.instance.GetLeaderBoard(LEADERBOARD_ID);
		
		
		if(loadedLeaderBoard == null) {
			Debug.Log("No Leaderboard found");
			return;
		}
		
		List<GPScore> scoresLB =  loadedLeaderBoard.GetScoresList(GPBoardTimeSpan.ALL_TIME, GPCollectionType.GLOBAL);
		
		foreach(GPScore score in scoresLB) {
			Debug.Log("OnScoreUpdated " + score.Rank + " " + score.PlayerId + " " + score.LongScore);
		}
		
		GPScore currentPlayerScore = loadedLeaderBoard.GetCurrentPlayerScore(displayTime, displayCollection);
		
		Debug.Log("currentPlayerScore: " + currentPlayerScore.LongScore + " rank:" + currentPlayerScore.Rank);
		
		
		UpdateScoresDisaplay();
		
	}
	
	void OnScoreSbumitted (GP_LeaderboardResult result) {
		SA_StatusBar.text = "Score Submit Resul:  " + result.message;
		LoadScore();
	}
	
	void OnDestroy() {
		
		GooglePlayConnection.ActionPlayerConnected +=  OnPlayerConnected;
		GooglePlayConnection.ActionPlayerDisconnected += OnPlayerDisconnected;
		
		GooglePlayConnection.ActionConnectionResultReceived += OnConnectionResult;
		
		
		GooglePlayManager.ActionScoreSubmited -= OnScoreSbumitted;
		GooglePlayManager.ActionScoresListLoaded -= ActionScoreRequestReceived;
		
	}
	/*	private void OnAuth(FBResult result) {
		if(SPFacebook.instance.IsLoggedIn) {
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
		
		SPFacebook.instance.Logout();
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
	
	/*public void ConncetButtonPress() {
		
		GooglePlayConnection.Instance.connect ();
	}*/
	// Update is called once per frame
	
	public void SmartBottom() {
		banner2 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.LowerCenter, GADBannerSize.SMART_BANNER);
		banner2.Show();
	}
	
	
	public void B2Hide() {
		banner2.Hide();
	}
	
	
	public void B2Show() {
		banner2.Show();
	}

}
