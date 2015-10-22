using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenagerAudio : MonoBehaviour {

	public List <AudioClip> audioList;

	private AudioSource music;

	// Use this for initialization
	void Start () {
		music = GetComponent <AudioSource>();

		StartCoroutine (PlayMusicBackground ());
	}

	private IEnumerator PlayMusicBackground () {
		while (true) {
			int n = Mathf.RoundToInt (Random.Range (0, audioList.Count));

			music.PlayOneShot (audioList[n]);

			yield return new WaitForSeconds (audioList[n].length);
		}
	}
}
