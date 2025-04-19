using System.Collections;
using System.Linq;
using UnityEngine;


// This script simulates weeds periodically growing over the wheat field,
// requiring the player to click multiple times to repel them.
public class WheatDistraction : MonoBehaviour, IClickable
{
    public SpriteRenderer sprite;
    public AudioManager audioManager;

    public float minWeedWaitTime;
    public float maxWeedWaitTime;

    public bool isWeedBlocking { get; private set; } = false;
    private bool weedRepelled = false;

    private int clickCount = 0;
    public int requiredClicks = 10;

    public BoxCollider2D boxCollider2D;

    public float forceWeedsEveryXSeconds = 15f;
    private float weedTimer = 0f;


    private void Start()
    {
        Debug.Log("Activating wheat distraction routine...");
        sprite.enabled = false;
        boxCollider2D.enabled = false;


        //StartCoroutine(WeedAttackRoutine());
    }

private void Update()
{
    if (isWeedBlocking)
    {
        if (weedRepelled)
        {
            Debug.Log("✨ Weeds repelled!");
            audioManager.Play("WheatPluck");

            sprite.enabled = false;
            boxCollider2D.enabled = false;
            isWeedBlocking = false;

            // Optional: reset timer if you want full delay again
            weedTimer = 0f;
        }
    }
    else
    {
        weedTimer += Time.deltaTime;

        if (weedTimer >= forceWeedsEveryXSeconds)
        {
            ForceWeedsNow();
            weedTimer = 0f;
        }
    }
}


    public void ForceWeedsNow()
    {
    isWeedBlocking = true;
    weedRepelled = false;
    clickCount = 0;

    sprite.enabled = true;
    boxCollider2D.enabled = true;

    Debug.Log("Forced: Weeds have overgrown the field!");
    }

IEnumerator WeedAttackRoutine()
{
    while (true)
    {
        yield return new WaitForSeconds(Random.Range(minWeedWaitTime, maxWeedWaitTime));

        isWeedBlocking = true;
        weedRepelled = false;
        clickCount = 0;

        sprite.enabled = true;
        boxCollider2D.enabled = true;

        Debug.Log("🌾 Weeds are blocking the field!");

        while (!weedRepelled)
        {
            yield return null;
        }

        Debug.Log("✨ Weeds repelled!");
        audioManager.Play("WheatPluck");

        sprite.enabled = false;
        boxCollider2D.enabled = false;
        isWeedBlocking = false;
    }
}


    public void Click()
    {
        if (!isWeedBlocking) return;

        clickCount++;
        Debug.Log($"Weed clicked! Current count: {clickCount}/{requiredClicks}");

        if (clickCount >= requiredClicks)
        {
            RepelWeeds();
        }
    }

    private void RepelWeeds()
    {
        weedRepelled = true;
    }
}
