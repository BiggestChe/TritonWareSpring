using TMPro;
using UnityEngine;

public class TicketGenerator : MonoBehaviour
{

    public GameManager gameManager;

    public TextMeshProUGUI textbox1;
    public TextMeshProUGUI textbox2;
    public TextMeshProUGUI textbox3;

    public ProgressBarScript progressBar;



    public static TicketGenerator tickets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tickets = this;
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

        textbox1.text = "x" + eggCount;
        textbox2.text = "x" + milkCount;
        textbox3.text = "x" + wheatCount;

        for (int i = 0; i < eggCount; i++)
            gameManager.ticketlist.Add(GameManager.IngredientType.Egg);

        for (int i = 0; i < milkCount; i++)
            gameManager.ticketlist.Add(GameManager.IngredientType.Milk);

        for (int i = 0; i < wheatCount; i++)
            gameManager.ticketlist.Add(GameManager.IngredientType.Wheat);

        progressBar.PlayLoadingBar();

        Debug.Log("Generated cake ticket: " + string.Join(", ", gameManager.ticketlist));
    }
}
