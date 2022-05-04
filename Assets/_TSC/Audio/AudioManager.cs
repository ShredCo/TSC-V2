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

    public CurrentArea CurrentArea;
    
    // Background-Music
    public AudioClip newTrack;
    private AudioManager audioManager;
    public AudioSource BackgroundMusic;

    
    [Header("Villages/City Music")]
    public AudioClip OkinaShores;
    public AudioClip YapaYapa;
    public AudioClip MoanaReefs;

    [Header("Routes Music")]
    public AudioClip Route1;

    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        CurrentArea = CurrentArea.OkinaShores;
    }

    private void Update()
    {
        ChangeLocationMusic();
    }

    public void ChangeLocationMusic()
    {
       switch (CurrentArea)
       {
           // Citys
           case CurrentArea.OkinaShores: 
               audioManager.ChangeSoundtrack(OkinaShores);
               break;
           case CurrentArea.YapaYapa: 
               audioManager.ChangeSoundtrack(YapaYapa);
               break;
           case CurrentArea.MoanaReefs:
               audioManager.ChangeSoundtrack(MoanaReefs);
               break;
           
           // Routes
           case CurrentArea.Route1:
               audioManager.ChangeSoundtrack(Route1);
               break;
       }
    }
    
    public void ChangeSoundtrack(AudioClip music)
    {
        if (BackgroundMusic.clip.name == music.name)
            return;

        BackgroundMusic.Stop();
        BackgroundMusic.clip = music;
        BackgroundMusic.Play();
    }
}
