using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoanaReef : MonoBehaviour
{
    public GameObject TextLocationGameObject;
    public TextMeshProUGUI TextLocationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && TextLocationName.text != "Moana Reefs")
        {
            StartCoroutine(ShowLocationName());
        }
    }

    IEnumerator ShowLocationName()
    {
        TextLocationGameObject.SetActive(true);
        TextLocationName.text = "Moana Reefs";
        yield return new WaitForSeconds(4f);
        TextLocationGameObject.SetActive(false);
    }
}
