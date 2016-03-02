using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnControl : MonoBehaviour 
{
	public GameObject ConnectBtn;
	public Text ConnectBtnText;
	public GameObject findMatchBtn;
	public GameObject inviteFriendBtn;
	public GameObject showRoomBtn;
	public GameObject leaveRoomBtn;
	public GameObject moveButtons;
	public GameObject blackPlayer;
	public GameObject bluePlayer;
	public GameObject greenPlayer;
	public GameObject redPlayer;	
	public Label[] patricipants;
	public SA_FriendUI[] friends;
	bool onetime1;
	bool onetime2;
	bool onetime3;
	bool onetime4;
	bool onetime5;
	// Use this for initialization
	void Start () 
	{
		GooglePlayConnection.ActionPlayerConnected +=  OnPlayerConnected;

		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) 
		{
			//checking if player already connected
			OnPlayerConnected ();
		} 
	}
	
	// Update is called once per frame


	void FixedUpdate() 
	{
		DrawParticipants();


		if(GooglePlayRTM.instance.currentRoom.status == GP_RTM_RoomStatus.ROOM_STATUS_ACTIVE) 
		{
			//if(!onetime1)
			//{
			//	onetime1 = true;
				GameObject.FindWithTag("Disable").SetActive(false);
			//}
		}
		
		if(GooglePlayRTM.instance.currentRoom.status!= GP_RTM_RoomStatus.ROOM_VARIANT_DEFAULT && GooglePlayRTM.instance.currentRoom.status!= GP_RTM_RoomStatus.ROOM_STATUS_ACTIVE) 
		{
			if(!onetime2)
			{
				onetime2 = true;
				showRoomBtn.SetActive(true);
			}
			//showRoomButton.EnabledButton();
		}
		else 
		{
			if(!onetime3)
			{
				onetime3 = true;
				showRoomBtn.SetActive(false);
			}
			//showRoomButton.DisabledButton();
		}

		if(GooglePlayRTM.instance.currentRoom.status == GP_RTM_RoomStatus.ROOM_VARIANT_DEFAULT) 
		{
			if(!onetime4)
			{
				onetime4 = true;
				leaveRoomBtn.SetActive(false);
			}
			//leaveRoomButton.DisabledButton();		
		} 
		else 
		{
			if(!onetime5)
			{
				onetime5 = true;
				leaveRoomBtn.SetActive(true);
			}
			//leaveRoomButton.EnabledButton();	
		}	
	}

	private void DrawParticipants() 
	{		
		foreach(Label p in patricipants) 
		{
			p.gameObject.SetActive(false);
		}
		int i = 0;
		foreach(GP_Participant p in GooglePlayRTM.instance.currentRoom.participants) 
		{
			patricipants[i].gameObject.SetActive(true);
			patricipants[i].SetParticipant(p);
			i++;
		}
	}

	private void OnPlayerConnected() 
	{
		GooglePlayManager.ActionFriendsListLoaded +=  OnFriendListLoaded;	
		ConnectBtnText.text = PlusNetworkManager.PNInstance.title;
	}

	void OnFriendListLoaded (GooglePlayResult result) 
	{
		Debug.Log("OnFriendListLoaded: " + result.message);
		GooglePlayManager.ActionFriendsListLoaded -=  OnFriendListLoaded;
		
		if(result.isSuccess) 
		{
			Debug.Log("Friends Load Success");
			int i = 0;
			foreach(string fId in GooglePlayManager.instance.friendsList) 
			{
				if(i < 2) 
				{
					friends[i].SetFriendId(fId);
				}
				i++;
			}
		}
	}
}
