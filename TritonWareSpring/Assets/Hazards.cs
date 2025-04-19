using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Hazards : MonoBehaviour
{

    public WheatDistraction wheatDistraction;
    public FoxDistraction foxDistraction;

    public MilkDistraction milkDistraction;

    int currentDistractions;

    public UnityEngine.UI.Image Hazard_Warning;

    public Sprite[] Hazard_Warnings;

    public GameManager game;

    float timer = 0f;
    public int seconds = 0;

    bool lifeLost = false;

    // Update is called once per frame
    void Update()
    {

        currentDistractions = 0;

        if(wheatDistraction.isWeedBlocking){
            currentDistractions ++;
        }

        if(foxDistraction.isFoxAttacking){
            currentDistractions ++;
        }

        if(milkDistraction.isCowMad){
            currentDistractions ++;
        }

        if(currentDistractions == 3){

            if(!lifeLost){

            timer+=Time.deltaTime;
            if (timer >= 1f){
                seconds++;
                timer = 0f;
            }

            if (seconds >=5){
                game.LoseLife();
                lifeLost = true;
            }


            }
    else
    {
        // Reset if conditions change
        timer = 0f;
        seconds = 0;
        lifeLost = false;
    }
        }
        DisplayHazard();
    }

    public void DisplayHazard(){
        if(currentDistractions > 0){
            Hazard_Warning.sprite = Hazard_Warnings[currentDistractions - 1];
            Hazard_Warning.enabled = true;
        }

        else{
            Hazard_Warning.enabled = false;

        }
}

}