using UnityEngine;
using System.Collections;

/// <summary>
/// Sound manager.
/// We think this class is helpful to control and maintain sound music and effects.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	/// <summary>
	/// The _instance of our singleton class.
	/// </summary>
	private static SoundManager _instance;

	public static SoundManager Instance
	{
		get
		{ 
			if(_instance == null)
			{
				_instance = FindObjectOfType<SoundManager>();
			}

			return _instance;
		}
	}

	private AudioSource asource;		//you can use audio source of your main cam.

	public bool IsMuted = false;		//Indicate if our class will be muted or not.

	public AudioClip sfxEat;		//sfx sound effects. Create how many you wants.
	public AudioClip sfxCoin;
	public AudioClip sfxClick;

	public AudioClip bgMenu;		//bg background music. Idem.
	public AudioClip bgLevel;
	public AudioClip bgWin;
	public AudioClip bgLose;

	void Awake()
	{
		SoundManager[] fake = FindObjectsOfType<SoundManager>();
		
		if(fake != null && fake.Length > 1)
		{
			throw new UnityException("Scene has two or more instances of SoundManager");
		}
		
	}


	/// <summary>
	/// Plaies the sound fx.
	/// </summary>
	/// <param name="opt">Opt.</param>
	public void PlaySoundFx(EnumSounds opt)
	{

		//In this enum option we can control audio volume that will apply to all places of game that uses it.
		//and we can change what will plays. All changes will reflect all calls during game code.
		switch(opt)
		{
		case EnumSounds.Eat:
			GetComponent<AudioSource>().PlayOneShot(sfxEat,0.75f);
			break;
		case EnumSounds.Coin:
			GetComponent<AudioSource>().PlayOneShot(sfxCoin,0.8f);
			break;
		case EnumSounds.Click:
			GetComponent<AudioSource>().PlayOneShot(sfxClick,1f);
			break;
		case EnumSounds.MusicMain:
			PlayMusic (bgMenu);
			break;
		case EnumSounds.MusicLevel:
			PlayMusic (bgLevel);
			break;
		case EnumSounds.MusicWin:
			PlayMusicEnd(bgWin);
			break;
		case EnumSounds.MusicLose:
			PlayMusic (bgLose);
			break;
			
		}
	}

	public void Pause()
	{
		ChangeMute(true);
	}

	public void Continue()
	{
		ChangeMute(false);
	}

	private void ChangeMute(bool toMute)
	{
		AudioSource[] asource = FindObjectsOfType<AudioSource>();
		for(int i=0; i< asource.Length; i++)
		{
			asource[i].mute = toMute;
		}
		IsMuted = toMute;
	}


	/// <summary>
	/// Plays the loop musics.
	/// </summary>
	/// <param name="music">Music.</param>
	private void PlayMusic(AudioClip music)
	{
		if(!IsMuted)
		{
			AudioSource asource = FindObjectOfType<AudioSource>();
			asource.clip = music;
			asource.loop = true;
			asource.volume = 0.5f;
			asource.playOnAwake = true;
			asource.Play ();
		}
	}

	/// <summary>
	/// Plays one shot of the ending music.
	/// </summary>
	/// <param name="music">Music.</param>
	private void PlayMusicEnd(AudioClip music)
	{
		if(!IsMuted)
		{
			AudioSource asource = FindObjectOfType<AudioSource>();
			asource.clip = music;
			asource.loop = false;
			asource.volume = 0.5f;
			asource.playOnAwake = true;
			asource.Play();
		}
	}




	
}
