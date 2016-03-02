//#define SA_DEBUG_MODE

using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlusNetworkManager : AndroidNativeExampleBase 
{
	/////////////////////////////////////////////////////////
	/// DO NOT TOUCH THE REST
	/// If you make changes, it is at your own risk.
	/// Made by Gamozome 30 / 9 - 2015
	/////////////////////////////////////////////////////////

	public static PlusNetworkManager PNInstance;
	[HideInInspector]
	public Text playerLabel;
	[HideInInspector]
	public Text gameState;
	[HideInInspector]
	public Text parisipants;
	public int minPlayers = 1;
	public int maxPlayersUpto8 = 3;
	[HideInInspector]
	public bool teamMatch;
	[HideInInspector]
	public int noOfFriend;
	[HideInInspector]
	public int noOfEnemy;
	public Transform[] spawnPosition;
	public GameObject[] spawnPrefab;
	[HideInInspector]
	public string title = "Connect";
	bool oneTime;
	string myID = "";
	int myPlayerPos1;
	GameObject myPlayerPrefab;
	PlusNetworkTransform[] myPlayerController = new PlusNetworkTransform[8];
	bool oneTime1;
	bool moveBtnOneTime;
	int ESOther;
	string myGame = "";
	bool DrawParticipantsBool;

	void Awake()
	{
		if(PNInstance != null)
			GameObject.Destroy(PNInstance);
		else
			PNInstance = this;
		
		DontDestroyOnLoad(this);
	}

	void Start() 
	{

		playerLabel.text = "Player Disconnected";

		//listen for GooglePlayConnection events
		GooglePlayInvitationManager.ActionInvitationReceived += OnInvite;
		GooglePlayInvitationManager.ActionInvitationAccepted += ActionInvitationAccepted;
		GooglePlayRTM.ActionRoomCreated += OnRoomCreated;
		GooglePlayConnection.ActionPlayerConnected +=  OnPlayerConnected;
		GooglePlayConnection.ActionPlayerDisconnected += OnPlayerDisconnected;
		GooglePlayConnection.ActionConnectionResultReceived += OnConnectionResult;
		
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) 
		{
			//checking if player already connected
			OnPlayerConnected ();
		} 
		//networking event
		GooglePlayRTM.ActionDataRecieved += OnGCDataReceived;
		//ravi

		int n = 0;
		foreach(GameObject PrefabInGame in spawnPrefab)
		{
			PlayerPrefs.SetString("prefabInGame"+n,PrefabInGame.name);
			PlayerPrefs.SetInt("prefabLen",n);
			n++;
		}
	}

	public void ConncetButtonPress() 
	{
		Debug.Log("GooglePlayManager State  -> " + GooglePlayConnection.State.ToString());
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) 
		{
			SA_StatusBar.text = "Disconnecting from Play Service...";
			GooglePlayConnection.instance.Disconnect ();
		} 
		else 
		{
			SA_StatusBar.text = "Connecting to Play Service...";
			GooglePlayConnection.instance.Connect ();
		}
	}
	
	public void ShowWatingRoom() 
	{
		GooglePlayRTM.instance.ShowWaitingRoomIntent();
	}
	public void findMatch() 
	{
		GooglePlayRTM.instance.FindMatch(minPlayers, maxPlayersUpto8);
	}

	public void InviteFriends() 
	{
		GooglePlayRTM.instance.OpenInvitationBoxUI(minPlayers, maxPlayersUpto8);
	}

	public void LeaveRoom() 
	{	
		SendDestoryElement();
		GooglePlayRTM.instance.LeaveRoom();
		Destroy(GameObject.Find(myPlayerPos1.ToString()));	
	}

	private void UpdateGameState(string msg) 
	{
		gameState.text = msg;
	}

	private void DrawParticipants() 
	{		
		int i = 0;

			string myID1 = GooglePlayManager.instance.player.playerId;
			foreach (GP_Participant p in GooglePlayRTM.instance.currentRoom.participants) {
				if (p.playerId.Equals (myID1)) {
					if (!oneTime) {
						oneTime = true;
						myID = p.id.ToString ();					
						PlayerPrefs.SetString ("myPlayerID", myID);
						DrawParticipantsBool = true;
					}
				}
				i++;
			}

	}

	void FixedUpdate() 
	{	
	//ravi
		if(GooglePlayRTM.instance.currentRoom.status == GP_RTM_RoomStatus.ROOM_STATUS_ACTIVE) 
		{		
			GameObject player;
			int i = 0;

			if (!oneTime1)
			{	
				foreach(GP_Participant p in GooglePlayRTM.instance.currentRoom.participants) 
				{
					if(p.id.Equals(myID))
					{
						myPlayerPrefab = spawnPrefab[PlayerPrefs.GetInt("ElementInUse")];
						player = (GameObject) GooglePlayRTM.Instantiate(myPlayerPrefab,spawnPosition[i].transform.position,spawnPosition[i].transform.rotation);
						myPlayerPrefab = player;
						myPlayerPos1 = i;
						PlayerPrefs.SetInt("myPlayerPos",myPlayerPos1);
						player.name = i.ToString();	
						player.tag = "plusMyPlayer";

//						you can use index numbers of players for any perticular functionalty 
//						so for example if you want to make player [0] a “GameOwner”, you can custom tag him by replacing
//						
//						player.tag = "plusMyPlayer";
//						
//						line to
//							
//						if(i == 0)
//						{
//							Assign any tag & apply Your Logic for player index 0…
//						}
//						else
//						{
//							player.tag = "plusMyPlayer";
//						}
					}
					i++;
				}
				sendElement();
			}
			oneTime1 = true;
		} 

		UpdateGameState("Room State: " + GooglePlayRTM.instance.currentRoom.status.ToString());
		parisipants.text = "Total Room Participants: " + GooglePlayRTM.instance.currentRoom.participants.Count;
		
		if(!DrawParticipantsBool)
		{
			DrawParticipants();
		}

	
		if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) 
		{
			title = "Disconnect";						
		} 
		else 
		{
			if(GooglePlayConnection.State == GPConnectionState.STATE_DISCONNECTED || GooglePlayConnection.State == GPConnectionState.STATE_UNCONFIGURED) 
			{				
				title = "Connect";
			} 
			else 
			{
				title = "Connecting..";
			}
		}	
	}

	private void OnPlayerDisconnected() 
	{
		SA_StatusBar.text = "Player Disconnected";
		playerLabel.text = "Player Disconnected";
	}
	
	private void OnPlayerConnected() 
	{
		SA_StatusBar.text = "Player Connected";
		playerLabel.text = GooglePlayManager.instance.player.name;
		GooglePlayInvitationManager.instance.RegisterInvitationListener();
	//	GooglePlayManager.ActionFriendsListLoaded +=  OnFriendListLoaded;
		GooglePlayManager.Instance.LoadFriends();
	}
	
	private void OnConnectionResult(GooglePlayConnectionResult result) 
	{
		SA_StatusBar.text = "ConnectionResul:  " + result.code.ToString();
		Debug.Log(result.code.ToString());
	}

	private string inviteId;
	private void OnInvite(GP_Invite invitation) 
	{
		if (invitation.InvitationType != GP_InvitationType.INVITATION_TYPE_REAL_TIME) 
		{
			return;
		}

		inviteId = invitation.Id;
		AndroidDialog dialog =  AndroidDialog.Create("Invite", "You have new invite from: " + invitation.Participant.DisplayName, "Manage Manually", "Open Google Inbox");
		dialog.ActionComplete += OnInvDialogComplete;
	}

	void ActionInvitationAccepted (GP_Invite invitation) 
	{
		Debug.Log("ActionInvitationAccepted called");

		if (invitation.InvitationType != GP_InvitationType.INVITATION_TYPE_REAL_TIME) 
		{
			return;
		}
		Debug.Log("Starting The Game");
		//make sure you have prepared your scene to start the game before you accepting the invite. Room join even will be triggered
		GooglePlayRTM.instance.AcceptInvitation(invitation.Id);
	}

	private void OnRoomCreated(GP_GamesStatusCodes code) {
		SA_StatusBar.text = "Room Create Result:  " + code.ToString();
	}

	private void OnInvDialogComplete(AndroidDialogResult result) 
	{	
		//parsing result
		switch(result) 
		{
		case AndroidDialogResult.YES:
			AndroidDialog dialog =  AndroidDialog.Create("Manage Invite", "Would you like to accept this invite?", "Accept", "Decline");
			dialog.ActionComplete += OnInvManageDialogComplete;
			break;
		case AndroidDialogResult.NO:
			GooglePlayRTM.instance.OpenInvitationInBoxUI();
			break;			
		}
	}

	private void OnInvManageDialogComplete(AndroidDialogResult result) 
	{
		switch(result) 
		{
		case AndroidDialogResult.YES:
			GooglePlayRTM.instance.AcceptInvitation(inviteId);
			break;
		case AndroidDialogResult.NO:
			GooglePlayRTM.instance.DeclineInvitation(inviteId);
			break;
		}
	}

	private void OnGCDataReceived(GP_RTM_Network_Package package) 
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR ) || SA_DEBUG_MODE		
		System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
		string str = enc.GetString(package.buffer);
		string[] string1 = str.Split(","[0]);

		int MsgID = int.Parse(string1[0]);
		if(MsgID == 0)
		{
			int i = int.Parse(string1[1]);
			ESOther = int.Parse(string1[2]);
			GameObject player;
			player = (GameObject) GooglePlayRTM.Instantiate(spawnPrefab[ESOther],spawnPosition[i].transform.position,spawnPosition[i].transform.rotation);	
			spawnPrefab[ESOther] = player;
			player.name = i.ToString();

			if(!teamMatch)
			{
				player.tag = "enemy";
			}

			else
			{
				if(myPlayerPos1 < noOfFriend)
				{
					if( i < noOfFriend)
					{						
						player.tag = "plusFriend";
					}
					
					else
					{
						player.tag = "plusEnemy";
					}
				}

				else
				{
					if( i < noOfFriend)
					{						
						player.tag = "plusEnemy";
					}
					
					else
					{
						player.tag = "plusFriend";
					}
				}
			}
		}

		else if(MsgID == 6)
		{
			int i = int.Parse(string1[1]);
			string method = string1[2];
			if(i != PlayerPrefs.GetInt("myPlayerPos"))
			{
				Invoke(method, 0);
			}
		}

		#endif		
	}

	public void moveBtn()
	{
		int i = 0;

		if(!moveBtnOneTime)
		{
			foreach(GP_Participant p in GooglePlayRTM.instance.currentRoom.participants) 
			{		
				if(p.id.Equals(myID))
				{			
					myGame = i.ToString();
					myPlayerController[myPlayerPos1] = GameObject.Find(myGame).GetComponent<PlusNetworkTransform>();
					myPlayerController[myPlayerPos1].moveBtn1();
				}
			i++;
			}
			moveBtnOneTime = true;
		}
		else
		{
			myPlayerController[myPlayerPos1].moveBtn1();
		}
	}

	public void moveBtnUp()
	{
		myPlayerController[myPlayerPos1].moveBtnUp();
	}

	public void sendElement()
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR) || SA_DEBUG_MODE

		string msg = "";
		int MsgID = 0;
		int i = PlayerPrefs.GetInt("myPlayerPos");
		int ES = PlayerPrefs.GetInt("ElementInUse");
		msg = MsgID.ToString() +","+ i.ToString() +","+ ES.ToString();	
		System.Text.UTF8Encoding  encoding = new System.Text.UTF8Encoding();
		byte[] data = encoding.GetBytes(msg);
		GooglePlayRTM.instance.SendDataToAll(data, GP_RTM_PackageType.RELIABLE);	
		#endif	
	}

	public void SendDestoryElement()
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR) || SA_DEBUG_MODE
		
		string msg = "";
		int MsgID = 5;
		int i = PlayerPrefs.GetInt("myPlayerPos");		
		msg = MsgID.ToString() +","+ i.ToString();
		System.Text.UTF8Encoding  encoding = new System.Text.UTF8Encoding();
		byte[] data = encoding.GetBytes(msg);
		GooglePlayRTM.instance.SendDataToAll(data, GP_RTM_PackageType.RELIABLE);

		#endif	
	}

	public void ElementInUse()
	{
		for(int n = 0 ; n<= PlayerPrefs.GetInt("prefabLen") ; n++ )
		{
			if (gameObject.name == PlayerPrefs.GetString("prefabInGame"+n))
			{
				PlayerPrefs.SetInt("ElementInUse",n);
			}
		}
		//Debug.Log(PlayerPrefs.GetInt("ElementInUse"));
	}

	public void SendMethodName(string methodName)
	{
		string msg = "";
		int MsgID = 6;
		int i = PlayerPrefs.GetInt("myPlayerPos");		
		msg = MsgID.ToString() +","+ i.ToString() +","+ methodName;
		System.Text.UTF8Encoding  encoding = new System.Text.UTF8Encoding();
		byte[] data = encoding.GetBytes(msg);
		GooglePlayRTM.instance.SendDataToAll(data, GP_RTM_PackageType.RELIABLE);
	}

	public void won()
	{
		AndroidMessage.Create("won","method call");
	}
}
