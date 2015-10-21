using UnityEngine;
using System.Collections;


/// <summary>
/// Limit horizontal collides.
/// Placed at box at the edge of scenario ends.
/// </summary>
public class LimitHorizontalCollides : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Raises the collision enter2d event.
	/// IMPORTANT: RigidBodies 2D fires Collision 2D! Remember it
	/// </summary>
	/// <param name="collider">Collider.</param>
	void OnCollisionEnter2D(Collision2D collider)
	{
		//Just tell to our characteres to stop run to nowhere.
		PlayerController play =	collider.gameObject.GetComponent<PlayerController>();

		if(play != null)
		{
			//Do something.
		}
	}

}
