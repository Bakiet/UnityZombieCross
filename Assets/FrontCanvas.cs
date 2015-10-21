using UnityEngine;
using System.Collections;

public class FrontCanvas : MonoBehaviour {

	private bool _isShow = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI()
	{
		GUILayout.BeginVertical();
		
		DrawToggleShowButton();

		GUILayout.EndVertical();
	}

	private void DrawToggleShowButton()
	{
		if (!_isShow)
		{
			if (GUILayout.Button("Show API tests"))
			{
				_isShow = true;
			}
		}
		if (_isShow)
		{
			if (GUILayout.Button("Hide API tests"))
			{
				_isShow = false;
			}
		}
	}
}
