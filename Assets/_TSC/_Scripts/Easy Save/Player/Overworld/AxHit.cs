using UnityEngine;

public class AxHit : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    

    private AudioSource audioSource;
   

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Hit()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];

    }
}