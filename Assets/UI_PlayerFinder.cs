using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerFinder : MonoBehaviour
{
    private Canvas ui;
    private GameObject player;
    private void Awake()
    {
        ui = GetComponent<Canvas>();
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        ui.worldCamera = player.GetComponent<Camera>();
    }


}
