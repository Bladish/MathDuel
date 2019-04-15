using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public Timer timer;
    public TMP_InputField inputeAnswer;
    public TextMeshProUGUI questions;
    public TextMeshProUGUI playerOne;
    public TextMeshProUGUI playerTwo;
    public TextMeshProUGUI yourAnswer;
    public float restartGame;
    int[] numbers;
    int rightAnswer;
    int answer;
    List<int> yourAnswers;
    int rightAnswerChecker;
    public float restartTime;

    private void Awake()
    {
        yourAnswers = new List<int>();
        timer.countDown = 15;
        questions.text = playerOne.text + " VS " + playerTwo.text;
        yourAnswer.enabled = false;
        rightAnswerChecker = 1;
    }

    private void Update()
    {
        EventSystem.current.SetSelectedGameObject(inputeAnswer.gameObject, null);
        inputeAnswer.OnPointerClick(new PointerEventData(EventSystem.current));

        if (timer.isGameStarted && Questions.canRandomize)
        {
            NewQuestion();
            inputeAnswer.text = "";
        }

        if(Questions.rounds >= 6 && timer.isGameStarted)
        {
            RestartGame();
        }

        if (Input.GetKeyDown("return"))
        {
            RightAnswer();
            Answer();
            DrawOutTextRightOrWrong();
        }
    }

    public void RightAnswer()
    {
        rightAnswer = numbers[0] + numbers[1];
    }

    public void Answer()
    {
        yourAnswer.enabled = true;
        answer = int.Parse(inputeAnswer.text);
        if (rightAnswer == answer)
        {
            rightAnswerChecker++;
            yourAnswers.Add(rightAnswerChecker);
        }
    }
    
    public void DrawOutTextRightOrWrong()
    {
        if (answer == rightAnswer)
        {
            yourAnswer.text = "Your answer was right" + " " + answer.ToString();
        }
        if (answer != rightAnswer)
        {
            yourAnswer.text = "Your answer was wrong" + " " + answer.ToString() + ", " + "The right answer was" + " " + rightAnswer.ToString();
        }

    }
    
    public void RestartGame()
    {
        Questions.rounds = 0;
        rightAnswerChecker = 0;
        questions.text = "You had" + " " + yourAnswers.Count.ToString() + " " + "out of 5";
        timer.isGameStarted = false;
        timer.countDown = restartTime;
        yourAnswers.Clear();
    }

    public void NewQuestion()
    {
        numbers = Questions.Randomize();
        questions.text = numbers[0].ToString() + " + " + numbers[1].ToString() + " = ?";
        Questions.canRandomize = false;
    }

}
