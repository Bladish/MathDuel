using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public Questions questions;
    public AIController aiController;
    public TextMeshProUGUI yourAnswer;
    public TextMeshProUGUI timerText;
    public float countDown;
    public bool isGameStarted;

    
    void FixedUpdate()
    {
        if(countDown >= 0 && !isGameStarted)
        {
            timerText.text = countDown.ToString("F0");
            TimeCalcultion();
        }
        if (countDown > 0 && isGameStarted)
        {
            timerText.text = countDown.ToString("F0");
            TimeCalcultion();
        }

        if (countDown <= 0)
        {
            countDown = 5f;
            timerText.text = countDown.ToString("F0");
            isGameStarted = true;
            questions.canRandomize = true;
            aiController.canAiTimerStart = true;
            yourAnswer.enabled = false;
        }

        
    }

    void TimeCalcultion()
    {
        countDown -= Time.deltaTime;
    }
}
