using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheatCounter : MonoBehaviour
{

    public GameObject Capsule;
    public GameManager game;
    private bool isCounting = false;
    public float interval = 1f;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "Wheat: 0";
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
            game.AddWheat(1);

        }
            isCounting = false;


        Debug.Log("incrementing wheat");
    }

    private IEnumerator IncrementCounter()
    {
        {
            yield return new WaitForSeconds(interval);
            Text.text = "Wheat: " + game.wheat.ToString();
        }
    }
} 
