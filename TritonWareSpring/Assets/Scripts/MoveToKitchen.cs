using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToKitchen : MonoBehaviour, Clickable_Interface
{
    public LayerSwitcher layerSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Click(){
        Debug.Log("should deactivate farm");

        layerSwitcher.SwitchToKitchen();
    }
}