using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggCounter : MonoBehaviour
{
    public GameObject Capsule;
    public GameManager game;
    public float interval = 1f;

    //three possible states for the chicken, 
    /*
    Idle - avaiable to be clicked and begin Laying
    Laying - currently Laying Eggs
    ReadyToCollect - collectable 
    */
    private enum ChickenState { Idle, Laying, ReadyToCollect }
    private ChickenState currentState = ChickenState.Idle;
    public float layTime = 3f;
    public TextMeshProUGUI Text;

    public SpriteRenderer FINISHED_EGG;
    public FoxDistraction distractionManager;


    public void Awake()
    {
        FINISHED_EGG.enabled = false;
    }
    //calls upon clicking on the chicken house
    public void OnCapsulePressed()
    {
    if (distractionManager.isFoxAttacking)
    {
        Debug.Log("You can't do that! Fox is attacking!");
        return;
    }

    switch (currentState)
    {
        case ChickenState.Idle:
            StartCoroutine(LayEggRoutine());
            break;

        case ChickenState.ReadyToCollect:
            CollectEgg();
            FINISHED_EGG.enabled = false;
            break;

        case ChickenState.Laying:
            Debug.Log("Egg is still being laid...");
            break;
    }
}


private IEnumerator LayEggRoutine()
{

    Debug.Log("Chicken started laying an egg...");
    currentState = ChickenState.Laying;

    // Optional: Add a loading animation or UI update here

    yield return new WaitForSeconds(layTime);

    //update chicken sprite to show egg is produced
    FINISHED_EGG.enabled = true;

    currentState = ChickenState.ReadyToCollect;
    Debug.Log("Egg is ready to collect!");

}

private void CollectEgg()
{
    //checks if basket is full
    if (game.IsFull())
    {
        Debug.Log("Basket is full! Can't collect egg.");
        return;
    }

    //adds ingredient to the "basket"
    game.AddIngredient(GameManager.IngredientType.Egg);
    currentState = ChickenState.Idle;
    Debug.Log("Egg collected!");
}


}