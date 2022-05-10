using UnityEngine;

public class PickUpSoundeffects : MonoBehaviour
{
    #region Singleton
    public static PickUpSoundeffects Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    // References
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip[] moneyPickUp;
    [SerializeField] private AudioClip[] cardPickUp;
    [SerializeField] private AudioClip[] woodPickUp;

    // Methods
    public void MoneySound()
    {
        audioSource.clip = moneyPickUp[Random.Range(0, moneyPickUp.Length)];
        audioSource.Play();
    }
    public void CardSound()
    {
        audioSource.clip = cardPickUp[Random.Range(0, cardPickUp.Length)];
        audioSource.Play();
    }
    public void WoodSound()
    {
        audioSource.clip = woodPickUp[Random.Range(0, woodPickUp.Length)];
        audioSource.Play();
    }
}
