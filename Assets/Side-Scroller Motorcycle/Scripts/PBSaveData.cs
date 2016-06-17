using UnityEngine;
using System.Collections;
using unity;
public class PBSaveData : MonoBehaviour {

	public int starts; 
	public int money;

	public int lives;
	public int stages;
	public int best_score;
	public int stage_progress;
	public int world_progress;

	public bool[][,] dot_tail_turn_on;//[profile][w,s];

	public bool[][] world_playable;//[profile][world]
	public bool[][] world_purchased;//[profile][world]
	public bool[][,] stage_playable; //[profile][world,stage]
	public bool[][,] stage_solved; //[profile][world,stage]

	public int[][,] stage_stars_score; //[profile][world,stage]
	public int[][] star_score_in_this_world;//[profile][world]
	public int[] stars_total_score;//[profile] this can be helpful if you want to unlock worlds when player get enough stars 

	public int[][,] best_int_score_in_this_stage; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
