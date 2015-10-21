using UnityEngine;
using System.Collections;


/// <summary>
/// Determine behavior of our Food when it collides player.
/// </summary>
public class FoodCollidesPlayer : MonoBehaviour {


	ScenePlayManager gm;
	PlayerController playerControl;


	void Awake()
	{
		gm = FindObjectOfType<ScenePlayManager>();

		//gets playerController to inform it what happened here.
		playerControl = this.gameObject.GetComponent<PlayerController>();

	}


	void OnCollisionEnter2D(Collision2D collision) 
	{
		//check if colides with food and what kind of food is.
		if (collision.gameObject.tag == "Food")
		{
			Food food = collision.gameObject.GetComponent<Food> ();

			//this example we only drop Bug food And Coins (coin with same behavior as food).
			//****** But this code will help you to create your own.
			switch (food.foodType) 
			{
				case EnumFoodType.Bug:
				{
					playerControl.DoEat(); //tell to our player that he must to eat now.
					Destroy(collision.gameObject);
				}
					break;
				case EnumFoodType.Coin:
				{
					playerControl.DoEatCoin(); //tell to our player that he must to eat now.
					Destroy(collision.gameObject);
				}
					break;
				default :
				{
					Destroy(collision.gameObject);
				}
					break;
			}
		}

	}



}
