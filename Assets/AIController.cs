using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameController gameController;
    public Ranks rank;
    public Questions questions;
    public float aiCurrentElo;
    public float counter;
    public int randNumber;
    public float randomTime;
    public int easy = 1650;
    public int medium = 1800;
    public int hard = 2000;
    public int aiAnswers;
    public bool canAiTimerStart;

    private void Update()
    {
        if (canAiTimerStart)
        {
            AiTimer();
        }
    }
    public void CheckAi()
    {
        aiCurrentElo = rank.aiElo;
        RandomNumber();

        if(aiCurrentElo < easy && counter > (randomTime + 0.5f) && randNumber > 60)
        {
            aiAnswers = questions.rightAnswerEasy;
            canAiTimerStart = false;
            gameController.playerTwoAnswerTime = counter;
            counter = 0;
        }

        if (aiCurrentElo > medium && aiCurrentElo < hard && counter > (randomTime + 0.2f) && randNumber > 40)
        {
            aiAnswers = questions.rightAnswerMedium;
            canAiTimerStart = false;
            gameController.playerTwoAnswerTime = counter;
            counter = 0;
        }

        if (aiCurrentElo > hard && counter >  randomTime && randNumber > 20)
        {
            aiAnswers = questions.rightAnswerHard;
            canAiTimerStart = false;
            gameController.playerTwoAnswerTime = counter;
            counter = 0;
        }
        if (counter > randomTime)
        {
            aiAnswers = randNumber;
            canAiTimerStart = false;
            gameController.playerTwoAnswerTime = counter;
            counter = 0;
        }
    }

    public void AiTimer()
    {
        counter += Time.deltaTime;
    }

    public void RandomNumber()
    {
        randNumber = Random.Range(0, 100);
    }

    public void RandomTime()
    {
        randomTime = Random.Range(0.4f, 4.5f);
    }
}
