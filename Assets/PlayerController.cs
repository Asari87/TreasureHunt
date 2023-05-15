using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private DynamicMoveProvider moveProvider;
    private void Awake()
    {
        moveProvider = GetComponentInChildren<DynamicMoveProvider>();
        SceneManager.sceneLoaded += HandleLoadedScene;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= HandleLoadedScene;
    }

    private void HandleLoadedScene(Scene currentScene, LoadSceneMode _)
    {
        if (currentScene.name.Equals(Scenes.GameScene.ToString()))
            moveProvider.moveSpeed = movementSpeed;
        else
            moveProvider.moveSpeed = 0;
    }
}
