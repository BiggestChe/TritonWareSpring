using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wheats : MonoBehaviour, Clickable_Interface
{
    public WheatCounter counter;
    public void Click(){
        Debug.Log("help");

        counter.OnCapsulePressed();
    }

}
