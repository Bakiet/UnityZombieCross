using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {
	// Use this for initialization
	public GameObject Hit;
	public GameObject Blood;
	public string ObjectToCollided;
	public Rigidbody2D body;
	public float radius = 100.0f;
	public GameObject Object;

	public int quantity = 1;
	public AudioSource sound;
	public int points;

	private const string INCREMENTAL_ACHIEVEMENT_ID_Veteran = "CgkIq6GznYALEAIQCw";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Assassin = "CgkIq6GznYALEAIQCg";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Sergeant = "CgkIq6GznYALEAIQCQ";

	private const string ACHIEVEMENT_ID_First_Freeze = "CgkIq6GznYALEAIQDg";
	private const string ACHIEVEMENT_ID_First_Buy = "CgkIq6GznYALEAIQDQ";
	private const string ACHIEVEMENT_ID_First_Burn = "CgkIq6GznYALEAIQDA";
	
	private const string ACHIEVEMENT_ID_First_Drown = "CgkIq6GznYALEAIQCA";
	private const string ACHIEVEMENT_ID_First_Death = "CgkIq6GznYALEAIQBw";
	private const string ACHIEVEMENT_ID_First_Explotion = "CgkIq6GznYALEAIQBg";
	private const string ACHIEVEMENT_ID_First_FrontFlip = "CgkIq6GznYALEAIQBA";
	private const string ACHIEVEMENT_ID_First_BackFlip = "CgkIq6GznYALEAIQAg";
	
	private const string INCREMENTAL_ACHIEVEMENT_ID_Two_FrontFlip = "CgkIq6GznYALEAIQBQ";
	private const string INCREMENTAL_ACHIEVEMENT_ID_Two_BackFlip = "CgkIq6GznYALEAIQAw";


	game_uGUI my_game_uGUI;

	void Start () {

	
		Hit.SetActive (false);
		Blood.SetActive (false);
		this.gameObject.SetActive(true);
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}

	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		//if(collision.gameObject.GetComponent<Rigidbody>().name != "Cube 1"){
		//	if(collision.gameObject.GetComponent<Rigidbody>().name == "front wheel"){
		
		//objectname = GameObject.Find ("urban_zombie_mobile1");
		//	Vector3 zombie = transform.position;
		
		
		//					Collider[] colliders = Physics.OverlapSphere (zombie, radius);
		//	foreach (Collider hit in colliders) {  //for loop that says if we hit any colliders, then do the following below
		GameObject gui = GameObject.FindGameObjectWithTag ("_gui_");
		if(gui != null){
			my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();
			
		}
		
		if (collision.gameObject.name == ObjectToCollided) {
			
			makeclick Achievement = new makeclick();
			Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Veteran,1);
			Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Assassin,1);
			Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Sergeant,1);
			
			my_game_uGUI.Update_int_score(points);
			/*	if (!game_uGUI.in_pause)
						{
							my_game_uGUI.my_progress_bar.Add_to_fill(quantity);

							if (my_game_uGUI.star_number<3)
							{
								my_game_uGUI.Add_stars(1);
							}
							
							//this.gameObject.SetActive(false);
						}*/
			
			if(sound){
				sound.Play();
			}
			Hit.transform.position = body.transform.position;
			Hit.SetActive (true);		
			Instantiate (Hit);
		//	CFX_SpawnSystem.Instantiate (Hit);	

			Blood.transform.position = body.transform.position;
			Blood.SetActive (true);
			Instantiate (Blood);
			
			if (Object != null)
			{  
				Destroy (Object);	
				Hit.SetActive (false);	
				Blood.SetActive (false);

			}
			
		}			
	}
/*	void OnTriggerEnter2D(Collider2D collision)
	{	
		//if(collision.gameObject.GetComponent<Rigidbody>().name != "Cube 1"){
			//	if(collision.gameObject.GetComponent<Rigidbody>().name == "front wheel"){
				
		//objectname = GameObject.Find ("urban_zombie_mobile1");
				//	Vector3 zombie = transform.position;


//					Collider[] colliders = Physics.OverlapSphere (zombie, radius);
				//	foreach (Collider hit in colliders) {  //for loop that says if we hit any colliders, then do the following below
		my_game_uGUI = GameObject.FindGameObjectWithTag("_gui_").GetComponent<game_uGUI>();

				if (collision.gameObject.name == ObjectToCollided) {
						
					makeclick Achievement = new makeclick();
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Veteran,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Assassin,1);
					Achievement.SENDACHIEVEMENTINCREMENT(INCREMENTAL_ACHIEVEMENT_ID_Sergeant,1);

					my_game_uGUI.Update_int_score(points);
					/*	if (!game_uGUI.in_pause)
						{
							my_game_uGUI.my_progress_bar.Add_to_fill(quantity);

							if (my_game_uGUI.star_number<3)
							{
								my_game_uGUI.Add_stars(1);
							}
							
							//this.gameObject.SetActive(false);
						}*/

				/*		if(sound){
							sound.Play();
						}
						Hit.transform.position = body.position;
						Hit.SetActive (true);						
						CFX_SpawnSystem.Instantiate (Hit);	
						
						Blood.transform.position = body.position;
						Blood.SetActive (true);
						CFX_SpawnSystem.Instantiate (Blood);
		
						if (Object != null)
						{  
							Destroy (Object);	
						}

					}			
	}
*/

	//Update is called once per frame
	void Update () {
	}

}

