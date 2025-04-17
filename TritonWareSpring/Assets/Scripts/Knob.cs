using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Knob : MonoBehaviour
{
    //creates an instance of the class that belongs to itself so I can use it to access the class from other classes
    public static Knob knobInstance;
    //used for the object positional values, let's me use RectTransform component of objects
    public RectTransform knobPosition;
    float speed;
    
    //used to 'actviate' the knob
    public bool activation = false; 
    //will used to record knob position after click 
    public float currentPos;

    public float minOffset = -7.8f;
    public float maxOffset = 7.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets knobInstance to an instance of this class
        knobInstance = this; 

        //random speed float value
        speed = UnityEngine.Random.Range(7f, 12f);

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
    
        if(activation)
        {
            // this shit is literally the same as the other implementation, wasted my fucking time for nothing
            Debug.Log("Activated!"); 
            if(Input.GetMouseButton(0)) 
            {
                Debug.Log("Mouse Input");
                //updates the position at where knob stopped 
                currentPos = knobPosition.localPosition.x; 
                Debug.Log(currentPos);

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



    // public void Click()
    // {
    //     // Debug.Log("Activated!"); 
    //     Debug.Log("Mouse Input");
    //     Debug.Log(currentPos);
    //     //updates the position at where knob stopped 
    //     currentPos = knobPosition.localPosition.x; 

    //     //disables movement 
    //     activation = false; 
        
    //     //resets position
    //     knobPosition.localPosition = new Vector2(minOffset,knobPosition.localPosition.y);
    // }


    public void ActivateKnob()
    {
        activation = true; //changes activation to true to start knob movement
    }
}
