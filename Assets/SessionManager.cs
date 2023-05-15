using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    [SerializeField] private IGameElement[] gameElements;

    private void Awake()
    {
        gameElements = GetComponentsInChildren<IGameElement>();
    }
    void Start()
    {
        Debug.Log("Game Start!");
        foreach (IGameElement gameElement in gameElements)
        {
            gameElement.OnGameStart(HandleGameOver);
        }
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over!");
        foreach (IGameElement gameElement in gameElements)
        {
            gameElement.OnGameStop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
