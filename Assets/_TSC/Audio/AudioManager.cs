using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion
    
    public CurrentArea CurrentArea;
    
    // Background-Music
    [SerializeField] AudioClip newTrack;
    [SerializeField] AudioSource backgroundMusicAudioSource;
    [SerializeField] AudioManager audioManager;
    
    [Header("Villages/City Music")]
    [SerializeField] AudioClip okinaShores;
    [SerializeField] AudioClip yapaYapa;
    [SerializeField] AudioClip moanaReefs;

    [Header("Routes Music")]
    [SerializeField] AudioClip route1;

    
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
               audioManager.ChangeSoundtrack(okinaShores);
               break;
           case CurrentArea.YapaYapa: 
               audioManager.ChangeSoundtrack(yapaYapa);
               break;
           case CurrentArea.MoanaReefs:
               audioManager.ChangeSoundtrack(moanaReefs);
               break;
           
           // Routes
           case CurrentArea.Route1:
               audioManager.ChangeSoundtrack(route1);
               break;
       }
    }
    
    public void ChangeSoundtrack(AudioClip music)
    {
        if (backgroundMusicAudioSource.clip.name == music.name)
            return;

        backgroundMusicAudioSource.Stop();
        backgroundMusicAudioSource.clip = music;
        backgroundMusicAudioSource.Play();
    }
}
