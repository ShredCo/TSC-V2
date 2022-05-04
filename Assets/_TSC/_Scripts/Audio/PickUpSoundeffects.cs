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
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip[] moneyPickUp;
    [SerializeField] AudioClip[] cardPickUp;
    [SerializeField] AudioClip[] woodPickUp;

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
