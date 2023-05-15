using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private int score;
    private int timeBonus;
    public static Action<Treasure> OnSpawn;
    public static Action<Treasure> OnPickup;

    public void SetScore(int score)
    {
        this.score = score; 
    }
    public int GetScore()
    {
        return score;
    }

    public void SetTimeBonus(int timeBonus)
    {
        this.timeBonus = timeBonus;
    }
    public int GetTimeBonus()
    {
        return timeBonus;
    }

    private void OnEnable()
    {
        OnSpawn?.Invoke(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnPickup?.Invoke(this);
        gameObject.SetActive(false);
    }


}
