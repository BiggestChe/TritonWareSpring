using System.Collections;
using UnityEngine;
using TMPro;

public class MilkCounter : MonoBehaviour
{
    public GameObject CowObject;
    public GameManager game;
    public float milkingTime = 3f;
    public TextMeshProUGUI Text;
    public SpriteRenderer FullMilkBucket;    // Visual cue for full bucket

    private enum MilkState { Idle, Milking, ReadyToCollect }
    private MilkState currentState = MilkState.Idle;

    private void Awake()
    {
        FullMilkBucket.enabled = false;
        Text.text = "Milk: 0";
    }

    public void OnCapsulePressed()
    {
        switch (currentState)
        {
            case MilkState.Idle:
                StartCoroutine(MilkCowRoutine());
                break;

            case MilkState.ReadyToCollect:
                CollectMilk();
                FullMilkBucket.enabled = false;
                break;

            case MilkState.Milking:
                Debug.Log("Milking in progress...");
                break;
        }
    }

    private IEnumerator MilkCowRoutine()
    {
        Debug.Log("Milking the cow...");
        currentState = MilkState.Milking;

        yield return new WaitForSeconds(milkingTime);
        FullMilkBucket.enabled = true;
        currentState = MilkState.ReadyToCollect;

        Debug.Log("Milk is ready to collect!");
    }

    private void CollectMilk()
    {
        if (game.IsFull())
        {
            Debug.Log("Basket is full! Can't collect milk.");
            return;
        }

        game.AddIngredient(GameManager.IngredientType.Milk);
        currentState = MilkState.Idle;

        Debug.Log("Milk collected!");
    }

}
