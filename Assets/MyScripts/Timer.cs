using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float newQuestionTime;
    public float showingAnswerTime;
    public float newGameTime;
    public bool isShowingAnswerTime;
    public bool isNewQuestionTime;
    public bool isNewGameTime;
    

    
    public void MyUpdate()
    {
        TimeCalcultion();    
    }

    void TimeCalcultion()
    {
        if (newQuestionTime >= 0 && isNewQuestionTime)
        {
            newQuestionTime -= Time.deltaTime;
            timerText.text = newQuestionTime.ToString("F0");
        }
        if (showingAnswerTime >= 0 && isShowingAnswerTime)
        {
            showingAnswerTime -= Time.deltaTime;
            timerText.text = showingAnswerTime.ToString("F0");
        }
        if (newGameTime >= 0 && isNewGameTime)
        {
            newGameTime -= Time.deltaTime;
            timerText.text = newGameTime.ToString("F0");
        }
    }

    public void NewQuestionTime()
    {
        newQuestionTime = 5f;
        isNewQuestionTime = true;
    }

    public void ShowingAnswers()
    {
        showingAnswerTime = 4f;
        isShowingAnswerTime = true;
    }

    public void NewGameTime()
    {
        newGameTime = 10f;
        isNewGameTime = true;
    }
}
