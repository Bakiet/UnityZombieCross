using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;
using GooglePlayGames.BasicApi.Multiplayer;

public class SelectedCharacter : MonoBehaviour, AndroidNativeExampleBase {

	public bool Multiplayer;
	private Dictionary<string, float> _finishTimes;
	private bool _multiplayerGame;
	private bool _multiplayerReady;
	private string _myParticipantId;
	public SA_PartisipantUI[] patricipants;


	public Transform spawnPos;

	private GameObject character;
	private GameObject opponentcharacter;
	/// <summary>
	/// death zone object reference
	/// </summary>
	//public Transform deathZone;
	
	/// <summary>
	/// reference to all character prefabs
	/// </summary>
	public GameObject[] characters;
	public GameObject[] opponentcharacters;

	// Use this for initialization
	IEnumerator Start () {


		yield return new WaitForEndOfFrame();

		//this code runs after SOOMLA has been initialized
		//set selected character to the first one by default
		GameObject selectedChar = characters[0];
		GameObject opponentselectedChar = opponentcharacters [0];
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

		if (Multiplayer) {

			//	StoreInventory.RefreshLocalInventory ();
			//check for other character selections in the storage
			if (StoreInventory.IsVirtualGoodEquipped ("bike"))
				opponentselectedChar = opponentcharacters [0];
			else if (StoreInventory.IsVirtualGoodEquipped ("super_bike"))
				opponentselectedChar = opponentcharacters [1];
			else if (StoreInventory.IsVirtualGoodEquipped ("party_bike"))
				opponentselectedChar = opponentcharacters [2];
			else if (StoreInventory.IsVirtualGoodEquipped ("nightmare_bike"))
				opponentselectedChar = opponentcharacters [3];
			else if (StoreInventory.IsVirtualGoodEquipped ("monster_bike"))
				opponentselectedChar = opponentcharacters [4];
			else if (StoreInventory.IsVirtualGoodEquipped ("neon_bike"))
				opponentselectedChar = opponentcharacters [5];
			else if (StoreInventory.IsVirtualGoodEquipped ("hell_bike"))
				opponentselectedChar = opponentcharacters [6];
			else if (StoreInventory.IsVirtualGoodEquipped ("test_bike"))
				opponentselectedChar = opponentcharacters [7];
		}
		else
		{
			//we didn't select a character yet, meaning this app runs for the first time
			//give and equip the white box by default and refresh shop
			StoreInventory.GiveItem("bike", 1);
			StoreInventory.EquipVirtualGood("bike");
			SIS.ShopManager.SetItemState();
		}
//		GameObject.Find ("bike").SetActive(true);
		if (Multiplayer) {
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
				i++;
				string nextParticipantId = patricipants[i].playerId;
				_finishTimes [nextParticipantId] = -1;

				_finishTimes [nextParticipantId] = -1;
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
					character.SetActive (true);
					//opponentScript.SetCarNumber (i + 1);
					// 6
					//_opponentScripts [nextParticipantId] = opponentScript;
				}
			}
		} else {
			//instantiate the selected character in the game and set death zone reference
			character = (GameObject)Instantiate (selectedChar, spawnPos.position, Quaternion.identity);
			character.SetActive (true);
		}
		//deathZone.GetComponent<FollowAxis>().target = character.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerFinished(string senderId, float finalTime) {
	/*	Debug.Log ("Participant " + senderId + " has finished with a time of " + finalTime);
		if (_finishTimes[senderId] < 0) { 
			Debug.Log ("sender id: " + senderId);
			_finishTimes[senderId] = finalTime;
			Debug.Log ("saved sender id");
		}
		CheckForMPGameOver();*/
	}
	public void LeftRoomConfirmed() {
		/*MultiplayerController.Instance.updateListener = null;
		Application.LoadLevel ("MainMenu");*/
	}
	public void PlayerLeftRoom(string participantId) {
		/*if (_finishTimes[participantId] < 0) {
			_finishTimes[participantId] = 999999.0f;
			if (_opponentScripts[participantId] != null) {
				_opponentScripts[participantId].HideCar();
			}
			CheckForMPGameOver();
		}*/
	}
	public void UpdateReceived(string senderId, float posX, float posY, float velX, float velY, float rotZ) {
		/*if (_multiplayerReady) {
			OpponentCarController opponent = _opponentScripts[senderId];
			if (opponent != null) {
				opponent.SetCarInformation (posX, posY, velX, velY, rotZ);
			}
		}*/
	}
}
