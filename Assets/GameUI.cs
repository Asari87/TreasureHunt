using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button quitButton;
    [SerializeField] private Button pauseButton;

    private SessionManager sessionManager;

    private void Awake()
    {
        sessionManager = FindObjectOfType<SessionManager>();
    }
    private void Start()
    {
        quitButton.onClick.AddListener(HandleQuitButton);
        pauseButton.onClick.AddListener(HandlePauseButton);
    }
    private void OnDestroy()
    {
        quitButton.onClick.RemoveAllListeners();
        pauseButton.onClick.RemoveAllListeners();
    }
    private void HandlePauseButton()
    {
        sessionManager.PauseGame();
        UI_AlertHandler.instance.ShowMessage("Pause", "Press the Confim button to resume game", HandleResume);
    }

    private void HandleQuitButton()
    {
        sessionManager.PauseGame();
        UI_AlertHandler.instance.ShowMessage("Quit?", "Are you sure you want to quit the game?", HandleQuit, HandleResume);
    }

    private void HandleQuit()
    {
        sessionManager.EndGame();
    }

    private void HandleResume()
    {
        sessionManager.ResumeGame();
    }

    
}
