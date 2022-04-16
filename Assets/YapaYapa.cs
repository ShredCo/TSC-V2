using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YapaYapa : MonoBehaviour
{
    public GameObject TextLocationGameObject;
    public TextMeshProUGUI TextLocationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && TextLocationName.text != "Yapa Yapa")
        {
            StartCoroutine(ShowLocationName());
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
