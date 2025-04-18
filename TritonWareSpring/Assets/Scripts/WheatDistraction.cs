using System.Collections;
using UnityEngine;

// This script simulates weeds periodically growing over the wheat field, 
// requiring the player to click multiple times to repel them.
public class WheatDistraction : MonoBehaviour, IClickable
{
    // Reference to the sprite that represents the weeds visually
    public SpriteRenderer sprite;

    // Reference to the audio manager to play sound effects
    public AudioManager audioManager;

    // Random wait time range between weed appearances
    public float minWeedWaitTime = 7f;
    public float maxWeedWaitTime = 15f;

    // Tracks whether weeds are currently blocking the field
    public bool isWeedBlocking = false;

    // Tracks whether weeds have been successfully repelled
    public bool WeedRepelled = false;

    // Counts how many times the player has clicked the weeds
    public int ClICK_COUNT = 0;

    public int REQUIRED_COUNTS = 10;
    // Start is called when the game begins
    private void Start()
    {
        // Hide the weed sprite initially
        sprite.enabled = false;

        // Begin the weed attack loop
        StartCoroutine(WeedAttackRoutine());
    }

    // This coroutine controls how often weeds appear and handles the weed blocking logic
    private IEnumerator WeedAttackRoutine()
    {
        while (true)
        {
            // Wait only if weeds are not already on the field
            if (!isWeedBlocking)
            {
                // Random delay before weeds appear
                float waitTime = Random.Range(minWeedWaitTime, maxWeedWaitTime);
                yield return new WaitForSeconds(waitTime);

                // Show the weeds and start blocking
                isWeedBlocking = true;
                sprite.enabled = true;
                Debug.Log("Weeds have overgrown the field!");

                // Wait until the player repels the weeds
                yield return new WaitUntil(() => WeedRepelled);

                audioManager.Play("WheatPluck");

                // Hide the weeds and reset the state
                sprite.enabled = false;
                isWeedBlocking = false;
                WeedRepelled = false;
                Debug.Log("Weeds cleared.");
            }

            yield return null; // Wait for the next frame before checking again
        }
    }

    // Called to reset the weed state after enough clicks
    public void DeactivateWeeds()
    {
        isWeedBlocking = false;
        WeedRepelled = true;
    }

    // Called when the player clicks the weed object
    public void Click()
    {
        if (isWeedBlocking)
        {
            // Increase the click count to simulate effort required
            ClICK_COUNT++;

            // After enough clicks, remove the weeds
            if (ClICK_COUNT >= REQUIRED_COUNTS)
            {
                DeactivateWeeds();           // Reset state
                REQUIRED_COUNTS = 0;             // Reset click count
            }
        }
    }
}
