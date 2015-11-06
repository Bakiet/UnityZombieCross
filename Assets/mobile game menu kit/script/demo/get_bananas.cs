using UnityEngine;
using System.Collections;

public class get_bananas : MonoBehaviour {

	public int quantity = 1;
	game_uGUI my_game_uGUI;

	void Start()
	{
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
	}

	void OnMouseDown ()
	{
		if (!game_uGUI.in_pause)
			{
			my_game_uGUI.my_progress_bar.Add_to_fill(quantity);
			}
	}
}
