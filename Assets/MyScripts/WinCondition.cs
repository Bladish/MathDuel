using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private AnswerDATA answerDATA;
    private TextHandler textHandler;
    private Ranks ranks;
    private List<AnswerDATA> answersPlayerOne;
    private List<AnswerDATA> answersPlayerTwo;
    public int playerOneWins;
    public int playerTwoWins;

    enum WinStates {None, Both, PlayerOne, PlayerTwo};

    private void Start()
    {
        textHandler = GetComponent<TextHandler>();
        ranks = GetComponent<Ranks>();
        answersPlayerOne = new List<AnswerDATA>();
        answersPlayerTwo = new List<AnswerDATA>();
    }

    public void RoundWinner()
    {
        WinStates winner = WinStates.None;
        int playerOneLastIndex = answersPlayerOne.Count - 1;
        int playerTwoLastIndex = answersPlayerTwo.Count - 1;
        if (answersPlayerOne[playerOneLastIndex].WasCorrect())
        {
            winner = WinStates.PlayerOne;
        }

        if(answersPlayerTwo[playerTwoLastIndex].WasCorrect())
        {
            if (winner == WinStates.PlayerOne) winner = WinStates.Both;
            else winner = WinStates.PlayerTwo;
        }
        if(winner == WinStates.Both)
        {
            winner = answersPlayerOne[playerOneLastIndex].time < answersPlayerTwo[playerTwoLastIndex].time ? WinStates.PlayerOne : WinStates.PlayerTwo;
        }

        switch (winner)
        {
            case WinStates.None:
                textHandler.Draw();
                break;
            case WinStates.PlayerOne:
                ranks.CheckYourRank(true, false);
                textHandler.PlayerOneWinner(answersPlayerOne[playerOneLastIndex].time);
                textHandler.PlayerTwoLooser();
                playerOneWins++;
                break;
            case WinStates.PlayerTwo:
                ranks.CheckYourRank(false, true);
                textHandler.PlayerTwoWinner(answersPlayerTwo[playerTwoLastIndex].time);
                textHandler.PlayerOneLooser();
                playerTwoWins++;
                break;
            default:
                break;
        }
    }

    public void EachRound(float t, int a, int r, int rightA, string p)
    {
        if("Player1" == p)
        {
            answerDATA = new AnswerDATA(t, a, r, rightA);
            answersPlayerOne.Add(answerDATA);
        }

        if("Player2" == p)
        {
            answerDATA = new AnswerDATA(t, a, r, rightA);
            answersPlayerTwo.Add(answerDATA);
        }
    }
}
