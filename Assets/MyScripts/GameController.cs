using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Ranks ranks;
    private StateMachine stateMachine;
    private Randomize randomize;
    private AIController aiController;
    private int answer;
    public Timer timer;
    public TMP_InputField inputeAnswer;
    public TextMeshProUGUI questionsText;
    public TextMeshProUGUI playerOne;
    public TextMeshProUGUI playerTwo;
    public TextMeshProUGUI yourAnswer;
    public float playerOneAnswerTime;
    public float playerTwoAnswerTime;


    private void Start()
    {
        timer.isNewGameTime = true;
        randomize = GetComponent<Randomize>();
        ranks = GetComponent<Ranks>();
        stateMachine = GetComponent<StateMachine>();
        aiController = GetComponent<AIController>();
        timer.newGameTime = 10;
        questionsText.text = playerOne.text + " VS " + playerTwo.text;
        yourAnswer.enabled = false;
    }

    private void Update()
    {
        timer.MyUpdate();
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu");
        EventSystem.current.SetSelectedGameObject(inputeAnswer.gameObject, null);
        inputeAnswer.OnPointerClick(new PointerEventData(EventSystem.current));
        if (Input.GetKeyDown(KeyCode.Return) && inputeAnswer.ToString() != System.String.Empty) Answer();

        if (timer.newGameTime <= 0 && timer.isNewGameTime)
        {
            NewQuestion();
            timer.isNewGameTime = false;
        }

        if (timer.showingAnswerTime <= 0 && timer.isShowingAnswerTime)
        {
            RestartGame();
            timer.isShowingAnswerTime = false;
        }

        if (timer.newQuestionTime <= 0 && timer.isNewQuestionTime)
        {
            DrawOutTextWinnerText();  
            timer.isNewQuestionTime = false;
        } 
    }

   
    public void Answer()
    {
        answer = int.Parse(inputeAnswer.text);
        playerOneAnswerTime = 5 - timer.newQuestionTime;
        aiController.CheckAi();
    }
    
    public void DrawOutTextWinnerText()
    {
        questionsText.fontSize = 38;
        yourAnswer.enabled = true;

        if (answer == stateMachine.rightAnswer)
        {
            yourAnswer.text = playerOne.name + " Right answer" + " " + "Your answer time was" + " " + playerOneAnswerTime.ToString("F1") + "s";
        }

        if (aiController.aiAnswers == stateMachine.rightAnswer)
        {
            
            questionsText.text = playerTwo.name + " Right answer" + " " + "Answer time was" + " " + playerTwoAnswerTime.ToString("F1") + "s";
        }

        if (answer != stateMachine.rightAnswer)
        {
            yourAnswer.text = playerOne.name + " " + "Wrong answer";
        }

        if (aiController.aiAnswers != stateMachine.rightAnswer)
        {
            questionsText.text = playerTwo.name + " " + "Wrong answer";
        }
        timer.ShowingAnswers();
    }
    
    public void RestartGame()
    {
        if (stateMachine.rightAnswer == answer) ranks.CheckYourRank(true, false);
        if (stateMachine.rightAnswer != answer) ranks.CheckYourRank(false, true);
        NewQuestion();
    }

    public void NewQuestion()
    {
        stateMachine.CheckState(ranks.yourElo, randomize.RandomizeArr());
        questionsText.fontSize = 50;
        questionsText.text = stateMachine.questionString;
        timer.NewQuestionTime();
        yourAnswer.enabled = false;
    }
}
