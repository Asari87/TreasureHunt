using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    private Timer gameTimer;
    private void Awake()
    {
        gameTimer = FindObjectOfType<Timer>();
    }
    
    void Update()
    {
        timer.text = gameTimer.GetFormattedTimeLeft();   
    }
}
