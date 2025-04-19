using System.Collections;
using UnityEngine;
using TMPro;

public class MilkCounter : MonoBehaviour
{
    public GameObject CowObject;
    public GameManager game;
    public float milkingTime = 3f;
    public TextMeshProUGUI Text;
    public SpriteRenderer FullMilkBucket;   
    public AudioManager audioManager;

    public GameObject progressBar;
    //three different types of milking
    //Idle - player hasnt clicked on
    //Milking - currently producing milk
    //ReadyToCollect - milk is ready to be harvested
    private enum MilkState { Idle, Milking, ReadyToCollect }
    private MilkState currentState = MilkState.Idle;

    private void Awake()
    {
        FullMilkBucket.enabled = false;
        progressBar.SetActive(false);
    }

    //upon clicking of milk house
    public void OnCapsulePressed()
    {
        switch (currentState)
        {
            case MilkState.Idle:
                StartCoroutine(MilkCowRoutine());
                progressBar.SetActive(true);

                break;

            case MilkState.ReadyToCollect:
                audioManager.Play("Pop2");

                CollectMilk();
                FullMilkBucket.enabled = false;
                progressBar.SetActive(false);

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

    //adds milk to basket, checks for fullness, if full, return 
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
