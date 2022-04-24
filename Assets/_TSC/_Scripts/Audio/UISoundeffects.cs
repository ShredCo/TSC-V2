using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISoundeffects : MonoBehaviour
{
    public static UISoundeffects Instance;

    private void Awake()
    {
        Instance = this;
    }

    public AudioSource AudioSource;

    public AudioClip ButtonPressMenu;
    public AudioClip ButtonPressCard;
    public AudioClip OpenCardSelectionSound;
    public AudioClip UINavigation;

    public AudioClip SelectionFailed;
    public AudioClip[] CardSelection;

    public void CardSelectSound()
    {
        AudioSource.volume = 1f;
        AudioSource.clip = CardSelection[Random.Range(0, CardSelection.Length)];
        AudioSource.Play();
    }
    public void SelectionFailedSound()
    {
        AudioSource.volume = 1f;
        AudioSource.clip = SelectionFailed;
        AudioSource.Play();
    }
    public void ButtonClick()
    {
        AudioSource.volume = 1f;
        AudioSource.clip = ButtonPressMenu;
        AudioSource.Play();
    }
    public void CardClick()
    {
        AudioSource.volume = 1f;
        AudioSource.clip = ButtonPressCard;
        AudioSource.Play();
    }
    public void OpenCardSelection()
    {
        AudioSource.volume = 1f;
        AudioSource.clip = OpenCardSelectionSound;
        AudioSource.Play();
    }
    public void UINavigationSound()
    {
        AudioSource.volume = 0.5f;
        AudioSource.clip = UINavigation;
        AudioSource.Play();
    }
}
