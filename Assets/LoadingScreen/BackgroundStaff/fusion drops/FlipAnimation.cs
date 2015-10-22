/*
 * Created by Gimer - Adam Bawelski
 * usergimer@gmail.com
 * www.gimer.pl
 */

using UnityEngine;
using System.Collections;

public enum playAnimation {
	invasion, bass
}

[RequireComponent (typeof (Animator))]
public class FlipAnimation : MonoBehaviour {

	public playAnimation animToPlay;

	[Range (0, 10)]
	public float loopTime = 2.5f;
	public bool replaceSide = true;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();

		StartCoroutine (ieFlipAnimation ());
	} // Start ()
	
	private IEnumerator ieFlipAnimation () {
		while (true) {
			switch (animToPlay) {
			case playAnimation.invasion:
				anim.SetTrigger ("left");

				yield return new WaitForSeconds (loopTime);

				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				anim.SetTrigger ("right");

				yield return new WaitForSeconds (loopTime);

				if (!replaceSide)
					transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				break;
			case playAnimation.bass:
				anim.SetTrigger ("bass");
				yield return new WaitForSeconds (loopTime);
				break;
			} // switch
		} // while
	} // ieFlipAnimation ()
} // end
