using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePickupHandler : MonoBehaviour
{
    private Timer timer;
    private void Awake()
    {
        timer = GetComponent<Timer>();
        Treasure.OnPickup += HandleTreasure;
    }
    private void OnDestroy()
    {
        Treasure.OnPickup -= HandleTreasure;
    }

    private void HandleTreasure(Treasure treasure)
    {
        Debug.Log($"Pickup {treasure}!");
        timer.AddBonusTime(treasure.GetTimeBonus());
    }

    
}
