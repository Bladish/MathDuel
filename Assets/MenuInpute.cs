using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class MenuInpute : MonoBehaviour
{
    public TMP_InputField inputFieldPlayerName;
    public HoldingObjects holdingObjects;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        EventSystem.current.SetSelectedGameObject(inputFieldPlayerName.gameObject, null);
        inputFieldPlayerName.OnPointerClick(new PointerEventData(EventSystem.current));
        if (Input.GetKeyDown(KeyCode.Return))
        {
            holdingObjects.inputFieldPlayerString = inputFieldPlayerName.text;
            SceneManager.LoadScene("MathDuelPoC");
        }
    }
}
