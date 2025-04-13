using System.Collections;
using UnityEngine;

public class FoxDistraction : MonoBehaviour, Clickable_Interface
{
    public SpriteRenderer sprite;
    public AudioManager audioManager;
    public float minFoxWaitTime = 5f;
    public float maxFoxWaitTime = 10f;

    public bool isFoxAttacking = false;
    public bool FoxRepelled = false;

    private int click_count = 0;


    private void Start()
    {
        sprite.enabled = false;
        StartCoroutine(FoxAttackRoutine());
    }

    //periodically, the fox chooses to attack based on randomly on a chosen wait interval
    private IEnumerator FoxAttackRoutine()
    {
        while (true)
        {
            if (!isFoxAttacking)
            {
                //fox waits
                float waitTime = Random.Range(minFoxWaitTime, maxFoxWaitTime);
                yield return new WaitForSeconds(waitTime);

                //pops up sprite
                isFoxAttacking = true;
                sprite.enabled = true;
                Debug.Log("Fox is attacking!");
                yield return new WaitUntil(() => FoxRepelled);

                //removes sprite, fox goes away
                sprite.enabled = false;
                isFoxAttacking = false;
                FoxRepelled = false;
                Debug.Log("Fox repelled.");
            }
            yield return null;
        }
    }

    //called when clicked()
    public void DeactivateFox()
    {
        isFoxAttacking = false;
        FoxRepelled = true;
    }

    public void Click()
    {
        if (isFoxAttacking)
        {
            //to get rid of fox, must click him 12 times
            click_count++;
            if (click_count >= 12)
            {
                audioManager.Play("FoxScreech");
                DeactivateFox();
                click_count = 0;
            }
        }
    }
}
