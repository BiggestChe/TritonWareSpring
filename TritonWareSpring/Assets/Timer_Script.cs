using System.Collections;
using TMPro;
using UnityEngine;

public class Timer_Script : MonoBehaviour
{

    public TextMeshProUGUI textbox; 

    public bool TimerOn = false;

    public float time;


    void Start()
    {
        TurnTimerOn();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (TimerOn)
        {
            time -= Time.deltaTime;

            // Update timer display
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            textbox.color = Color.red;
            textbox.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        yield return null;

        }
    }

        public void TurnTimerOn()
    {
        TimerOn = true;
    }

    public void TurnTimerOff()
    {
        TimerOn = false;
    }
}
