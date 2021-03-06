﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ranks : MonoBehaviour
{
    public TextMeshProUGUI playerOneRank;
    public TextMeshProUGUI playerTwoRank;
    public StateMachine stateMachine;
    const float victory = 30;
    const float loosing = -20;
    public float eloChange;
    public float currentElo = 1500;
    public float aiElo;
    public float yourElo;
    public string yourRank;

    private void Start()
    {
        yourElo = currentElo;
        playerOneRank.text = System.String.Empty;
        playerTwoRank.text = System.String.Empty;
    }

    public void CheckYourRank(bool win, bool loose)
    {
        if(win) EloCalculationWin();
        if (loose) EloCalculationLoose();
        if (yourElo < 1400)
        {
            yourRank = "WorkWork";
            aiElo = Random.Range(1300, 1400);
            playerTwoRank.text = "WorkWork";
        }
        if (yourElo >= 1400)
        {
            yourRank = "SadPanda";
            aiElo = Random.Range(1400, 1500);
            playerTwoRank.text = "SadPanda";
        }
        if (yourElo >= 1600)
        {
            yourRank = "AngryPanda";
            aiElo = Random.Range(1500, 1600);
            playerTwoRank.text = "AngryPanda";
        }
        if (yourElo >= 1700)
        {
            yourRank = "HappyPanda";
            aiElo = Random.Range(1600, 1700);
            playerTwoRank.text = "HappyPanda";
        }
        if (yourElo >= 1800)
        {
            yourRank = "PandaIsAwesome";
            aiElo = Random.Range(1700, 1800);
            playerTwoRank.text = "PandaIsAwesome";
        }
        if (yourElo >= 2000)
        {
            yourRank = "PandaIsGod";
            aiElo = Random.Range(1800, 2050);
            playerTwoRank.text = "PandaIsGod";
        }
        playerOneRank.text = yourRank;
    }

    public void EloCalculationWin()
    {
        float avgElo = (currentElo + aiElo) / 2;
        eloChange = (avgElo - currentElo) * 0.1725f + victory;
        currentElo += eloChange;
        yourElo = currentElo;
    }

    public void EloCalculationLoose()
    {
        float avgElo = (currentElo + aiElo) / 2;
        eloChange = (avgElo - currentElo) * 0.1725f - Mathf.Abs(loosing);
        currentElo += eloChange;
        yourElo = currentElo;
    }

}
