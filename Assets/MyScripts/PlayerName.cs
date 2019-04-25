using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerName : MonoBehaviour
{
    HoldingObjects dontDestroyOnLoad;
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    void Awake()
    {
        dontDestroyOnLoad = FindObjectOfType<HoldingObjects>();
        if (dontDestroyOnLoad == null)
        {
            return;
        }
        playerOneName.text = dontDestroyOnLoad.inputFieldPlayerString;
        playerTwoName.text = dontDestroyOnLoad.playerTwoName;
    }
}
