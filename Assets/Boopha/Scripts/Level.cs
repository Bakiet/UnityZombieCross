using UnityEngine;
using System.Collections;


/// <summary>
/// Level.
/// Structure of our level.
/// </summary>
public class Level
{
	public int WorldNum;
	public int NumLevel;

	public bool isBlocked = true;

	//how many food to drop at level
	public int qtdFood;

	public int foodToPass;
	public int foods2Star;
	public int foods3Star;

	public int starsAcquired;

	public bool isWin;




}
