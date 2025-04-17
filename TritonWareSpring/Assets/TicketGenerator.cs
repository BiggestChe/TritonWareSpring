using UnityEngine;

public class TicketGenerator : MonoBehaviour
{

    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateCakeTicket();
        Debug.Log(gameManager.ticketlist.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateCakeTicket()
    {
        gameManager.ticketlist.Clear(); // Clear any previous ticket

        int eggCount = Random.Range(1, 4);   // 1 to 3
        int milkCount = Random.Range(1, 4);  // 1 to 3
        int wheatCount = Random.Range(1, 4); // 1 to 3

        for (int i = 0; i < eggCount; i++)
            gameManager.ticketlist.Add(GameManager.IngredientType.Egg);
        
        for (int i = 0; i < milkCount; i++)
            gameManager.ticketlist.Add(GameManager.IngredientType.Milk);
        
        for (int i = 0; i < wheatCount; i++)
            gameManager.ticketlist.Add(GameManager.IngredientType.Wheat);


        Debug.Log("Generated cake ticket: " + string.Join(", ", gameManager.ticketlist));
    }

}
