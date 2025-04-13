using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum IngredientType { Egg, Milk, Wheat }

    public int MaxCapacity = 5;

    // Represents the player's basket
    public List<IngredientType> basket = new List<IngredientType>();

    //Game Stats
    public int timer;

    public int cakes = 0;

    public List<IngredientType> ticketlist = new List<IngredientType>();
    


    //isfull
    public bool IsFull()
    {
        return basket.Count >= MaxCapacity;
    }

    public void AddIngredient(IngredientType ingredient)
    {
        if (!IsFull())
        {
            basket.Add(ingredient);
            Debug.Log(ingredient + " added. Basket now has " + basket.Count + " items.");
        }
        else
        {
            Debug.Log("Basket is full! Can't add more ingredients.");
        }
    }
    //adds egg to ingredient array
    public void AddEggs()
    {
        AddIngredient(IngredientType.Egg);
        Debug.Log("Egg added");
    }

    //adds milk to ingredient array

    public void AddMilk()
    {
        AddIngredient(IngredientType.Milk);
        Debug.Log("Milk added");

    }

    //adds wheat to ingredient array

    public void AddWheat()
    {
        Debug.Log("Wheat added");

        AddIngredient(IngredientType.Wheat);
    }

    // Optional: Method to remove or use ingredients from the basket
    public void UseIngredient(IngredientType ingredient)
    {
        if (basket.Contains(ingredient))
        {
            basket.Remove(ingredient);
            Debug.Log(ingredient + " used. Basket now has " + basket.Count + " items.");
        }
        else
        {
            Debug.Log("No " + ingredient + " in basket to use.");
        }
    }
}
