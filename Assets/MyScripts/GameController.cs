using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private TextHandler textHandler;
    private Ranks ranks;
    private StateMachine stateMachine;
    private Randomize randomize;
    private AIController aiController;
    private GameObject dontDestroyOnLoadObjects;
    private WinCondition winCondition;
    public Timer timer;
    public GameObject inputeText;
    public TMP_InputField inputeAnswer;
    public int rounds;
    public float playerOneAnswerTime;
    public float playerTwoAnswerTime;
    private int answer;


    private void Start()
    {
        timer.isNewGameTime = true;
        randomize = GetComponent<Randomize>();
        ranks = GetComponent<Ranks>();
        stateMachine = GetComponent<StateMachine>();
        aiController = GetComponent<AIController>();
        winCondition = GetComponent<WinCondition>();
        textHandler = GetComponent<TextHandler>();
        timer.newGameTime = 10;
        dontDestroyOnLoadObjects = GameObject.Find("DontDestroyOnLoadObjects");

    }

    private void Update()
    {
        timer.MyUpdate();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            Destroy(dontDestroyOnLoadObjects);
        } 
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
        
        if(timer.newQuestionTime <= 0 && rounds >= 5)
        {
            
        }
    }

   
    public void Answer()
    {
        iTween.PunchScale(inputeText, new Vector3(4,4,0), 0.8f);
        answer = int.Parse(inputeAnswer.text);
        playerOneAnswerTime = 5 - timer.newQuestionTime;
        aiController.CheckAi();
        winCondition.EachRound(playerOneAnswerTime, answer, rounds, stateMachine.rightAnswer, textHandler.playerOne.name);
        winCondition.EachRound(playerTwoAnswerTime, aiController.aiAnswers, rounds, stateMachine.rightAnswer, textHandler.playerTwo.name);
        textHandler.PlayerOneAnswer();
    }
    
    public void DrawOutTextWinnerText()
    {
        winCondition.RoundWinner();
        timer.ShowingAnswers();
        textHandler.EnablePlayerAnswerText();
    }
    
    public void RestartGame()
    {
        NewQuestion();
    }

    public void NewQuestion()
    {
        stateMachine.CheckState(ranks.yourElo, randomize.RandomizeArr());
        textHandler.NewQuestion(stateMachine.questionString);
        timer.NewQuestionTime();
        playerTwoAnswerTime = aiController.RandomTime();
        rounds++;
    }
}
