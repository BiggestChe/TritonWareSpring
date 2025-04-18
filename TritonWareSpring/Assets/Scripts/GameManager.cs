using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject eggImage;
    public GameObject milkImage;
    public GameObject wheatImage;

    public Canvas player_UI;

    public GameObject LoseScreen;
    public List<Transform> basketSlots = new List<Transform>();
    public Transform basketUI;
    public enum IngredientType { Egg, Milk, Wheat }
    public Dictionary<IngredientType, GameObject> ingredient_UI;

    // Represents the player's basket
    public int MaxCapacity = 5;
    public List<IngredientType> basket = new List<IngredientType>();

    //Game Stats
    public int timer;
    public int cakes = 0;
    public bool hasDough = false;

    public GameObject dough; 

    public List<IngredientType> ticketlist = new List<IngredientType>();

    public int blender_eggs = 0;
    public int blender_wheat = 0;
    public int blender_milk = 0;

    public int lives = 3;



    void Start()
    {
        LoseScreen.SetActive(false);
        dough.SetActive(false);
        {

        //a dictionary connected ingredient types to their GameObject
        ingredient_UI = new Dictionary<IngredientType, GameObject>
        {
        { IngredientType.Egg, eggImage},
        { IngredientType.Milk, milkImage },
        { IngredientType.Wheat, wheatImage }
        };
        }
    }

    void Update()
    {
        DoughObtained();
        
    }

    //using a list of objects, associate the current basket list with the slots
    //of the basket UI
    public void UpdateBasketUI()
{
    for(int i = 0; i<basket.Count && i< basketSlots.Count; i++){
        IngredientType ingredient = basket[i];

        //using mapping of ingredient to UI image, make an instance of the ingredient in the 
        //basket
        if (basketSlots[i].childCount < 1){
            
            if (ingredient_UI.ContainsKey(ingredient))
        {
            GameObject added_Ingredient = Instantiate(ingredient_UI[ingredient], basketSlots[i]);
            added_Ingredient.tag = ingredient_UI[ingredient].tag;

            //creates a child under the slot parent
            //accesses rect transform property to set to Vector2.zero (0, 0)
            //in terms of parent slot
            added_Ingredient.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        }
        
    }

    }

    //if the basket is full, do not allow any more ingredients
    public bool IsFull()
    {
        return basket.Count >= MaxCapacity;
    }

    /*
    adds ingredient to list based on parameter added
    checks for fullness, should cap at 5
    */
    public void AddIngredient(IngredientType ingredient)
    {
        if (!IsFull())
        {
            basket.Add(ingredient);
            Debug.Log(ingredient + " added. Basket now has " + basket.Count + " items.");
            UpdateBasketUI();
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

    //remove or use ingredients from the basket
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

    public void DoughObtained(){
        if (hasDough == true){
        dough.SetActive(true);
        }
    }

    public void LoseLife(){
        lives--;
        if(lives == 0){
            OnLose();
        }
    }

    public void OnLose(){
        LoseScreen.SetActive(true);
        player_UI.enabled = false;
    }

    public void PassBlender()
    {
        hasDough = true;
    }
}
