/*
 * Created by Gimer - Adam Bawelski
 * usergimer@gmail.com
 * www.gimer.pl
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum EnumStartAnimation {
	none, appear, entery_of_the_left, entery_of_the_top, entery_of_the_right, entery_of_the_bottom, eye_opening, tornado
}

public class LoadSceneScript : MonoBehaviour {

	/**
	 * This scene must be in Build Settings
	 */
	public string sceneName;
	public bool loadImmediately = false;

	/**
	 * Some scenes are loaded so quickly that it's worth giving the player a moment to get to know the logo or read the text.
	 */ 
	[Range (0, 10)]
	public float waitTime = 1f;
	public GameObject goCanvas;
	public Image imgProgressBar;
	public Text txtLoadingProgress;

	//Animations
	public EnumStartAnimation StartAnimation;
	private List <Vector4> alphaEnd = new List<Vector4>();
	private Animator anim;

	public bool wasCompletedAnimations = false;

	private static LoadSceneScript instance { get; set; }

	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			if (this != instance)
				Destroy (this.gameObject);
		}
	} // Awake ()
	
	void Start () {
		anim = GetComponentInChildren <Animator>();

		if (loadImmediately)
			StartCoroutine (LoadingScene ());
		else {
			StartCoroutine (MakeOff ());
		}
	} // Start ()

	 public IEnumerator LoadingScene () {
		wasCompletedAnimations = false;
		goCanvas.SetActive (true);
		imgProgressBar.fillAmount = 0f;
		if (txtLoadingProgress != null)
			txtLoadingProgress.text = "0 %";
		
		float waitForEndAnimationTime = 0.5f;

		switch (StartAnimation) {
		case EnumStartAnimation.appear:
			waitForEndAnimationTime = 1.0f;
			StartCoroutine (ChangeAplhaOn ());
			break;
		case EnumStartAnimation.entery_of_the_left:
			anim.SetTrigger ("left");
			break;
		case EnumStartAnimation.entery_of_the_top:
			anim.SetTrigger ("top");
			break;
		case EnumStartAnimation.entery_of_the_right:
			anim.SetTrigger ("right");
			break;
		case EnumStartAnimation.entery_of_the_bottom:
			anim.SetTrigger ("bottom");
			break;
		case EnumStartAnimation.eye_opening:
			anim.SetTrigger ("eyeOpening");
			break;
		case EnumStartAnimation.tornado:
			anim.SetTrigger ("tornadoOn");
			break;
		default:
			waitForEndAnimationTime = 0.0f;
			break;
		}

		yield return new WaitForSeconds (waitTime + waitForEndAnimationTime);
		
		AsyncOperation async = Application.LoadLevelAsync (sceneName);

		if (imgProgressBar != null)
		while (!async.isDone) {
			imgProgressBar.fillAmount = async.progress;

			if (txtLoadingProgress != null)
				txtLoadingProgress.text = (int)(async.progress * 100) + " %";
			
			yield return null;
		}
		else
		while (!async.isDone) {			
			if (txtLoadingProgress != null)
				txtLoadingProgress.text = (int)(async.progress * 100) + " %";
			
			yield return null;
		}

		StartCoroutine (MakeOff ());
	} // LoadingScene ()

	/**
	 * Load Scene without canvas
	 */
	public void LoadSmallScene (string name) {
		Application.LoadLevel (name.ToString ());
	}

	/**
	 * Load Scene with canvas animations
	 */
	public void StartLoadScene (string name) {
		if (wasCompletedAnimations) {
			sceneName = name;
			StartCoroutine (LoadingScene ());
		} else {
			Debug.Log ("Wait for end animations");
		}
	}

	#region Effects
	private IEnumerator ChangeAplhaOn () {
		Image[] listOfImagesComponents = transform.GetComponentsInChildren <Image>();

		alphaEnd = new List<Vector4>();
		foreach (Image ic in listOfImagesComponents) {
			alphaEnd.Add (ic.color);
			ic.color = new Vector4 (ic.color.r, ic.color.g, ic.color.b, 0f);
		}

		// add text color
		alphaEnd.Add (txtLoadingProgress.color);
		txtLoadingProgress.color = new Color (txtLoadingProgress.color.r, txtLoadingProgress.color.g, txtLoadingProgress.color.b, 0f);

		anim.SetTrigger ("canvasOn");

		for (int i = 0; i < 20; i++) {
			for (int j = listOfImagesComponents.Length -1; j > -1; j--) {
				if (alphaEnd [j].w > listOfImagesComponents [j].color.a) {
					var tempColor = listOfImagesComponents [j].color;
					tempColor.a += 0.05f;

					listOfImagesComponents [j].color = tempColor;
				}
			}

			// change text alpha
			var temp = txtLoadingProgress.color;
			temp.a += 0.05f;
			txtLoadingProgress.color = temp;

			yield return new WaitForSeconds (0.05f);
		}
	} // ChangeAplhaOn()

	private IEnumerator ChangeAplhaOff () {
		Image[] listOfImagesComponents = transform.GetComponentsInChildren <Image>();

		alphaEnd = new List<Vector4>();
		foreach (Image ic in listOfImagesComponents) {
			alphaEnd.Add (ic.color);
		}

		// add text color
		alphaEnd.Add (txtLoadingProgress.color);
		
		for (int i = 0; i < 20; i++) {
			for (int j = listOfImagesComponents.Length -1; j > -1; j--) {
				if (0f != listOfImagesComponents [j].color.a) {
					var tempColor = listOfImagesComponents [j].color;
					tempColor.a -= 0.05f;
					
					listOfImagesComponents [j].color = tempColor;
				}
			}

			// change text alpha
			var temp = txtLoadingProgress.color;
			temp.a -= 0.05f;
			txtLoadingProgress.color = temp;
			
			yield return new WaitForSeconds (0.05f);
		}

		anim.SetTrigger ("canvasOff");

		// reset
		for (int j = listOfImagesComponents.Length -1; j > -1; j--) {
			listOfImagesComponents [j].color = new Color (alphaEnd [j].x, alphaEnd [j].y, alphaEnd [j].z, alphaEnd [j].w);
		}
		
		// change text alpha
		txtLoadingProgress.color = new Color (alphaEnd [alphaEnd.Count - 1].x, alphaEnd [alphaEnd.Count - 1].y, alphaEnd [alphaEnd.Count - 1].z, alphaEnd [alphaEnd.Count - 1].w);
	
		goCanvas.SetActive (false);
	} // ChangeAplhaOff()
	#endregion

	private IEnumerator MakeOff () {
		loadImmediately = false;
		imgProgressBar.fillAmount = 1f;
		txtLoadingProgress.text = "100 %";
		
		switch (StartAnimation) {
		case EnumStartAnimation.appear:
			StartCoroutine (ChangeAplhaOff ());
			break;
		case EnumStartAnimation.entery_of_the_left:
			anim.SetTrigger ("left2");
			break;
		case EnumStartAnimation.entery_of_the_top:
			anim.SetTrigger ("top2");
			break;
		case EnumStartAnimation.entery_of_the_right:
			anim.SetTrigger ("right2");
			break;
		case EnumStartAnimation.entery_of_the_bottom:
			anim.SetTrigger ("bottom2");
			break;
		case EnumStartAnimation.eye_opening:
			anim.SetTrigger ("eyeClosing");
			break;
		case EnumStartAnimation.tornado:
			anim.SetTrigger ("tornadoOff");
			break;
		}

		// wait for end of animations
		yield return new WaitForSeconds (3f);
		goCanvas.SetActive (false);

		wasCompletedAnimations = true;
	} // MakeOff ()


} // end
