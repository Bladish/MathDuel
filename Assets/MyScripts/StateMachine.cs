using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    QuestionsEasyState questionsEasySate;
    QuestionsMediumState questionsMediumState;
    QuestionsHardState questionsHardState;
    QuestionsVeryHardState questionsVeryHardState;
    QuestionsExtremeState questionsExtremeState;
    public int rightAnswer;
    public string questionString;

    private void Start()
    {
        questionsEasySate = GetComponent<QuestionsEasyState>();
        questionsMediumState = GetComponent<QuestionsMediumState>();
        questionsHardState = GetComponent<QuestionsHardState>();
        questionsVeryHardState = GetComponent<QuestionsVeryHardState>();
        questionsExtremeState = GetComponent<QuestionsExtremeState>();
    }
    public void CheckState(float elo, int[] randomize)
    {
        int[] arr = randomize;
        if (elo < 1600)
        {
            questionsEasySate.Question(arr);
            rightAnswer = questionsEasySate.rightAnswer;
            questionString = questionsEasySate.question;
        }

        if (elo >= 1600 && elo < 1700)
        {
            questionsMediumState.Question(arr);
            rightAnswer = questionsMediumState.rightAnswer;
            questionString = questionsMediumState.question;
        }
        if (elo >= 1700 && elo < 1800)
        {
            questionsHardState.Question(arr);
            rightAnswer = questionsHardState.rightAnswer;
            questionString = questionsHardState.question;
        }
        if (elo >= 1800 && elo < 1900)
        {
            questionsVeryHardState.Question(arr);
            rightAnswer = questionsVeryHardState.rightAnswer;
            questionString = questionsVeryHardState.question;
        }

        if (elo >= 1900)
        {
            questionsExtremeState.Question(arr);
            rightAnswer = questionsExtremeState.rightAnswer;
            questionString = questionsExtremeState.question;
        }
    }
}
