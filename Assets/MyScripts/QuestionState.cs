using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestionState : MonoBehaviour
{
    public int[] numbers;
    public string question;
    public int rightAnswer;
    public abstract void Question(int [] arr);
}
