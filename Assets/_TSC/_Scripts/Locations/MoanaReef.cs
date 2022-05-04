using System.Collections;
using UnityEngine;
using TMPro;

public class MoanaReef : MonoBehaviour
{
    // Text for HUD
    [SerializeField] GameObject textLocationGameObject;
    [SerializeField] TextMeshProUGUI textLocationName;
    
    // Background music
    AudioManager audioManager;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && audioManager.CurrentArea != CurrentArea.MoanaReefs)
        {
            // Change location text & change the background music
            StartCoroutine(ShowLocationName());
            audioManager.CurrentArea = CurrentArea.MoanaReefs;
        }
    }

    // Shows the current location name 4 sec. in the HUD
    IEnumerator ShowLocationName()
    {
        // Change Text
        textLocationGameObject.SetActive(true);
        textLocationName.text = "Moana Reefs";
        yield return new WaitForSeconds(4f);
        textLocationGameObject.SetActive(false);
    }
}
