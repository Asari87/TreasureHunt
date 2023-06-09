using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using Unity.XR.CoreUtils;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerController : MonoBehaviour
{
    private XROrigin origin;
    [SerializeField] private float movementSpeed;
    private DynamicMoveProvider moveProvider;
    private void Awake()
    {
        origin = GetComponentInChildren<XROrigin>();
        moveProvider = GetComponentInChildren<DynamicMoveProvider>();
        SceneManager.sceneLoaded += HandleLoadedScene;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= HandleLoadedScene;
    }

    private void HandleLoadedScene(Scene currentScene, LoadSceneMode _)
    {
        origin.transform.SetPositionAndRotation(Vector3.zero,Quaternion.Euler(Vector3.zero));
        
        if (currentScene.name.Equals(Scenes.GameScene.ToString()))
            EnableMovement();
        else
            DisableMovement();
    }

    public void DisableMovement()
    {
        moveProvider.moveSpeed = 0;
    }
    public void EnableMovement()
    {
        moveProvider.moveSpeed = movementSpeed;
    }
}
