using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OkinaShores : MonoBehaviour
{
    public GameObject TextLocationGameObject;
    public TextMeshProUGUI TextLocationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && TextLocationName.text != "Okina Shores")
        {
            StartCoroutine(ShowLocationName());
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
