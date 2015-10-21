using UnityEngine;
using System.Collections;


/// <summary>
/// Food collides floor.
/// Determines behavior of our food when it collides the bottom box.
/// Lost it.
/// </summary>
public class FoodCollidesFloor : MonoBehaviour
{

	ScenePlayManager gm;

	void Awake()
	{
		gm = FindObjectOfType<ScenePlayManager>();

	}
	

	//void OnTriggerEnter (Collider other)
	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.tag != "Player")
		{
			//Floor use else case. You can use this to things like achievements.
			//gm.LostFood();
			Destroy(collision.gameObject);
		}
	}

	
}