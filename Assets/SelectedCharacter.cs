using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;
//using GooglePlayGames.BasicApi.Multiplayer;

public class SelectedCharacter : MonoBehaviour {


	//public bool Multiplayer;

	//private bool _multiplayerGame;
	//private bool _multiplayerReady;
	//private string _myParticipantId;
	//public SA_PartisipantUI[] patricipants;


	public Transform spawnPos;

	private GameObject character;
	//private GameObject opponentcharacter;
	//private GameObject effect;
	/// <summary>
	/// death zone object reference
	/// </summary>
	//public Transform deathZone;
	
	/// <summary>
	/// reference to all character prefabs
	/// </summary>
	public GameObject[] characters;
	//public GameObject[] opponentcharacters;
	//public GameObject[] effects;

	public static bool super_bike_effect =false;
	public static bool party_effect =false;
	public static bool nightmare_effect =false;
	public static bool monster_effect =false;
	public static bool neon_effect =false;
	public static bool hell_effect =false;


	public static bool bikeselected=false;
	public static bool superbikeselected=false;
	public static bool partybikeselected=false;
	public static bool nightmarebikeselected=false;
	public static bool monsterbikeselected=false;
	public static bool neonbikeselected=false;
	public static bool hellbikeselected=false;
	public static bool testbikeselected=false;
	public static bool bluebikeselected=false;
	public static bool peacebikeselected=false;
	public static bool summerbikeselected=false;
	public static bool sunshinebikeselected=false;
	public static bool superbikeeffectselected=false;
	public static bool partybikeeffectselected=false;
	public static bool nightmarebikeeffectselected=false;
	public static bool monsterbikeeffectselected=false;
	public static bool neonbikeeffectselected=false;
	public static bool hellbikeeffectselected=false;

	// Use this for initialization
	IEnumerator Start () {

		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
			//GooglePlayConnection.Instance.Disconnect ();
		} else {
			//GooglePlayConnection.Instance.Connect ();
		}
		yield return new WaitForEndOfFrame();

		//this code runs after SOOMLA has been initialized
		//set selected character to the first one by default
		GameObject selectedChar = characters[0];
		//GameObject selectedChar = null;
		//GameObject	opponentselectedChar = opponentcharacters [0];

	//	StoreInventory.RefreshLocalInventory ();
		//check for other character selections in the storage
		//if (StoreInventory.IsVirtualGoodEquipped("bike"))
		if (bikeselected)
			selectedChar = characters[0];
		//else if (StoreInventory.IsVirtualGoodEquipped("super_bike"))
		else if (superbikeselected)
			selectedChar = characters[1];
		else if (partybikeselected)
			selectedChar = characters[2];
		else if (nightmarebikeselected)
			selectedChar = characters[3];
		else if (monsterbikeselected)
			selectedChar = characters[4];
		else if (neonbikeselected)
			selectedChar = characters[5];
		else if (hellbikeselected)
			selectedChar = characters[6];
		else if (bluebikeselected)
			selectedChar = characters[7];
		else if (summerbikeselected)
			selectedChar = characters[8];
		else if (peacebikeselected)
			selectedChar = characters[9];
		else if (sunshinebikeselected)
			selectedChar = characters[10];

		//GameObject selectedEffect = effects[0];
		
		//	StoreInventory.RefreshLocalInventory ();
		//check for other character selections in the storage
		if (superbikeeffectselected) {
			super_bike_effect = true;
			superbikeselected = true;
		} else {
			super_bike_effect = false;
		}
		if (partybikeeffectselected){
			party_effect = true;
			partybikeselected = true;
		}else{
			party_effect = false;
		}
		if (nightmarebikeeffectselected) {
			nightmare_effect = true;
			nightmarebikeselected = true;
		} else {
			nightmare_effect = false;
		}
		if (monsterbikeeffectselected) {
			monster_effect = true;
			monsterbikeselected = true;
		} else {
			monster_effect = false;
		}
		if (neonbikeeffectselected) {
			neon_effect = true;
			neonbikeselected = true;
		} else {
			neon_effect = false;
		}
		if (hellbikeeffectselected) {
			hell_effect = true;
			hellbikeselected = true;
		} else {
			hell_effect = false;
		}

	
		if (selectedChar == null) {
			//we didn't select a character yet, meaning this app runs for the first time
			//give and equip the white box by default and refresh shop
			//StoreInventory.GiveItem("bike", 1);
			//StoreInventory.EquipVirtualGood("bike");
			//SIS.ShopManager.SetItemState();
		}
		/*if (selectedEffect == null) {

			selectedEffect = effects[0];

		}*/

	/*	if (Multiplayer) {

			//	StoreInventory.RefreshLocalInventory ();
			//check for other character selections in the storage
			if (bikeselected)
				opponentselectedChar = opponentcharacters [0];
			else if (superbikeselected)
				opponentselectedChar = opponentcharacters [1];
			else if (partybikeselected)
				opponentselectedChar = opponentcharacters [2];
			else if (nightmarebikeselected)
				opponentselectedChar = opponentcharacters [3];
			else if (monsterbikeselected)
				opponentselectedChar = opponentcharacters [4];
			else if (neonbikeselected)
				opponentselectedChar = opponentcharacters [5];
			else if (hellbikeselected)
				opponentselectedChar = opponentcharacters [6];
			else if (bluebikeselected)
				opponentselectedChar = opponentcharacters [7];
			else if (summerbikeselected)
				opponentselectedChar = opponentcharacters [8];
			else if (peacebikeselected)
				opponentselectedChar = opponentcharacters [9];
			else if (sunshinebikeselected)
				opponentselectedChar = opponentcharacters [10];

		}
		else
		{

		}*/
		//GameObject.Find ("bike").SetActive(true);
		/*if (Multiplayer) {
			//MultiplayerController.Instance.updateListener = this;
			// 1
			//_myParticipantId = MultiplayerController.Instance.GetMyParticipantId ();
			// 2
			//List<Participant> allPlayers = MultiplayerController.Instance.GetAllPlayers ();
			//_opponentScripts = new Dictionary<string, OpponentCarController> (allPlayers.Count - 1); 
			//_finishTimes = new Dictionary<string, float> (allPlayers.Count);

			int i = 0;
			foreach(GP_Participant p in GooglePlayRTM.instance.currentRoom.participants) {
				patricipants[i].gameObject.SetActive(true);
				patricipants[i].SetParticipant(p);

				string nextParticipantId = patricipants[i].playerId.text;
				_finishTimes [nextParticipantId] = -1;

				i++;
				Debug.Log ("Setting up car for " + nextParticipantId);
				// 3
				if (nextParticipantId == _myParticipantId) {
					// 4
					character = (GameObject)Instantiate (selectedChar, spawnPos.position, Quaternion.identity);
					character.SetActive (true);
					//myCar.GetComponent<CarController> ().SetCarChoice (i + 1, true);
					//myCar.transform.position = carStartPoint;
				} else {
					// 5
					opponentcharacter = (GameObject)Instantiate (opponentselectedChar, spawnPos.position, Quaternion.identity);
					//OpponentCarController opponentScript = opponentcharacter.GetComponent<OpponentCarController> ();
					opponentcharacter.SetActive (true);
					//opponentScript.SetCarNumber (i + 1);
					// 6
					//_opponentScripts [nextParticipantId] = opponentScript;
				}
			}
		} else {
			//instantiate the selected character in the game and set death zone reference
			character = (GameObject)Instantiate (selectedChar, spawnPos.position, Quaternion.identity);
			character.SetActive (true);
			//if have effect
			if(selectedEffect){
				effect = (GameObject)Instantiate (selectedEffect, character.GetComponent<Motorcycle_Controller2D>().rearWheel.position, Quaternion.identity);
				effect.SetActive (true);
			}
		}*/
		//deathZone.GetComponent<FollowAxis>().target = character.transform;
		//if(Motorcycle_Controller2D.lastcheckpoint){

		/*

		character = (GameObject)Instantiate (selectedChar, spawnPos.position, Quaternion.identity);
		character.SetActive (true);

		*/

		//}
		//if have effect
		/*if(selectedEffect){
			effect = (GameObject)Instantiate (selectedEffect, character.GetComponent<Motorcycle_Controller2D>().rearWheel.position, Quaternion.identity);
			effect.SetActive (true);
		}*/
	
	}

}
