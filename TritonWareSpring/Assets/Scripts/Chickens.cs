using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chickens : MonoBehaviour, Clickable_Interface
{

    public EggCounter counter;
    public void Click(){
        Debug.Log("help");
        counter.OnCapsulePressed();
    }

}
