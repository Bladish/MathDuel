using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsMediumState : QuestionState
{
    public override void Question(int[] arr)
    {
        numbers = arr;
        if (numbers[0] < 3)
        {
            question = numbers[0].ToString() + " + " + numbers[1].ToString() + " - " + numbers[2].ToString() + " = ";
            rightAnswer = numbers[0] + numbers[1] - numbers[2];
        }
        if (numbers[0] > 3 && numbers[0] < 5)
        {
            question = numbers[0].ToString() + " + " + numbers[1].ToString() + " + " + numbers[2].ToString() + " = ";
            rightAnswer = numbers[0] + numbers[1] + numbers[2];
        }
        if (numbers[0] > 5)
        {
            question = numbers[0].ToString() + " - " + numbers[1].ToString() + " + " + numbers[2].ToString() + " = ";
            rightAnswer = numbers[0] - numbers[1] + numbers[2];
        }
    }
}

