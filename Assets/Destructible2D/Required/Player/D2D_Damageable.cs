using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu(D2D_Helper.ComponentMenuPrefix + "Damageable")]
public class D2D_Damageable : MonoBehaviour
{

	public	string	identifier				= "";		// Use to identify the slow motion
	public bool UsedSlowMotion;
	public	float	delay					= 1;		// Delay to start Slow Motion
	public	float	desiredFreezeDuration	= 5;		// Duration in seconds of the slow motion
	public	float desiredTimeScale		= 0.5f;		    // Desired game speed 0 stops game, 1 full speed
	public	float desiredEndTimeScale		= 1;		// Desired game speed when slow motion ends 0 stops game, 1 full speed
	public	Action	callback	= null;		// Action To execute when slow motion ends
	private int count = 0;

	public float Damage;
	
	public float Age;
	
	public float ActivateDelay = 0.5f;
	
	public bool AllowDestruction;
	
	public float DamageLimit = 100.0f;
	
	public GameObject ReplaceWith;
	
	public void InflictDamage(float amount)
	{
		if (Age >= ActivateDelay) // Discard damage until it's old enough
		{
			if (amount != 0.0f)
			{
				Damage += amount;
				
				D2D_Helper.BroadcastMessage(transform, "OnDamageInflicted", amount, SendMessageOptions.DontRequireReceiver);
				
				UpdateDestruction();
			}
		}
	}
	
	public void UpdateDestruction()
	{
		if (AllowDestruction == true)
		{
#if UNITY_EDITOR
			if (Application.isPlaying == false)
			{
				return;
			}
#endif
			if (Damage >= DamageLimit)
			{
				if (ReplaceWith != null)
				{
					D2D_Helper.CloneGameObject(ReplaceWith, transform.parent, transform.position, transform.rotation);
				}
				
				D2D_Helper.Destroy(gameObject);
			}
		}
	}
	
	protected virtual void Update()
	{
		Age += Time.deltaTime;
	}
	
	protected virtual void OnDestructibleSplit(D2D_SplitData splitData)
	{
		Age    = 0.0f; // Reset age if this is a split part
		Damage = 0.0f; // Reset damage if this is a split part
	}
}