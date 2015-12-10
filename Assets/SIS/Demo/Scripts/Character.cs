/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace SIS_Demo
{
    /// <summary>
    /// character logic for jumping and colliding with obstacles
    /// </summary>
    public class Character : MonoBehaviour
    {
        /// <summary>
        /// jump strength multiplier
        /// </summary>
        public int multiplier;

        /// <summary>
        /// fixed force to jump on x-axis
        /// </summary>
        public int forceX;

        /// <summary>
        /// height range for jump strength
        /// </summary>
        public Vector2 jumpRange = new Vector2(0, 1000);

        //caching properties
        private Rigidbody2D rb;
        private float force;
        private bool canJump = false;


        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        //listen to player input
        void Update()
        {
            //do not jump over UI elements
            if (!canJump || EventSystem.current.IsPointerOverGameObject()) return;

            //set initial force when the screen gets touched
            if (Input.GetMouseButtonDown(0))
            {
                force = jumpRange.x;
            }

            //multiply force when holding touch down
            if (Input.GetMouseButton(0))
            {
                force += multiplier;
                force = Mathf.Clamp(force, jumpRange.x, jumpRange.y);
                DemoManager.ResizeSprite(force, jumpRange);
            }

            //add force when releasing the touch
            if (Input.GetMouseButtonUp(0))
            {
                rb.AddForce(new Vector2(forceX, force), ForceMode2D.Force);
                force = 0;
            }
        }


        //entered a platform: 
        //reset strength indicator sprite and clear forces
        void OnCollisionEnter2D()
        {
            DemoManager.ResetSprite();

            canJump = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }


        //left a platform:
        //play jump sound and disable double jump
        void OnCollisionExit2D()
        {
            DemoManager.Jump();
            canJump = false;
        }


        //collided with the death zone
        void OnTriggerEnter2D()
        {
            DemoManager.GameOver();
        }
    }
}