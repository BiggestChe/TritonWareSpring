using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wheats : MonoBehaviour, Clickable_Interface
{
    public WheatCounter counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
        Debug.Log("help");

        counter.OnCapsulePressed();
    }

}
