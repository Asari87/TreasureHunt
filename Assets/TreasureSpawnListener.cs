using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawnListener : MonoBehaviour
{
    [SerializeField] private float showMarkerMinimumDistance;
    [SerializeField] private SpriteRenderer marker;
    [SerializeField] private Transform playerTransform;
    private Vector3 treasureLocation;
    private void Awake()
    {
        Treasure.OnSpawn += HandleSpawn;
    }
    private void OnDestroy()
    {
        Treasure.OnSpawn -= HandleSpawn;
    }

    private void HandleSpawn(Treasure spawnedTreasure)
    {
        treasureLocation = spawnedTreasure.transform.position;
    }

    private void Update()
    {
        if (treasureLocation == Vector3.zero) return;
        marker.enabled = Vector3.Distance(playerTransform.position, treasureLocation) > showMarkerMinimumDistance;
        if (!marker.enabled) return;
        Vector3 treasureDirection = (treasureLocation - playerTransform.position).normalized;
        transform.rotation = Quaternion.LookRotation(treasureDirection);    
        


    }

}
