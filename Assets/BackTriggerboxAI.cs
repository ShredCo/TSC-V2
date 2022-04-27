using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTriggerboxAI : MonoBehaviour
{
    private float timeToShoot = 0.4f;
    private float timeCounter = 0f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            FrontTriggerboxAI.Instance.shootingState = ShootingState.Backflip;
        }
    }
}
