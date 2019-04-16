using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerName : MonoBehaviour
{
    HoldingObjects dontDestroyOnLoad;
    public TextMeshProUGUI playerName;
    void Start()
    {
        dontDestroyOnLoad = FindObjectOfType<HoldingObjects>();
        if (dontDestroyOnLoad == null)
        {
            Debug.Log("No player information from menu");
            return;
        }
        playerName.text = dontDestroyOnLoad.inputFieldPlayerString;
    }
}
