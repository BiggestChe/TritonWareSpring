using Unity.VisualScripting;
using UnityEngine;

public class CookingSlider : MonoBehaviour
{
    public static CookingSlider sliderInstance;

    //will be used to record if we got a cake 
    public GameManager game; 

    public GameObject MiniGame;
    public GameObject KitchenObjects; 

    public TicketGenerator ticket;

    public Canvas canvas;



    //strike zone bounds
    public float strikeMin; 
    public float strikeMax; 

    //should run everytime the object is enabled
    void Awake()
    {
        sliderInstance = this; 
    }
    

    //call this method to activate the knob
    public void Bake()
    {

        Debug.Log("Bake was called"); 
        //this should start knob movement 
        Knob.knobInstance.ActivateKnob();
        
    }

    public void strikeCheck()
    {
        //checks if the knob position stopped in strike zone 
        if(Knob.knobInstance.currentPos >= strikeMin && Knob.knobInstance.currentPos <= strikeMax)
        {
            Debug.Log(Knob.knobInstance.currentPos);
            Debug.Log(strikeMin);
            Debug.Log(strikeMax);
            Debug.Log("Was here 1 ");
            
            //is so, add cake to counter and disable the minigame 
            game.cakes++;
            MiniGame.SetActive(false);
            KitchenObjects.SetActive(true);
            canvas.enabled = true;    
            Debug.Log("UI activated");

            //new ticket created!
            TicketGenerator.tickets.GenerateCakeTicket();


        }
        else
        {
            Debug.Log(Knob.knobInstance.currentPos);
            Debug.Log(strikeMin);
            Debug.Log(strikeMax);
            Debug.Log("Was here 2");
            //if not, lose life and disable the minigame
            game.LoseLife(); 
            MiniGame.SetActive(false);
            KitchenObjects.SetActive(true);
            canvas.enabled = true;    

        }
    }
}
