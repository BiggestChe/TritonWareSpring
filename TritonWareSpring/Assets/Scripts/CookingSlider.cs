using UnityEngine;

public class CookingSlider : MonoBehaviour
{
    //instance of the cookingslider class 
    public CookingSlider cookingInstance; 

    //Knob and Cooking slider gives access to the RectTransform component of both objects 
    public RectTransform knobPosition; 
    public RectTransform cookingSliderPosition;

    //will track if the cooking was successful 
    public static bool success; 

    //strike zone bounds
    public float strikeMin = -1; 
    public float strikeMax = 1f; 

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
            success = true; 
        }
        //or it'll be false 
        else 
        {
            success = false; 
        }
    }
}
