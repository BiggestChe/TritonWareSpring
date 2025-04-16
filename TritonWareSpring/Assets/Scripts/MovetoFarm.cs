using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToFarm : MonoBehaviour, IClickable
{

    public LayerSwitcher layerSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Click(){

        Debug.Log("hopefully moves to farm");

        layerSwitcher.SwitchToFarm();


    }
}
