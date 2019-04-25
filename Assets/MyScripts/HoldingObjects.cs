using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HoldingObjects : MonoBehaviour
{
    public string inputFieldPlayerString;
    public string playerTwoName;

    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }
}
