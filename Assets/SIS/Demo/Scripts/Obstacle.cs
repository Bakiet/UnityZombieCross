/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;

namespace SIS_Demo
{
    /// <summary>
    /// single obstacle that gives coins when collided.
    /// deactivates and spawns new one when out of view
    /// </summary>
    public class Obstacle : MonoBehaviour
    {
        private bool shouldEarn = true;


        //earn coins only one time
        void OnCollisionEnter2D()
        {
            if (shouldEarn) DemoManager.IncreasePoints();
            shouldEarn = false;
        }


        //spawn a new obstacle if this one is out of view
        void OnBecameInvisible()
        {
            #if UNITY_EDITOR
                if (Application.isPlaying) return;
            #endif

            Invoke("Deactivate", 1);
        }


        void Deactivate()
        {
            DemoManager.SpawnObstacle();
            transform.parent.gameObject.SetActive(false);
        }
    }
}