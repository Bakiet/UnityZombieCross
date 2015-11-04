/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;

/// <summary>
/// simple script will load the assigned scene
/// </summary>
public class UIButtonScene : MonoBehaviour
{
	//string sceneName = "W1_Stage_1_M";
    public void LoadScene()
    {
       // if (!string.IsNullOrEmpty(sceneName))
			Application.LoadLevel("W1_Stage_1_M");
    }
}
