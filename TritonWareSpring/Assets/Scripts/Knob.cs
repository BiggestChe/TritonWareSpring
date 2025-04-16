using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Knob : MonoBehaviour
{
    //creates an instance of the class that belongs to itself so I can use it to access the class form other classes
    public static Knob knobInstance;
    //used for the object positional values, let's me use RectTransform component of objects
    public RectTransform knobPosition;
    float speed = 1f; //speed of the movement of progress oval 
    
    //used to 'actviate' the knob
    public bool activation = false; 
    //will used to record knob position after click 
    public float currentPos;

    public float minOffset = -2.6f;
    public float maxOffset = 2.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets knobInstance to an instance of this class
        knobInstance = this; 

        if (knobPosition == null)
        {
            knobPosition = GetComponent<RectTransform>();
        }

        //set position to left most side of CookingSlider
        knobPosition.localPosition = new Vector2(minOffset,knobPosition.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        //knob position is less than the positional difference move to the right
        if(activation)
        {
            // Debug.Log("Activated!"); 
            if(Input.GetMouseButton(0)) 
            {
                Debug.Log("Mouse Input");
                //updates the position at where knob stopped 
                currentPos = knobPosition.localPosition.x; 

                //disables movement 
                activation = false; 
                
                //resets position
                knobPosition.localPosition = new Vector2(minOffset,knobPosition.localPosition.y);
            }

            //current knob positional is moved
            knobPosition.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
            // Debug.Log("Movement");

        }

        if(knobPosition.localPosition.x >= maxOffset)
        {
            //if mouse click doesn't occure this will just set currentPos to the right most side of progress bar
            currentPos = maxOffset;

            //disables movement 
            activation = false; 

            Debug.Log("Max");
            //resets position
            knobPosition.localPosition = new Vector2(minOffset,knobPosition.localPosition.y);
            
        }
    } 


    //might not be used
    public float getCurrentPos()
    {
        return currentPos; 
    }

    public void ActivateKnob()
    {
        activation = true; //changes activation to true to start knob movement
    }
}
