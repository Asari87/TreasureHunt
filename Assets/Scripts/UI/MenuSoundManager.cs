using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MenuSoundManager : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip pressedClip;
    [SerializeField] private AudioClip ambianceClip;

    private void Awake()
    {
        source= GetComponent<AudioSource>();
    }
    /// <summary>
    /// Animation event callback
    /// </summary>
    public void PlayHoverSound()
    {
        source.clip = hoverClip;
        source.Play();
    }

    /// <summary>
    /// Animation event callback
    /// </summary>
    public void PlayPressedSound()
    {
        source.clip = pressedClip;
        source.Play();
    }
}
