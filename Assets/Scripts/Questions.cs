using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public Ranks rank;
    public bool canRandomize;
    public int rounds = 0;
    int[] numbers;
    public string questionEasy;
    public string questionMedium;
    public string questionHard;
    public int rightAnswerEasy;
    public int rightAnswerMedium;
    public int rightAnswerHard;

    private void Start()
    {
        numbers = new int[5];
        canRandomize = true;
    }

    public int[] Randomize()
    {
        int[] arr = new int[5];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(1, 10);
        }
        rounds++;
        Debug.Log(rounds);
        canRandomize = false;
        return arr;
    }

    public void QuestionEasy()
    {
        numbers = Randomize();
        questionEasy = numbers[0].ToString() + " + " + numbers[1].ToString() + " = ";
        rightAnswerEasy = numbers[0] + numbers[1];
    }

    public void QuestionMedium()
    {
        numbers = Randomize();
        if (numbers[0] < 3)
        {
            questionMedium = numbers[0].ToString() + " + " + numbers[1].ToString() + " - " + numbers[2].ToString() + " = ";
            rightAnswerMedium = numbers[0] + numbers[1] - numbers[2];
        }
        if (numbers[0] > 3 && numbers[0] < 5)
        {
            questionMedium = numbers[0].ToString() + " + " + numbers[1].ToString() + " + " + numbers[2].ToString() + " = ";
            rightAnswerMedium = numbers[0] + numbers[1] + numbers[2];
        }
        if (numbers[0] > 5)
        {
            questionMedium = numbers[0].ToString() + " - " + numbers[1].ToString() + " + " + numbers[2].ToString() + " = ";
            rightAnswerMedium = numbers[0] - numbers[1] + numbers[2];
        }
    }


    public void QuestionHard()
    {
        numbers = Randomize();
        if (numbers[0] < 3)
        {
            questionHard = numbers[0].ToString() + " + " + numbers[1].ToString() + " * " + numbers[2].ToString() + " = ";
            rightAnswerHard = numbers[0] + numbers[1] * numbers[2];
        }
        if (numbers[0] > 3 && numbers[0] < 5)
        {
            questionHard = numbers[0].ToString() + " * " + numbers[1].ToString() + " - " + numbers[2].ToString() + " = ";
            rightAnswerHard = numbers[0] * numbers[1] - numbers[2];
        }
        if (numbers[0] > 5)
        {
            questionHard = numbers[0].ToString() + " * " + numbers[1].ToString() + " + " + numbers[2].ToString() + " = ";
            rightAnswerHard = numbers[0] * numbers[1] + numbers[3];
        }
    }
}
