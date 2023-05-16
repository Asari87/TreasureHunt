using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerFinder : MonoBehaviour
{
    private Canvas ui;
    private GameObject player;

    void Start()
    {
        ui = GetComponent<Canvas>();
        player = GameObject.FindWithTag("Player");
        ui.worldCamera = player.GetComponent<Camera>();
    }


}
