using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Route1 : MonoBehaviour
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
        if (other.CompareTag("Player") && audioManager.CurrentArea != CurrentArea.Route1)
        {
            // Change Location Text
            StartCoroutine(ShowLocationName());
        
            // Change Music
            audioManager.CurrentArea = CurrentArea.Route1;
        }
    }

    IEnumerator ShowLocationName()
    {
        TextLocationGameObject.SetActive(true);
        TextLocationName.text = "Route 1";
        yield return new WaitForSeconds(4f);
        TextLocationGameObject.SetActive(false);
    }
}
