using System.Collections;
using UnityEngine;

public class FoxDistraction : MonoBehaviour, IClickable
{
    public SpriteRenderer sprite;
    public AudioManager audioManager;

    public BoxCollider2D boxCollider2D;
    public float minFoxWaitTime = 5f;
    public float maxFoxWaitTime = 10f;

    public bool isFoxAttacking = false;
    public bool FoxRepelled = false;

    public int ClICK_COUNT = 0;

    public int REQUIRED_COUNTS = 10;


    private void Start()
    {
        boxCollider2D.enabled = false;
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
                boxCollider2D.enabled = true;
                Debug.Log("Fox is attacking!");
                yield return new WaitUntil(() => FoxRepelled);

                //removes sprite, fox goes away
                sprite.enabled = false;
                isFoxAttacking = false;
                FoxRepelled = false;
                boxCollider2D.enabled = false;

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
            ClICK_COUNT++;
            if (ClICK_COUNT >= REQUIRED_COUNTS)
            {
                audioManager.Play("FoxScreech");
                DeactivateFox();
                ClICK_COUNT = 0;
            }
        }
    }
}
