using UnityEngine;
using System.Collections;

/// <summary>
/// Main screen manager.
/// Control all behavior at main screen. 
/// </summary>
public class MainScreenManager : MonoBehaviour 
{
	public GUISkin newGuiSkin;
	public Texture background;


	// Use this for initialization
	void Start () {
		SoundManager.Instance.PlaySoundFx(EnumSounds.MusicMain);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin = newGuiSkin; //using this skin we can change button appearance's

		//this is an important step.
		//AWAYS at begining of our OnGui method we call for ScreenAdapt to scale our gui to de screen resolution.
		
		//BeginScale with background is a way to easy to draw a background.
		ScreenAdapt.Instance.BeginScaleGUI(background);

		if(GUI.Button(new Rect(ScreenAdapt.Instance.marginLeft,
		                       ScreenAdapt.Instance.marginBottom,
		                       180, 60), "Play"))
		{
			Application.LoadLevel("SceneWorldSelect");
		}

		//after we finish to draw our gui, just end our scale.
		ScreenAdapt.Instance.EndScaleGUI();
	}

}
