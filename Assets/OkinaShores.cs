using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OkinaShores : MonoBehaviour
{
    public GameObject TextLocationGameObject;
    public TextMeshProUGUI TextLocationName;
    
    // Background Music
    public AudioClip NewTrack;
    private AudioManager audioManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && TextLocationName.text != "Okina Shores")
        {
            StartCoroutine(ShowLocationName());
            
            // Change Music
            if(NewTrack != null)
                audioManager.ChangeSoundtrack(NewTrack);
        }
    }

    IEnumerator ShowLocationName()
    {
        TextLocationGameObject.SetActive(true);
        TextLocationName.text = "Okina Shores";
        yield return new WaitForSeconds(4f);
        TextLocationGameObject.SetActive(false);
    }
}
