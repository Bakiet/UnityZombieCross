/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;

namespace SIS_Demo
{
    /// <summary>
    /// static instance for accessing all game elements,
    /// such as playing sound, resizing the jump sprite and restarting the game
    /// </summary>
    public class DemoManager : MonoBehaviour
    {
        private static DemoManager instance;
        private AudioSource audioSource;
        
        //local variable for collected points/coins,
        //reset after each round
        private int collected = 0;

        /// <summary>
        /// reference to the obstacle spawner
        /// </summary>
        public ObstacleSpawner spawner;

        /// <summary>
        /// UI text for displaying points earned
        /// </summary>
        public Text points;

        /// <summary>
        /// UI text for displaying game over text
        /// </summary>
        public Text gameOver;

        /// <summary>
        /// UI text for displaying additional demo info
        /// </summary>
        public Text infoText;


        /// <summary>
        /// sound to play on jumping
        /// </summary>
        public AudioClip jumpClip;

        /// <summary>
        /// sound to play when reaching platforms
        /// </summary>
        public AudioClip coinsClip;

        /// <summary>
        /// sound to play on game lost
        /// </summary>
        public AudioClip loseClip;


        /// <summary>
        /// inner jump strength indicator sprite
        /// </summary>
        public RectTransform innerRect;

        /// <summary>
        /// outer jump strength indicator sprite
        /// </summary>
        public RectTransform outerRect;

        private Vector2 rectSize;


        //set references
        public void Init()
        {
            instance = this;
            audioSource = Camera.main.GetComponent<AudioSource>();

            points.text = "0";
            rectSize = innerRect.sizeDelta;

            #if !UNITY_EDITOR
                infoText.gameObject.SetActive(false);
            #endif
        }


        /// <summary>
        /// reload scene
        /// </summary>
        public void Restart()
        {
            Application.LoadLevel("SIS_Demo");
        }


        /// <summary>
        /// increase local points variable and set text
        /// </summary>
        public static void IncreasePoints()
        {
            instance.collected++;
            instance.points.text = instance.collected.ToString();
            instance.audioSource.PlayOneShot(instance.coinsClip);
        }


        /// <summary>
        /// play jump sound
        /// </summary>
        public static void Jump()
        {
            instance.audioSource.PlayOneShot(instance.jumpClip);
        }


        /// <summary>
        /// spawn obstacle in the spawner script
        /// </summary>
        public static void SpawnObstacle()
        {
            instance.spawner.Spawn();
        }


        /// <summary>
        /// resize jump strength indicator based on force
        /// </summary>
        public static void ResizeSprite(float force, Vector2 range)
        {
            float totalRange = range.x + range.y;
            float totalSize = instance.rectSize.x + instance.outerRect.sizeDelta.x;

            int size = (int)((force / totalRange) * totalSize);
            size = (int)Mathf.Clamp(size, instance.rectSize.x, instance.outerRect.sizeDelta.x);
            instance.innerRect.sizeDelta = new Vector2(size, size);
        }


        /// <summary>
        /// reset jump strength indicator sprite to beginning
        /// </summary>
        public static void ResetSprite()
        {
            instance.innerRect.sizeDelta = instance.rectSize;
        }


        /// <summary>
        /// play lost sound and earn points collected during the game
        /// </summary>
        public static void GameOver()
        {
            instance.audioSource.PlayOneShot(instance.loseClip);
            instance.gameOver.gameObject.SetActive(true);

            //this adds the collected points to the storage
            StoreInventory.GiveItem("Coins", instance.collected);
            instance.collected = 0;
        }
    }
}
