using UnityEngine;
using System.Collections;


/// <summary>
/// This class is used by PlayerController to help to control animation
/// and simplificate main class. Othercase PlayerController should be a huge class.
/// </summary>
public class PlayerAnimMachine : MonoBehaviour 
{

	private EnumPlayerAnims _currentAnim = EnumPlayerAnims.Run;
	
	public EnumPlayerAnims CurrentAnimation
	{
		get{ return 
			(EnumPlayerAnims)anim.GetInteger("CurrentAnimation");
		}
		set {
			if(value != CurrentAnimation)
			{
				_currentAnim = value;
				anim.SetInteger("CurrentAnimation", (int)value);
			}
		}
	}

	public Animator anim;

	//simplifies to indicate if player are or not able to walk.
	public bool IsWalkAnim
	{
		get 
		{
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun")) //if anim is run, so keep walking
			{
				return true;
			}
			else if(anim.GetCurrentAnimatorStateInfo(0).IsName("BoophaIdle")) //if it is not occupied, lets move!
			{
				Debug.Log ("entra");
				CurrentAnimation = EnumPlayerAnims.Run; //do the job. Change animation to run, and say that it able to run.
				return true;
			}

			//else case, player are not able to walk right now.
			return false;
		}
	}



	void OnAwake()
	{
		anim = this.GetComponent<Animator>();
	}


	//***** All this method below are to control animation changing it. ***


	public void AnimIdle()
	{
		CurrentAnimation = EnumPlayerAnims.Idle;
	}

	public void AnimRun()
	{
		CurrentAnimation = EnumPlayerAnims.Run;
	}

	public void AnimEat()
	{
		anim.SetTrigger("TriggerFood");
	}
	

	public void AnimWin()
	{
		anim.SetTrigger("TriggerWin");
	}

	public void AnimLose()
	{
		anim.SetTrigger("TriggerLose");
	}
	


}
