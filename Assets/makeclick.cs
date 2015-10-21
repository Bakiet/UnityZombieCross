using UnityEngine;
using System.Collections;

public class makeclick : MonoBehaviour {
	//Facebook
	private static bool IsUserInfoLoaded = false;
	private static bool IsFrindsInfoLoaded = false;
	private static bool IsAuntificated = false;



	private string LEADERBOARD_ID;

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

	public bool callfunction=false;
	public string functioncalled;

	void Start () {

		if (callfunction) {
			Invoke(functioncalled,0);
		}
	//	SPFacebook.instance.OnInitCompleteAction += OnInit;
	//	SPFacebook.instance.OnFocusChangedAction += OnFocusChanged;
		
		
	//	SPFacebook.instance.OnAuthCompleteAction += OnAuth;
		
		
		
	//	SPFacebook.instance.OnPostingCompleteAction += OnPost;

		
	//	SPFacebook.instance.Init();


	
	}
	public void Connect() {
		if(!IsAuntificated) {
			SPFacebook.instance.Login("email,publish_actions");

		} else {
			LogOut();

		}
	}
	
	private void OnInit() {
		if(SPFacebook.instance.IsLoggedIn) {
			IsAuntificated = true;
		} else {

		}
	}
	private void OnFocusChanged(bool focus) {
		
	
		
		if (!focus)  {                                                                                        
			                                       
			Time.timeScale = 0;                                                                  
		} else  {                                                                                        
			                           
			Time.timeScale = 1;                                                                  
		}   
	}
	
	private void OnAuth(FBResult result) {
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




	private void LogOut() {
		IsUserInfoLoaded = false;
		
		IsAuntificated = false;
		
		SPFacebook.instance.Logout();
	}

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
		
		AndroidSocialGate.StartShareIntent("Hello Share Intent", "This is my text to share", tex,  "facebook.katana");
		
		Destroy(tex);
		
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
	void Update () {
	
	}
	
}
