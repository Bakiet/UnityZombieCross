using UnityEngine;
using System.Collections;


/// <summary>
/// Controls player by input and behavios at scenario.
/// We use physics so we need our player have a rigidbody2D.
/// </summary>
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {


	public bool playable = true;					//if false, dont update. Used after level ends

	public EnumSide SideWalk = EnumSide.Right;		//We can do this without this variable, but to easy undertood i decided to clarify using it

	private Vector3 lookLeft;						//Represent a lookAt side. Used to not create a lot of vectors which update..
	private Vector3 lookRight;						//Represent a lookAt side. Used to not create a lot of vectors which update..

	private Vector2 velocTemp = new Vector2();		//stores temporary actual velocity vector. Created only one time;

	public float velocity = 3.5f;					//this variable will control how much moviment in x will be setted.

	private InputManager inputManage;
	private Rigidbody2D rigidBod2d;

	private PlayerAnimMachine aniMachine;		//our animation controller helper



	void Awake()
	{
		inputManage = GameObject.FindObjectOfType<InputManager>();

		//check if one or more classes that we need exist. Case not tell us through an error.

		if(inputManage == null)
		{
			throw new UnassignedReferenceException("inputManage as InputManager is null. "); //component has been not assigned at Inspector tab.
		}

		aniMachine = FindObjectOfType<PlayerAnimMachine>();

		if(aniMachine == null)
		{
			throw new UnassignedReferenceException("aniMachine as PlayerAnimMachine is null."); //component has been not assigned at Inspector tab.
		}


		rigidBod2d = this.GetComponent<Rigidbody2D>();

		// i prefer occupy memory instead cpu to not slow down using garbage collector.
		//Look left and Look right are setter once to use less cpu.
		lookLeft = new Vector3(-this.gameObject.transform.localScale.x
		                       ,this.gameObject.transform.localScale.y
		                       ,this.gameObject.transform.localScale.z);

		lookRight = new Vector3(this.gameObject.transform.localScale.x
		                        ,this.gameObject.transform.localScale.y
		                        ,this.gameObject.transform.localScale.z);
	}
	

	// Update is called once per frame
	void Update () 
	{
		//check if palyer is updatable.
		if(!playable) { return; }

		//check input to change or not side to walk.
		CheckInput();

	}

	/// <summary>
	/// Here we will move and do actions with our player.
	/// </summary>
	void FixedUpdate()
	{
		if(!playable) { return; }

		//if anim control says that we can move, we move it.
		if(aniMachine.IsWalkAnim)
		{
			DoWalk();	
		}
	}

	/// <summary>
	/// Checks the input.
	/// Check and change anim of input action.
	/// </summary>
	public void CheckInput()
	{
		if(inputManage.IsLeftPressed)
		{
			SideWalk = EnumSide.Left;
		}
		else if(inputManage.IsRightPressed)
		{
			SideWalk = EnumSide.Right;
		}
	}


	/// <summary>
	/// Does the walk. Do character move with velocity.
	/// </summary>
	public void DoWalk()
	{
		//gets player velocity for temporary use.
		//this way we never do changes directly to current velocity.
		velocTemp = rigidBod2d.velocity;

		//check side to walk. To Left velocity is negative because X comes to zero.
		if(SideWalk == EnumSide.Left)
		{
			velocTemp.x = velocity * -1;
			FlipSide(lookLeft); // use that vector variable we defined at Awake method.
		}
		else if(SideWalk == EnumSide.Right)
		{
			velocTemp.x  = velocity;
			FlipSide(lookRight); // use that vector variable we defined at Awake method.
		}

		//set new changed velocity to our Player rigidbody.
		rigidBod2d.velocity = velocTemp;
	}
	


	/// <summary>
	/// When Food prefab touches the player, it call for this method.
	/// </summary>
	public void DoEat()
	{
		//change animation
		aniMachine.AnimEat();

		//tell to hud do necessary changes
		HUDManager.Instance.EatFood();

		//plays eat sound 
		SoundManager.Instance.PlaySoundFx(EnumSounds.Eat);
	}

	/// <summary>
	/// When Food prefab touches the player, it call for this method.
	/// </summary>
	public void DoEatCoin()
	{
		//change animation
		aniMachine.AnimEat();
		
		//tell to hud do necessary changes
		HUDManager.Instance.EatCoin();
		
		//plays get coin sound 
		SoundManager.Instance.PlaySoundFx(EnumSounds.Coin);
	}


	/// <summary>
	/// Flips the side to Look at Right or Left changing scale x.
	/// </summary>
	/// <param name="lookAt">Look at.</param>
	public void FlipSide(Vector3 lookAt)
	{
		this.gameObject.transform.localScale = lookAt;
	}


	/// <summary>
	/// This method say to our player that he must to stop update because level has ended.
	/// </summary>
	public void StopEndLevel()
	{
		playable = false;
		inputManage.ClearInput();
	}

	/// <summary>
	/// I use this method to easy to you control win position at end of level.
	/// </summary>
	public void ToWinPosition()
	{
		playable = false;
		inputManage.ClearInput();
		aniMachine.AnimWin();
	}

	/// <summary>
	/// I use this method to easy to you control loose position at end of level.
	/// </summary>
	public void ToLosePosition()
	{
		aniMachine.AnimLose ();
		playable= false;
		inputManage.ClearInput();
	}


	




}