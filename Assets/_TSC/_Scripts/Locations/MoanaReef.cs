using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoanaReef : MonoBehaviour
{
    public GameObject TextLocationGameObject;
    public TextMeshProUGUI TextLocationName;
    
    // Background Music
    public AudioClip NewTrack;
    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && audioManager.CurrentArea != CurrentArea.MoanaReefs)
        {
            // Change Location Text
            StartCoroutine(ShowLocationName());
            audioManager.CurrentArea = CurrentArea.MoanaReefs;
        }
    }

    IEnumerator ShowLocationName()
    {
        // Change Text
        TextLocationGameObject.SetActive(true);
        TextLocationName.text = "Moana Reefs";
        yield return new WaitForSeconds(4f);
        TextLocationGameObject.SetActive(false);
    }
}