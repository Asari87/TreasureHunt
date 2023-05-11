using System.Collections;
using System.Collections.Generic;

using Unity.XR.CoreUtils;

using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] cloudPrefabs;
    [SerializeField] private int numberOfClouds;
    [SerializeField] private float radiusFromCenter;
    [SerializeField, Tooltip("X and Y represent the minimun and maximum cloud height")] 
    private Vector2 cloudLayerHeight;
    //[SerializeField] [Range(0,1)] private float cloudDensity;
    //[SerializeField] private Vector2 windDirection;

    private Transform[] cloudPool;


    private void Awake()
    {

        //initialize cloud pool
        cloudPool= new Transform[numberOfClouds];
        for (int i = 0; i < numberOfClouds; i++)
        {
            cloudPool[i] = Instantiate(cloudPrefabs[Random.Range(0,cloudPrefabs.Length)]);
            cloudPool[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        for (int i = 0; i < cloudPool.Length; i++)
        {

            Vector3 spawnPosition = Random.insideUnitSphere * radiusFromCenter;
            spawnPosition.y = Random.Range(cloudLayerHeight.x, cloudLayerHeight.y);
            cloudPool[i].transform.SetPositionAndRotation(spawnPosition, Quaternion.Euler(0, Random.Range(0,359), 0));
            cloudPool[i].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        
    }

}
