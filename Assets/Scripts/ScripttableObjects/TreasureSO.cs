using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Treasure", menuName = "Treasure/New Treasure", order = 1)]
public class TreasureSO : ScriptableObject
{
    public Treasure prefab;
    public int score;
    public int timeBonus;
}
