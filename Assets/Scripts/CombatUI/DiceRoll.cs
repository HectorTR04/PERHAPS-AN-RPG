using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets
{
    public class DiceRoll : MonoBehaviour
    {
        public Sprite[] diceSprites; // Array of dice sprites
        public float animationDuration = 2f; // Total duration of the animation in seconds
        public float endPositionX = 2f; // Ending position on the x-axis
        private float timer = 0f; // Timer to keep track of animation progress
        private int currentIndex = 0; // Index of the current sprite in the array
        private bool isAnimating = true; // Flag to control animation playback

        void Start()
        {
            // Set starting position
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
        }

        void Update()
        {
            if (!isAnimating)
                return;

            // Update the timer
            timer += Time.deltaTime;

            // Calculate the progress of the animation (value between 0 and 1)
            float progress = timer / animationDuration;

            // Calculate the rotation angle for the dice (360 degrees for a full lap)
            float rotationAngle = 360f * progress;

            // Rotate the dice around its center
            transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            // Calculate the position offset for the dice (move to the right)
            float offsetX = progress * (endPositionX + 2f); // Adjust this value as needed for the desired distance

            // Move the dice
            transform.position = new Vector3(-2f + offsetX, transform.position.y, transform.position.z);

            // Check if it's time to switch to the next sprite
            if (progress >= 1f)
            {
                // Increment the current index or loop back to the beginning if reached the end
                currentIndex = (currentIndex + 1) % diceSprites.Length;

                // Update the sprite
                GetComponent<SpriteRenderer>().sprite = diceSprites[currentIndex];

                // Reset the timer
                timer = 0f;

                // Check if completed a full lap
                if (currentIndex == 0)
                {
                    // Stop the animation
                    isAnimating = false;
                }
            }
        }
    }
}
