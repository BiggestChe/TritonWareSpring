using UnityEngine;

public class Knob : MonoBehaviour
{
    //creates an instance of the class that belongs to itself so I can use it to access the class form other classes
    public static Knob knobInstance;
    //used for the object positional values, let's me use RectTransform component of objects
    public RectTransform Knob; 
    public RectTransform CookingSlider;
    public float speed = 100f; //speed of the movement of progress oval 

    //used to 'actviate' the knob
    public bool activation = false; 
    //will used to record knob position after click 
    public float currentPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets knobInstance to an instance of this class
        knobInstance = this; 

        //calculate x position offset 
        public float positionalDifference = CookingSlider.rect.width - Knob.rect.width; 
        //set position to left most side of CookingSlider
        Knob.anchoredPosition = new Vector2(0,Knob.anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        //knob position is less than the positional difference move to the right
        if(activation)
        {
            //current knob positional is moved
            Knob.anchoredPosition += new Vector2(speed * Time.deltaTime, 0)
            if(Input.GetMouseButtonDown(0))
            {
                //updates the position at where knob stopped 
                currentPos = Knob.anchoredPosition.x; 

                //disables movement 
                activation = false; 
                
                //resets position
                Knob.anchoredPosition = new Vector2(0,Knob.anchoredPosition.y);
            }
            //if mouse click doesn't occure this will just set currentPos to the right most side of progress bar
            currentPos = Knob.anchoredPosition.x;

            //disables movement 
            activation = false; 

            //resets position
            Knob.anchoredPosition = new Vector2(0,Knob.anchoredPosition.y);
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
