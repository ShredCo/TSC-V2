using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheeringSoundsPirates : MonoBehaviour
{
    // Place to add Cheering Sounds
    private CheeringSoundsPirates cheeringManager;
    public AudioSource cheeringSound;

    public AudioClip pirateCheering1;
    public AudioClip pirateCheering2;
    public AudioClip pirateCheering3;
    public AudioClip pirateCheering4;


    int currentPirateCheeringSound = 0;

    private void Start()
    {
        cheeringManager = FindObjectOfType<CheeringSoundsPirates>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentPirateCheeringSound += 1;

            if (currentPirateCheeringSound > 4)
            {
                currentPirateCheeringSound = 1;
            }

            switch (currentPirateCheeringSound)
            {
                case 1:
                    cheeringManager.ChangeCheeringSound(pirateCheering1);
                    break;
                case 2:
                    cheeringManager.ChangeCheeringSound(pirateCheering2);
                    break;
                case 3:
                    cheeringManager.ChangeCheeringSound(pirateCheering3);
                    break;
                case 4:
                    cheeringManager.ChangeCheeringSound(pirateCheering4);
                    break;
            }
        }
    }

    public void ChangeCheeringSound(AudioClip music)
    {
        if (cheeringSound.clip.name == music.name)
            return;

        cheeringSound.clip = music;
        cheeringSound.Play();
    }
}
