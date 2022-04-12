using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float timer;
    public int minutes;
    public int seconds;
    public int milliseconds;
    void Update()
    {

        if (FindObjectOfType<Starter>().startTimer == true)
        {

            timer += Time.deltaTime;
            minutes = Mathf.FloorToInt(timer / 60F);
            seconds = Mathf.FloorToInt(timer % 60F);
            milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
            TimerText.text = seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }

    }
}
