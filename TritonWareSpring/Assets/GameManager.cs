using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Player Stats
    public int milk = 0;
    public int eggs = 0;
    public int wheat = 0;
    public int cakes = 0;
    public int MaxCapacity = 5;

    public bool IsFull = false;


    //Game Stats

    public int timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMilk(int amount)
    {
        milk += amount;
        Debug.Log("Milk: " + milk);
    }

    public void AddEggs(int amount)
    {
        eggs += amount;
        Debug.Log("Eggs: " + eggs);
    }

    public void AddWheat(int amount)
    {
        wheat += amount;
        Debug.Log("Wheat: " + wheat);
    }
}
