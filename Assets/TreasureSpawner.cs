using System;
using System.Linq;

using UnityEngine;

using Random = UnityEngine.Random;

public class TreasureSpawner : MonoBehaviour
{
    private Transform[] spawnPoints;
    private TreasureSO[] treasures;
    private Treasure[] treasurePool;

    private void Awake()
    {
        try
        {
            GetTreasures();
            InitSpawnPoints();
        }catch(System.Exception e)
        {
            Debug.LogError(e.Message);
            return;
        }

        treasurePool = new Treasure[treasures.Length];
        for (int i = 0; i < treasures.Length; i++)
        {
            treasurePool[i] = Instantiate(treasures[i].prefab);
            treasurePool[i].SetScore(treasures[i].score);
        }
    }

    private void InitSpawnPoints()
    {
        spawnPoints = new Transform[transform.childCount];
        if (spawnPoints.Length == 0)
            throw new Exception("No spawn points for treasures!!!");
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    private void GetTreasures()
    {
        treasures = Resources.LoadAll<TreasureSO>("Treasures");
        if (treasures.Length == 0)
            throw new Exception("No treasures to hunt!!!");
    }

    void Update()
    {
        //check if any treasure is visible
        if (treasurePool.Any(t => t.gameObject.activeSelf)) return;
        //pick a random treasure
        Treasure randomPick = treasurePool[Random.Range(0, treasurePool.Length)];
        //pick a random spawn point
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //spawn treasure
        randomPick.transform.SetPositionAndRotation(randomPoint.position, randomPoint.rotation);
        randomPick.gameObject.SetActive(true);

    }
}
