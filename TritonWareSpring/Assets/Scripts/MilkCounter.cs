using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MilkCounter : MonoBehaviour
{

    public GameObject Capsule;
    public GameManager game;
    private bool isCounting = false;
    public float interval = 1f;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "Milk: 0";
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

            game.AddMilk(1);

        Debug.Log("incrementing");
    }

    private IEnumerator IncrementCounter()
    {
        {
            yield return new WaitForSeconds(interval);
            Text.text = "Milk: " + game.milk.ToString();
        }
    }
}
