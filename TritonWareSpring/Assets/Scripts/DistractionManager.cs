using System.Collections;
using UnityEngine;

public class DistractionManager : MonoBehaviour, Clickable_Interface
{
    public EggCounter eggCounter; // Reference to the EggCounter script
    public WheatCounter wheatManager; // Reference to the WheatManager script

    // Fox-related variables
    public float minFoxWaitTime = 5f; // Minimum time the fox will wait before attacking (in seconds)
    public float maxFoxWaitTime = 10f; // Maximum time the fox will wait before attacking (in seconds)
    public float foxAttackDuration = 3f; // How long the fox stays attacking (in seconds)

    public SpriteRenderer sprite;

    public AudioManager audioManager;


    // Weed Repellent-related variables
    public float weedRepellentDuration = 10f; // How long the weed repellent lasts (in seconds)

    // Flags to track distractions
    public bool isFoxAttacking = false;
    public bool FoxRepelled = false;
    public bool isWeedRepellentActive = false;
    public int click_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Start the fox attack routine
        StartCoroutine(FoxAttackRoutine());
        sprite.enabled = false;
    }

    // Fox attack routine (runs periodically while the game is active)
    private IEnumerator FoxAttackRoutine()
    {
        while (true) // Fox attack continues indefinitely (or until you add a stop condition)
        {
            if (!isFoxAttacking) // Only start a fox attack if it's not already attacking
            {
                // Wait for a random time interval between fox attacks
                float waitTime = Random.Range(minFoxWaitTime, maxFoxWaitTime);
                yield return new WaitForSeconds(waitTime);

                // Start the fox attack
                isFoxAttacking = true;
                sprite.enabled = true;
                Debug.Log("Fox is attacking! No eggs can be produced.");

                // Wait until the fox is repelled
                yield return new WaitUntil(() => FoxRepelled);

                // End the fox attack
                sprite.enabled = false;
                isFoxAttacking = false;
                FoxRepelled = false;
                Debug.Log("Fox left! Egg production resumed.");

            }
            yield return null; // Wait for the next frame
        }

    }

    //turns off fox
    public void DeactivateFox()
    {
        isFoxAttacking = false;
        FoxRepelled = true;
        Debug.Log("Fox has been removed!");
    }
    public void Click()
    {
        if (isFoxAttacking)
        {
            click_count += 1;
            audioManager.Play("FoxScreech");


            if (click_count == 12)
            {
                DeactivateFox();
                click_count = 0;
            }
        }
        Debug.Log("this is where the fox should be");
    }

    // Method to activate weed repellent (called when the player uses the weed repellent)
    public void ActivateWeedRepellent()
    {
        if (!isWeedRepellentActive)
        {
            isWeedRepellentActive = true;
            Debug.Log("Weed repellent activated! Weeds won't grow for a while.");

            // Wait for the duration of the weed repellent effect
            StartCoroutine(WeedRepellentDuration());

            // After the effect duration, deactivate the weed repellent
            StartCoroutine(WeedRepellentDuration());
        }
    }

    private IEnumerator WeedRepellentDuration()
    {
        yield return new WaitForSeconds(weedRepellentDuration);

        isWeedRepellentActive = false;
        Debug.Log("Weed repellent effect ended! Weeds can grow again.");
    }
}
