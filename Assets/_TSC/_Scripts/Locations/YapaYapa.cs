using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YapaYapa : MonoBehaviour
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
        if (other.CompareTag("Player") && audioManager.CurrentArea != CurrentArea.YapaYapa)
        {
            
            StartCoroutine(ShowLocationName());
            
            // Change Music
            audioManager.CurrentArea = CurrentArea.OkinaShores;
        }
    }

    IEnumerator ShowLocationName()
    {
        TextLocationGameObject.SetActive(true);
        TextLocationName.text = "Yapa Yapa";
        yield return new WaitForSeconds(4f);
        TextLocationGameObject.SetActive(false);
    }
}
