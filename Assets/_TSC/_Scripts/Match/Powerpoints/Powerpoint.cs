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
            if (gameObject.CompareTag("Powerfield Blue"))
            {
                Destroy(gameObject);
                SpawnPowerfields.instance.powerfieldsCountRed -= 1;
                if (GameManagerOneVsOne.Instance.powerpointsCountBlue < 5)
                {
                    GameManagerOneVsOne.Instance.powerpointsCountBlue += 1;
                }
            }
            if (gameObject.CompareTag("Powerfield Red"))
            {
                Destroy(gameObject);
                SpawnPowerfields.instance.powerfieldsCountRed -= 1;
                if (GameManagerOneVsOne.Instance.powerpointsCountRed < 5)
                {
                    GameManagerOneVsOne.Instance.powerpointsCountRed += 1;
                }
            }
            
        }
    }
}
