using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggCounter : MonoBehaviour
{

    public GameObject Capsule;
    public GameManager game;
    private bool isCounting = false;
    public float interval = 1f;
    public TextMeshProUGUI Text;

    public DistractionManager distractionManager;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "Eggs: 0";
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //on chicken house pressed, and no fox attack
    //increment chickens gained by 1
    public void OnCapsulePressed()
    {
        if (!isCounting && !distractionManager.isFoxAttacking) 
        {
            isCounting = true;
            StartCoroutine(IncrementCounter());
            game.AddEggs(1);
        }

        else{
            Debug.Log("you can't do that!");
        }
            isCounting = false;
        Debug.Log("incrementing");
    }

    //increment counter of eggs gained using data values of Gamemanager.game.
    private IEnumerator IncrementCounter()
    {
        {
            while(!distractionManager.isFoxAttacking){

            yield return new WaitForSeconds(interval);
            Text.text = "Eggs: " + game.eggs.ToString();
            }

        }
    }


}