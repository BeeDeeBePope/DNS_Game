using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Variables._Definitions;

public class LevelTimer : MonoBehaviour
{
    public float TimeLimit = 180;
    public StringVariable TimerText;
    public UnityEvent TimerStoppedEvent;

    // Update is called once per frame
    void Update()
    {
        TimeLimit -= Time.deltaTime;

        if (TimeLimit >= 0)
        {
            int fullTime = (int)Mathf.Round(TimeLimit);
            int minutes = fullTime / 60;
            int seconds = fullTime % 60;

            TimerText.Value = "Pozostały czas: " + minutes + ":" + (seconds < 10 ? "0" + seconds : seconds.ToString());
        }
        else
        {
            TimerText.Value = "KONIEC CZASU!!!";
            TimerStoppedEvent.Invoke();
        }
    }
}
