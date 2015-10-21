using UnityEngine;
using System.Collections;


/// <summary>
/// Get counter.
/// Helpful class that will control ou values. Food, Coins, etc.
/// </summary>
public class GetCounter : MonoBehaviour {


	private int _value; 	 //current value assigned.
	public int maxValue = 0; //zero to infinite.

	public int Value
	{
		get { return _value;}
		set { 
			_value = value;
		}
	}


	//********* We can use only one method, passing positive and negative values.
	//but this way we can read and understand more easily than that.
	
	/// <summary>
	/// Add the specified value.
	/// Treat and add value. Does not matter if is an negative number.
	/// </summary>
	/// <param name="value">Value.</param>
	public void Add(int value)
	{
		if(value <0)
		{
			value *= -1;
		}
		_value += value;
	}

	/// <summary>
	/// Remove the specified value.
	/// Treat and remove value. Does not matter if is an negative number.
	/// </summary>
	/// <param name="value">Value.</param>
	public void Remove(int value)
	{
		if(value <0)
		{
			value *= -1;
		}

		_value -= value;
	}


}
