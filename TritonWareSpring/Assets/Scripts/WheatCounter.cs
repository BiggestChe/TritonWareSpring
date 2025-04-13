using System.Collections;
using UnityEngine;
using TMPro;

//wheat counter for clicking and adding of the wheat
public class WheatCounter : MonoBehaviour
{
    public GameObject Capsule;
    public GameManager game;
    public float growTime = 3f;
    public TextMeshProUGUI Text;
    public WheatDistraction distractionManager;

    private enum WheatState { Idle, Growing, ReadyToHarvest }
    private WheatState currentState = WheatState.Idle;

    public GameObject BeginningSeed;

    public SpriteRenderer FullyGrownHay;

    public void Awake()
    {
        BeginningSeed.SetActive(false);
        FullyGrownHay.enabled = false;
    }

    // Called when the player clicks on the wheat field
    public void OnCapsulePressed()
    {
        if (distractionManager.isWeedBlocking)
        {
            Debug.Log("You can't grow wheat! Weeds are blocking the field.");
            return;
        }

        switch (currentState)
        {
            case WheatState.Idle:

                StartCoroutine(GrowWheatRoutine());
                break;

            case WheatState.ReadyToHarvest:
                HarvestWheat();
                BeginningSeed.SetActive(false);
                FullyGrownHay.enabled = false;
                break;

            case WheatState.Growing:
                Debug.Log("Wheat is still growing...");
                break;
        }
    }

    //routine that handles the process of growing wheat routine
    //task: with Player UI, connect to a progress bar of the creation of the ingredient
    private IEnumerator GrowWheatRoutine()
    {
        Debug.Log("Wheat is growing...");
        currentState = WheatState.Growing;

        //activate 
        BeginningSeed.SetActive(true);

        yield return new WaitForSeconds(growTime);

        BeginningSeed.SetActive(false);
        FullyGrownHay.enabled = true;

        currentState = WheatState.ReadyToHarvest;
        Debug.Log("Wheat is ready to harvest!");
    }

    private void HarvestWheat()
    {
        if (game.IsFull())
        {
            Debug.Log("Basket is full! Can't harvest wheat.");
            return;
        }

        game.AddIngredient(GameManager.IngredientType.Wheat);
        currentState = WheatState.Idle;
        Debug.Log("Wheat harvested!");
    }
}
