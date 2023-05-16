using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    [SerializeField] private IGameElement[] gameElements;
    private PlayerController playerController;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameElements = GetComponentsInChildren<IGameElement>();
        
    }
    void Start()
    {
        Debug.Log("Game Start!");
        foreach (IGameElement gameElement in gameElements)
        {
            gameElement.OnGameStart(HandleGameOver);
        }
        playerController.EnableMovement();
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over!");
        foreach (IGameElement gameElement in gameElements)
        {
            gameElement.OnGameStop();
        }
        playerController.DisableMovement();
    }

    public void PauseGame()
    {
        foreach (IGameElement gameElement in gameElements)
        {
            gameElement.OnGamePaused();
        }
        playerController.DisableMovement();

    }
    public void ResumeGame()
    {
        foreach (IGameElement gameElement in gameElements)
        {
            gameElement.OnGameResume();
        }
        playerController.EnableMovement();

    }

    internal void EndGame()
    {
        HandleGameOver();
    }
}
