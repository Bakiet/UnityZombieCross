using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;
using System;

public class StartAndroidAds : MonoBehaviour {

	public string ad;
	public int invoked=1;
	private static int countstatic;
	private string title="Zombie Cross";
	private string message="Like this game? Please Rate us";
	private string yes ="YES";
	private string later="LATER";
	private string no="NO";
	private string url="";
	public event Action<AndroidDialogResult> ActionComplete = delegate{};

	private const string MY_BANNERS_AD_UNIT_ID		 = "ca-app-pub-7288875708989992/5953651462"; 
	private const string MY_INTERSTISIALS_AD_UNIT_ID =  "ca-app-pub-7288875708989992/3000185061"; 
	
	private GoogleMobileAdBanner banner1;
	private GoogleMobileAdBanner banner2;
	public int timestoexe=1;
	private int count=0;
	private bool IsInterstisialsAdReady = false;
	
	
	private DefaultPreviewButton ShowIntersButton;
	
	private DefaultPreviewButton[] b1CreateButtons;
	private DefaultPreviewButton b1Hide;
	private DefaultPreviewButton b1Show;
	private DefaultPreviewButton b1Refresh;
	private DefaultPreviewButton ChangePost1;
	private DefaultPreviewButton ChangePost2;
	private DefaultPreviewButton b1Destroy;
	
	
	private DefaultPreviewButton[] b2CreateButtons;
	private DefaultPreviewButton b2Hide;
	private DefaultPreviewButton b2Show;
	private DefaultPreviewButton b2Refresh;
	private DefaultPreviewButton b2Destroy;
	// Use this for initialization
	void Start () {

		//if (ad == "SmartTop" ||  ad == "SmartBottom" || ad == "StartInterstitialAd" || ad == "B2Hide" || ad == "ConncetButtonPress") {

				AndroidAdMobController.instance.Init (MY_BANNERS_AD_UNIT_ID);
			
				//If yoi whant to use Interstisial ad also, you need to set additional ad unin id for Interstisial as well
				AndroidAdMobController.instance.SetInterstisialsUnitID (MY_INTERSTISIALS_AD_UNIT_ID);
			
			
				//Optional, add data for better ad targeting
				AndroidAdMobController.instance.SetGender (GoogleGender.Male);
				AndroidAdMobController.instance.AddKeyword ("game");
				AndroidAdMobController.instance.SetBirthday (1989, AndroidMonth.MARCH, 18);
				AndroidAdMobController.instance.TagForChildDirectedTreatment (false);
		
				//Causes a device to receive test ads. The deviceId can be obtained by viewing the logcat output after creating a new ad
				//AndroidAdMobController.instance.AddTestDevice("6B9FA8031AEFDC4758B7D8987F77A5A6");
			
			
			
				AndroidAdMobController.instance.OnInterstitialLoaded += OnInterstisialsLoaded; 
				AndroidAdMobController.instance.OnInterstitialOpened += OnInterstisialsOpen;
			
			
			
				//listening for InApp Event
				//You will only receive in-app purchase (IAP) ads if you specifically configure an IAP ad campaign in the AdMob front end.
				AndroidAdMobController.instance.OnAdInAppRequest += OnInAppRequest;


				//listen for GooglePlayConnection events
				GooglePlayConnection.ActionPlayerConnected +=  OnPlayerConnected;
				GooglePlayConnection.ActionPlayerDisconnected += OnPlayerDisconnected;
				//GooglePlayConnection.ActionConnectionResultReceived += ActionConnectionResultReceived;
				/*
				//listen for GooglePlayManager events
				GooglePlayManager.ActionAchievementUpdated += OnAchievementUpdated;
				GooglePlayManager.ActionScoreSubmited += OnScoreSubmited;
				GooglePlayManager.ActionScoresListLoaded += OnScoreUpdated;
				
				GooglePlayManager.ActionSendGiftResultReceived += OnGiftResult;
				GooglePlayManager.ActionPendingGameRequestsDetected += OnPendingGiftsDetected;
				GooglePlayManager.ActionGameRequestsAccepted += OnGameRequestAccepted;
				
				GooglePlayManager.ActionOAuthTokenLoaded += ActionOAuthTokenLoaded;
				GooglePlayManager.ActionAvailableDeviceAccountsLoaded += ActionAvailableDeviceAccountsLoaded;
				GooglePlayManager.ActionAchievementsLoaded += OnAchievmnetsLoadedInfoListner;
				*/
		if (StoreInventory.GetItemBalance ("no_ads") <= 0 || StoreInventory.GetItemBalance ("coins") <= 0) {
				count = count +1;
				countstatic = countstatic + 1;
				//if(countstatic == 1){
					if(timestoexe <= count){
					Invoke (ad, invoked);
					}
				//}
			}
		//}
	}

	public void StartInterstitialAd() {
		if (PlayerPrefs.GetInt("profile_0_ready_purchased") != 1) {
		AndroidAdMobController.instance.StartInterstitialAd ();
		}
	}
	
	public void LoadInterstitialAd() {
		AndroidAdMobController.instance.LoadInterstitialAd ();
	}
	
	public void ShowInterstitialAd() {
		AndroidAdMobController.instance.ShowInterstitialAd ();
	}
	
	/*
	public void CreateBannerCustomPos() {
		banner1 = AndroidAdMobController.instance.CreateAdBanner(300, 100, GADBannerSize.BANNER);
		banner1.Show();
	}
	
	public void CreateBannerUpperLeft() {
		banner1 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.UpperLeft, GADBannerSize.BANNER);
		banner1.Show();
	}
	
	public void CreateBannerUpperCneter() {
		banner1 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.UpperCenter, GADBannerSize.BANNER);
		banner1.Show();
	}
	
	public void CreateBannerBottomLeft() {
		banner1 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.LowerLeft, GADBannerSize.BANNER);
		banner1.Show();
	}
	
	public void CreateBannerBottomCenter() {
		banner1 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.LowerCenter, GADBannerSize.BANNER);
		banner1.Show();
	}*/
	/*
	public void CreateBannerBottomRight() {
		banner1 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.LowerRight, GADBannerSize.BANNER);
		banner1.Show();
	}*/
	/*
	public void B1Hide() {
		banner1.Hide();
	}
	
	
	public void B1Show() {
		banner1.Show();
	}
	
	public void B1Refresh() {
		banner1.Refresh();
	}
	
	public void B1Destrouy() {
		AndroidAdMobController.instance.DestroyBanner(banner1.id);
		banner1 = null;
	}
	*/
	
	public void SmartTOP() {
		banner2 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.UpperCenter, GADBannerSize.SMART_BANNER);
		banner2.Show();
	}
	
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
	
	public void B2Refresh() {
		banner2.Refresh();
	}
	
	public void B2Destrouy() {
		AndroidAdMobController.instance.DestroyBanner(banner2.id);
		banner2 = null;
	}
	
	public void ChnagePostToMiddle() {
		//banner1.SetBannerPosition(TextAnchor.MiddleCenter);
	}
	
	public void ChangePostRandom() {
//		banner1.SetBannerPosition(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height));
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnInterstisialsLoaded() {
		IsInterstisialsAdReady = true;
	}
	
	private void OnInterstisialsOpen() {
		IsInterstisialsAdReady = false;
	}
	
	private void OnInAppRequest(string productId) {
		
		//AN_PoupsProxy.showMessage ("In App Request", "In App Request for product Id: " + productId + " received");
		
		
		//Then you should perfrom purchase  for this product id, using this or another game billing plugin
		//Once the purchase is complete, you should call RecordInAppResolution with one of the constants defined in GADInAppResolution:
		
		AndroidAdMobController.instance.RecordInAppResolution(GADInAppResolution.RESOLUTION_SUCCESS);
		
	}
	private void ConncetButtonPress() {
		//Debug.Log("GooglePlayManager State  -> " + GooglePlayConnection.State.ToString());
		//if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
		//SA_StatusBar.text = "Disconnecting from Play Service...";
		//	GooglePlayConnection.Instance.Disconnect ();
		//} else {
		//SA_StatusBar.text = "Connecting to Play Service...";
		GooglePlayConnection.Instance.Connect ();
		//}
	}

	private void OnPlayerDisconnected() {
		//SA_StatusBar.text = "Player Disconnected";
		//playerLabel.text = "Player Disconnected";
	}
		
	private void OnPlayerConnected() {
	//	SA_StatusBar.text = "Player Connected";
		//playerLabel.text = GooglePlayManager.Instance.player.name + "(" + GooglePlayManager.Instance.currentAccount + ")";
	}
	private void OnClick() {
		/*if (ad == "B2Hide" || ad == "ShareFB" || ad == "LikePage") {
			Invoke (ad, invoked);
		}
		if(ad == "RateDialogPopUp"){
			AN_PoupsProxy.showRateDialog(title, message, yes, later, no);
		}*/

	}
	/*
	public void LikePage() {
		Application.OpenURL("https://www.facebook.com/zombiecrossgame/");
	}
	public void ShareFB() {
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
		
	}*/
	
	/*
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
	}*/
	/*
	public void onPopUpCallBack(string buttonIndex) {
		int index = System.Convert.ToInt16(buttonIndex);
		switch(index) {
		case 0: 
			AN_PoupsProxy.OpenAppRatePage(url);
			DispatchAction(AndroidDialogResult.RATED);
			break;
		case 1:
			DispatchAction(AndroidDialogResult.REMIND);
			break;
		case 2:
			DispatchAction(AndroidDialogResult.DECLINED);
			break;
		}

		Destroy(gameObject);
	} */
	/*
	public void onDismissed(string data) {
		ActionComplete(AndroidDialogResult.CLOSED);
		Destroy(gameObject);
	}*/
	/*
	protected void DispatchAction(AndroidDialogResult res) {
		ActionComplete(res);
	}*/
	/*
	private void ConncetButtonPress() {
		//Debug.Log("GooglePlayManager State  -> " + GooglePlayConnection.State.ToString());
		//if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			//SA_StatusBar.text = "Disconnecting from Play Service...";
		//	GooglePlayConnection.Instance.Disconnect ();
		//} else {
			//SA_StatusBar.text = "Connecting to Play Service...";
			GooglePlayConnection.Instance.Connect ();
		//}
	}*/
	/*
	private void OnPlayerDisconnected() {
		//SA_StatusBar.text = "Player Disconnected";
		//playerLabel.text = "Player Disconnected";
	}*/
	/*
	private void OnPlayerConnected() {
	//	SA_StatusBar.text = "Player Connected";
		//playerLabel.text = GooglePlayManager.Instance.player.name + "(" + GooglePlayManager.Instance.currentAccount + ")";
	}*/
	/*
	private void ActionConnectionResultReceived(GooglePlayConnectionResult result) {
		
		if(result.IsSuccess) {
			//Debug.Log("Connected!");
		} else {
			//Debug.Log("Cnnection failed with code: " + result.code.ToString());
		}
		//SA_StatusBar.text = "ConnectionResul:  " + result.code.ToString();
	}*/
	/*
	void OnGiftResult (GooglePlayGiftRequestResult result) {
		//SA_StatusBar.text = "Gift Send Result:  " + result.code.ToString();
		//AN_PoupsProxy.showMessage("Gfit Send Complete", "Gift Send Result: " + result.code.ToString());
	}*/
	/*
	void OnPendingGiftsDetected (List<GPGameRequest> gifts) {
		AndroidDialog dialog = AndroidDialog.Create("Pending Gifts Detected", "You got few gifts from your friends, do you whant to take a look?");
		dialog.ActionComplete += OnPromtGiftDialogClose;
	}*/
	
	/*
	private void OnPromtGiftDialogClose(AndroidDialogResult res) {
		//parsing result
		switch(res) {
		case AndroidDialogResult.YES:
			GooglePlayManager.Instance.ShowRequestsAccepDialog();
			break;
			
			
		}
	}*/
	/*
	void OnGameRequestAccepted (List<GPGameRequest> gifts) {
		foreach(GPGameRequest g in gifts) {
			//AN_PoupsProxy.showMessage("Gfit Accepted", g.playload + " is excepted");
		}
	}*/
	
	
	
	/*
	private void ActionAvailableDeviceAccountsLoaded(List<string> accounts) {
		string msg = "Device contains following google accounts:" + "\n";
		foreach(string acc in GooglePlayManager.Instance.deviceGoogleAccountList) {
			msg += acc + "\n";
		} 
		
		AndroidDialog dialog = AndroidDialog.Create("Accounts Loaded", msg, "Sign With Fitst one", "Do Nothing");
		dialog.ActionComplete += SighDialogComplete;
		
	}*/
	/*
	private void SighDialogComplete (AndroidDialogResult res) {
		if(res == AndroidDialogResult.YES) {
			GooglePlayConnection.Instance.Connect(GooglePlayManager.Instance.deviceGoogleAccountList[0]);
		}
		
	}*/
	
	
	/*
	private void ActionOAuthTokenLoaded(string token) {
		
		//AN_PoupsProxy.showMessage("Token Loaded", GooglePlayManager.Instance.loadedAuthToken);
	}
	*/
	/*
	public void RequestAdvertisingId() {
		GooglePlayUtils.ActionAdvertisingIdLoaded += ActionAdvertisingIdLoaded;
		GooglePlayUtils.Instance.GetAdvertisingId();
	}
	*/
	
	
	
	//--------------------------------------
	// EVENTS
	//--------------------------------------
	
	/*private void ActionAdvertisingIdLoaded (GP_AdvertisingIdLoadResult res) {
		GooglePlayUtils.ActionAdvertisingIdLoaded -= ActionAdvertisingIdLoaded;
		
		if(res.IsSucceeded) {
			AndroidMessage.Create("Succeeded", "Advertising Id: " + res.id);
		} else {
			AndroidMessage.Create("Failed", "Advertising Id failed to loaed");
		}
		
		
	}*/
	
	/*private void OnAchievmnetsLoadedInfoListner(GooglePlayResult res) {
		/*GPAchievement achievement = GooglePlayManager.Instance.GetAchievement(INCREMENTAL_ACHIEVEMENT_ID);
		
		
		if(achievement != null) {
			a_id.text 		= "Id: " + achievement.Id;
			a_name.text 	= "Name: " +achievement.Name;
			a_descr.text 	= "Description: " + achievement.Description;
			a_type.text 	= "Type: " + achievement.Type.ToString();
			a_state.text 	= "State: " + achievement.State.ToString();
			a_steps.text 	= "CurrentSteps: " + achievement.CurrentSteps.ToString();
			a_total.text 	= "TotalSteps: " + achievement.TotalSteps.ToString();
		}
	}*/
	
	/*private void OnAchievementsLoaded(GooglePlayResult result) {
		GooglePlayManager.ActionAchievementsLoaded -= OnAchievementsLoaded;
		if(result.isSuccess) {
			
			foreach (GPAchievement achievement in GooglePlayManager.Instance.Achievements) {
				Debug.Log(achievement.Id);
				Debug.Log(achievement.Name);
				Debug.Log(achievement.Description);
				Debug.Log(achievement.Type);
				Debug.Log(achievement.State);
				Debug.Log(achievement.CurrentSteps);
				Debug.Log(achievement.TotalSteps);
			}
			
		//	SA_StatusBar.text = "Total Achievement: " + GooglePlayManager.Instance.Achievements.Count.ToString();
		//	AN_PoupsProxy.showMessage ("Achievments Loaded", "Total Achievements: " + GooglePlayManager.Instance.Achievements.Count.ToString());
		} else {
		//	SA_StatusBar.text = result.message;
		//	AN_PoupsProxy.showMessage ("Achievments Loaded error: ", result.message);
		}
		
	}*/
	/*
	private void OnAchievementUpdated(GP_AchievementResult result) {
		//SA_StatusBar.text = "Achievment Updated: Id: " + result.achievementId + "\n status: " + result.message;
		//AN_PoupsProxy.showMessage ("Achievment Updated ", "Id: " + result.achievementId + "\n status: " + result.message);
	}
	*/
	
	
	/*private void OnLeaderBoardsLoaded(GooglePlayResult result) {
		GooglePlayManager.ActionLeaderboardsLoaded -= OnLeaderBoardsLoaded;
		
		if(result.isSuccess) {
			//if( GooglePlayManager.Instance.GetLeaderBoard(LEADERBOARD_ID) == null) {
			//	AN_PoupsProxy.showMessage("Leader boards loaded", LEADERBOARD_ID + " not found in leader boards list");
			//	return;
			//}
			
			
		//	SA_StatusBar.text = LEADERBOARD_NAME + "  score  " + GooglePlayManager.Instance.GetLeaderBoard(LEADERBOARD_ID).GetCurrentPlayerScore(GPBoardTimeSpan.ALL_TIME, GPCollectionType.FRIENDS).LongScore.ToString();
			//AN_PoupsProxy.showMessage (LEADERBOARD_NAME + "  score",  GooglePlayManager.Instance.GetLeaderBoard(LEADERBOARD_ID).GetCurrentPlayerScore(GPBoardTimeSpan.ALL_TIME, GPCollectionType.FRIENDS).LongScore.ToString());
		} else {
			//SA_StatusBar.text = result.message;
			//AN_PoupsProxy.showMessage ("Leader-Boards Loaded error: ", result.message);
		}
		
		UpdateBoardInfo();
		
	}*/
	/*
	private void UpdateBoardInfo() {
		GPLeaderBoard leaderboard = GooglePlayManager.Instance.GetLeaderBoard(LEADERBOARD_ID);
		if(leaderboard != null) {
			b_id.text 		= "Id: " + leaderboard.Id;
			b_name.text 	= "Name: " +leaderboard.Name;
			
			GPScore score = leaderboard.GetCurrentPlayerScore(GPBoardTimeSpan.ALL_TIME, GPCollectionType.FRIENDS);
			if (score != null) {
				b_all_time.text = "All Time Score: " + score.LongScore;
			} else {
				b_all_time.text = "All Time Score: EMPTY";
			}
		} else {
			b_all_time.text = "All Time Score: " + " -1";
		}*/
	//}
	/*
	private void OnScoreSubmited(GP_LeaderboardResult result) {
		if (result.isSuccess) {
			SA_StatusBar.text = "Score Submited:  " + result.message
				+ " LeaderboardId: " + result.Leaderboard.Id
					+ " LongScore: " + result.Leaderboard.GetCurrentPlayerScore(GPBoardTimeSpan.ALL_TIME, GPCollectionType.GLOBAL).LongScore;

		} else {
		//	SA_StatusBar.text = "Score Submit Fail:  " + result.message;
		}
	}*/
	/*
	private void OnScoreUpdated(GooglePlayResult res) {
		UpdateBoardInfo();
	}*/
	

}
