using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Knob : MonoBehaviour
{
    //holds a static reference to the Knob instance so other classes can access it globally (singleton) 
    //very useful when I don't need multiple instances of a class 
    public static Knob knobInstance;
    //used for the object positional values, let's me use RectTransform component of objects
    public RectTransform knobPosition;
    float speed;
    float reverseSpeed; 
    bool goingReverse = false; 
    
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
        reverseSpeed = UnityEngine.Random.Range(-12f, -7f); 

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
            if((knobPosition.localPosition.x == minOffset && goingReverse == false) || 
            (knobPosition.localPosition.x < maxOffset && knobPosition.localPosition.x > minOffset && goingReverse == false))
            {   
                Debug.Log("Should go fowards"); 
                knobPosition.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else if(knobPosition.localPosition.x >= maxOffset || 
            (knobPosition.localPosition.x < maxOffset && knobPosition.localPosition.x > minOffset && goingReverse == true))
            {
                Debug.Log("Should go reverse"); 
                goingReverse = true;
                Debug.Log(goingReverse);
                knobPosition.localPosition += new Vector3(reverseSpeed* Time.deltaTime, 0, 0);
            }
            else if(knobPosition.localPosition.x <= minOffset && goingReverse == true)
            {
                Debug.Log("Should go fowards again"); 
                goingReverse = false; 
                knobPosition.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
                
            }
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
