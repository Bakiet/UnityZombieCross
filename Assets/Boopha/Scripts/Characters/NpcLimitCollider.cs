using UnityEngine;
using System.Collections;


/// <summary>
/// This class is used in boxes at limits of scenary. When NPC touches it, just goes to anothe side.
/// Prevent to NPC continues until infinity and beyond =)
/// </summary>
public class NpcLimitCollider : MonoBehaviour {

	private float timeToChange = 0.3f;
	private float elapsedTime =0.0f;
	

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(elapsedTime >= timeToChange)
		{
			elapsedTime =0.0f;

			if (collision.gameObject.tag == "NPC") 
			{
				collision.gameObject.GetComponent<NpcController>().GoToOtherSide ();
			}
		}
	}
}
