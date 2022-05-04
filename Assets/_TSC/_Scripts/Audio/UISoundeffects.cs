using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISoundeffects : MonoBehaviour
{
    #region Singleton
    public static UISoundeffects Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    // References
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip buttonPressMenu;
    [SerializeField] AudioClip buttonPressCard;
    [SerializeField] AudioClip openCardSelectionSound;
    [SerializeField] AudioClip userInterfaceNavigation;

    [SerializeField] AudioClip selectionFailed;
    [SerializeField] AudioClip[] cardSelection;

    // Methods
    public void CardSelectSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = cardSelection[Random.Range(0, cardSelection.Length)];
        audioSource.Play();
    }
    public void SelectionFailedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = selectionFailed;
        audioSource.Play();
    }
    public void ButtonClick()
    {
        audioSource.volume = 1f;
        audioSource.clip = buttonPressMenu;
        audioSource.Play();
    }
    public void CardClick()
    {
        audioSource.volume = 1f;
        audioSource.clip = buttonPressCard;
        audioSource.Play();
    }
    public void OpenCardSelection()
    {
        audioSource.volume = 1f;
        audioSource.clip = openCardSelectionSound;
        audioSource.Play();
    }
    public void UINavigationSound()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = userInterfaceNavigation;
        audioSource.Play();
    }
}
