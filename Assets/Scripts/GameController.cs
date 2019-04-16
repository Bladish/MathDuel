using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Timer timer;
    public TMP_InputField inputeAnswer;
    public TextMeshProUGUI questionsText;
    public TextMeshProUGUI playerOne;
    public TextMeshProUGUI playerTwo;
    public TextMeshProUGUI yourAnswer;
    public Ranks ranks;
    public Questions questions;
    public AIController aiController;
    int rightAnswer;
    int answer;
    List<int> yourAnswers;
    public float restartTime = 10;
    string currentDifficulty;
    float playerOneAnswerTime;
    public float playerTwoAnswerTime;
    


    private void Awake()
    {
        yourAnswers = new List<int>();
        timer.countDown = 15;
        questionsText.text = playerOne.text + " VS " + playerTwo.text;
        yourAnswer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu");
        EventSystem.current.SetSelectedGameObject(inputeAnswer.gameObject, null);
        inputeAnswer.OnPointerClick(new PointerEventData(EventSystem.current));

        if (timer.isGameStarted && questions.canRandomize)
        {
            NewQuestion();
            inputeAnswer.text = "";
        }

        if(questions.rounds >= 6 && timer.isGameStarted)
        {
            RestartGame();
        }

        if (Input.GetKeyDown("return") && timer.isGameStarted)
        {
            playerOneAnswerTime = timer.countDown;
            if(ranks.yourElo < 1650)
            {
                rightAnswer = questions.rightAnswerEasy;
                Debug.Log(rightAnswer);
                Answer();
                DrawOutTextWinnerText();
            }

            if(ranks.yourElo >= 1650  && ranks.yourElo < 1800)
            {
                rightAnswer = questions.rightAnswerMedium;
                Answer();
                DrawOutTextWinnerText();
            }

            if(ranks.yourElo >= 1800)
            {
                rightAnswer = questions.rightAnswerHard;
                Answer();
                DrawOutTextWinnerText();
            }
        }
    }

   
    public void Answer()
    {
        yourAnswer.enabled = true;
        answer = int.Parse(inputeAnswer.text); 
        if (rightAnswer == answer)
        {
            yourAnswers.Add(questions.rounds);
        }
    }
    
    public void DrawOutTextWinnerText()
    {
        if (answer == rightAnswer)
        {
            yourAnswer.text = playerOne.name + " Right answer" + " " + "Your answer time was" + " " + playerOneAnswerTime.ToString("F1") + "s";
        }
        if (aiController.aiAnswers == rightAnswer)
        {
            questionsText.text = playerTwo.name + " Right answer" + " " + "Answer time was" + " " + playerTwoAnswerTime.ToString("F1") + "s";
        }
        if (answer != rightAnswer) yourAnswer.text = playerOne.name + " " + "Wrong answer";
        if (aiController.aiAnswers != rightAnswer) questionsText.text = playerTwo.name + " " + "Wrong answer";
    }
    
    public void RestartGame()
    {
        if(yourAnswers.Count >= 3) ranks.CheckYourRank(true, false);
        if (yourAnswers.Count < 3) ranks.CheckYourRank(false, true);
        aiController.CheckAi();
        questions.rounds = 0;
        questionsText.text = "You had" + " " + yourAnswers.Count.ToString() + " " + "out of 5";
        timer.isGameStarted = false;
        timer.countDown = restartTime;
        yourAnswers.Clear();
    }

    public void NewQuestion()
    {
        aiController.counter = 0;
        if (ranks.yourElo < 1650)
        {
            questions.QuestionEasy();
            questionsText.text = questions.questionEasy;
        }
        if (ranks.yourElo >= 1650 && ranks.yourElo < 1800)
        {
            questions.QuestionMedium();
            questionsText.text = questions.questionMedium;
        }
        if (ranks.yourElo >= 1800)
        {
            questions.QuestionHard();
            questionsText.text = questions.questionHard;
        }
    }
}
