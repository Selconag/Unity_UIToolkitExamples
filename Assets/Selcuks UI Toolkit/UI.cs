using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("ButtonStart");
        Button buttonStop = root.Q<Button>("ButtonStop");
        Button buttonExit = root.Q<Button>("ButtonExit");

        buttonStart.clicked += () => StartBehaviour();
        buttonStop.clicked += () => StopBehaviour();
        buttonExit.clicked += () => ExitGame();
    }

    private void StartBehaviour()
    {
        
    }

    private void StopBehaviour()
    {

    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
