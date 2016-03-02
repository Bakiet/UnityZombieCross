using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Label : MonoBehaviour {



	public Text id;
	public Text status;
	public Text playerId;
	public Text playerName;

	private Texture defaulttexture;



	public void SetParticipant(GP_Participant p) {

		id.text = "";
		playerId.text = "";
		playerName.text = "";
		status.text = GP_RTM_ParticipantStatus.STATUS_UNRESPONSIVE.ToString();



		GooglePlayerTemplate player = GooglePlayManager.instance.GetPlayerById(p.playerId);
		if(player != null) {
			playerId.text = "Player Id: " + p.playerId;
			playerName.text = "Name: " + player.name;



		}
		id.text  = "ID: " +  p.id;
		status.text = "Status: " + p.Status.ToString();


	}
}
