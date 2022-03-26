using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Singleton
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Place to add Background-Music
    private AudioManager audioManager;
    public AudioSource backgroundMusic;

    public AudioClip track1;
    public AudioClip track2;

    int currentTrack = 1;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void nextTrack()
    {
        currentTrack += 1;

        if (currentTrack > 2)
        {
            currentTrack = 1;
        }

        switch (currentTrack)
        {
            case 1:
                audioManager.ChangeSoundtrack(track1);
                break;
            case 2:
                audioManager.ChangeSoundtrack(track2);
                break;
        }
    }

    public void ChangeSoundtrack(AudioClip music)
    {
        if (backgroundMusic.clip.name == music.name)
            return;

        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }
}
