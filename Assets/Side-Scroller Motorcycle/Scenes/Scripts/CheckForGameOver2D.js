#pragma strict
//@script RequireComponent(Rigidbody)

//Attach this script to the Body of your vehicle
var CollisionDuration : float;
var TimeToGameOver : float = 5f;
var IsGameOver : boolean = false;

function OnCollisionStay2D(collision : Collision2D)
{
	CollisionDuration += Time.deltaTime;
	
	if(CollisionDuration >= TimeToGameOver)
	{
		//Place your code here
		Application.LoadLevel(Application.loadedLevel); // Restart the current level
		IsGameOver = true;
		Debug.Log("GameOver!");
	}
}