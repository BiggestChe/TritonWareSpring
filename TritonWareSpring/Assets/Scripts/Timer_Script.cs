using System.Collections;
using TMPro;
using UnityEngine;

public class Timer_Script : MonoBehaviour
{
    public TextMeshProUGUI textbox;

    public bool TimerOn = false;

    public float time;

    public GameManager gameManager;

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

            // Clamp time to zero if it goes below
            if (time <= 0)
            {
                time = 0;
                TimerOn = false;
                textbox.text = "00 : 00";
                textbox.color = Color.red;

                // Trigger lose condition
                gameManager.OnLose();
                yield break; // Exit the coroutine
            }

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
