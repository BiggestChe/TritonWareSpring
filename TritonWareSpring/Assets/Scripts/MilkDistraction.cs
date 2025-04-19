using System.Collections;
using System.Linq;
using UnityEngine;

public class MilkDistraction : MonoBehaviour, IClickable
{
    public SpriteRenderer sprite;
    public AudioManager audioManager;

    // Random wait time range between angry cow 
    public float minCowAngerTime = 7f;
    public float maxCowAngerTime = 15f;

    // Tracks whether the cow is pissed
    public bool isCowMad = false;

    // Tracks whether the cow is happy or not
    public bool isCowHappy = false;

    // Counts how many times the player has clicked the weeds
    public int ClICK_COUNT = 0;
    public int REQUIRED_COUNTS = 10;
        public BoxCollider2D boxCollider2D;


    // Start is called when the game begins
    private void Start()
    {
        // Hide the weed sprite initially
        sprite.enabled = false;
        boxCollider2D.enabled = false;

        // Begin the weed attack loop
        StartCoroutine(CowAngerRoutine());
    }

    //routine for cow distraction
    private IEnumerator CowAngerRoutine()
    {
        while (true)
        {
            if (!isCowMad)
            {
                float waitTime = Random.Range(minCowAngerTime, maxCowAngerTime);
                yield return new WaitForSeconds(waitTime);

                //cow is mad, turn on angered cow sprite
                isCowMad = true;
                sprite.enabled = true;
                boxCollider2D.enabled = true;

                Debug.Log("The cow is mad!");

                // Wait until the player makes cow happy
                yield return new WaitUntil(() => isCowHappy);

                audioManager.Play("Moo");

                // Hide the angered cow and reset the state
                sprite.enabled = false;
                boxCollider2D.enabled = false;

                isCowHappy = false;
                isCowMad = false;
                Debug.Log("Cow Calmed.");
            }

            yield return null; // Wait for the next frame before checking again
        }

    }

    //called when click to calm down cow
    public void DeActivateCow()
    {
        isCowMad = false;
        isCowHappy = true;

    }

    public void Click()
    {
        {
            if(isCowMad)
            {
                Debug.Log("should be incrementing");
                // Increase the click count to simulate effort required
                ClICK_COUNT++;

                // After enough clicks, remove the weeds
                if (ClICK_COUNT >= REQUIRED_COUNTS)
                {
                    DeActivateCow();           // Reset state
                    REQUIRED_COUNTS = 0;             // Reset click count
                }
            }
        }
    }
}