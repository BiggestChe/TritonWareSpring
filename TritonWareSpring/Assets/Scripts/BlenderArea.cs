using UnityEngine;

public class BlenderCheck : MonoBehaviour, IClickable
{
    //should activate on button press of blender

    public GameManager gameManager;

    public void CheckBlenderIngredients()
    {

        int requiredEggs = 0;
        int requiredMilk = 0;
        int requiredWheat = 0;

        // Count the ingredients needed for the current ticket
        foreach (GameManager.IngredientType ingredientType in gameManager.ticketlist)
        {
            switch (ingredientType)
            {
                case GameManager.IngredientType.Egg:
                    requiredEggs++;
                    break;
                case GameManager.IngredientType.Milk:
                    requiredMilk++;
                    break;
                case GameManager.IngredientType.Wheat:
                    requiredWheat++;
                    break;
            }
        }

        Debug.Log(requiredEggs);
        Debug.Log(requiredMilk);
        Debug.Log(requiredWheat);

        // Now compare the blender contents to the required values
        if (gameManager.blender_eggs == requiredEggs &&
            gameManager.blender_milk == requiredMilk &&
            gameManager.blender_wheat == requiredWheat)
        {

            //sets hasDough = true; allowed to put oven minigame
            gameManager.hasDough = true;
            Debug.Log("all matching");
            ResetBlender();
            TicketGenerator.tickets.GenerateCakeTicket();
        }
        else
        {
            gameManager.hasDough = false;
            gameManager.LoseLife();
            Debug.Log("Wrong Ingredients");
            ResetBlender();
            TicketGenerator.tickets.GenerateCakeTicket();
        }
    }

    public void Click(){
        CheckBlenderIngredients();
    }
    public void ResetBlender()
    {
        gameManager.blender_eggs = 0;
        gameManager.blender_milk = 0;
        gameManager.blender_wheat = 0;
    }

}
