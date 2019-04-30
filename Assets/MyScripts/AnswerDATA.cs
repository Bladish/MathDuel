using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  AnswerDATA
{
    public float time;
    public int answer;
    public int round;
    public int rightAnswer;

    public AnswerDATA(float t, int a, int r, int rightA)
    {
        time = t;
        answer = a;
        rightAnswer = rightA;
        round = r;
    }

    public bool WasCorrect()
    {
        return answer == rightAnswer;
    }
}
