using System;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class ballSFX : MonoBehaviour
{
    public AudioSource playBallSound;

    private void Start()
    {
        playBallSound = GetComponent<AudioSource>();
    }
    
   private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("SoccerPlayer"))
       {
           playBallSound.pitch = Random.Range(0.5f, 1.8f);
           playBallSound.Play();
       }    
   }
}
