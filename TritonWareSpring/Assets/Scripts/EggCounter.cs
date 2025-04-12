using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggCounter : MonoBehaviour
{

    public GameObject Capsule;
    public GameManager game;
    private bool isCounting = false;
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
    private bool isLaying = false;
    public TextMeshProUGUI Text;

    public DistractionManager distractionManager;

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

    currentState = ChickenState.ReadyToCollect;
    Debug.Log("Egg is ready to collect!");
    // Optional: Show an icon or visual indicator on chicken
}

private void CollectEgg()
{
    game.AddEggs(1);
    currentState = ChickenState.Idle;
    Debug.Log("Egg collected!");
    Text.text = "Eggs: " + game.eggs.ToString();
}


}