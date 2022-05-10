using System.Collections;
using UnityEngine;
using TMPro;

public class YapaYapa : MonoBehaviour
{
    // Text for HUD
    [SerializeField] private GameObject textLocationGameObject;
    [SerializeField] private TextMeshProUGUI textLocationName;
    
    // Background Music
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && audioManager.CurrentArea != CurrentArea.YapaYapa)
        {
            // Change location text & change the background music
            StartCoroutine(ShowLocationName());
            audioManager.CurrentArea = CurrentArea.OkinaShores;
        }
    }

    // Shows the current location name 4 sec. in the HUD
    IEnumerator ShowLocationName()
    {
        textLocationGameObject.SetActive(true);
        textLocationName.text = "Yapa Yapa";
        yield return new WaitForSeconds(4f);
        textLocationGameObject.SetActive(false);
    }
}
