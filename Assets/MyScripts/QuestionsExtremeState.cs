using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsExtremeState : QuestionState
{
    public override void Question(int[] arr)
    {
        numbers = arr;
        if (numbers[0] <= 3)
        {
            question = numbers[0].ToString() + " * " + numbers[1].ToString() + " + " + numbers[2].ToString() + " + " + numbers[3].ToString() + " = ";
            rightAnswer = numbers[0] * numbers[1] + numbers[2] + numbers[3];
        }
        if (numbers[0] > 3 && numbers[0] <= 5)
        {
            question = numbers[0].ToString() + " + " + numbers[1].ToString() + " * " + numbers[2].ToString() + " - " + numbers[3].ToString() + " = ";
            rightAnswer = numbers[0] + numbers[1] * numbers[2] - numbers[3];
        }
        if (numbers[0] > 5)
        {
            question = numbers[0].ToString() + " - " + numbers[1].ToString() + " + " + numbers[2].ToString() + " * " + numbers[3].ToString() + " = ";
            rightAnswer = numbers[0] - numbers[1] + numbers[2] * numbers[3];
        }
    }
}
