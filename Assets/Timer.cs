using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime;
    float time;


    void Start()
    {
        timerText.text = startTime.ToString();
        time = Time.time;
    }

    void FixedUpdate()
    {
        if (startTime > 0)
        {
            TimeCalcultion();
            timerText.text = startTime.ToString();
        }
    }

    void TimeCalcultion()
    {
        if (time < Time.time)
        {
            time = Time.time + 1;
            startTime -= 1;
        }
    }
}
