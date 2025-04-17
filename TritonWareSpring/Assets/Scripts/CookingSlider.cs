using Unity.VisualScripting;
using UnityEngine;

public class CookingSlider : MonoBehaviour
{
    //will be used to record if we got a cake 
    public GameManager game; 

    //instance of the cookingslider class 
    public static CookingSlider cookingInstance; 

    //strike zone bounds
    public float strikeMin = -1.7f; 
    public float strikeMax = 1.7f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookingInstance = this; 
        Bake();
    }


    //call this method to activate the knob
    void Bake()
    {
        //this should start knob movement 
        Knob.knobInstance.activation = true; 
        //if the updates pos is within strike zone, success is true 
        if(Knob.knobInstance.currentPos >= strikeMin && Knob.knobInstance.currentPos <= strikeMax)
        {
            game.cakes++;
        }
        else
        {
            return;
        }
    }
}
