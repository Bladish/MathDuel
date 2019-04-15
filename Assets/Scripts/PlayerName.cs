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
        if(dontDestroyOnLoad == null)
        {
            return;
        }
        dontDestroyOnLoad = FindObjectOfType<HoldingObjects>();
        playerName.text = dontDestroyOnLoad.inputFieldString;
    }
}
