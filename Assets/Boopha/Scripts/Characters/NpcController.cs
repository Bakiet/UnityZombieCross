using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class NpcController : MonoBehaviour 
{
	public EnumNpcAnims _currentAnim = EnumNpcAnims.Walk;

	public EnumNpcAnims CurrentAnimation
	{
		get{ return (EnumNpcAnims)anim.GetInteger("CurrentAnimation");}
		set {
			//ChangeAnim(value);
			_currentAnim = value;
			anim.SetInteger("CurrentAnimation", (int)value);
		}
	}

	public bool playable = true;							//if false, dont update. Used after level ends
	
	public EnumSide SideWalk = EnumSide.Right;				//We can do this without this variable, but to easy undertood i decided to clarify using it
	private Vector3 lookLeft;								//Represent a lookAt side. Used to not create a lot of vectors which update..
	private Vector3 lookRight;								//Represent a lookAt side. Used to not create a lot of vectors which update..

	//TIME TO RANDOM CHANGE SIDE DECISION
	private float chanceChanceSide = 30f;			//percentage of chance to decide change side.
	private float timeToChangeSide = 0.7f;			//amount of time needed to think about change side.
	private float elapsedTimeChangeSide = 0.0f;		//count amount of time since last change side.

	//TIME TO DROP FOOD
	private float timeToDrop = 1.9f;			//for each loop of time, drop food
	private float elapsedTimeToDrop = 0.0f;		//count amount of time since last drop.


	public Rigidbody2D foodPrefab;				//What will NPC drop?


	private Vector2 velocTemp = new Vector2();				//stores temporary actual velocity vector. Created only one time;
	public float velocity = 5f;								//this variable will control how much moviment in x will be setted.
	private Rigidbody2D rigidBod2d;							//get this rigidbody once. Use less cpu.
	private Animator anim;


	void Awake()
	{
		rigidBod2d = this.GetComponent<Rigidbody2D>();	//fill rigidbody2D with this own rigidbody

		anim = this.GetComponent<Animator>();	//npc has an animator, so lets control it.

		//Look left and Look right are setter once to use less cpu.
		lookLeft = new Vector3(-this.gameObject.transform.localScale.x
		                       ,this.gameObject.transform.localScale.y
		                       ,this.gameObject.transform.localScale.z);
		
		lookRight = new Vector3(this.gameObject.transform.localScale.x
		                        ,this.gameObject.transform.localScale.y
		                        ,this.gameObject.transform.localScale.z);

		//assert if has food prefab to drop.
		if(foodPrefab == null) { throw new UnityException("Has no foodPrefab defined at NPC."); }

	}

	// Update is called once per frame
	void Update () 
	{
		//only update if state is 'playable'
		if(!playable) { return; }

		//just plus time since last drop.
		elapsedTimeToDrop += Time.deltaTime;

		//check and change side if npc wants to.
		CheckChangeSide();

	}


	void FixedUpdate()
	{
		//to corect our changes in time, we use fixed update
		if(!playable) { return; }

		//check time between drops, so drop it or not.
		if(elapsedTimeToDrop >= timeToDrop) 
		{
			elapsedTimeToDrop = 0.000f; //precision
			DropFood(); //drop food
		}
		else
		{			
			//when drop dont walk.
			//when walk no drop happens
			DoWalk(); 
		}
	}

	public void DropFood()
	{
		//lets use the number on screen to dont instantiate another variable.
		//if dont have any food in pack, do nothing. 
		if(HUDManager.Instance.GetPackFoodQuantity <= 0) { return; }

		//else, change anim to Drop.
		CurrentAnimation = EnumNpcAnims.Drop;

		//Instantiate new Food prefab at same location, "default" rotation.
		Instantiate(foodPrefab, this.transform.localPosition, this.transform.localRotation);

		//tell to hud to subtract dropped food.
		HUDManager.Instance.ReduceFood();
	}
	
	
	public void DoWalk()
	{
		//just assurance, if char are dont doing drop anim, correct it to walk.
		//may be caused for another unfinished anim when we set drop anim. So correct it now.
		if(CurrentAnimation == EnumNpcAnims.Drop) { CurrentAnimation = EnumNpcAnims.Walk;}

		//if no side selected, then do nothing, just return.
		if(CurrentAnimation != EnumNpcAnims.Walk) { return; }
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("NpcDrop")) { return; }

		//gets NPC velocity for temporary use.
		//this way we never do changes directly to current velocity.
		velocTemp = rigidBod2d.velocity;

		//check side to walk. To Left velocity is negative because X comes to zero.
		if(SideWalk == EnumSide.Left)
		{
			velocTemp.x  = velocity * -1;
			this.FlipSide(lookLeft); // use that vector variable we defined at Awake method.
		}
		else
		{
			velocTemp.x  = velocity;
			FlipSide(lookRight);	// use that vector  variable we defined at Awake method.
		}

		//set new changed velocity to our NPC rigidbody.
		rigidBod2d.velocity = velocTemp;
	}

	public void CheckChangeSide()
	{
		//even plus this time to become near to change
		elapsedTimeChangeSide += Time.deltaTime;

		//if time to chance come, set amount of time to zero.
		if(elapsedTimeChangeSide >= timeToChangeSide) 
		{
			elapsedTimeChangeSide =0.0f;

			//check percent chance to change side
			float chance = Random.value * 100f;

			//if random is less than predeterminated percentage, go to other side.
			if(chance <= chanceChanceSide)
			{
				GoToOtherSide();
			}
		}
	}

	/// <summary>
	/// Goes to other side. Just change option SideWalk to another one.
	/// The variable SideWalk will be used in others methods.
	/// </summary>
	public void GoToOtherSide()
	{
		if(SideWalk == EnumSide.Left)
		{
			SideWalk = EnumSide.Right;
		}
		else
		{
			SideWalk = EnumSide.Left;
		}

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
	/// Indicate to NPC to stop because level has ended.
	/// </summary>
	public void StopEndLevel()
	{
		playable = false; // this will cancel update methods.
		CurrentAnimation = EnumNpcAnims.Dumb; //dumb is a animation that NPC just round your eyes.
	}

	/// <summary>
	/// Changes the animation.
	/// </summary>
	/// <param name="newAnim">New animation.</param>
	public void ChangeAnim(EnumNpcAnims newAnim)
	{
		//dont wast time trying to change to same current anim.
		if(_currentAnim == newAnim) {return;}

		//else, set new anim using Property at begining.
		_currentAnim = newAnim;

		Animator anim = this.GetComponent<Animator>();

		//align property with real anim occurring.
		anim.SetInteger("CurrentAnimation", (int)CurrentAnimation);
	}




}