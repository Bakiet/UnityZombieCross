#pragma strict
var TransparentStyle : GUIStyle;


function Start () {

}

function Update () {

}

function OnGUI()
{
	if(GUI.Button(Rect(Screen.width - 640,Screen.height - 400,80,80),"ButtonExit", TransparentStyle))
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}