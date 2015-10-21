using UnityEngine;
using System.Collections;

/// <summary>
/// Food.
/// This class defines our Food behavior at all.
/// </summary>
public class Food : MonoBehaviour {

	private static int _qtd = 0;   	//count total food dropped. You can use this info to achievementes etc.

	//to this two variable you can convert in only one. I prefer to use both 
	//i think is more simply to understand code after some time.

	public EnumFoodType foodType;			//say what will be this food type.
	public EnumFoodEffect foodEffect;		//and what effect this will do.

	public bool MovCatchCoin = false;
	
	public static int probabCoin = 15;  //1-100 -> until 7% is coin. 10% / 13% / 16%
	public static int probabPowerUp = 25; //= 13% //from 7% until 19% (seems 12%) is powerUp;   22% / 25% / 28% /


	public Sprite[] foodKinds;	//Use it to put all of your sprites that can be dropped.

	/// <summary>
	/// Awake this instance.
	/// Even when awake, we need to create a 'personality' to our food.
	/// </summary>
	void Awake()
	{
		Create();
	}
	

	private void Create()
	{
		int chance = (int)(Random.value * 100);
		int specie = 1;

		//**** We dont use this part.
		//**** But i decide to put this code here to auxiliate you if you like to use.
		//**** random percentage to know what 'personality' our food will have.

		//COIN
		if (chance <= probabCoin)
		{
			foodType = EnumFoodType.Coin;
			foodEffect = EnumFoodEffect.Coin;
			specie = 0;	//appearance of our food.
		}
		//FOOD
		else
		{
			foodType = EnumFoodType.Bug;
			foodEffect = EnumFoodEffect.Feed;
			specie =   Random.Range (1,9); //((Random.value + 0.2f) * 10)-1; //rands between 1-10.
		}

		//use that array of prefabs to get renderer by position of 'specie'.
		this.GetComponent<SpriteRenderer>().sprite = foodKinds[specie];

		_qtd++; //just to know how many food has been created.
	}





}
