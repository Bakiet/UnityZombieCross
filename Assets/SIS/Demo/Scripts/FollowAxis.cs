/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;

namespace SIS_Demo
{
    /// <summary>
    /// follows an object restricted to the x-axis
    /// </summary>
    public class FollowAxis : MonoBehaviour
    {
        /// <summary>
        /// target to follow
        /// </summary>
        public Transform target;

        //cache start position
        private Vector3 pos;


        void Awake()
        {
            pos = transform.position;
        }


        void LateUpdate()
        {
            Vector3 locked = transform.position;
            if (target != transform.parent)
                locked.x = target.position.x;

            locked.y = pos.y;
            transform.position = locked;
        }
    }
}
