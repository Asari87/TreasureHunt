using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IGameElement
{
    private int score;
    private void Awake()
    {
        Treasure.OnPickup += HandleTreasureScore;
    }
    private void OnDestroy()
    {
        Treasure.OnPickup -= HandleTreasureScore;
    }
    private void HandleTreasureScore(Treasure obj)
    {
        score += obj.GetScore();
    }

    public void OnGamePaused()
    {
        
    }

    public void OnGameResume()
    {
        
    }

    public void OnGameStart(Action _)
    {
        score = 0;
    }

    public void OnGameStop()
    {
        Debug.Log(score);
        PlayerPrefs.SetInt("Score", score);           
    }

}
