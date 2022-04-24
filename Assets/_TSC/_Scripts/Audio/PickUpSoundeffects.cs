using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSoundeffects : MonoBehaviour
{
    public static PickUpSoundeffects Instance;

    private void Awake()
    {
        Instance = this;
    }

    public AudioSource AudioSource;

    public AudioClip[] MoneyPickUp;
    public AudioClip[] CardPickUp;
    public AudioClip[] WoodPickUp;

    public void MoneySound()
    {
        AudioSource.clip = MoneyPickUp[Random.Range(0, MoneyPickUp.Length)];
        AudioSource.Play();
    }
    public void CardSound()
    {
        AudioSource.clip = CardPickUp[Random.Range(0, CardPickUp.Length)];
        AudioSource.Play();
    }
    public void WoodSound()
    {
        AudioSource.clip = WoodPickUp[Random.Range(0, WoodPickUp.Length)];
        AudioSource.Play();
    }
}
