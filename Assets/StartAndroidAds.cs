using UnityEngine;
using System.Collections;

public class StartAndroidAds : MonoBehaviour {

	public string ad;

	private const string MY_BANNERS_AD_UNIT_ID		 = "ca-app-pub-7288875708989992/5953651462"; 
	private const string MY_INTERSTISIALS_AD_UNIT_ID =  "ca-app-pub-7288875708989992/3000185061"; 
	
	private GoogleMobileAdBanner banner1;
	private GoogleMobileAdBanner banner2;
	
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

		AndroidAdMobController.instance.Init(MY_BANNERS_AD_UNIT_ID);
		
		//If yoi whant to use Interstisial ad also, you need to set additional ad unin id for Interstisial as well
		AndroidAdMobController.instance.SetInterstisialsUnitID(MY_INTERSTISIALS_AD_UNIT_ID);
		
		
		//Optional, add data for better ad targeting
		AndroidAdMobController.instance.SetGender(GoogleGender.Male);
		AndroidAdMobController.instance.AddKeyword("game");
		AndroidAdMobController.instance.SetBirthday(1989, AndroidMonth.MARCH, 18);
		AndroidAdMobController.instance.TagForChildDirectedTreatment(false);
	
		//Causes a device to receive test ads. The deviceId can be obtained by viewing the logcat output after creating a new ad
		//AndroidAdMobController.instance.AddTestDevice("6B9FA8031AEFDC4758B7D8987F77A5A6");
		
		
		
		AndroidAdMobController.instance.OnInterstitialLoaded += OnInterstisialsLoaded; 
		AndroidAdMobController.instance.OnInterstitialOpened += OnInterstisialsOpen;
		
		
		
		//listening for InApp Event
		//You will only receive in-app purchase (IAP) ads if you specifically configure an IAP ad campaign in the AdMob front end.
		AndroidAdMobController.instance.OnAdInAppRequest += OnInAppRequest;

		Invoke(ad, 1);
	
	}

	public void StartInterstitialAd() {
		AndroidAdMobController.instance.StartInterstitialAd ();
	}
	
	public void LoadInterstitialAd() {
		AndroidAdMobController.instance.LoadInterstitialAd ();
	}
	
	public void ShowInterstitialAd() {
		AndroidAdMobController.instance.ShowInterstitialAd ();
	}
	
	
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
	}
	
	public void CreateBannerBottomRight() {
		banner1 = AndroidAdMobController.instance.CreateAdBanner(TextAnchor.LowerRight, GADBannerSize.BANNER);
		banner1.Show();
	}
	
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
		banner1.SetBannerPosition(TextAnchor.MiddleCenter);
	}
	
	public void ChangePostRandom() {
		banner1.SetBannerPosition(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
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
		
		AN_PoupsProxy.showMessage ("In App Request", "In App Request for product Id: " + productId + " received");
		
		
		//Then you should perfrom purchase  for this product id, using this or another game billing plugin
		//Once the purchase is complete, you should call RecordInAppResolution with one of the constants defined in GADInAppResolution:
		
		AndroidAdMobController.instance.RecordInAppResolution(GADInAppResolution.RESOLUTION_SUCCESS);
		
	}

}
