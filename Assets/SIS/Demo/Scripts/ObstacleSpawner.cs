/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SIS_Demo
{
    /// <summary>
    /// spawns new obstacles to jump on in a random offset
    /// </summary>
    public class ObstacleSpawner : MonoBehaviour
    {
        /// <summary>
        /// maximum amount of obstacles at one time
        /// </summary>
        public int maxCount = 5;

        /// <summary>
        /// prefab to instantiate for obstacles
        /// </summary>
        public GameObject obstacle;

        /// <summary>
        /// position of the first platform
        /// </summary>
        public Transform startPos;

        //position of the last platform
        private Transform lastPos;

        /// <summary>
        /// x-offset range for platforms
        /// </summary>
        public Vector2 range;

        /// <summary>
        /// thickness range for platforms
        /// </summary>
        public Vector2 width;

        /// <summary>
        /// height range for platforms
        /// </summary>
        public Vector2 height;


        void Start()
        {
            for (int i = 0; i < maxCount - 1; i++)
                Spawn();

            InvokeRepeating("CollectGarbage", 5, 5);
        }


        /// <summary>
        /// Spawns a new obstacle with random offset to the last one
        /// </summary>
        public void Spawn()
        {
            if (lastPos == null) lastPos = startPos;

            float posX = Random.Range(range.x, range.y);
            float scaleX = Random.Range(width.x, width.y);
            float scaleY = Random.Range(height.x, height.y);

            GameObject obj = (GameObject)Instantiate(obstacle);
            obj.transform.position = lastPos.position + new Vector3(posX, 0, 0);
            obj.transform.localScale = new Vector3(scaleX, scaleY, 1);
            obj.transform.parent = transform;

            lastPos = obj.transform;
        }


        //destroy inactive obstacles every few seconds
        void CollectGarbage()
        {
            int childCount = transform.childCount - 1;
            for (int i = childCount; i >= 0; i--)
            {
                GameObject child = transform.GetChild(i).gameObject;
                if (!child.activeInHierarchy)
                    Destroy(child);
            }
        }
    }
}
