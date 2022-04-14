using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Powerpoint : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(gameObject);
            SpawnPowerpoints.instance.powerpointCount -= 1;

            if (PlayerController.Instance.powerpointsCount < 5)
            {
                PlayerController.Instance.powerpointsCount += 1;
            }
            
            Debug.Log("Player Powerpoints = " + PlayerController.Instance.powerpointsCount);
        }
    }
}
