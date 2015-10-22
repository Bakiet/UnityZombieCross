using UnityEngine;
using System.Collections;

public class OpenNewScene : MonoBehaviour {

	public EnumStartAnimation newAnimation;

	public void StartLoadingScene (string name) {
		LoadSceneScript lss = FindObjectOfType <LoadSceneScript>();

		if (lss != null) {
			if (lss.wasCompletedAnimations)
				lss.StartLoadScene (name);
			else 
				Debug.Log ("Wait for end animations");
		} else {
			Debug.Log ("There is no LoadSceneScript in Inspector");
		} 
	} // StartLoadingScene ()

	public void ChangeAnimation () {
		LoadSceneScript lss = FindObjectOfType <LoadSceneScript>();
		
		if (lss != null) {
			if (lss.wasCompletedAnimations)
				lss.StartAnimation = newAnimation;
			else 
				Debug.Log ("Wait for end animations");
		} else {
			Debug.Log ("There is no LoadSceneScript in Inspector");
		}
	} // ChangeAnimation ()
	

} // end
