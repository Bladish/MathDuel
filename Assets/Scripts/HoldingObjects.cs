﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HoldingObjects : MonoBehaviour
{
    public TMP_InputField inputField;
    public string inputFieldString;


    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            inputFieldString = inputField.text;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("MathDuelPoC"); 
        }
    }
}
