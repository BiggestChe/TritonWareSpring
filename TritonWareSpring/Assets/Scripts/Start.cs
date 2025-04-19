using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class StartGame : MonoBehaviour, IClickable
{

    public GameObject kitchenScene;

    public GameObject farmScene;

    public Canvas playerUI;

    public GameManager gameManager;

    public GameObject Start_Screen;

    public 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        kitchenScene.SetActive(false);
        farmScene.SetActive(false);
        playerUI.enabled = false;
        gameManager.enabled = false;
    }

    public void DestroyPanel(){
        Destroy(Start_Screen);
        kitchenScene.SetActive(true);
        farmScene.SetActive(true);
        playerUI.enabled = true;
        gameManager.enabled = true;
    }
    public void Click(){
        return;
    }
}