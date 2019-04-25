using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsEasyState : QuestionState
{
    public override void Question(int[] arr)
    {
        Debug.Log("EasyQuestion");
        numbers = arr;
        question = numbers[0].ToString() + " + " + numbers[1].ToString() + " = ";
        rightAnswer = numbers[0] + numbers[1];
    }
}
