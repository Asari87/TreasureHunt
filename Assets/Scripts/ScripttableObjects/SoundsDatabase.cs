using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SoundsDatabase : ScriptableObject
{

    [Header("Ambiance")]
    [SerializeField] public AudioClip[] menuAmbience;
    [SerializeField] public AudioClip[] gameAmbience;

    [Header("UI Buttons")]
    public AudioClip buttonHover;
    public AudioClip buttonPress;

}
