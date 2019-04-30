using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class TextHandler : MonoBehaviour
{
    public TextMeshProUGUI playerOneAnswerText;
    public TextMeshProUGUI playerTwoAnswerText;
    public TextMeshProUGUI questionsText;
    public TextMeshProUGUI playerOne;
    public TextMeshProUGUI playerOneRank;
    public TextMeshProUGUI playerTwo;
    public TextMeshProUGUI playerTwoRank;
    public string[] insults;
    public string[] loosing;


    private void Start()
    {
        playerOneAnswerText.enabled = false;
        playerTwoAnswerText.enabled = false;
        questionsText.text = playerOne.text + " VS " + playerTwo.text;
        AddTextFileToString();
    }

    public void NewQuestion(string question)
    {
        questionsText.text = question;
        DisablePlayerAnswerText();
    }

    public void PlayerOneAnswer()
    {
        playerOneAnswerText.enabled = true;
        playerOneAnswerText.text = "Wihoo";
    }

    public void PlayerOneWinner(float t)
    {
        playerOneAnswerText.text = playerTwo.text + " " + insults[Random.Range(0, insults.Length)];
        questionsText.text = playerOne.text + " Is the winner and the answer time was " + t.ToString("F1") + "s";
    }

    public void PlayerOneLooser()
    {
        playerOneAnswerText.text = loosing[Random.Range(0, loosing.Length)];
    }

    public void PlayerTwoAnswer()
    {
        playerTwoAnswerText.enabled = true;
        playerTwoAnswerText.text = "To Easy";
    }

    public void PlayerTwoWinner(float t)
    {
        playerTwoAnswerText.text = playerOne.text + " " + insults[Random.Range(0, insults.Length)];
        questionsText.text = playerTwo.text + " Is the winner and the answer time was " + t.ToString("F1") + "s";
    }

    public void PlayerTwoLooser()
    {
        playerTwoAnswerText.text = loosing[Random.Range(0, loosing.Length)];
    }

    public void Draw()
    {
        questionsText.text = "Draw";
    }

    public void EnablePlayerAnswerText()
    {
        playerOneAnswerText.enabled = true;
        playerTwoAnswerText.enabled = true;
    }

    public void DisablePlayerAnswerText()
    {
        playerOneAnswerText.enabled = false;
        playerTwoAnswerText.enabled = false;
    }
    
    void AddTextFileToString()
    {
        string pathInsults = "Assets/Resources/Insults.txt";
        string pathLoosing = "Assets/Resources/Loosing.txt";
        insults = File.ReadAllLines(pathInsults);
        loosing = File.ReadAllLines(pathLoosing);
    }
}
