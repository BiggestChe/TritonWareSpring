using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitcher : MonoBehaviour
{
    public GameObject farmLayer;
    public GameObject kitchenLayer;

    void Start()
    {
        kitchenLayer.SetActive(false);
        
    }
    public void SwitchToKitchen()
    {
        farmLayer.SetActive(false);
        kitchenLayer.SetActive(true);
    }

    public void SwitchToFarm()
    {
        kitchenLayer.SetActive(false);
        farmLayer.SetActive(true);
    }
}
