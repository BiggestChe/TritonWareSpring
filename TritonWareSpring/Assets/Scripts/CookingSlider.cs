using UnityEngine;

public class CookingSlider : MonoBehaviour
{
    //instance of the cookingslider class 
    public CookingSlider cookingInstance; 

    //Knob and Cooking slider gives access to the RectTransform component of both objects 
    public RectTransform Knob; 
    public RectTransform CookingSlider;

    //will track if the cooking was successful 
    public static bool success; 

    //strike zone bounds
    public float strikeMin = -2f; 
    public float strikeMax = 2f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //sets the isntance of the class to 'this' so I can use it in the blender class (maybe)
            cookingInstance = this; 
            bake();
        }
        
    }

    //call this method to activate the knob
    void Bake()
    {
        //this should start knob movement 
        knobInstance.activation = true; 
        //if the updates pos is within strike zone, success is true 
        if(knobInstance.currentPos >= strikeMin && knobInstance.currentPos <= strikeMax)
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
