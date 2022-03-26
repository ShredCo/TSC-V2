using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheeringSoundsEnglishSoldiers : MonoBehaviour
{

    // Place to add Cheering Sounds
    private CheeringSoundsEnglishSoldiers cheeringManager;
    public AudioSource cheeringSound;

    public AudioClip englishCheering1;
    public AudioClip englishCheering2;
    public AudioClip englishCheering3;
    public AudioClip englishCheering4;


    int currentEnglishSoldierCheeringSound = 0;

    private void Start()
    {
        cheeringManager = FindObjectOfType<CheeringSoundsEnglishSoldiers>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentEnglishSoldierCheeringSound += 1;

            if (currentEnglishSoldierCheeringSound > 4)
            {
                currentEnglishSoldierCheeringSound = 1;
            }

            switch (currentEnglishSoldierCheeringSound)
            {
                case 1:
                    cheeringManager.ChangeCheeringSound(englishCheering1);
                    break;
                case 2:
                    cheeringManager.ChangeCheeringSound(englishCheering2);
                    break;
                case 3:
                    cheeringManager.ChangeCheeringSound(englishCheering3);
                    break;
                case 4:
                    cheeringManager.ChangeCheeringSound(englishCheering4);
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
