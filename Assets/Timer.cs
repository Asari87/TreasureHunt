using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Timer : MonoBehaviour, IGameElement
{
    [SerializeField] private float maxStartTime = 60;

    private float timeLeft;
    private bool isGameActive = false;

    public Action OnTimeout;

    public string GetFormattedTimeLeft()
    {

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = timeLeft - 60 * minutes;
        return $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }
    private void Awake()
    {
        OnGameStop();
    }
    void Update()
    {
        if (!isGameActive || timeLeft == 0) return;
        timeLeft -= Time.deltaTime;
        if(timeLeft<= 0)
        {
            timeLeft = 0;
            OnTimeout?.Invoke();
        }
    }

    public void AddBonusTime(float bonus)
    {
        timeLeft += bonus;
    }

    public void OnGameStart(Action callback)
    {
        OnTimeout = callback;
        timeLeft = maxStartTime;
        isGameActive = true;
    }

    public void OnGameStop()
    {
        timeLeft = 0;
        isGameActive = false;
    }
}
