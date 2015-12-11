using UnityEngine;
using System.Collections;

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




	void Start () {

	

		if (functioncalled != "ShareFB" || functioncalled != "LikePage" || functioncalled != "RateDialogPopUp"  || functioncalled !="showAchievementsUI") {
			if (callfunction) {
				Invoke (functioncalled, 0);
			}
		}
	//	SPFacebook.instance.OnInitCompleteAction += OnInit;
	//	SPFacebook.instance.OnFocusChangedAction += OnFocusChanged;
		
		
	//	SPFacebook.instance.OnAuthCompleteAction += OnAuth;
		
		
		
	//	SPFacebook.instance.OnPostingCompleteAction += OnPost;

		
	//	SPFacebook.instance.Init();


	
	}
	/*public void Connect() {
		if(!IsAuntificated) {
			SPFacebook.instance.Login("email,publish_actions");

		} else {
			LogOut();

		}
	}
	*/
	/*private void OnInit() {
		if(SPFacebook.instance.IsLoggedIn) {
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

	    GooglePlayConnection.Instance.connect ();
	}
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
