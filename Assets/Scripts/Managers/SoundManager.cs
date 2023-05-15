using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeReference] private AudioSource effectsSource;
    [SerializeReference] private AudioSource musicSource;

    private SoundsDatabase soundsDB;
    private void Awake()
    {
        soundsDB = Resources.Load<SoundsDatabase>("Sounds/SoundsDB");
        UIButtonEventNotifier.OnButtonEvent += HandleButtonEvent;
        Treasure.OnPickup += PlayCoinsSound;
    }

    private void OnDestroy()
    {
        UIButtonEventNotifier.OnButtonEvent -= HandleButtonEvent;
        Treasure.OnPickup -= PlayCoinsSound;
    }

    private void PlayCoinsSound(Treasure _)
    {
        AudioClip effect = soundsDB.coinSounds[Random.Range(0,soundsDB.coinSounds.Length)];
        PlayEffect(effect);
    }

    private void HandleButtonEvent(ButtonEvent buttonEvent)
    {
        switch (buttonEvent)
        {
            case ButtonEvent.Hover:
                PlayEffect(soundsDB.buttonHover);
                break;
            case ButtonEvent.Pressed:
                PlayEffect(soundsDB.buttonPress);
                break;
        }
    }

    private void Update()
    {
        if(!musicSource.isPlaying)
        {
            musicSource.clip = soundsDB.menuAmbience[Random.Range(0, soundsDB.menuAmbience.Length)];
            musicSource.Play();
        }
    }

    public void PlayEffect(AudioClip clip)
    {
        effectsSource.clip = clip;
        effectsSource.Play();
    }

    public void PlayClipAtPoint(AudioClip clip, Vector3 worldPosition, float volume = 1)
    {
        AudioSource.PlayClipAtPoint(clip, worldPosition, volume);
    }

}
