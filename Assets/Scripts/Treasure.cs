using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private int score;
    public static Action<Treasure> OnPickup;

    public void SetScore(int score)
    {
        this.score = score; 
    }
    public int GetScore()
    {
        return score;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnPickup?.Invoke(this);
        gameObject.SetActive(false);
    }


}
