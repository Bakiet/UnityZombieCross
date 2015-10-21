using UnityEngine;
using System.Collections;
using Soomla.Store;

public class SelectedCharacter : MonoBehaviour {


	public Transform spawnPos;

	private GameObject character;
	/// <summary>
	/// death zone object reference
	/// </summary>
	//public Transform deathZone;
	
	/// <summary>
	/// reference to all character prefabs
	/// </summary>
	public GameObject[] characters;

	// Use this for initialization
	IEnumerator Start () {


		yield return new WaitForEndOfFrame();

		//this code runs after SOOMLA has been initialized
		//set selected character to the first one by default
		GameObject selectedChar = characters[0];
	//	StoreInventory.RefreshLocalInventory ();
		//check for other character selections in the storage
		if (StoreInventory.IsVirtualGoodEquipped("bike"))
			selectedChar = characters[0];
		else if (StoreInventory.IsVirtualGoodEquipped("super_bike"))
			selectedChar = characters[1];
		else if (StoreInventory.IsVirtualGoodEquipped("party_bike"))
			selectedChar = characters[2];
		else if (StoreInventory.IsVirtualGoodEquipped("nightmare_bike"))
			selectedChar = characters[3];
		else if (StoreInventory.IsVirtualGoodEquipped("monster_bike"))
			selectedChar = characters[4];
		else if (StoreInventory.IsVirtualGoodEquipped("neon_bike"))
			selectedChar = characters[5];
		else if (StoreInventory.IsVirtualGoodEquipped("hell_bike"))
			selectedChar = characters[6];
		else if (StoreInventory.IsVirtualGoodEquipped("test_bike"))
			selectedChar = characters[7];
		else
		{
			//we didn't select a character yet, meaning this app runs for the first time
			//give and equip the white box by default and refresh shop
			StoreInventory.GiveItem("bike", 1);
			StoreInventory.EquipVirtualGood("bike");
			SIS.ShopManager.SetItemState();
		}
//		GameObject.Find ("bike").SetActive(true);

		//instantiate the selected character in the game and set death zone reference
		character = (GameObject)Instantiate(selectedChar, spawnPos.position, Quaternion.identity);
		character.SetActive(true);

		//deathZone.GetComponent<FollowAxis>().target = character.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
