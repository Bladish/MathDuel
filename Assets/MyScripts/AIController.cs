using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameController gameController;
    private StateMachine stateMachine;
    private Ranks rank;
    public float aiCurrentElo;
    public int randNumber;
    public int easy = 1650;
    public int medium = 1800;
    public int hard = 2000;
    public int aiAnswers;

    public void Start()
    {
        gameController = GetComponent<GameController>();
        stateMachine = GetComponent<StateMachine>();
        rank = GetComponent<Ranks>();
    }
  
    public void CheckAi()
    {
        aiCurrentElo = rank.aiElo;
        RandomNumber();

        if(aiCurrentElo < easy &&  randNumber > 60)
        {
            aiAnswers = stateMachine.rightAnswer;
            gameController.playerTwoAnswerTime = gameController.playerTwoAnswerTime + 0.5f;
        }

        if (aiCurrentElo > medium && aiCurrentElo < hard && randNumber > 40)
        {
            aiAnswers = stateMachine.rightAnswer;
            gameController.playerTwoAnswerTime = gameController.playerTwoAnswerTime + 0.8f;
        }

        if (aiCurrentElo > hard && randNumber > 20)
        {
            aiAnswers = stateMachine.rightAnswer;
            gameController.playerTwoAnswerTime = gameController.playerTwoAnswerTime + 0.9f; 
        }
        
    }

    public void RandomNumber()
    {
        randNumber = Random.Range(0, 100);
    }

    public float RandomTime()
    {
        float randomTime;
        randomTime = Random.Range(0.4f, 4.1f);
        return randomTime;
    }
}
