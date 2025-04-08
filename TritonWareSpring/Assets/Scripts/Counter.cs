using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    public GameObject Capsule;
    private int counter = 0; 
    private bool isCounting = false;
    public float interval = 1f;

    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void OnCapsulePressed()
    {
        if (!isCounting)
        {
            isCounting = true;
            StartCoroutine(IncrementCounter());
        }
            isCounting = false;


        Debug.Log("incrementing");
    }

    private IEnumerator IncrementCounter()
    {
        {
            yield return new WaitForSeconds(interval);
            counter++;
            Text.text = counter.ToString();
        }
    }
}
