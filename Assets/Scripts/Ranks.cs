using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranks : MonoBehaviour
{
    const float victory = 15;
    public float eloChange;
    public float currentElo = 1500;
    public float aiElo;
    public enum ranks {SadPanda, AngryPanda, HappyPanda, PandaIsAwesome, PandaIsGod}
    public enum aiRanks {CatIsNice, DogIsBetter, CatAreMemes, SayHiToDoggo, PandaIsGod}

    public void EloCalculation()
    {
        float avgElo = (currentElo + aiElo) / 2;
        eloChange = (avgElo - currentElo) * 0.1725f + victory;
        currentElo += eloChange;
    }
}
