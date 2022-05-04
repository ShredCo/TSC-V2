using System.Collections;
using UnityEngine;
using TMPro;

public class OkinaShores : MonoBehaviour
{
    // Text for HUD
    [SerializeField] GameObject textLocationGameObject;
    [SerializeField] TextMeshProUGUI textLocationName;

    // Background Music
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && audioManager.CurrentArea != CurrentArea.OkinaShores)
        {
            // Change Location Text & change the background music
            StartCoroutine(ShowLocationName());
            audioManager.CurrentArea = CurrentArea.OkinaShores;
        }
    }

    // Shows the current location name 4 sec. in the HUD
    IEnumerator ShowLocationName()
    {
        // Change Text
        textLocationGameObject.SetActive(true);
        textLocationName.text = "Okina Shores";
        yield return new WaitForSeconds(4f);
        textLocationGameObject.SetActive(false);
    }
}
