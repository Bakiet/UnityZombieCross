using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class makeclick : MonoBehaviour {
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
		int maxNumberOfSavedGamesToShow = 5;
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
	
	void OnSpanshotLoadDialogComplete (AndroidDialogResult res) {
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
		
		AndroidMessage.Create("Result", "New Game Save Request");
	}
	
	private void ActionGameSaveLoaded (GP_SpanshotLoadResult result) {
	
		Debug.Log("ActionGameSaveLoaded: " + result.Message);
		if(result.IsSucceeded) {

			Debug.Log("Snapshot.Title: " 					+ result.Snapshot.meta.Title);
			Debug.Log("Snapshot.Description: " 				+ result.Snapshot.meta.Description);
			Debug.Log("Snapshot.CoverImageUrl): " 			+ result.Snapshot.meta.CoverImageUrl);
			Debug.Log("Snapshot.LastModifiedTimestamp: " 	+ result.Snapshot.meta.LastModifiedTimestamp);
			
			Debug.Log("Snapshot.stringData: " 				+ result.Snapshot.stringData);
			Debug.Log("Snapshot.bytes.Length: " 			+ result.Snapshot.bytes.Length);
			
			AndroidMessage.Create("Loaded Game", "");


		
		} 
		
		//SA_StatusBar.text = "Games Loaded: " + result.Message;
		
	}



	
	private void ActionGameSaveResult (GP_SpanshotLoadResult result) {
		GooglePlaySavedGamesManager.ActionGameSaveResult -= ActionGameSaveResult;
		Debug.Log("ActionGameSaveResult: " + result.Message);
		
		if(result.IsSucceeded) {
			AndroidToast.ShowToastNotification ("Saved game", 3); //SA_StatusBar.text = "Games Saved: " + result.Snapshot.meta.Title;
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

	private IEnumerator MakeScreenshotAndSaveGameData() {
		
		
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
		//string currentSaveName =  "Saved Game";
		string description  = "Modified data at: " + System.DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");


		
		GooglePlaySavedGamesManager.ActionGameSaveResult += ActionGameSaveResult;
		GooglePlaySavedGamesManager.Instance.CreateNewSnapshot(currentSaveName, description, Screenshot, Random.Range(1, 10000).ToString(), TotalPlayedTime);
		
		
		
		Destroy(Screenshot);
	}

	void Start () {

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
